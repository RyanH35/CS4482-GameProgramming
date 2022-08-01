using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryScene : MonoBehaviour
{
    public void menu()
    {
        Destroy(GameObject.Find("Card Deck"));
        Destroy(GameObject.Find("Copy Deck"));
        Destroy(GameObject.Find("Discard Deck"));
        SceneManager.LoadScene("MainMenu");
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
