using UnityEngine;
using Player;

namespace Asteroids
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Asteroid : MonoBehaviour
    {
        [SerializeField] private float speed;

        private Rigidbody2D _rb;

        private void Awake() {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void Start() {
            var target    = FindFirstObjectByType<PlayerController>();
            var direction = GetTargetDirection(target);
            Launch(direction);
        }

        private Vector2 GetTargetDirection(PlayerController target) {
            var targetPos = target.transform.position;
            var delta     = targetPos-transform.position;
            var direction =delta.normalized;

            return direction;
        }
        private void Launch(Vector2 direction) {
            _rb.AddForce(direction*speed,ForceMode2D.Impulse);
        }
    }
}
