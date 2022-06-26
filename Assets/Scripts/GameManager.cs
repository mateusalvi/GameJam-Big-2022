using FMOD.Studio;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    EventInstance soundAmbience;

    [SerializeField] bool endless = false;

    int enemyNumber = 0;

    void Start()
    {
        soundAmbience = FMODUnity.RuntimeManager.CreateInstance("event:/BGM/bgm_gameplay");
        soundAmbience.start();

        EnemyScript[] enemies = FindObjectsOfType<EnemyScript>();
        if(enemies!= null)
        {
            enemyNumber = enemies.Length;
        }
       
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
            EnemyScript[] enemies = FindObjectsOfType<EnemyScript>();
            if (enemies != null)
            {
                enemyNumber = enemies.Length;
                soundAmbience.setParameterByName("bgm-increase", 0.03f * enemyNumber);
            }

            CheckWin();
        }            
    }

    void CheckWin()
    {
        if (!endless)
        {
            if (enemyNumber >= 100)
            {
                StartWinScene();
            }
        }
    }

    public void StartWinScene()
    {
        SceneManager.LoadScene(4);
    }

    public void RestartScreen()
    {
        SceneManager.LoadScene(2);
    }

    public void StartChallenge()
    {
        SceneManager.LoadScene(1);
    }

    public void StartEndless()
    {
        SceneManager.LoadScene(2);
    }


    public void ExitGame()
    {
        Application.Quit();
    }

    void OnDestroy()
    {
        soundAmbience.stop(STOP_MODE.IMMEDIATE);
    }
}

