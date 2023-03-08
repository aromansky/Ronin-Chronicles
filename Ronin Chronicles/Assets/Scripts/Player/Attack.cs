using System.Linq;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private Animator _anim;
    private Collider _col;
    private PlayerCharacteristics _characteristics;
    public bool hit = false;

    void Start()
    {
       _anim = GetComponent<Animator>();
        _col = GameObject.FindGameObjectsWithTag("Katana").First().GetComponent<Collider>();
        _characteristics = GetComponent<PlayerCharacteristics>();
    }

    void Update()
    {
        if (Input.GetMouseButton(0) && !hit && _characteristics.HP > 0)
            _anim.Play("Attack_1");
    }

    public void Hit()
    {
        hit = !hit;
        _col.enabled = true;
    }
        

    public void DisableCollider() =>
        _col.enabled = false;
}
