using Managers;
using UnityEngine;

namespace Asteroids
{
    public class AsteroidSpawner : MonoBehaviour
    {
        [SerializeField]
        private Asteroid [] asteroidPrefabs;

        [SerializeField]
        private Transform[] spawnPoints;

        [SerializeField]
        private Transform[] targets;

        [SerializeField]
        private float spawnInterval;

        private float _spawnTimer;

        private void Start() {
            _spawnTimer = 0;

        }

        private void Update() {
            if (!GameManager.Instance.IsInGame) return;

            _spawnTimer += Time.deltaTime;

            if (_spawnTimer < spawnInterval) return;

            SpawnAsteroid();
            _spawnTimer = 0;
        }

        private Vector3 GetSpawnPosition() {
            var spawnPointIdx =Random.Range(0,spawnPoints.Length);
            var spawnPoint    = spawnPoints[spawnPointIdx];
            return spawnPoint.position;
        }

        private Vector2 GetTargetPosition() {
            var targetIdx      =Random.Range(0,targets.Length);
            var target         = targets[targetIdx];
            return target.position;
        }

        private Asteroid GetRandomAsteroid() {
            var prefabIdx=Random.Range(0,asteroidPrefabs.Length);
            var prefab=asteroidPrefabs[prefabIdx];
            return prefab;
        }

        private void SpawnAsteroid() {
            var spawnPosition=GetSpawnPosition();
            var targetPosition = GetTargetPosition();
            var asteroidPrefab=GetRandomAsteroid();

            var asteroid= Instantiate(asteroidPrefab,spawnPosition,Quaternion.identity);
            asteroid.Launch(targetPosition);
        }

    }
}
