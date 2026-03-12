using System;
using Player;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Asteroids
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Asteroid : MonoBehaviour
    {
        [SerializeField] private float minSpeed;
        [SerializeField] private float maxSpeed;

        [SerializeField] private float minRotationSpeed;
        [SerializeField] private float maxRotationSpeed;

        private Rigidbody2D _rb;

        private void Awake() {
            _rb = GetComponent<Rigidbody2D>();
        }

        public void Launch(Vector2 target) {
            var currentPosition = _rb.position;
            var positionDelta   = target - currentPosition;
            var direction       = positionDelta.normalized;
            var speed           = Random.Range(minSpeed, maxSpeed);
            var velocity        = direction * speed;

            var rotationDir   = Random.value < 0.5f ? -1 : 1;
            var rotationSpeed = Random.Range(minRotationSpeed, maxRotationSpeed);
            var rotation      = rotationDir * rotationSpeed;

            _rb.linearVelocity  = velocity;
            _rb.angularVelocity = rotation;
        }

        private void OnTriggerEnter2D(Collider2D other) {
            if (other.CompareTag("Asteroid Wall"))
            {
                Destroy(gameObject);
            }
        }
    }
}

