using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HerdMember : MonoBehaviour
{
    private void OnEnable()
    {
        GameEvents.MaxFearReached.AddListener(MaxFearAction);
    }

    private void MaxFearAction()
    {
        Debug.Log("Deer Runs away");
    }
}
