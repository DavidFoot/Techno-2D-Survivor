using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySound : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] AudioClip m_laser;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnDisable()
    {
        AudioSource.PlayClipAtPoint(m_laser,transform.position);
    }
}
