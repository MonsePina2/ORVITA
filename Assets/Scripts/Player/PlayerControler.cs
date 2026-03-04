using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerControler : MonoBehaviour
    {
        public void OnMove(InputAction.CallbackContext ctx) {
            var value     = ctx.ReadValue<Vector2>();
            var direction = new Vector3(value.x, value.y, 0);
            transform.Translate(direction*Time.deltaTime);
        }
    }
}
