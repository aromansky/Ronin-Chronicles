using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryScreen : MonoBehaviour
{
    public GameObject interfaceUI;
    public GameObject victoryUI;

    void Start()
    {
        victoryUI.SetActive(false);
        DeathScreen.GameOver = false;
    }

    void Update()
    {
        if (NumEnemies.count == 0)
        {
            interfaceUI.SetActive(false);
            victoryUI.SetActive(true);
            Cursor.lockState = CursorLockMode.Confined;
            DeathScreen.GameOver = true;
            Time.timeScale = Mathf.Lerp(Time.timeScale, 0f, Time.deltaTime);
        }
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        Debug.Log("Load");
        SceneManager.LoadScene("Menu");
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        Debug.Log("Load main scene");
        SceneManager.LoadScene("Main Scene");
    }
}
