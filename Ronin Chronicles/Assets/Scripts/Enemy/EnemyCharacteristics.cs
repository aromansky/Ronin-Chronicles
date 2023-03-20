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
    public float HP;
    public float MaxHP;
    public KatanaDamage katana;
    public bool IsDead = false;
}
