using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetAnotherTrail : MonoBehaviour
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

    public void SetAnotherTrail_set()
    {
        trail.SetActive(true);
    }

    public void SetAnotherTrail_remove()
    {
        trail.SetActive(false);
    }
}
