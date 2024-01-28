using Scellecs.Morpeh;
using Scellecs.Morpeh.Systems;
using UnityEngine;

namespace _Assets.Scripts.Ecs.Movement.Characters
{
    [CreateAssetMenu(menuName = "ECS/Systems/" + nameof(CharacterControllerMovementSystem), fileName = "MovementSystem")]
    public class CharacterControllerMovementSystem : UpdateSystem
    {
        private Filter _movementFilter;
        
        public override void OnAwake()
        {
            _movementFilter = World.Filter.With<CharacterControllerMovementComponent>().Build();
        }

        public override void OnUpdate(float deltaTime)
        {
            foreach (var entity in _movementFilter)
            {
                var movement = entity.GetComponent<CharacterControllerMovementComponent>();
                movement.characterController.Move(movement.direction * movement.speed * deltaTime);
            }
        }
    }
}