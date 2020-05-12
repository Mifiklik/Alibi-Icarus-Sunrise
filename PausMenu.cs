using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PausMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI; 

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            if (GameIsPaused )
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }// при нажатии на Esc включает/выключает меню паузы
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    } // возвращает в игру

    private void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }// выводит меню паузы

    public void MainMenu()
    {
        Debug.Log("Loading...");
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    } //запускает главное меню

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }// выход из игры

    public void Restart()
    {
        Time.timeScale = 1f;
        Debug.Log("RESTART");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // перезапуск уровня
    }
}
