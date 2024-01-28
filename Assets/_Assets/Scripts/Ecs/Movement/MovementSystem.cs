using Scellecs.Morpeh;
using Scellecs.Morpeh.Systems;
using UnityEngine;

namespace _Assets.Scripts.Ecs.Movement
{
    [CreateAssetMenu(menuName = "ECS/Systems/" + nameof(MovementSystem), fileName = "MovementSystem")]
    public class MovementSystem : UpdateSystem
    {
        private Filter _movementFilter;
        
        public override void OnAwake()
        {
            _movementFilter = World.Filter.With<MovementComponent>().Build();
        }

        public override void OnUpdate(float deltaTime)
        {
            foreach (var entity in _movementFilter)
            {
                var movement = entity.GetComponent<MovementComponent>();
                movement.characterController.Move(movement.direction * movement.speed * deltaTime);
            }
        }
    }
}