using UnityEngine;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {

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
            _gameTime = 0;
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
            Debug.Log("Game Over!");
        }
    }
}
