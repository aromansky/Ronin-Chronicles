using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTrail : MonoBehaviour
{
    public GameObject trail;
    // Start is called before the first frame update
    void Start()
    {
        trail.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetTrail_set()
    {
        trail.SetActive(true);
    }

    public void SetTrail_remove()
    {
        trail.SetActive(false);
    }
}

