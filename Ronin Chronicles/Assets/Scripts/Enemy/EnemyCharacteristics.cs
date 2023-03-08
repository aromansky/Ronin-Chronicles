using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharacteristics : MonoBehaviour
{
    public float speed;
    public float turningSpeed;
    public float targetDistance;
    public float visionLength;
    public GameObject target;
    public int HP;
    public KatanaDamage katana;
    private Animator anim;
    private Attack _at;
}
