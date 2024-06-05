using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private static MusicManager instance;
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

}
