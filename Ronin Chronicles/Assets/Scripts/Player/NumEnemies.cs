using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class NumEnemies : MonoBehaviour
{

    public TextMeshProUGUI mesh;

    // Update is called once per frame
    void Update()
    {
        int count = GameObject.FindGameObjectsWithTag("Enemy").Length;
        mesh.text = $"Numbers of enemies: {count}";
        mesh.color = Color.red;

        if (count == 0)
            Invoke("Vin", 5);
    }

    void Vin()
    {
        SceneManager.LoadScene("Victory Menu");
        Cursor.lockState = CursorLockMode.Confined;
    }
}
