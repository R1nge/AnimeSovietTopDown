using _Assets.Scripts.Ecs.Movement;
using _Assets.Scripts.Ecs.Movement.Characters;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Systems;
using UnityEngine;

namespace _Assets.Scripts.Ecs.Player
{
    [CreateAssetMenu(menuName = "ECS/Systems/Player/" + nameof(PlayerJumpInputSystem))]
    public sealed class PlayerJumpInputSystem : UpdateSystem
    {
        private Filter _filter;
        private float _lerp;
        private bool _canJump;
        private bool _jumped;
        private float _startPosition;

        public override void OnAwake()
        {
            _filter = World.Filter.With<PlayerMarkerComponent>().With<CharacterControllerMovementComponent>().With<JumpComponent>().Build();
        }

        public override void OnUpdate(float deltaTime)
        {
            var player = _filter.First();
            ref var character = ref player.GetComponent<CharacterControllerMovementComponent>();
            var jump = player.GetComponent<JumpComponent>();

            _canJump = character.characterController.isGrounded;

            if (Input.GetMouseButtonDown(0) && !_jumped && _canJump)
            {
                _startPosition = character.characterController.transform.position.y;
                _jumped = true;
            }

            if (_jumped)
            {
                if (_lerp < 1)
                {
                    //TODO: use a custom lerp function?
                    character.direction.y = Mathf.Lerp(_startPosition, _startPosition + jump.jumpHeight, _lerp);
                    float duration = jump.jumpDuration;
                    _lerp += deltaTime / duration;
                }

                if (_lerp >= 1)
                {
                    _lerp = 0;
                    _jumped = false;
                }
            }
        }
    }
}