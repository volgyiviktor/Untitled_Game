using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    public void NewGame()
    {
        SceneManager.LoadSceneAsync(1);
        //SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadLevel(int level)
    {
       
        SceneManager.LoadScene(level);

    }
}
