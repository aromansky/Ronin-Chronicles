using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ComboState
{ 
    NONE,
    Attack_1
}

public class PlayerAttack : MonoBehaviour
{
    private CharacterController _charController;
    private Animator _animator;
    private bool ResetTime;
    private float DefaultTimer = 0.4f;
    private float CurrentTimer;

    private ComboState CurrentComboState;

    void Start()
    {
        CurrentTimer = DefaultTimer;
        CurrentComboState = ComboState.NONE;
        _charController = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        Attack();
        ResetComboState();
    }
    
    void Attack()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            CurrentComboState++;
            ResetTime = true;
            CurrentTimer = DefaultTimer;
            if(CurrentComboState == ComboState.Attack_1)
                _animator.SetBool("Attack_1", true);
        }
        else if (Input.GetKeyUp(KeyCode.Mouse0))
            _animator.SetBool("Attack_1", false);
    }

    void ResetComboState()
    {
        if (ResetTime)
            CurrentTimer -= Time.deltaTime;
        if (CurrentTimer <= 0f)
        {
            CurrentComboState = ComboState.NONE;
            ResetTime = false;
            CurrentTimer = DefaultTimer;
        }
    }
}
