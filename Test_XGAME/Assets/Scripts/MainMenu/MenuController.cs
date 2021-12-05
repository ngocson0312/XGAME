using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void MainMenu()
    {
        
        SceneManager.LoadScene(0);
        
    }

    public void Retry()
    {
        
        SceneManager.LoadScene(1);
    }

    public void NextLevel()
    {

        SceneManager.LoadScene(1);
    }
}
