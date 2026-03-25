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

        [SerializeField] private GameObject deathParticlesPrefab;

        [SerializeField] private Animator animator;

        private Vector3 _inputDirection;

        private void FixedUpdate() {
            var direction = _inputDirection * speed;
            rb.AddForce(direction);
        }

        public void OnMove(InputAction.CallbackContext ctx) {
            var value = ctx.ReadValue<Vector2>();
            _inputDirection = new Vector3(value.x, value.y, 0);

            if (_inputDirection == Vector3.zero)
            {
                engineAudioSourse .Stop();
            }
            else
            {
                engineAudioSourse.Play();
                animator.SetFloat("XDirection",_inputDirection.x);
                animator.SetFloat("YDirection",_inputDirection.y);
            }



    }

        private void OnTriggerEnter2D(Collider2D other) {


            var asteroid = other.GetComponentInParent<Asteroid>();
            if (asteroid != null)
            {
                GameManager.Instance.GameOver();
                Instantiate(deathParticlesPrefab,transform.position, Quaternion.identity);
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
