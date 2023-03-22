using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacteristics : MonoBehaviour
{
    // Подписал все параметры. Так и в коде их легче читать, и в инспекторе при наведении
    // будет выдавать описание Tooltip. А ещё задал параметры по умолчанию
    [Header("Характеристики")]
    [Tooltip("Скорость ходьбы персонажа (м/с)")]
    public float moveSpeed = 10f;

    [Tooltip("Скорость бега персонажа (м/с)")]
    public float runSpeed = 15f; // Вместо множителя решил явно указывать скорость бега,
                                 // иначе тяжелее сделать интерполяцию от ходьбы к бегу

    [Tooltip("Гравитация (м/с^2)")]
    public float gravity = 9.8f;

    [Tooltip("Текущие очки жизни персонажа")]
    public float HP = 100f;

    [Tooltip("Максимальное количество жизней персонажа")]
    public float MaxHP = 100f;
}
