using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class playerController : MonoBehaviour
{
    [SerializeField] public float m_PlayerMovementSpeed = 3f;
    [SerializeField] public GameObject m_basicWeapon;
    [SerializeField] public float m_weapon_delay=0.5f;
    [SerializeField] public bool m_isShooting=false;
    private float m_shootTimer;
    private Vector2 m_cursorWorldPosition;
    private Camera m_camera;
    private Coroutine m_SHOOT;

    // Start is called before the first frame update
    void Start()
    {
        m_camera = Camera.main;
        m_SHOOT = StartCoroutine("ShootWeapon");
    }

    // Update is called once per frame
    void Update()
    {
        if (m_isShooting)
        {
            m_shootTimer -= Time.deltaTime;
            if(m_shootTimer <= 0)
            {
                Shoot();
                m_shootTimer = m_weapon_delay;
            }
        }
    }

    public void StartShooting()
    {
        m_isShooting = true;
        m_shootTimer = 0;
    }

    public void StopShooting()
    {
        m_isShooting = false;
    }
    public void Shoot()
    {
        m_cursorWorldPosition = m_camera.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
        var direction = m_cursorWorldPosition - (Vector2)transform.position;
        direction.Normalize();
        GameObject m_projectiles = Instantiate(m_basicWeapon, transform.position, Quaternion.identity);
        m_projectiles.GetComponent<projectilesController>().MoveProjectiles(direction, transform);
    }
    //private IEnumerator ShootWeapon()
    //{
    //    while (true)
    //    {
    //        m_cursorWorldPosition = m_camera.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
    //        var direction = m_cursorWorldPosition - (Vector2)transform.position;
    //        direction.Normalize();
    //        if (m_isShooting) 
    //        {
    //            GameObject m_projectiles = Instantiate(m_basicWeapon, transform.position, Quaternion.identity);
    //            m_projectiles.GetComponent<projectilesController>().MoveProjectiles(direction, transform);            
    //        }
    //        yield return null;

    //        StopCoroutine(m_SHOOT);
    //    }
    //}
}
