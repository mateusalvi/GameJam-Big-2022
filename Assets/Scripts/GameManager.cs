using FMOD.Studio;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    EventInstance soundAmbience;

    int enemyNumber = 0;

    void Start()
    {
        soundAmbience = FMODUnity.RuntimeManager.CreateInstance("event:/BGM/bgm_gameplay");
        soundAmbience.start();
    }

    // Start is called before the first frame update
    void Awake()
    {

        if (SceneManager.GetActiveScene().name == "Restart Scene" || SceneManager.GetActiveScene().name == "Win" || SceneManager.GetActiveScene().name == "Menu")
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Restart Scene" || SceneManager.GetActiveScene().name == "Win" || SceneManager.GetActiveScene().name == "Menu")
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
        }
        else
        {
            CheckWin();
        }            
    }

    void CheckWin()
    {
          
    }

    public void StartWinScene()
    {
        SceneManager.LoadScene(3);
    }

    public void RestartScreen()
    {
        SceneManager.LoadScene(2);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    void OnDestroy()
    {
      

    }
}

