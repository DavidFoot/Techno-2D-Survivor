using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform m_spaceShip;
    // Start is called before the first frame update
    void Start()
    {
        Camera.main.transform.position = new Vector3(m_spaceShip.position.x,m_spaceShip.position.y, Camera.main.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        Camera.main.transform.position = new Vector3(m_spaceShip.position.x, m_spaceShip.position.y, Camera.main.transform.position.z);
    }
}
