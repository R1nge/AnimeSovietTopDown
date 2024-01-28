using _Assets.Scripts.Ecs.Movement;
using _Assets.Scripts.Ecs.Player;
using _Assets.Scripts.Enemies;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Systems;
using UnityEngine;

namespace _Assets.Scripts.Ecs.Enemies.Attack
{
    [CreateAssetMenu(menuName = "ECS/Systems/" + nameof(EnemyAttackSystem))]
    public sealed class EnemyAttackSystem : UpdateSystem
    {
        private Filter _enemyFilter;
        private Filter _playerFilter;

        public override void OnAwake()
        {
            _enemyFilter = World.Filter.With<EnemyAttackComponent>().With<MovementComponent>().Build();
            _playerFilter = World.Filter.With<PlayerMarkerComponent>().With<MovementComponent>().Build();
        }

        public override void OnUpdate(float deltaTime)
        {
            var player = _playerFilter.First();
            foreach (var entity in _enemyFilter)
            {
                var enemy = entity.GetComponent<EnemyAttackComponent>();
                var movement = entity.GetComponent<MovementComponent>();

                var distance = Vector3.Distance(
                    movement.characterController.transform.position,
                    player.GetComponent<MovementComponent>().characterController.transform.position
                );

                if (distance <= enemy.attackRange)
                {
                    enemy.enemyController.EnemyStateMachine.SwitchState(EnemyStateMachine.EnemyStatesType.Attacking);
                }
            }
        }
    }
}