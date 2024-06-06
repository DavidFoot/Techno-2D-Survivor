using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class EnemiesSpawnManager : MonoBehaviour
{
    [SerializeField] List<GameObject> m_enemiesPrefab;
    [SerializeField] Transform m_Player;
    [SerializeField] Transform m_enemyPool;
    [SerializeField] int m_initPool = 25;
    public static Queue<GameObject> m_queue = new Queue<GameObject>();
    public static int m_activeEnemyCount;
    [SerializeField] int m_initSpawn = 15;
    [SerializeField] int m_minActiveEnemies = 10;
    [SerializeField] public float m_minDistanceRadius;
    [SerializeField] public float m_maxDistanceRadius;
    void Start()
    {
        for (int i = 0; i < m_initPool; i++) { EnqueueEnemies(); }
        SpawnEnemyBatch();
    }

    private void SpawnEnemyBatch()
    {
        for (int i = 0; i < m_initSpawn; i++) { 
            if(m_queue.Count > 0)
            {
                GameObject enemyToSpawn = m_queue.Dequeue();
                m_activeEnemyCount++;

                //Test Random pos
                var rndDistance = UnityEngine.Random.Range(m_minDistanceRadius, m_maxDistanceRadius);
                float radius = 1f;
                Vector3 randomPos = UnityEngine.Random.insideUnitCircle * radius;
                Vector3 m_direction = Vector3.Normalize(randomPos - m_Player.position);
                randomPos = m_Player.position + m_direction * rndDistance;
                enemyToSpawn.transform.position = randomPos;


                enemyToSpawn.SetActive(true);
            }
            else
            {
                EnqueueEnemies();
            }   
        }
    }
    public static void EliminatedEnemy(GameObject _object)
    {
        _object.SetActive(false);
        m_activeEnemyCount--;
        m_queue.Enqueue(_object);
    }
    private void EnqueueEnemies()
    {
        int m_index = UnityEngine.Random.Range(0,m_enemiesPrefab.Count);
        GameObject enemy = Instantiate(m_enemiesPrefab[m_index],m_enemyPool) ;
        enemy.name = m_enemiesPrefab[m_index].name;
        var enemyScript = enemy.AddComponent<EnemyController>();
        enemyScript.m_Target = m_Player;
        enemy.AddComponent<CircleCollider2D>();
        enemy.AddComponent<Rigidbody2D>().gravityScale = 0; ;
        m_queue.Enqueue(enemy);
        enemy.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(m_activeEnemyCount <= m_minActiveEnemies)
        {
            SpawnEnemyBatch();
        }
    }
}
