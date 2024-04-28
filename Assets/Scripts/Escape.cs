using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Escape : MonoBehaviour
    
{
    public GameObject pauseMenuScreen;

    void Start()
    {
        
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
           
            Time.timeScale = 0;
            pauseMenuScreen.SetActive(true);

        }
    }
    public void Home()
    {
        SceneManager.LoadSceneAsync(0);
        //SceneManager.LoadScene(0);

    }

}
