
using UnityEngine;

public class playerController : MonoBehaviour
{
    [SerializeField] public float m_PlayerMovementSpeed = 3f;
    [SerializeField] public GameObject m_basicWeapon;
    [SerializeField] public bool m_isShooting=false;
    [SerializeField] public projectilesController m_projectile;
    private Vector2 m_Direction;
    private float m_shootTimer;
    private Vector2 m_cursorWorldPosition;
    private Camera m_camera;

    // Start is called before the first frame update
    void Start()
    {
        m_camera = Camera.main;
        m_projectile = GetComponent<projectilesController>();
    }

    // Update is called once per frame
    void Update()
    {
        m_cursorWorldPosition = m_camera.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
        m_Direction = m_cursorWorldPosition - (Vector2)transform.position;
        m_Direction.Normalize();
        transform.up = m_Direction;
        if (m_isShooting)
        {
            m_shootTimer -= Time.deltaTime;
            if(m_shootTimer <= 0)
            {
                Shoot();
                m_shootTimer = 0.3f;
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
        GameObject m_projectiles = Instantiate(m_basicWeapon, transform.position, Quaternion.identity);
        m_projectiles.GetComponent<projectilesController>().MoveProjectiles(m_Direction, transform);
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
