using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject mainMenu; // Публичная переменная GameObject , отвечает за главное меню 
    public GameObject settingsMenu; // Публичная переменная GameObject , отвечает за меню настроек
   public void StartGame() // публичный метод для кнопки в меню ,  отвечает за запуск следуещей сцены
   {
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1); // запуск следуещей сцены по индексу
   }
   public void ExitGame() // публичный метод для кнопки в меню ,  отвечает за выход из игры
   {
       Application.Quit(); // выход из игры
   }
  
  
}
