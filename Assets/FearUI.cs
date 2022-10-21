using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FearUI : MonoBehaviour
{
    public FearSystem playerFearSystem;
    public Graphic fearImage;
    private Color opacity;
    private AudioSource heartbeatAudio;
    private float normalizedFear = 0f;
    private void OnEnable()
    {
        opacity = new Color(1f, 1f, 1f, 0f);
        heartbeatAudio = GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        normalizedFear = Mathf.Clamp01(playerFearSystem.currentFearLevel / playerFearSystem.maxFear);

        opacity.a = heartbeatAudio.volume = normalizedFear;

        fearImage.color = opacity;
    }

}
