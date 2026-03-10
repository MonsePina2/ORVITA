using UnityEngine;

namespace Asteroids
{
    public class AsteroidSpawner : MonoBehaviour
    {
        [SerializeField]
        private Asteroid asteroidPrefab;

        [SerializeField]
        private Transform[] spawnPoints;

        [SerializeField]
        private Transform[] targets;

        [SerializeField]
        private float spawnInterval;

        private void Start() {
            var spawnPointIdx=Random.Range(0,spawnPoints.Length);
            var spawnPoint = spawnPoints[spawnPointIdx];
            var spawnPosition= spawnPoint.position;

           var asteroid= Instantiate(asteroidPrefab,spawnPosition,Quaternion.identity);

           var targetIdx=Random.Range(0,targets.Length);
           var target = targets[targetIdx];
           var targetPosition = target.position;
           asteroid.Launch(targetPosition);
        }
    }
}
