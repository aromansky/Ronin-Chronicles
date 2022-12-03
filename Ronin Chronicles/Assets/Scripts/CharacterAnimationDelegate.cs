using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationDelegate : MonoBehaviour
{
    public GameObject Katana_Attack_Point;
    
    void Katana_Attack_On()
    {
        Katana_Attack_Point.SetActive(true);
    }

    void Katana_Attack_Off()
    {
        if(Katana_Attack_Point.activeInHierarchy)
            Katana_Attack_Point.SetActive(false);
    }
}
