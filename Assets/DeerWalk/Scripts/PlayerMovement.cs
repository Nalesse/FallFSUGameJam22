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
    private InputAction running;
    private InputAction cameraCtrl;
    public Rigidbody Rb { get; private set; }

    private Vector2 cameraDelta = Vector2.zero;
    private Vector2 currentInputVector;
    private Vector2 smoothInputVelocity;

    private Animator _animator;
    private Animator animator
    {
        get
        {
            if (_animator == null)
            {
                _animator = GetComponent<Animator>();
                if (_animator == null)
                {
                    Debug.LogError($"Animator not found on {name}");
                    return null;
                }
            }
            return _animator;
        }
    }

    private bool isRunning = false;

    //Inspector vars
    [SerializeField] private float movementSpeed;
    [SerializeField] private float smoothInputSpeed = .2f;

    private void Awake()
    {
        playerActionMap = new PlayerActionMap();
        Rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        movement = playerActionMap.Player.Move;
        movement.Enable();

        running = playerActionMap.Player.Run;
        running.Enable();

        cameraCtrl = playerActionMap.Player.CameraControl;
        cameraCtrl.Enable();
    }
    private void OnDisable()
    {
        movement.Disable();
    }

    private void FixedUpdate()
    {
        isRunning = running.IsPressed();

        Vector2 input = movement.ReadValue<Vector2>();
        //Smooths the movement
        currentInputVector = Vector2.SmoothDamp(currentInputVector, input, ref smoothInputVelocity, smoothInputSpeed);

        // maps the vector 2 input to a vector 3
        Vector3 direction = new Vector3(currentInputVector.x, 0, currentInputVector.y);
        
        // Moves the player
        //Rb.MovePosition(Rb.position + direction * (movementSpeed * Time.fixedDeltaTime));
        
        if (direction != Vector3.zero)
        {
            Rb.velocity = direction * (movementSpeed * (isRunning ? 2f : 1f));
            animator.SetBool("Moving", true);
        }
        else
        {
            animator.SetBool("Moving", false);
        }

        animator.SetFloat("MoveX", Mathf.Clamp01(currentInputVector.x) * (isRunning ? 2f : 1f));
        animator.SetFloat("MoveY", Mathf.Clamp01(currentInputVector.y) * (isRunning ? 2f : 1f));
    }

    private void LateUpdate()
    {
        cameraDelta = cameraCtrl.ReadValue<Vector2>();
    }

    public Vector2 GetPlayerCamMovement()
    {
        return cameraDelta;
    }
}
