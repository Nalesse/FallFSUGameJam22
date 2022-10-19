using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class GameEvents
{
    /// <summary>
    /// When the max fear level is reached this event is triggered
    /// </summary>
    public static readonly UnityEvent MaxFearReached = new UnityEvent();
}
