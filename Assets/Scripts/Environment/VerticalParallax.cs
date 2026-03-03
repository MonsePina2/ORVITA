using UnityEngine;

namespace Environment
{
    public class VerticalParallax : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private float height;

        private Vector3 _startPosition;

        private void Awake() {
            _startPosition = transform.position;
        }

        private void Update() {
            var movement=speed*Time.deltaTime;

            transform.Translate(movement * Vector3.up);
        }
    }
}
