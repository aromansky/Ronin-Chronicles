using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AbsorbLife : MonoBehaviour
{
    // ���������� ����� �������� ���������� �� �������� ������. ������, ���� ���������� �������� �� ����������, �� ����� ����� ����������.
    // �� ������ ������ ���������� ����� ����������� ���� ������ � ���� ������ ������.

    private Rect rect;
    private Camera cam;
    private PlayerCharacteristics player;
    private int cnt_old;

    public bool cooldown = true; // ���������� ����������.
    public bool absorb;


    void Start()
    {

        cam = GetComponent<Camera>();
        rect = new Rect(0, 0, cam.pixelWidth, cam.pixelHeight);
        player = GameObject.FindGameObjectsWithTag("mainHero").First().GetComponent<PlayerCharacteristics>();

        cnt_old = GameObject.FindGameObjectsWithTag("Enemy").Count();
    }
    void Update()
    {

        if (Input.GetKeyUp(KeyCode.Q) && cooldown)
        {
            cooldown = !cooldown;
            Invoke("SetCoolDown", player.AbsorbLifeCd);

        }

        if (!Input.GetKey(KeyCode.Q))
            absorb =  false;

        if (cooldown && GameObject.FindGameObjectsWithTag("Enemy").Count() != 0)
        {
            GameObject enemy = NearestEnemy();
            EnemyCharacteristics enemy_ch = enemy.GetComponent<EnemyCharacteristics>();
   
            var cnt_new = GameObject.FindGameObjectsWithTag("Enemy").Count();


            if (cnt_new != cnt_old && !Input.GetKey(KeyCode.Q))
                cnt_old = cnt_new;

            if (rect.Contains(cam.WorldToScreenPoint(GameObject.FindGameObjectsWithTag("Enemy").First().transform.position)) &&
            Vector3.Distance(GameObject.FindGameObjectsWithTag("Enemy").First().transform.position, GameObject.FindGameObjectsWithTag("mainHero").First().transform.position) < player.Range &&
            Input.GetKey(KeyCode.Q) && !enemy_ch.IsDead)
            {
                if (cnt_new != cnt_old)
                {
                    (cooldown, cnt_old) = (!cooldown, cnt_new);
                    Invoke("SetCoolDown", player.AbsorbLifeCd);
                };


                if (!enemy_ch.IsDead && player.HP < player.MaxHP)
                    (enemy_ch.HP, player.HP, absorb) = (enemy_ch.HP - player.AbsorbLifeDamage * Time.deltaTime, player.HP + player.AbsorbLifeDamage * player.AbsorbLifeCoeff * Time.deltaTime, true);
            }
        }
    }

    public void SetCoolDown() => cooldown = !cooldown;

    GameObject NearestEnemy()
    {
        var minDist = float.MaxValue;
        GameObject res = null;
        foreach(var x in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            float dist = Vector3.Distance(x.transform.position, GameObject.FindGameObjectsWithTag("mainHero").First().transform.position);
            if (dist < minDist)
                (minDist, res) = (dist, x);
        }
        return res;
    }
}

