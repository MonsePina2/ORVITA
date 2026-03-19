using UnityEngine;
using TMPro;
namespace Managers
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private GameObject mainMenuUI;
        [SerializeField] private TMP_Text mainMenuHighScoreText;

        [SerializeField] private GameObject gameUI;
        [SerializeField] private TMP_Text   gameScoreText;

        [SerializeField] private GameObject gameOverUI;
        [SerializeField] private TMP_Text gameOverScoreText;
        [SerializeField] private TMP_Text gameOverHighScoreText;

        public void UpdateMainMenuHighScore(float highScore) {
            mainMenuHighScoreText.text = $"{highScore:F2}";
        }

        public void UpdateScore(float score) {
            gameScoreText.text = $" {score:f2}s";
        }

        public void UpdateGameOverScores(float highScore, float score) {
            gameOverHighScoreText.text = $"{highScore:F2}s";
            gameOverScoreText.text = $" {score:F2}s";
        }

        public void ShowMainMenuUI() {
            mainMenuUI.SetActive(true);
            gameUI.SetActive(false);
            gameOverUI.SetActive(false);
        }

        public void ShowGameUI() {
            mainMenuUI.SetActive(false);
            gameUI.SetActive(true);
            gameOverUI.SetActive(false);
        }

        public void ShowGameOverUI() {
            mainMenuUI.SetActive(false);
            gameUI.SetActive(false);
            gameOverUI.SetActive(true);
        }

    }
}
