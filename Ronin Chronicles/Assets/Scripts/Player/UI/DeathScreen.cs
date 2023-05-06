using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    public static bool GameOver = false;
    public GameObject interfaceUI;
    public GameObject deathUI;

    private PlayerCharacteristics _playerCharacteristics;

    void Start()
    {
        _playerCharacteristics = transform.root.GetComponent<PlayerCharacteristics>();
        deathUI.SetActive(false);
        GameOver = false;
    }

    void Update()
    {
        if (_playerCharacteristics.HP <= 0)
        {
            interfaceUI.SetActive(false);
            deathUI.SetActive(true);
            Cursor.lockState = CursorLockMode.Confined;
            GameOver = true;
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
