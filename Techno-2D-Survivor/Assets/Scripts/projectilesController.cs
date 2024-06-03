using UnityEngine;

public class projectilesController : MonoBehaviour
{
    private Transform m_origine;
    [SerializeField] private float m_velocity=6f;
    [SerializeField] public float m_weaponDelay;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (m_origine != null)
        {
            float m_distance = Vector2.Distance(transform.position, m_origine.position);
            if(m_distance >= 6)
            {
                Destroy(gameObject);
            }
        }
            
    }
    public void MoveProjectiles(Vector2 _direction,Transform _origin)
    {
        GetComponent<Rigidbody2D>().velocity = _direction * m_velocity;
        m_origine = _origin;
    }
}
