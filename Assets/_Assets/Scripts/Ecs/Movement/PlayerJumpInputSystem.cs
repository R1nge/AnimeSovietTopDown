using System;
using _Assets.Scripts.Ecs.Movement.Characters;
using _Assets.Scripts.Ecs.Player;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Systems;
using UnityEngine;

namespace _Assets.Scripts.Ecs.Movement
{
    [CreateAssetMenu(menuName = "ECS/Systems/Player/" + nameof(PlayerJumpInputSystem))]
    public sealed class PlayerJumpInputSystem : UpdateSystem
    {
        private Filter _filter;
        private float _lerp;
        private bool _canJump;
        private bool _jumped;

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
                _jumped = true;
            }

            if (_jumped)
            {
                if (_lerp < 1)
                {
                    character.direction.y = Mathf.Lerp(0, jump.jumpHeight, _lerp);
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