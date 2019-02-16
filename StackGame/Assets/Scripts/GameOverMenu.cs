using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public void PlayGame()
    {
        Debug.Log("Button Pressed: Play Again");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void MainMenu()
    {
        Debug.Log("Button Pressed: Main Menu");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }
}
