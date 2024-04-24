using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicScript : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    public AudioClip musicClip;

    public static MusicScript insatnce;

    void Start()
    {
        musicSource.clip = musicClip;
        musicSource.Play();
    }

    private void Awake()
    {
        if (insatnce==null)
        {
            insatnce = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
       
    }

   
}
