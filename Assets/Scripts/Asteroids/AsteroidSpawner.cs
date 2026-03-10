using UnityEngine;

namespace Asteroids
{
    public class AsteroidSpawner : MonoBehaviour
    {
        [SerializeField]
        private Asteroid asteroidPrefab;

        [SerializeField]
        private Transform  spawnPoint;

        [SerializeField]
        private Transform  target;

        [SerializeField]
        private float spawnInterval;

        private void Start() {
            Instantiate(asteroidPrefab,spawnPoint.position,Quaternion.identity);
        }
    }
}
