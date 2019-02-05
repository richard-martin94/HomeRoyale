using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    void Update()
    {
        // checks if 'escape' key has been pressed and the gamestate is not paused
        if (Input.GetButtonDown("Cancel") && GameIsPaused == true)
        {
            Resume();
        }
        else if(Input.GetButtonDown("Cancel") && GameIsPaused == false)
        {
            Pause();
        }
    }

    public void Resume()
    {
        // turns the menu off when the resume button is clicked 
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        // turns the menu on when the escape button 
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
}
