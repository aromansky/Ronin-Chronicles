using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyWithSword : MonoBehaviour
{
    public int health; // здоровье персонажа
    public int time_to_destruction; // время до исчезновения после смерти
    public float speed; // скорость пермещения персонажа 
    public float distance; // расстояние, на котором персонаж будет держатся от игрока
    public float vision_length; // расстояние, на которое может смотреть
    public GameObject target;

    // перемещение персонажа
    void Moving(Vector3 character_position, Vector3 target_position)
    {
        float angle = Vector3.Angle(character_position, target_position);

        if (Vector3.Distance(target_position, character_position) <= vision_length && Vector3.Distance(target_position, character_position) >= distance) // Проверка расстояния до игрока 
        {
            transform.position = Vector3.MoveTowards(character_position, target_position, Time.deltaTime * speed);

            // надо сделать поворот к цели
        }
        else if (Vector3.Distance(target_position, character_position) >= distance)
        {
            //надо сделать, чтобы он держал это расстояние
        }
    }

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // Проверка уровня здоровья
        if (health <= 0)
        {
            Transform.Destroy(gameObject, time_to_destruction);
        }


        Moving(gameObject.transform.position, target.transform.position);

    }


}
