using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    private PlayerActionMap playerActionMap;
    private InputAction movement;
    private Rigidbody rb;

    private Vector2 currentInputVector;
    private Vector2 smoothInputVelocity;
    
    //Inspector vars
    [SerializeField] private float movementSpeed;
    [SerializeField] private float smoothInputSpeed = .2f;

    private void Awake()
    {
        playerActionMap = new PlayerActionMap();
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        movement = playerActionMap.Player.Move;
        movement.Enable();
    }
    private void OnDisable()
    {
        movement.Disable();
    }

    private void FixedUpdate()
    {
        Vector2 input = movement.ReadValue<Vector2>();
        //Smooths the movement
        currentInputVector = Vector2.SmoothDamp(currentInputVector, input, ref smoothInputVelocity, smoothInputSpeed);

        // maps the vector 2 input to a vector 3
        Vector3 direction = new Vector3(currentInputVector.x, 0, currentInputVector.y);
        
        // Moves the player
        rb.MovePosition(rb.position + direction * (movementSpeed * Time.deltaTime));

    }
}
