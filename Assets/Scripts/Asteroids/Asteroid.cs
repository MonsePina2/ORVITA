using UnityEngine;
using Player;
using UnityEngine.WSA;

namespace Asteroids
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Asteroid : MonoBehaviour
    {
        [Range(.5f,50)]
        [SerializeField] private float speed;
        private Rigidbody2D _rb;

        private void Awake() {
            _rb = GetComponent<Rigidbody2D>();
        }

        public void Launch(Vector2 target) {
            var currentPosition = _rb.position;
            var positionDelta   = target - currentPosition;
            var direction=positionDelta.normalized;
            var velocity= direction*speed;
            _rb.linearVelocity = velocity;
        }

        private void OnTriggerEnter2D(Collider2D other) {
            Debug.Log("Triggered with" + other.name);
        }
        private void OnTriggerEnter2D(Collision2D other) {
            Debug.Log("Collided with"+other.gameObject.name);
        }
    }
}
