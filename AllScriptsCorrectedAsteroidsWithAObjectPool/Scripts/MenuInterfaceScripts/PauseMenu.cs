using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject[] pauseMenuItems;
    public GameObject[] settingsItems;
    public GameObject[] gameOver;
    public ShipController pl;
    GameObject player;
    ShipController controllerPlayer;
    public static bool pause = false;
    public bool timerPlus = false;
    
    void Start()
    {
       
    }
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if(pause)
        {
          if(Input.GetKeyDown(KeyCode.Escape))
          {
            
            Resume();
          }
        }
       else
        {
          if(Input.GetKeyDown(KeyCode.Escape))
          {
            
            Pause();
          }
        }
    }
    
    public void Resume()
    {
        Cursor.lockState = CursorLockMode.Locked;
        pauseMenu.SetActive(false);
        StartCoroutine(TimerScale());
        pause = false;
    }
    public void Pause()
    {
      Cursor.lockState = CursorLockMode.None;
        if(player)
        {
        controllerPlayer = player.GetComponent<ShipController>();
        }
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        pause = true;
        foreach(GameObject item in pauseMenuItems)
        {
            item.SetActive(true);
        }
        foreach(GameObject settingItem in settingsItems)
        {
            settingItem.SetActive(false);
        }
    }
    public void NewGame()
    {
      SceneManager.LoadScene("Asteroids");
      pauseMenu.SetActive(false);
      Cursor.lockState = CursorLockMode.Locked;
      foreach(GameObject game in gameOver)
      {
          game.SetActive(false);
      }
      Time.timeScale = 1f;
    }
    public void ControllSettings()
    {
        foreach(GameObject item in pauseMenuItems)
        {
            item.SetActive(false);
        }
        foreach(GameObject settingItem in settingsItems)
        {
            settingItem.SetActive(true);
        }
    }
    public void BackMenuPause()
    {
        foreach(GameObject item in pauseMenuItems)
        {
            item.SetActive(true);
        }
        foreach(GameObject settingItem in settingsItems)
        {
            settingItem.SetActive(false);
        }
    }
    public void MouseKeyBoard()
    {
      controllerPlayer.mousekeyBoard = true;
      controllerPlayer.keyBoard = false;
      pl.mousekeyBoard = true;
      pl.keyBoard = false;
    }
    public void KeyBoard()
    {
      controllerPlayer.mousekeyBoard = false;
      controllerPlayer.keyBoard = true;
      pl.mousekeyBoard = false;
      pl.keyBoard = true;
    }
    public void Exit()
    {
      Application.Quit();  
    }
    IEnumerator TimerScale()
    {
      
      Time.timeScale = 0.5f;
      yield return new WaitForSeconds(0.2f);
      Time.timeScale = 0.6f;
      yield return new WaitForSeconds(0.2f);
      Time.timeScale = 0.7f;
      yield return new WaitForSeconds(0.2f);
      Time.timeScale = 0.8f;
      yield return new WaitForSeconds(0.2f);
      Time.timeScale = 0.9f;
      yield return new WaitForSeconds(0.2f);
      Time.timeScale = 1f;
      

    }
}
