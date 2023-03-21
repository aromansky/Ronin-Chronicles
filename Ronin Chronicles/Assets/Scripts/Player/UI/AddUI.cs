using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.VersionControl;
using UnityEngine;

public class AddUI : MonoBehaviour
{
    public GameObject ui;
    void Start()
    {
        Camera cam = GetComponent<Camera>();
        Instantiate(ui);
    }

}
