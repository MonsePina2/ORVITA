using UnityEngine;
using UnityEngine.SceneManagement;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {

        private const string HIGH_SCORE_KEY = "HighScore";

        private enum GameState
        {
            MAIN_MENU,
            IN_GAME,
            GAME_OVER,
        }


        public static GameManager Instance;

        [SerializeField]private UIManager uiManager;

        private float _gameTime;
        private GameState _currentState;

        public bool IsMainMenu => _currentState == GameState.MAIN_MENU;
        public bool IsInGame => _currentState == GameState.IN_GAME;
        public bool IsGameOver => _currentState == GameState.GAME_OVER;

        private void Awake() {
            if (Instance != null && Instance != this)
            {
               Destroy(gameObject);
               return;
            }
            Instance = this;

        }

        private void Start() {
            _currentState = GameState.MAIN_MENU;

            var highScore = PlayerPrefs.GetFloat(HIGH_SCORE_KEY, 0);
            uiManager.UpdateMainMenuHighScore(highScore);
            uiManager.ShowMainMenuUI();



        }

        public void MainMenu() {
            var currentScene=SceneManager.GetActiveScene();
            var currentSceneIdx=currentScene.buildIndex;
            SceneManager.LoadScene(currentSceneIdx);
        }

        public void StartGame() {
            _gameTime     = 0;
            _currentState = GameState.IN_GAME;
            uiManager.ShowGameUI();
        }

        private void Update() {
            if (!IsInGame)return;

             _gameTime += Time.deltaTime;
             uiManager.UpdateScore(_gameTime);



        }

        public void GameOver() {
            _currentState = GameState.GAME_OVER;

            var highScore = PlayerPrefs.GetFloat(HIGH_SCORE_KEY, 0);
            if (_gameTime >= highScore)
            {
                PlayerPrefs.SetFloat(HIGH_SCORE_KEY, _gameTime);
                highScore = _gameTime;
            }

            uiManager.UpdateGameOverScores(highScore,_gameTime);
            uiManager.ShowGameOverUI();
        }

        public void ResetHighScore() {
            PlayerPrefs.DeleteKey(HIGH_SCORE_KEY);
            uiManager.UpdateMainMenuHighScore(0);
            uiManager.UpdateGameOverScores(0,_gameTime);
        }

        public void QuitGame() {
            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            #endif
            Application.Quit();
        }
    }
}
