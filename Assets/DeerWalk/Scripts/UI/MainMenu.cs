using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{

    public class MainMenu : MonoBehaviour
    {
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

        public void DisplaySettingsScreen()
        {
            gameObject.SetActive(false);
            settingsScreen.SetActive(true);
        }
    }
}
