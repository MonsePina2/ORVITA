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

        [SerializeField]private UiManager uiManager;

        private float _gameTime;

        private GameState _currentState;
        private void Awake() {
            if (Instance != null && Instance != this)
            {
               Destroy(gameObject);
               return;
            }
            Instance = this;
            _gameTime = 0;
            _currentState = GameState.IN_GAME;
        }

        private void Update() {
            if (_currentState != GameState.IN_GAME)return;

             _gameTime += Time.deltaTime;
             uiManager.UpdateScore(_gameTime);



        }

        public void GameOver() {
            _currentState = GameState.GAME_OVER;
            Debug.Log("Game Over!");
        }
    }
}
