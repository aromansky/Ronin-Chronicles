using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class AbsorbCd : MonoBehaviour
{
    private PlayerCharacteristics player;
    private AbsorbLife sc;
    private Animator anim;


    void Start()
    {
        player = GameObject.FindGameObjectsWithTag("mainHero").First().GetComponent<PlayerCharacteristics>();
        sc = GameObject.FindGameObjectsWithTag("MainCamera").First().GetComponent<AbsorbLife>();
        anim = GameObject.FindGameObjectsWithTag("mainHero").First().GetComponent<Animator>();
    }

    public void SetCoolDown() => sc.cooldown = !sc.cooldown;


    public void EndAbsorb()
    {
        anim.SetBool("Absorb", false);
        if (sc.absorb)
        {
            
            SetCoolDown();
            Invoke("SetCoolDown", player.AbsorbLifeCd);
        }
        
    }
}
