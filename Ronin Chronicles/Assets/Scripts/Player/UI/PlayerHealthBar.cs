using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    public Image Bar;
    
    private PlayerCharacteristics _characteristics;
    void Start()
    {
        _characteristics = GetComponent<PlayerCharacteristics>();
    }

    // Update is called once per frame
    void Update()
    {
        Bar.fillAmount = _characteristics.HP / _characteristics.MaxHP;
    }
}
