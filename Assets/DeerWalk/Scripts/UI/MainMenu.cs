using UnityEngine;

namespace DeerWalk.Scripts.UI
{

    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private GameObject settingsScreen;

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
