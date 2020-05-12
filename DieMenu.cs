using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DieMenu : MonoBehaviour
{
    
    public GameObject dieMenuTurretUI, dieMeunuSpiderUI;

    public string killer; // имя убицы, чтоб вывести праильное сообщение на экран
    
  

   

    public void PlayerDie()
    {
        switch (killer)
        {
            case "turret":
                dieMenuTurretUI.SetActive(true);
                break;
            case "spider":
                dieMeunuSpiderUI.SetActive(true);
                break;
        } //причина смерти => нужный экран смерти
        
        
            
            Time.timeScale = 0f; //отключение времени, т.е все процессы игры отключаются, а точнее иигра не играется))))
        
        
    }

    public void MainMenu()
    {
        Debug.Log("Loading...");
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu"); //запуск главного меню
        
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit(); // выход из игры
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        Debug.Log("RESTART"); //перезапуск уровня
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
