using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{

    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private GameObject creditsScreen;
        [SerializeField] private GameObject settingsScreen;
        
        public void ChangeScene(int buildIndex)
        {
            SceneManager.LoadScene(buildIndex, LoadSceneMode.Single);
        }

        public void QuitGame()
        {
            Application.Quit();
            Debug.Log("Game quit");
        }

        public void DisplayCreditsScreen()
        {
            gameObject.SetActive(false);
            creditsScreen.SetActive(true);
        }

        public void DisplaySettingsScreen()
        {
            gameObject.SetActive(false);
            settingsScreen.SetActive(true);
        }
    }
}
