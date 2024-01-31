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
    [CreateAssetMenu(menuName = "ECS/Systems/" + nameof(RangeEnemyAttackSystem))]
    public sealed class RangeEnemyAttackSystem : UpdateSystem
    {
        [Inject] private ProjectileFactory _projectileFactory;
        private Filter _enemyFilter;
        private Filter _playerFilter;

        public override void OnAwake()
        {
            _playerFilter = World.Filter.With<PlayerMarkerComponent>().With<CharacterControllerMovementComponent>().Build();
        }

        public override void OnUpdate(float deltaTime)
        {
            
            _enemyFilter = World.Filter.With<RangeEnemyComponent>().With<RangeEnemyComponent>().With<CharacterControllerMovementComponent>().With<RotationComponent>().Without<EnemyDeadMarker>().Build();
            
            var player = _playerFilter.First();
            foreach (var entity in _enemyFilter)
            {
                ref var rangeEnemyComponent = ref entity.GetComponent<RangeEnemyComponent>();

                var playerPosition = player.GetComponent<CharacterControllerMovementComponent>().characterController.transform.position;
                var shootPointPosition = rangeEnemyComponent.shootPoint.position;
                var enemyPosition = entity.GetComponent<CharacterControllerMovementComponent>().characterController.transform.position;
                var vectorFromEnemyToPlayer = playerPosition - enemyPosition;
                vectorFromEnemyToPlayer.y = 0;

                ref var enemyRotation = ref entity.GetComponent<RotationComponent>();
                enemyRotation.rotation = Quaternion.LookRotation(vectorFromEnemyToPlayer, Vector3.up);

                if (rangeEnemyComponent.rangeEnemyStats.currentCooldown > 0)
                {
                    rangeEnemyComponent.rangeEnemyStats.currentCooldown -= Time.deltaTime;
                }
                else
                {
                    rangeEnemyComponent.rangeEnemyStats.currentCooldown = rangeEnemyComponent.rangeEnemyStats.maxCooldown;

                    ref var movement = ref entity.GetComponent<CharacterControllerMovementComponent>();

                    var distance = Vector3.Distance(
                        movement.characterController.transform.position,
                        playerPosition
                    );

                    if (distance <= rangeEnemyComponent.baseEnemyStats.attackRange)
                    {
                        rangeEnemyComponent.enemyController.EnemyStateMachine.SwitchState(EnemyStateMachine.EnemyStatesType.Attack);

                        var projectile = _projectileFactory.Create(ProjectileFactory.ProjectileType.Enemy);
                        projectile.transform.position = shootPointPosition;
                        projectile.transform.forward = vectorFromEnemyToPlayer.normalized;
                        projectile.SetDamage(rangeEnemyComponent.baseEnemyStats.damage);

                        movement.direction = Vector3.zero;
                    }
                    else
                    {
                        rangeEnemyComponent.enemyController.EnemyStateMachine.SwitchState(EnemyStateMachine.EnemyStatesType.Chase);
                    }
                }
            }
        }
    }
}