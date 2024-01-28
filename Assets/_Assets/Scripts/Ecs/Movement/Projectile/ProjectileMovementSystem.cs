using Scellecs.Morpeh;
using Scellecs.Morpeh.Systems;
using UnityEngine;

namespace _Assets.Scripts.Ecs.Movement.Projectile
{
    [CreateAssetMenu(menuName = "ECS/Systems/" + nameof(ProjectileMovementSystem))]
    public class ProjectileMovementSystem : UpdateSystem
    {
        private Filter _movementFilter;
        public override void OnAwake()
        {
            _movementFilter = World.Filter.With<ProjectileMovementComponent>().Build();
        }

        public override void OnUpdate(float deltaTime)
        {
            foreach (var entity in _movementFilter)
            {
                var movement = entity.GetComponent<ProjectileMovementComponent>();
                movement.transform.position += movement.transform.forward * movement.speed * deltaTime;
            }
        }
    }
}