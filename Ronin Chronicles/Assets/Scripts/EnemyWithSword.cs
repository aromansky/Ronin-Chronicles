using System;
using UnityEngine;

public class EnemyWithSword : MonoBehaviour
{
    public int health; // �������� ���������
    public int timeToDestruction; // ����� �� ������������ ����� ������
    public float speed; // �������� ���������� ��������� 
    public float turningSpeed; // �������� �������� ��������� 
    public float targetDistance; // ����������, �� ������� �������� ����� �������� �� ������
    public float visionLength; // ����������, �� ������� ����� ��������
    public GameObject target;
    const float eps = 0.1f;

    
    void Moving(Transform character, Transform target) // ����������� ���������
    {
        // ������� � ������� ����
        Vector3 direction = (target.position - character.position).normalized;
        Quaternion LookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Lerp(transform.rotation, LookRotation, Time.deltaTime * turningSpeed);

        if (Vector3.Distance(target.position, character.position) <= visionLength && Vector3.Distance(target.position, character.position) > targetDistance) // �������� ���������� �� ������ 
        {
            transform.position = Vector3.MoveTowards(character.position, target.position, Time.deltaTime * speed);
        }
        if (Vector3.Distance(target.position, character.position) < targetDistance - eps)
        {
            // �������� ������ ����� "�����" ������, �������� �� �������� ���������
            float angle = target.eulerAngles.y * (float) Math.PI/180;
            Vector3 backStep = new Vector3(target.position.x + targetDistance * (float)Math.Sin(angle), 0f, target.position.z + targetDistance * (float)Math.Cos(angle));
            transform.position = Vector3.MoveTowards(character.position, backStep, Time.deltaTime * speed);
            
        }
        

    }    

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // �������� ������ ��������
        if (health <= 0)
        {
            Transform.Destroy(gameObject, timeToDestruction);
        }

        if (Vector3.Distance(gameObject.transform.position, target.transform.position) <= visionLength)
        {
            Moving(gameObject.transform, target.transform);
        }
    }


}
