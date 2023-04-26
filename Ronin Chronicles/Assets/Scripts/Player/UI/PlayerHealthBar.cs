using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    public Image hpBar;
    public Image afterHpBar;
    [Tooltip("Время, через которое afterHpBar уменьшается до hpBar")]
    public float delayTime = 0.5f;
    [Tooltip("Время, за которое afterHpBar уменьшается до hpBar")]
    public float deltaTime = 0.5f;

    private PlayerCharacteristics _characteristics;
    private float previousHP;
    private const float eps = 0.00001f;
    private float timePassed; // Пременная для after HP

    void Start()
    {
        _characteristics = GetComponent<PlayerCharacteristics>();

        previousHP = _characteristics.HP;
        hpBar.fillAmount = _characteristics.HP / _characteristics.MaxHP;
        afterHpBar.fillAmount = _characteristics.HP / _characteristics.MaxHP;
        timePassed = 0f;
    }

    void Update()
    {
        UpdateHP();
    }

    /// <summary>
    /// Обновляет основную и второстепенную полоски жизней
    /// </summary>
    void UpdateHP()
    {
        if (previousHP > _characteristics.HP)
        {
            hpBar.fillAmount = _characteristics.HP / _characteristics.MaxHP;

            Invoke(nameof(HandleAfterHP), deltaTime);
        }
        else if (previousHP < _characteristics.HP)
        {
            previousHP = _characteristics.HP;

            hpBar.fillAmount = _characteristics.HP / _characteristics.MaxHP;
            afterHpBar.fillAmount = _characteristics.HP / _characteristics.MaxHP;

            timePassed = 0f;
        }
        else
        {
            timePassed = 0f;
        }
    }

    /// <summary>
    /// Полоска от предыдущих жизней, убывает до текущих за deltaTime времени
    /// </summary>
    void HandleAfterHP()
    {
        timePassed += Time.deltaTime / deltaTime;

        float tempHP = Mathf.Lerp(previousHP, _characteristics.HP, timePassed);

        if (Mathf.Abs(tempHP - _characteristics.HP) < eps)
        {
            tempHP = _characteristics.HP;
            previousHP = tempHP;
        }

        afterHpBar.fillAmount = tempHP / _characteristics.MaxHP;
    }
}
