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

    private IEnumerator fearCoroutine;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (playerMovement.Rb.velocity.z > maxVelocity)
        {
            triggerFearIncrease = true;

            if (fearCoroutine == null)
            {
                fearCoroutine = ChangeFearLevel();
                StartCoroutine(fearCoroutine);
            }
        }
        else
        {
            triggerFearIncrease = false;
        }

        if (currentFearLevel >= maxFear)
        {
            DoFearAction();
        }

        if (fearCoroutine != null && currentFearLevel <= 0)
        {
            StopCoroutine(fearCoroutine);
            fearCoroutine = null;
        }
        
    }

    private void DoFearAction()
    {
        GameEvents.MaxFearReached.Invoke();

    }

    private IEnumerator ChangeFearLevel() //we also need to decrease fear somehow, so let's just fold it in
    {
        while (triggerFearIncrease)
        {
            currentFearLevel++;
            yield return new WaitForSeconds(1);
        }

        while (!triggerFearIncrease && currentFearLevel > 0)
        {
            if (currentFearLevel > maxFear)
            {
                currentFearLevel = maxFear;
            }
            currentFearLevel--;
            yield return new WaitForSeconds(1);
        }
    }
}
