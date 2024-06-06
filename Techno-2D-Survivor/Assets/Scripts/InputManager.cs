
using UnityEngine;

public class InputManager : MonoBehaviour
{
    //[SerializeField] private GameObject m_player;
    private playerController m_playerController;
    void Start()
    {
        m_playerController = GetComponent<playerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.D))
        {
            transform.Translate(transform.InverseTransformDirection(new Vector2(1, 0)) * m_playerController.m_PlayerMovementSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(transform.InverseTransformDirection(new Vector2(-1, 0)) * m_playerController.m_PlayerMovementSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(transform.InverseTransformDirection(Vector3.up) * m_playerController.m_PlayerMovementSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(transform.InverseTransformDirection(new Vector2(0, -1)) * m_playerController.m_PlayerMovementSpeed * Time.deltaTime);
        }
        if (Input.GetMouseButtonDown(0)) m_playerController.StartShooting();
        if (Input.GetMouseButtonUp(0))   m_playerController.StopShooting();
        

    }
}
