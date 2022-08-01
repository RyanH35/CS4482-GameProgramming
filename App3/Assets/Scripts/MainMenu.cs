using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void startGame()
    {
        SceneManager.LoadScene("Shop");
    }

    public void tutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
