using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    private PlayerCharacteristics _characteristics;
    private Animator _anim;
    void Start()
    {
        _characteristics = GetComponent<PlayerCharacteristics>();
        _anim = GetComponent<Animator>();
    }
    void Update()
    {
        if (_characteristics.HP <= 0)
        {
            _anim.SetBool("Dead", true);
        }
            

    }
}
