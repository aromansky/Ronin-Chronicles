using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public Animator anim;

    void Update()
    {
        if (Input.GetMouseButton(0))
            anim.Play("Attack_1");
    }
}
