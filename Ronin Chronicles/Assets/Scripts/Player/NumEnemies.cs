using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NumEnemies : MonoBehaviour
{

    public TextMeshProUGUI mesh;

    // Update is called once per frame
    void Update()
    {
        mesh.text = $"Numbers of enemies: {GameObject.FindGameObjectsWithTag("Enemy").Length}";
        mesh.color = Color.red;
    }
}
