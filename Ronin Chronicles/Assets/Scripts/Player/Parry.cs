using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parry : MonoBehaviour
{
    private Animator anim;
    private Attack at;
    private PlayerCharacteristics characteristics;

    public bool block = false;
    public bool coolDown = false;

    void Start()
    {
        at = GetComponent<Attack>();
        anim = GetComponent<Animator>();
        characteristics = GetComponent<PlayerCharacteristics>();
    }

    void Update()
    {
        if (Input.GetMouseButton(1) && !coolDown && !block)
            anim.Play("Parry");
    }

    public void Block()
    {
        at.attack_num = 1;
        block = !block;
        at.hit = false;
    }

    public void EndBlock()
    {
        coolDown = true;
        anim.SetBool("Attack_1", false);
        Invoke("Cd", characteristics.BlockCd);
    }

    public void Cd() => coolDown = false;
}
