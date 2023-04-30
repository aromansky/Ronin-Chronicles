using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using System;

public class AbsorbLife : MonoBehaviour
{
    // ѕоглощение здоровь€ работает в зависимости от здоровь€ игрока, т.е, если показатель здоровь€ максимален, то игрок не может испоьзовать способность. ѕомимо этого, игрок не может использовать способность, если в поле зрени€ нет врагов.

    private float vievAngle = 65f; // ”гол пол€ зрени€. Ёксперементальным путЄм вы€снено, что это оптимальный угол дл€ адекватной работы способности.

    private Rect rect;
    private Camera cam;
    private PlayerCharacteristics player;
    private int cnt_old;

    public bool ab_benefit; // взможность использовани€ способности.
    public bool cooldown = true; // готовность способноти.
    public bool absorb;
    private Animator anim;
    private Attack _at;

    void Start()
    {
        anim = GameObject.FindGameObjectsWithTag("mainHero").First().GetComponent<Animator>();
        cam = GetComponent<Camera>();
        rect = new Rect(0, 0, cam.pixelWidth, cam.pixelHeight);
        player = GameObject.FindGameObjectsWithTag("mainHero").First().GetComponent<PlayerCharacteristics>();

        cnt_old = GameObject.FindGameObjectsWithTag("Enemy").Count();
        _at = GameObject.FindGameObjectsWithTag("mainHero").First().GetComponent<Attack>();

    }
    void Update()
    {
        if (!PauseMenu.GameIsPaused)
        {
            ab_benefit = false;
            absorb = false;
            if (cooldown && GameObject.FindGameObjectsWithTag("Enemy").Count() != 0 && player.MaxHP > player.HP)
            {
                GameObject enemy = NearestEnemy();

                if (enemy != null)
                {
                    ab_benefit = true;
                    if (Input.GetKeyUp(KeyCode.Q) && cooldown)
                    {
                        cooldown = !cooldown;
                        Invoke("SetCoolDown", player.AbsorbLifeCd);
                    }

                    if (!Input.GetKey(KeyCode.Q))
                        absorb = false;

                    EnemyCharacteristics enemy_ch = enemy.GetComponent<EnemyCharacteristics>();

                    var cnt_new = GameObject.FindGameObjectsWithTag("Enemy").Count();

                    if (cnt_new != cnt_old && !Input.GetKey(KeyCode.Q))
                        cnt_old = cnt_new;

                    if (Vector3.Distance(enemy.transform.position, GameObject.FindGameObjectsWithTag("mainHero").First().transform.position) < player.Range && Input.GetKey(KeyCode.Q) && !enemy_ch.IsDead && !_at.hit)
                    {
                        if (cnt_new != cnt_old)
                        {
                            (cooldown, cnt_old) = (!cooldown, cnt_new);
                            Invoke("SetCoolDown", player.AbsorbLifeCd);
                        };


                        if (!enemy_ch.IsDead && player.HP < player.MaxHP)
                        {
                            anim.SetBool("Absorb", true);
                            anim.Play("Absorb");
                            (enemy_ch.HP, player.HP, absorb) = (enemy_ch.HP - player.AbsorbLifeDamage * Time.deltaTime, player.HP + player.AbsorbLifeDamage * player.AbsorbLifeCoeff * Time.deltaTime, true);
                        }
                    }
                }
                
            }
        }
    }

    public void SetCoolDown() => cooldown = !cooldown;

    GameObject NearestEnemy()
    {
        var minDist = float.MaxValue;
        var pl_pos = GameObject.FindGameObjectsWithTag("mainHero").First().transform.position;
        pl_pos.y += 1.5f;
        GameObject res = null;
        foreach (var x in GameObject.FindGameObjectsWithTag("Enemy").Where(y => rect.Contains(cam.WorldToScreenPoint(y.transform.position))))
        {
            var en_pos = x.transform.position;
            en_pos.y += 1.5f;
            if (!Physics.Linecast(en_pos, pl_pos))
            {
                float dist = Vector3.Distance(x.transform.position, pl_pos);
                if (dist < minDist && Vector3.Angle(GameObject.FindGameObjectsWithTag("mainHero").First().transform.forward, x.transform.position - pl_pos) < vievAngle)
                    (minDist, res) = (dist, x);
            }
        }

        //Debug.DrawLine(res.transform.position, pl_pos, Color.green); // ”далить, когда убедимc€ в корректной работе способности

        return res;
    }
}
