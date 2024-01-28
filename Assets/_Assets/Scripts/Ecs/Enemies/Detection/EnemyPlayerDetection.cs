using _Assets.Scripts.Ecs.Movement;
using _Assets.Scripts.Ecs.Player;
using UnityEngine;

namespace _Assets.Scripts.Ecs.Enemies.Detection
{
    using Scellecs.Morpeh;

    [CreateAssetMenu(menuName = "ECS/Systems/" + nameof(EnemyPlayerDetection))]
    public sealed class EnemyPlayerDetection : Scellecs.Morpeh.Systems.UpdateSystem
    {
        private Filter _enemyFilter;
        private Filter _playerFilter;

        public override void OnAwake()
        {
            _enemyFilter = World.Filter.With<EnemyMarkerComponent>().With<MovementComponent>().Build();
            _playerFilter = World.Filter.With<PlayerMarkerComponent>().Build();
        }

        public override void OnUpdate(float deltaTime)
        {
            var player = _playerFilter.First();
            foreach (var entity in _enemyFilter)
            {
                var movement = entity.GetComponent<MovementComponent>();
                var distance = Vector3.Distance(
                    movement.characterController.transform.position,
                    player.GetComponent<MovementComponent>().characterController.transform.position
                );
                if (distance <= 10)
                {
                    Debug.Log("Detected");
                }
                else
                {
                    Debug.Log("Not Detected");
                }
            }
        }
    }
}