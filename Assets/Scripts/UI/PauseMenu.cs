using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    
    private PlayerActionMap playerActionMap;
    private InputAction pause;
    private bool isPaused;

    [SerializeField] private GameObject pauseMenu;

    private void Awake()
    {
        playerActionMap = new PlayerActionMap();
        playerActionMap.UI.Pause.performed += PauseOnperformed;
    }

    private void PauseOnperformed(InputAction.CallbackContext obj)
    {
        if (!isPaused)
        {
            Time.timeScale = 0f;
            pauseMenu.SetActive(true);
            isPaused = true;
        }
        else
        {
            Time.timeScale = 1f;
            pauseMenu.SetActive(false);
            isPaused = false;
        }
    }

    private void OnEnable()
    {
        pause = playerActionMap.UI.Pause;
        pause.Enable();
    }
    private void OnDisable()
    {
        pause.Disable();
    }

   
}
