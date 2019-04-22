using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    public List<AudioSource> audioSources = new List<AudioSource>();
    [HideInInspector]
    public List<string> nameProperty = new List<string>();


    // Use this for initialization
    void Start()
    {
        AudioListener.volume = 1;
        DontDestroyOnLoad(gameObject);
    }

   
}

    
