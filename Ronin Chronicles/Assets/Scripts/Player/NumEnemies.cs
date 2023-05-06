using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class NumEnemies : MonoBehaviour
{
    public static int count;
    public TextMeshProUGUI mesh;

    // Update is called once per frame
    void Update()
    {
        count = GameObject.FindGameObjectsWithTag("Enemy").Length;
        mesh.text = $"Numbers of enemies: {count}";
        mesh.color = Color.red;

        if (count == 0)
            Invoke("Vin", 5);
    }
}
