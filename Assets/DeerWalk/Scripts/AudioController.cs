using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField] private List<AudioClip> footstepSounds;

    private AudioSource _audioSource;
    private AudioSource audioSource
    {
        get
        {
            if (_audioSource == null)
            {
                _audioSource = GetComponent<AudioSource>();
                if (_audioSource == null)
                {
                    Debug.LogError($"AudioSource not found on {name}");
                    return null;
                }
            }
            return _audioSource;
        }
    }

    public void DoFootstep()
    {
        if (footstepSounds.Count == 0)
            return;

        int i = Random.Range(0, footstepSounds.Count);

        audioSource.clip = footstepSounds[i];
        audioSource.Play();
    }
}
