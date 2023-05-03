using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharacteristics : MonoBehaviour
{
    [Header("----- Movement -----")]
    [Tooltip("Walk speed (m/s)")]
    public float moveSpeed = 2.2f;

    [Tooltip("Run speed (m/s)")]
    public float runSpeed = 6.5f;

    [Tooltip("If distance between enemy and target equal or greater than runDistance (m), then enemy will run")]
    public float runDistance = 500f;

    [Tooltip("Movement acceleration (m/s^2)")]
    public float acceleration = 2f;

    [Tooltip("The speed of rotation around its axis")]
    public float turningSpeed;


    [Header("----- Targeting -----")]
    [Tooltip("The distance it will keep with it's target")]
    public float targetDistance;

    [Tooltip("The distance from which it will start following a target")]
    public float visionLength;

    [Tooltip("The object it will targer (player)")]
    public GameObject target;


    [Header("----- Combat -----")]
    [Tooltip("Amount hp that enemy takes away from player")]
    public float damage = 10f;

    [Tooltip("Time between attacks")]
    public float attackCd = 2f;


    [Header("----- HP -----")]
    public float HP;
    public float MaxHP;
    public bool IsDead = false;
}
