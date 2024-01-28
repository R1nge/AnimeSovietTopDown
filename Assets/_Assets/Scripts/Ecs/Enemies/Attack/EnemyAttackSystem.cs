using _Assets.Scripts.Ecs.Damages;
using _Assets.Scripts.Ecs.Movement;
using _Assets.Scripts.Ecs.Movement.Characters;
using _Assets.Scripts.Ecs.Player;
using _Assets.Scripts.Enemies;
using _Assets.Scripts.Services;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Systems;
using UnityEngine;
using VContainer;

namespace _Assets.Scripts.Ecs.Enemies.Attack
{
    [CreateAssetMenu(menuName = "ECS/Systems/" + nameof(EnemyAttackSystem))]
    public sealed class EnemyAttackSystem : UpdateSystem
    {
        [Inject] private ProjectileFactory _projectileFactory;
        private Filter _enemyFilter;
        private Filter _playerFilter;

        public override void OnAwake()
        {
            _enemyFilter = World.Filter.With<EnemyAttackComponent>().With<CharacterControllerMovementComponent>()
                .Build();
            _playerFilter = World.Filter.With<PlayerMarkerComponent>().With<CharacterControllerMovementComponent>()
                .Build();
        }

        public override void OnUpdate(float deltaTime)
        {
            var player = _playerFilter.First();
            foreach (var entity in _enemyFilter)
            {
                ref var enemy = ref entity.GetComponent<EnemyAttackComponent>();
                
                if (enemy.currentCoolDown > 0)
                {
                    enemy.currentCoolDown -= Time.deltaTime;
                }
                else
                {
                    enemy.currentCoolDown = enemy.cooldown;

                    ref var movement = ref entity.GetComponent<CharacterControllerMovementComponent>();

                    var distance = Vector3.Distance(
                        movement.characterController.transform.position,
                        player.GetComponent<CharacterControllerMovementComponent>().characterController.transform.position
                    );

                    if (distance <= enemy.attackRange)
                    {
                        enemy.enemyController.EnemyStateMachine.SwitchState(EnemyStateMachine.EnemyStatesType
                            .Attacking);

                        var enemyPosition = enemy.shootPoint.position;
                        var playerPosition = player.GetComponent<CharacterControllerMovementComponent>().characterController.transform.position;
                        var vectorFromEnemyToPlayer = playerPosition - enemyPosition;
                        
                        var projectile = _projectileFactory.Create();
                        projectile.transform.position = enemyPosition;
                        projectile.transform.forward = vectorFromEnemyToPlayer.normalized;


                        movement.direction = Vector3.zero;
                    }
                    else
                    {
                        enemy.enemyController.EnemyStateMachine.SwitchState(EnemyStateMachine.EnemyStatesType.Chasing);
                    }
                }
            }
        }
    }
}