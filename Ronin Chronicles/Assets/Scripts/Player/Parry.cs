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
        if (!PauseMenu.GameIsPaused && !DeathScreen.GameOver && Input.GetMouseButton(1) && !coolDown && !block)
            anim.Play("Parry");
    }

    public void Block()
    {
        anim.SetBool("Attack_1", false);
        at.attack_num = 1;
        block = !block;
    }

    public void EndBlock()
    {
        anim.SetBool("Attack_1", false);
        coolDown = true;
        Invoke("Cd", characteristics.BlockCd);
    }

    public void Cd() => coolDown = false;
}
