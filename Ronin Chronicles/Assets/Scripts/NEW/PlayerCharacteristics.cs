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
    [Tooltip("Скорость ходьбы (m/s)")]
    public float moveSpeed = 2.25f;

    [Tooltip("Скорость бега (m/s)")]
    public float runSpeed = 7f;

    [Tooltip("Ускорение/торможение движения (хз, какая размерность)")]
    public float acceleration = 300f;

    [Tooltip("Графитация (m/s^2)")]
    public float gravity = 9.8f;


    [Header("----- HP -----")]
    [Tooltip("Текщие очки здоровья")]
    public float HP = 100f;

    [Tooltip("Максимум очков здоровья")]
    public float MaxHP = 100f;
}
