using UnityEngine;
using TMPro;
namespace Managers
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private GameObject mainMenuUI;

        [SerializeField] private GameObject gameUI;
        [SerializeField] private TMP_Text   gameScoreText;

        [SerializeField] private GameObject gameOverUI;

        public void UpdateScore(float score) {
            gameScoreText.text = $" {score:f2}s";
        }

        public void ShowMainMenu() {
            mainMenuUI.SetActive(true);
            gameUI.SetActive(false);
            gameOverUI.SetActive(false);
        }

        public void ShowGameUI() {
            mainMenuUI.SetActive(false);
            gameUI.SetActive(true);
            gameOverUI.SetActive(false);
        }

        public void ShowGameOver() {
            mainMenuUI.SetActive(false);
            gameUI.SetActive(false);
            gameOverUI.SetActive(true);
        }

    }
}
