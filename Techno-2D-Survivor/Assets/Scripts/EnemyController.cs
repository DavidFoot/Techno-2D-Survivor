
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] public Transform m_Target;
    [SerializeField] public float m_speed = 2f;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.GetComponent<EnemyController>())
        {
            EnemiesSpawnManager.EliminatedEnemy(gameObject);
        }       
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, m_Target.position, m_speed * Time.deltaTime);
    }
}
