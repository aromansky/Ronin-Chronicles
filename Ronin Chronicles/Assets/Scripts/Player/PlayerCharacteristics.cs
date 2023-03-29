using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacteristics : MonoBehaviour
{
    public float Range;
    public float AbsorbLifeDamage;
    public float AbsorbLifeCoeff;
    public float AbsorbLifeCd;
    // �������� ��� ���������. ��� � � ���� �� ����� ������, � � ���������� ��� ���������
    // ����� �������� �������� Tooltip. � ��� ����� ��������� �� ���������
    [Header("��������������")]
    [Tooltip("�������� ������ ��������� (�/�)")]
    public float moveSpeed = 10f;

    [Tooltip("�������� ���� ��������� (�/�)")]
    public float runSpeed = 15f; // ������ ��������� ����� ���� ��������� �������� ����,
                                 // ����� ������� ������� ������������ �� ������ � ����

    [Tooltip("���������� (�/�^2)")]
    public float gravity = 9.8f;

    [Tooltip("������� ���� ����� ���������")]
    public float HP = 100f;

    [Tooltip("������������ ���������� ������ ���������")]
    public float MaxHP = 100f;
}
