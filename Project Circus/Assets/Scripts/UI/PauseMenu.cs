using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    private bool settingsOpen = false;

    public GameObject pauseMenuUI;
    public GameObject settingsMenu;

    private void Start()
    {
        pauseMenuUI.SetActive(false);
        settingsMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && settingsOpen == false)
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape) && settingsOpen == true)
        {
            settingsMenu.SetActive(false);
            pauseMenuUI.SetActive(true);
            settingsOpen = false;
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        settingsMenu.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    
    public void Settings()
    {
        pauseMenuUI.SetActive(false);
        settingsMenu.SetActive(true);
        settingsOpen = true;
    }
    
    public void Quit()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    
}
