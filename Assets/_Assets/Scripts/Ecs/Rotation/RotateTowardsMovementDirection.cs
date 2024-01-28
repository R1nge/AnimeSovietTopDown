using _Assets.Scripts.Ecs.Movement.Characters;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Systems;
using UnityEngine;

namespace _Assets.Scripts.Ecs.Rotation
{
    [CreateAssetMenu(menuName = "ECS/Systems/" + nameof(RotateTowardsMovementDirection))]
    public sealed class RotateTowardsMovementDirection : UpdateSystem
    {
        private Filter _filter;

        public override void OnAwake()
        {
            _filter = World.Filter.With<RotationComponent>().With<CharacterControllerMovementComponent>().Build();
        }

        public override void OnUpdate(float deltaTime)
        {
            foreach (var entity in _filter)
            {
                var movementComponent = entity.GetComponent<CharacterControllerMovementComponent>();

                if (movementComponent.direction == Vector3.zero)
                {
                    return;
                }

                ref var rotation = ref entity.GetComponent<RotationComponent>();
                rotation.rotation = Quaternion.LookRotation(movementComponent.direction);
            }
        }
    }
}