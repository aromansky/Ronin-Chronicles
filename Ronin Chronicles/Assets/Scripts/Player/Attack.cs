using System.Linq;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private Animator _anim;
    private PlayerCharacteristics _characteristics;
    public bool hit = false;

    void Start()
    {
       _anim = GetComponent<Animator>();
        _characteristics = GetComponent<PlayerCharacteristics>();
    }

    void Update()
    {
        if (Input.GetMouseButton(0) && !hit && _characteristics.HP > 0)
            _anim.Play("Attack_1");
    }

    public void Hit() =>
        hit = !hit;



}
