using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Leader") || other == null) return;
        if (GameManager.Instance.NumberOfHerdAlive <= 0) return;
        GameEvents.WinState.Invoke();
    }
}
