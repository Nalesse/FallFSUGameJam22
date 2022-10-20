using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(ParticleSystem))]
public class WindSystem : MonoBehaviour
{
    [SerializeField] private ParticleSystem windParticle;
    [SerializeField] private AnimationCurve WinDirectionCurve;
    [SerializeField] private float multiplier = 1.0f;



    private void Start()
    {
        
        // need to add some randomness
        var velocityOverLifetime = windParticle.velocityOverLifetime;
        velocityOverLifetime.enabled = true;
        velocityOverLifetime.space = ParticleSystemSimulationSpace.Local;
        

        ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(multiplier, WinDirectionCurve);
        velocityOverLifetime.x = minMaxCurve;
        velocityOverLifetime.y = minMaxCurve;
        velocityOverLifetime.z = minMaxCurve;



    }
}
