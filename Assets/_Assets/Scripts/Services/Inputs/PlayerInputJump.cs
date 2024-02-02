using _Assets.Scripts.Misc;
using UnityEngine;
using VContainer;

namespace _Assets.Scripts.Services.Inputs
{
    public class PlayerInputJump : MonoBehaviour
    {
        [SerializeField] private ClickableButton jumpButton;
        [Inject] private InputService _inputService;

        private void Start()
        {
            jumpButton.ButtonDown += ButtonPressed;
            jumpButton.ButtonUp += ButtonReleased;
        }

        private void ButtonPressed() => _inputService.Jump = true;

        private void ButtonReleased() => _inputService.Jump = false;

        private void OnDestroy()
        {
            jumpButton.ButtonDown -= ButtonPressed;
            jumpButton.ButtonUp -= ButtonReleased;
        }
    }
}