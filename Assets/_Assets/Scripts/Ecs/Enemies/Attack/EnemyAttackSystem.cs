using _Assets.Scripts.Ecs.Damages;
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
        private Request<DamageRequest> _damageRequest;

        public override void OnAwake()
        {
            _enemyFilter = World.Filter.With<EnemyAttackComponent>().With<MovementComponent>().Build();
            _playerFilter = World.Filter.With<PlayerMarkerComponent>().With<MovementComponent>().Build();
            _damageRequest = World.GetRequest<DamageRequest>();
        }

        public override void OnUpdate(float deltaTime)
        {
            var player = _playerFilter.First();
            foreach (var entity in _enemyFilter)
            {
                var enemy = entity.GetComponent<EnemyAttackComponent>();
                ref var movement = ref entity.GetComponent<MovementComponent>();

                var distance = Vector3.Distance(
                    movement.characterController.transform.position,
                    player.GetComponent<MovementComponent>().characterController.transform.position
                );

                if (distance <= enemy.attackRange)
                {
                    movement.direction = Vector3.zero;
                    
                    enemy.enemyController.EnemyStateMachine.SwitchState(EnemyStateMachine.EnemyStatesType.Attacking);
                    
                    _damageRequest.Publish(new DamageRequest
                    {
                        Damage = enemy.damage,
                        TargetEntityId = player.ID
                    });
                }
                else
                {
                    enemy.enemyController.EnemyStateMachine.SwitchState(EnemyStateMachine.EnemyStatesType.Chasing);
                }
            }
        }
    }
}