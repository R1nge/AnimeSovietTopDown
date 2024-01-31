using _Assets.Scripts.Ecs.Movement.Characters;
using _Assets.Scripts.Ecs.Player;
using _Assets.Scripts.Enemies;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Systems;
using UnityEngine;

namespace _Assets.Scripts.Ecs.Enemies.Detection
{
    //This logic is the same across all enemies, create a base enemy component and use it.
    [CreateAssetMenu(menuName = "ECS/Systems/" + nameof(RangeEnemyPlayerDetectionSystem))]
    public sealed class RangeEnemyPlayerDetectionSystem : UpdateSystem
    {
        private Filter _enemyFilter;
        private Filter _playerFilter;

        public override void OnAwake()
        {
            _enemyFilter = World.Filter.With<RangeEnemyComponent>().With<CharacterControllerMovementComponent>().Build();
            _playerFilter = World.Filter.With<PlayerMarkerComponent>().Build();
        }

        public override void OnUpdate(float deltaTime)
        {
            var player = _playerFilter.First();
            foreach (var entity in _enemyFilter)
            {
                var enemy = entity.GetComponent<RangeEnemyComponent>();
                var movement = entity.GetComponent<CharacterControllerMovementComponent>();

                var distance = Vector3.Distance(
                    movement.characterController.transform.position,
                    player.GetComponent<CharacterControllerMovementComponent>().characterController.transform.position
                );

                if (distance <= enemy.baseEnemyStats.detectRange)
                {
                    if (enemy.enemyController.EnemyStateMachine.CurrentStateType != EnemyStateMachine.EnemyStatesType.Attack)
                    {
                        enemy.enemyController.EnemyStateMachine.SwitchState(EnemyStateMachine.EnemyStatesType.Chase);    
                    }
                }
                else
                {
                    enemy.enemyController.EnemyStateMachine.SwitchState(EnemyStateMachine.EnemyStatesType.Idle);
                }
            }
        }
    }
}