using System.Collections;
using UnityEngine;

public class RandomEmoteHandler : MonoBehaviour
{
    private IEnumerator emoteHandler;
    private float timeSinceLastEmote = 0f;
    private Animator anim;

    [Range(1f, 45f)][SerializeField] private float timeBetweenEmotes;

    void Start()
    {
        anim = GetComponent<Animator>();
        emoteHandler = HandleEmotes();
        StartCoroutine(emoteHandler);
    }

    private IEnumerator HandleEmotes()
    {
        float timeBetween = Random.Range(timeBetweenEmotes, 60f);

        while (timeSinceLastEmote <= timeBetween)
        {
            timeSinceLastEmote += Time.deltaTime;
            yield return null;
        }

        anim.SetTrigger("emote");
    }

}
