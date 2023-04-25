using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacteristics : MonoBehaviour
{
    [Header("----- Absorb HP Skill -----")]
    public float Range;
    public float AbsorbLifeDamage;
    public float AbsorbLifeCoeff;
    public float AbsorbLifeCd;


    [Header("----- Common attacks -----")]
    public float KatanaDamage;
    public float AttackCd;


    [Header("----- Movement -----")]
    [Tooltip("Walk speed (m/s)")]
    public float moveSpeed = 2.25f;

    [Tooltip("Run speed (m/s)")]
    public float runSpeed = 7f;

    [Tooltip("Movement acceleration (m/s^2)")]
    public float acceleration = 2f;

    [Tooltip("Gravity acceleration (m/s^2)")]
    public float gravity = 9.8f;


    [Header("----- HP -----")]
    [Tooltip("Current amount of health points")]
    public float HP = 100f;

    [Tooltip("Maximum amount of health points")]
    public float MaxHP = 100f;
}
