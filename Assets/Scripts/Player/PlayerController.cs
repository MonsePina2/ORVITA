using Asteroids;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float speed;

        [SerializeField] private Rigidbody2D rb;

        private Vector3 _inputDirection;

        private void FixedUpdate() {
            var direction = _inputDirection * speed;
            rb.AddForce(direction);
        }

        public void OnMove(InputAction.CallbackContext ctx) {
            var value     = ctx.ReadValue<Vector2>();
            _inputDirection = new Vector3(value.x, value.y, 0);

        }

        private void OnTriggerEnter2D(Collider2D other) {


            var asteroid = other.GetComponentInParent<Asteroid>();
            if (asteroid != null)
            {
                Destroy(gameObject);
            }

            //var objectParent=other.transform.root.parent;
            //if (objectParent.CompareTag("Asteroid"))
            //{
            //    Destroy(gameObject);
            //}
        }
    }
}
