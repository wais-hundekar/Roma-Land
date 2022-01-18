using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    void Start()
    {
        GameIsPaused = false;
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
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
    }

    public void Resume()
    {
        GameIsPaused = false;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;

    }
    void Pause()
    {
        GameIsPaused = true;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;

    }
    public void QuitGame()
    {
        //Replace Game Over with main menu screen
        SceneManager.LoadScene("Game Over");
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
