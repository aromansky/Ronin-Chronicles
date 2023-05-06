using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    private Canvas canvas1;
    private Canvas canvas2;

    public void Start()
    {
        canvas1 = GameObject.Find("Main").GetComponent<Canvas>();
        canvas2 = GameObject.Find("Help").GetComponent<Canvas>();
        canvas2.enabled = true;
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene("Main Scene");
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void ExitGame()
    {
        Debug.Log("Игра закрылась");
        Application.Quit();
    }

    public void Help() =>
        (canvas1.enabled, canvas2.enabled) = (false, true);

    public void Back() =>
        (canvas1.enabled, canvas2.enabled) = (true, false);
}