using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
    public void Play()
    {
        Debug.Log("Loading...");
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level 1"); // запуск первого уровня
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit(); // выход из игры
    }

  
}
