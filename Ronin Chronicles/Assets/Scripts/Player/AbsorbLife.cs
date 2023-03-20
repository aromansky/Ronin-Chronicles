using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AbsorbLife : MonoBehaviour
{
    // Поглощение жизни работает независимо от здоровья игрока. Однако, если показатель здоровья не максимален, то игрок может исцелиться.
    // На данный момент поглощение жизни захватывает всех врагов в поле зрения игрока.

    private Rect rect;
    private Camera cam;
    private PlayerCharacteristics player;
    private int cnt_old;

    public bool flag = false;  // клавиша зажата.
    public bool cooldown = true; // готовность способноти.


    void Start()
    {

        cam = GetComponent<Camera>();
        rect = new Rect(0, 0, cam.pixelWidth, cam.pixelHeight);
        player = GameObject.FindGameObjectsWithTag("mainHero").First().GetComponent<PlayerCharacteristics>();

        cnt_old = GameObject.FindGameObjectsWithTag("Enemy").Count();
    }
    void Update()
    {

        if (Input.GetKeyUp(KeyCode.Q) && !flag && cooldown)
        {
            flag = !flag;
            cooldown = !cooldown;
            Invoke("SetFlag", player.AbsorbLifeCd);
            Invoke("SetCoolDown", player.AbsorbLifeCd);

        }

        if (!Input.GetKey(KeyCode.Q) && flag)
            flag = !flag;

        if (cooldown && !flag && GameObject.FindGameObjectsWithTag("Enemy").Count() != 0)
        {
            EnemyCharacteristics enemy = GameObject.FindGameObjectsWithTag("Enemy").First().GetComponent<EnemyCharacteristics>();
            var cnt_new = GameObject.FindGameObjectsWithTag("Enemy").Count();


            if (cnt_new != cnt_old && !Input.GetKey(KeyCode.Q))
                cnt_old = cnt_new;

            if (rect.Contains(cam.WorldToScreenPoint(GameObject.FindGameObjectsWithTag("Enemy").First().transform.position)) &&
            Vector3.Distance(GameObject.FindGameObjectsWithTag("Enemy").First().transform.position, GameObject.FindGameObjectsWithTag("mainHero").First().transform.position) < player.Range &&
            Input.GetKey(KeyCode.Q) && !enemy.IsDead)
            {
                if (cnt_new != cnt_old)
                {
                    (cooldown, cnt_old) = (!cooldown, cnt_new);
                    flag = !flag;
                    Invoke("SetCoolDown", player.AbsorbLifeCd);
                };


                if (!enemy.IsDead && player.HP < player.MaxHP)
                    (enemy.HP, player.HP) = (enemy.HP - player.AbsorbLifeDamage * Time.deltaTime, player.HP + player.AbsorbLifeDamage * player.AbsorbLifeCoeff * Time.deltaTime);

            }
        }
    }

    public void SetCoolDown() => cooldown = !cooldown;
    public void SetFlag() => flag = !flag;
}

