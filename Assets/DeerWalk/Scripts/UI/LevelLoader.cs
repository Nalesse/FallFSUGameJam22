using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DeerWalk.Scripts.UI
{
    public class LevelLoader : MonoBehaviour
    {
        [SerializeField] private Animator transition;
        [SerializeField] private float transitionTime = 1f;
        // cache the reference
        private static readonly int StartFade = Animator.StringToHash("startFade");

        public void LoadNextLevel(int buildIndex)
        {
            StartCoroutine(LoadLevel(buildIndex));
        }

        IEnumerator LoadLevel(int buildIndex)
        {
            transition.SetTrigger(StartFade);
            yield return new WaitForSeconds(transitionTime);
            SceneManager.LoadScene(buildIndex);
        }
    
    }
}
