using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    InputManager inputManager;
    CharacterMovement characterMovement;
    PlayerCharacteristics playerCharacteristics;
    float moveSpeed;
    float runSpeed;
    float movementAcceleration;
    Vector2 moveInput;

    private void Awake()
    {
        inputManager = GetComponent<InputManager>();
        characterMovement = GetComponent<CharacterMovement>();

        playerCharacteristics = GetComponent<PlayerCharacteristics>();
        moveSpeed = playerCharacteristics.moveSpeed;
        runSpeed = playerCharacteristics.runSpeed;
        movementAcceleration = playerCharacteristics.acceleration;
    }


    void Update()
    {
        moveInput = inputManager.movementInput;
    }

    private void FixedUpdate()
    {
        MovementLogic();
    }


    /// <summary>
    /// Реализация движения игрока.
    /// </summary>
    private void MovementLogic()
    {
        if (moveInput != Vector2.zero)
        {
            characterMovement.HandleMovement(moveInput, moveSpeed, movementAcceleration);
        }
        else
        {
            characterMovement.HandleMovement(moveInput, 0, movementAcceleration);
        }
        characterMovement.HandleRotaion(moveInput, 10);
    }
}
