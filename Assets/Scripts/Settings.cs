using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    //public void SoundToggle(bool mute)
    //{
    //    if (!mute)
    //    {
    //        AudioListener.volume = 0;

    //    }
    //    else { AudioListener.volume = 1; }
    //}

    //new music toggle

    private Sprite musicOnImg;
    public Sprite musicOffImg;
    public Button musicbutton;
    private bool musicOn = true;

    public AudioSource audioSource;

    void Start()
    {
        musicOnImg = musicbutton.image.sprite;
    }

    void Update()
    {
         
    }

    public void MusicButtonClicked()
    {
        if (musicOn)
        {
            musicbutton.image.sprite = musicOffImg;
            musicOn = false;
            audioSource.mute = true;

        }
        else
        {
            musicbutton.image.sprite = musicOnImg;
            musicOn = true;
            audioSource.mute = false;

        }
    }

}
