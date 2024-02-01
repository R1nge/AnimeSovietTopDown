using _Assets.Scripts.Ecs.Movement.Characters;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Systems;
using UnityEngine;

namespace _Assets.Scripts.Ecs.Movement
{
    [CreateAssetMenu(menuName = "ECS/Systems/Player/" + nameof(PlayerJumpInputSystem))]
    public sealed class PlayerJumpInputSystem : UpdateSystem
    {
        private Filter _filter;

        public override void OnAwake()
        {
            _filter = World.Filter.With<CharacterControllerMovementComponent>().Build();
        }

        public override void OnUpdate(float deltaTime)
        {
            if (Input.GetMouseButtonDown(0))
            {
                var player = _filter.First();
                ref var character = ref player.GetComponent<CharacterControllerMovementComponent>();
                character.direction.y = 10;
            }
        }
    }
}