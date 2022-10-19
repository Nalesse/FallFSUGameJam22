using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FearSystem: MonoBehaviour
{
    private PlayerMovement playerMovement;
    private int currentFearLevel;
    private int maxFear = 10;
    private int maxVelocity = 7;
    private bool triggerFearIncrease = true;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (playerMovement.Rb.velocity.z > maxVelocity && triggerFearIncrease)
        {
            StartCoroutine(AddFear());
        }

        if (currentFearLevel < maxFear) return;
        
        GameEvents.MaxFearReached.Invoke();
        currentFearLevel = 0;
    }

    private IEnumerator AddFear()
    {
        currentFearLevel++;
        triggerFearIncrease = false;
        yield return new WaitForSeconds(1);
        triggerFearIncrease = true;
    }
}
