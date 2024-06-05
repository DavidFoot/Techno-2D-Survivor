using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;

public class MusicManager : MonoBehaviour
{
    [SerializeField] List<AudioClip> musicClipList;
    private static MusicManager instance;
    private AudioSource m_audioSource;
    [SerializeField] AudioMixer m_audioMixer;
    [Range(-80f, 20f)]
    [SerializeField] float m_masterVolume;
    [Range(-80f, 20f)]
    [SerializeField] float m_MusicVolume;

    // Start is called before the first frame update
    private void Awake()
    {
        // Creation d'un singleton qui permet d'avoir qu'une seule instance de MusicManager au travers de toute l'execution du programme
        // Afin que ce MusicManager ne soit pas interrompu/détruit au changement de scène on le "DontDestroyOnLoad
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else { 
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        m_audioSource = GetComponent<AudioSource>();
        m_audioSource.clip = musicClipList[0];
        m_audioSource.Play();
    }
    private void Update()
    {
        m_audioMixer.SetFloat("MyMasterVolume",m_masterVolume);
        m_audioMixer.SetFloat("MyMusicVolume", m_MusicVolume);
    }
}
