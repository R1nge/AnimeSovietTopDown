using _Assets.Scripts.Ecs.Movement.Characters;
using _Assets.Scripts.Ecs.Player;
using _Assets.Scripts.Enemies;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Systems;
using UnityEngine;

namespace _Assets.Scripts.Ecs.Enemies.Detection
{
    [CreateAssetMenu(menuName = "ECS/Systems/" + nameof(EnemyPlayerDetectionSystem))]
    public sealed class EnemyPlayerDetectionSystem : UpdateSystem
    {
        private Filter _enemyFilter;
        private Filter _playerFilter;

        public override void OnAwake()
        {
            _enemyFilter = World.Filter.With<EnemyBaseComponent>().With<EnemyPlayerDetectionComponent>().With<CharacterControllerMovementComponent>().Build();
            _playerFilter = World.Filter.With<PlayerMarkerComponent>().Build();
        }

        public override void OnUpdate(float deltaTime)
        {
            var player = _playerFilter.First();
            foreach (var entity in _enemyFilter)
            {
                var enemyPlayerDetectionComponent = entity.GetComponent<EnemyPlayerDetectionComponent>();
                var enemyBase = entity.GetComponent<EnemyBaseComponent>();
                var movement = entity.GetComponent<CharacterControllerMovementComponent>();

                var distance = Vector3.Distance(
                    movement.characterController.transform.position,
                    player.GetComponent<CharacterControllerMovementComponent>().characterController.transform.position
                );

                if (distance <= enemyPlayerDetectionComponent.detectRange)
                {
                    if (enemyBase.enemyController.EnemyStateMachine.CurrentStateType != EnemyStateMachine.EnemyStatesType.Attack)
                    {
                        enemyBase.enemyController.EnemyStateMachine.SwitchState(EnemyStateMachine.EnemyStatesType.Chase);    
                    }
                }
                else
                {
                    enemyBase.enemyController.EnemyStateMachine.SwitchState(EnemyStateMachine.EnemyStatesType.Idle);
                }
            }
        }
    }
}