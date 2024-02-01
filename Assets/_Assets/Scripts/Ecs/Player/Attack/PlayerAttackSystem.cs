using _Assets.Scripts.Ecs.Enemies;
using _Assets.Scripts.Ecs.Enemies.RangeEnemy.Attack;
using _Assets.Scripts.Ecs.Movement.Characters;
using _Assets.Scripts.Ecs.Rotation;
using _Assets.Scripts.Misc;
using _Assets.Scripts.Services;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Systems;
using UnityEngine;
using VContainer;

namespace _Assets.Scripts.Ecs.Player.Attack
{
    [CreateAssetMenu(menuName = "ECS/Systems/" + nameof(PlayerAttackSystem))]
    public class PlayerAttackSystem : UpdateSystem
    {
        [Inject] private IMyLogger _myLogger;
        [Inject] private ProjectileFactory _projectileFactory;
        private Filter _enemyFilter;
        private Filter _playerFilter;

        public override void OnAwake()
        {
            _playerFilter = World.Filter
                .With<PlayerAttackComponent>()
                .With<CharacterControllerMovementComponent>()
                .With<RotationComponent>()
                .Build();
        }

        public override void OnUpdate(float deltaTime)
        {
            _enemyFilter = World.Filter
                .With<RangeEnemyAttackComponent>()
                .With<CharacterControllerMovementComponent>()
                .Without<EnemyDeadMarker>()
                .Build();

            var player = _playerFilter.First();
            ref var playerAttackComponent = ref player.GetComponent<PlayerAttackComponent>();

            var playerPosition = player.GetComponent<CharacterControllerMovementComponent>().characterController.transform.position;
            var shootPointPosition = playerAttackComponent.shootPoint.position;

            Entity closestEnemy = null;
            float closestDistance = float.MaxValue;

            if (playerAttackComponent.currentCoolDown > 0)
            {
                playerAttackComponent.currentCoolDown -= Time.deltaTime;
            }

            foreach (var entity in _enemyFilter)
            {
                if (playerAttackComponent.currentCoolDown <= 0)
                {
                    var movement = entity.GetComponent<CharacterControllerMovementComponent>();

                    var distance = Vector3.Distance(
                        movement.characterController.transform.position,
                        player.GetComponent<CharacterControllerMovementComponent>().characterController.transform.position
                    );

                    if (distance < closestDistance)
                    {
                        closestDistance = distance;
                        closestEnemy = entity;
                    }
                }
            }

            if (closestEnemy == null)
            {
                _myLogger.LogWarning("Closest enemy is null");
                return;
            }

            if (closestDistance <= playerAttackComponent.attackRange)
            {
                var vectorFromPlayerToEnemy = closestEnemy.GetComponent<CharacterControllerMovementComponent>().characterController.transform.position - playerPosition;

                var projectile = _projectileFactory.Create(ProjectileFactory.ProjectileType.Player);
                projectile.transform.position = shootPointPosition;
                projectile.transform.forward = vectorFromPlayerToEnemy.normalized;

                playerAttackComponent.currentCoolDown = playerAttackComponent.cooldown;
            }
        }
    }
}