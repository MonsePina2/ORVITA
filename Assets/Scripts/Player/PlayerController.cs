using Asteroids;
using Managers;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float speed;

        [SerializeField] private Rigidbody2D rb;

        [SerializeField] private AudioSource engineAudioSourse;

        private Vector3 _inputDirection;

        private void FixedUpdate() {
            var direction = _inputDirection * speed;
            rb.AddForce(direction);
        }

        public void OnMove(InputAction.CallbackContext ctx) {
            var value = ctx.ReadValue<Vector2>();
            _inputDirection = new Vector3(value.x, value.y, 0);
            engineAudioSourse .Stop();
            engineAudioSourse.Play();

    }

        private void OnTriggerEnter2D(Collider2D other) {


            var asteroid = other.GetComponentInParent<Asteroid>();
            if (asteroid != null)
            {
                GameManager.Instance.GameOver();
                Destroy(gameObject);
            }

            //var objectParent=other.transform.root;
            //if (objectParent.CompareTag("Asteroid"))
            //{
            //    Destroy(gameObject);
            //}
        }
    }
}
