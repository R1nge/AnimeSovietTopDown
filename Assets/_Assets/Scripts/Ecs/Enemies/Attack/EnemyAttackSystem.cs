using _Assets.Scripts.Ecs.Movement.Characters;
using _Assets.Scripts.Ecs.Player;
using _Assets.Scripts.Ecs.Rotation;
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
            _enemyFilter = World.Filter.With<EnemyMarkerComponent>().With<EnemyAttackComponent>().With<CharacterControllerMovementComponent>().With<RotationComponent>().Build();
            _playerFilter = World.Filter.With<PlayerMarkerComponent>().With<CharacterControllerMovementComponent>().Build();
        }

        public override void OnUpdate(float deltaTime)
        {
            var player = _playerFilter.First();
            foreach (var entity in _enemyFilter)
            {
                ref var enemyAttackComponent = ref entity.GetComponent<EnemyAttackComponent>();
                
                var playerPosition = player.GetComponent<CharacterControllerMovementComponent>().characterController.transform.position;
                var shootPointPosition = enemyAttackComponent.shootPoint.position;
                var enemyPosition = entity.GetComponent<CharacterControllerMovementComponent>().characterController.transform.position;
                var vectorFromEnemyToPlayer = playerPosition - enemyPosition;
                vectorFromEnemyToPlayer.y = 0;
                
                ref var enemyRotation = ref entity.GetComponent<RotationComponent>();
                enemyRotation.rotation = Quaternion.LookRotation(vectorFromEnemyToPlayer, Vector3.up);
                
                if (enemyAttackComponent.currentCoolDown > 0)
                {
                    enemyAttackComponent.currentCoolDown -= Time.deltaTime;
                }
                else
                {
                    enemyAttackComponent.currentCoolDown = enemyAttackComponent.cooldown;

                    ref var movement = ref entity.GetComponent<CharacterControllerMovementComponent>();

                    var distance = Vector3.Distance(
                        movement.characterController.transform.position,
                        playerPosition
                    );

                    if (distance <= enemyAttackComponent.attackRange)
                    {
                        enemyAttackComponent.enemyController.EnemyStateMachine.SwitchState(EnemyStateMachine.EnemyStatesType.Attacking);
                        
                        var projectile = _projectileFactory.Create(ProjectileFactory.ProjectileType.Enemy);
                        projectile.transform.position = shootPointPosition;
                        projectile.transform.forward = vectorFromEnemyToPlayer.normalized;


                        movement.direction = Vector3.zero;
                    }
                    else
                    {
                        enemyAttackComponent.enemyController.EnemyStateMachine.SwitchState(EnemyStateMachine.EnemyStatesType.Chasing);
                    }
                }
            }
        }
    }
}