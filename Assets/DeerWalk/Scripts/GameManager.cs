using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public int NumberOfHerdAlive { get; set; }
    public static GameManager Instance { get; private set; }
    private bool gamOverTrigger = true;
    private void Awake() 
    { 
        // If there is an instance, and it's not me, delete myself.
    
        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this; 
        } 
    }

    private void OnEnable()
    {
        GameEvents.WinState.AddListener(WinGame);
    }

    private void OnDisable()
    {
        GameEvents.WinState.RemoveListener(WinGame);
    }

    private void Update()
    {
        if (NumberOfHerdAlive <= 0 && gamOverTrigger)
        {
            LoseGame();
            gamOverTrigger = false;
        }
    }

    private void LoseGame()
    {
        
    }

    private void WinGame()
    {
        Debug.Log("You win!");
    }

   
    
}
