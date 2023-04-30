using System.Linq;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private Animator anim;
    private PlayerCharacteristics characteristics;
    public bool hit = false;
    private int attack_num = 1;

    void Start()
    {
        anim = GetComponent<Animator>();
        characteristics = GetComponent<PlayerCharacteristics>();
    }

    void Update()
    {
        if (!PauseMenu.GameIsPaused && Input.GetMouseButtonDown(0) && !hit && characteristics.HP > 0 && !anim.GetBool("Absorb"))
            anim.Play($"LightAttack_00{attack_num}");
    }

    public void Hit()
    {
        hit = !hit;
    }

    void CheckClick() => attack_num = !hit ? 1 : attack_num;

    public void IncAttack()
    {
        if (Input.GetMouseButton(0))
        {
            attack_num = (attack_num == 3) ? 1 : ++attack_num;
            Invoke("CheckClick", 4); // Возможно, надо будет подобрать число лучше
        }

        else
            attack_num = 1;

    }
}
