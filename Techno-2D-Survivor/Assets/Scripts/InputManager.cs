
using System.Runtime.InteropServices;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private GameObject m_player;
    private playerController m_playerController;
    void Start()
    {
        m_playerController = m_player.GetComponent<playerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(new Vector2(1, 0) * m_playerController.m_PlayerMovementSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(new Vector2(-1, 0) * m_playerController.m_PlayerMovementSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(new Vector2(0, 1) * m_playerController.m_PlayerMovementSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(new Vector2(0, -1) * m_playerController.m_PlayerMovementSpeed * Time.deltaTime);
        }

        if(Input.GetMouseButtonDown(0))m_playerController.StartShooting();
        if (Input.GetMouseButtonUp(0)) m_playerController.StopShooting();
        

    }
}
