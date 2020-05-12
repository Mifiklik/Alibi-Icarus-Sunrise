using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinMenu : MonoBehaviour
{
    
    public GameObject winMenuKillUI, winMenuExitUI, winMenuAlternativeUI;
    public string winReson;
    public string nextLevel;




    public void PlayerWin()
    {
        switch (winReson)
        {
            case "kill":
                winMenuKillUI.SetActive(true);
                break;
            case "alternative":
                winMenuAlternativeUI.SetActive(true);
                break;
            case "exit":
                winMenuExitUI.SetActive(true);
                break;
        }// варианты концовок

        
        Time.timeScale = 0f;


    }

    public void MainMenu()
    {
        Debug.Log("Loading...");
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu"); // запуск главного меню
        
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }// выход из игры

    public void Prodolgit()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(nextLevel);
    }// переход на следующий уровень
    public void Restart()
    {
        Time.timeScale = 1f;
        Debug.Log("RESTART");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }// перезапуск уровня
}
