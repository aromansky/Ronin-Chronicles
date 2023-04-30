using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parry : MonoBehaviour
{
    private Animator anim;
    private Attack at;
    public bool block = false;

    void Start()
    {
        at = GetComponent<Attack>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            anim.Play("Parry");
        }
    }

    public void Block()
    {
        at.hit = false;
        at.attack_num = 1;
        block = !block;
    }
}
