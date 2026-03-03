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
            if (Mathf.Approximately(speed, 0)) return;

            MoveBackground();

            LoopBackgroundIfNeed();
        }

        private void MoveBackground() {
            var movement=speed*Time.deltaTime;
            transform.Translate(movement * Vector3.up);
        }

        private void LoopBackgroundIfNeed() {
            var offset = transform.position.y - _startPosition.y;

            if (Mathf.Abs(offset)<height) return;

            var direction=Mathf.Sign(offset);

            var overshoot=offset-direction*height;

            var overShootDir = Vector3.up * overshoot;

            transform.position = _startPosition + overShootDir;
        }
    }
}
