using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    public GameObject interfaceUI;

    void Start()
    {
        pauseMenuUI.SetActive(false);
        interfaceUI.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
    }

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
        pauseMenuUI.SetActive(false);
        interfaceUI.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        interfaceUI.SetActive(false);
        Cursor.lockState = CursorLockMode.Confined;
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        Debug.Log("Load");
        SceneManager.LoadScene("Menu");
    }
    
    public void ExitGame()
    {
        Debug.Log("Игра закрылась");
        Application.Quit();
    }
}