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
    public Rigidbody Rb { get; private set; }

    private Vector2 currentInputVector;
    private Vector2 smoothInputVelocity;

    private AudioSource _audioSource;
    private AudioSource audioSource
    {
        get
        {
            if (_audioSource == null)
            {
                _audioSource = GetComponent<AudioSource>();
                if (_audioSource == null)
                {
                    Debug.LogError($"AudioSource not found on {name}");
                    return null;
                }
            }
            return _audioSource;
        }
    }

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
    [SerializeField] private List<AudioClip> footstepSounds;

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

    public void DoFootstep()
    {
        if (footstepSounds.Count == 0)
            return;

        int i = UnityEngine.Random.Range(0, footstepSounds.Count);

        audioSource.clip = footstepSounds[i];
        audioSource.Play();
    }
}
