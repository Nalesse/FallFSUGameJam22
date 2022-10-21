using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CloudFine.FlockBox;

public class HerdMember : MonoBehaviour
{
    private BehaviorSettings followerSettings;
    public BehaviorSettings panicSettings;
    private void OnEnable()
    {
        GameEvents.MaxFearReached.AddListener(MaxFearAction);
        followerSettings = GetComponent<PhysicsSteeringAgent>().activeSettings;
        
    }

    private void Start()
    {
        GameManager.Instance.NumberOfHerdAlive += 1;
    }

    private void MaxFearAction()
    {
        GetComponent<PhysicsSteeringAgent>().activeSettings = panicSettings;
        Debug.Log($"Deer {name} Runs away");
    }

    private void DeathAction()
    {
        GameManager.Instance.NumberOfHerdAlive -= 1;
        Destroy(this.gameObject);
    }
}
