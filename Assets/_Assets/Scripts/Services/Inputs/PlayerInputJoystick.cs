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
            _inputService.SetInputVector(new Vector3(joystick.Direction.x, 0, joystick.Direction.y));
        }
    }
}