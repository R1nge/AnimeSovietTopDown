using _Assets.Scripts.Ecs.Movement;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Systems;
using UnityEngine;

namespace _Assets.Scripts.Ecs.Enemies.Movement
{
    [CreateAssetMenu(menuName = "ECS/Systems/" + nameof(EnemyMovementSystem))]
    public sealed class EnemyMovementSystem : UpdateSystem
    {
        private Filter _filter;

        public override void OnAwake()
        {
            _filter = World.Filter.With<EnemyMarkerComponent>().With<MovementComponent>().Build();
        }

        public override void OnUpdate(float deltaTime)
        {
            foreach (var entity in _filter)
            {
                entity.GetComponent<MovementComponent>().direction = new Vector3(1, 0, 0);
            }
        }
    }
}