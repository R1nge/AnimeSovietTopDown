using UnityEngine;
using VContainer;

namespace _Assets.Scripts.Services.Inputs
{
    public class PlayerInputJoystick : MonoBehaviour
    {
        [SerializeField] private Joystick joystick;
        [Inject] private InputService _inputService;

        private void Update()
        {
            var y = 0;
            if (Input.GetMouseButtonDown(0))
            {
                y = 1000;
            }
            _inputService.SetMovementVector(new Vector3(joystick.Direction.x, y, joystick.Direction.y));
        }
    }
}