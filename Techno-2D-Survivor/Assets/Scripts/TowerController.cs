using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour
{
    [SerializeField] Transform m_Player;
    [SerializeField] float m_SpotDistance;
    private Transform capsuleTransform;
    private Vector3 m_vectorBetweenplayer;
    private Vector3 m_direction;
    private float m_distancePlayer;
    [SerializeField] public GameObject m_basicWeapon;

    // Start is called before the first frame update
    void Start()
    {
        capsuleTransform = FindObjectOfType<CapsuleCollider>().GetComponentInParent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
        m_vectorBetweenplayer = m_Player.position - transform.position;
        m_direction = m_vectorBetweenplayer.normalized;
        m_distancePlayer = m_vectorBetweenplayer.sqrMagnitude;

        Debug.Log("Distance au joueur = " + m_distancePlayer + " Limite de spot : " + m_SpotDistance * m_SpotDistance);

        if (m_distancePlayer <= m_SpotDistance * m_SpotDistance)
        {
            Debug.Log("Je suis à distance de Tir");
            capsuleTransform.up = m_direction;
            GameObject m_projectiles = Instantiate(m_basicWeapon, capsuleTransform.position, Quaternion.identity);
            m_projectiles.GetComponent<projectilesController>().MoveProjectiles(m_direction, transform);
        }
        else 
        {
            capsuleTransform.Rotate(0, 0, -0.3f);
        }
    }
}
