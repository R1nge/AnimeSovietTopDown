﻿using _Assets.Scripts.Ecs.Enemies;
using _Assets.Scripts.Ecs.Movement.Characters;
using _Assets.Scripts.Ecs.Rotation;
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
        [Inject] private ProjectileFactory _projectileFactory;
        private Filter _enemyFilter;
        private Filter _playerFilter;

        public override void OnAwake()
        {
            _enemyFilter = World.Filter
                .With<EnemyMarkerComponent>()
                .With<CharacterControllerMovementComponent>()
                .Build();
            _playerFilter = World.Filter
                .With<PlayerAttackComponent>()
                .With<CharacterControllerMovementComponent>()
                .With<RotationComponent>()
                .Build();
        }

        public override void OnUpdate(float deltaTime)
        {
            var player = _playerFilter.First();
            ref var playerAttackComponent = ref player.GetComponent<PlayerAttackComponent>();

            var playerPosition = player.GetComponent<CharacterControllerMovementComponent>().characterController.transform.position;
            var shootPointPosition = playerAttackComponent.shootPoint.position;

            Entity closestEnemy = null;
            float closestDistance = float.MaxValue;

            foreach (var entity in _enemyFilter)
            {
                if (playerAttackComponent.currentCoolDown > 0)
                {
                    playerAttackComponent.currentCoolDown -= Time.deltaTime;
                }
                else
                {
                    playerAttackComponent.currentCoolDown = playerAttackComponent.cooldown;

                    ref var movement = ref entity.GetComponent<CharacterControllerMovementComponent>();

                    var distance = Vector3.Distance(
                        movement.characterController.transform.position,
                        player.GetComponent<CharacterControllerMovementComponent>().characterController.transform
                            .position
                    );

                    if (distance < closestDistance)
                    {
                        closestDistance = distance;
                        closestEnemy = entity;
                    }
                }
            }

            if (closestEnemy == null)
                return;

            var vectorFromPlayerToEnemy = closestEnemy.GetComponent<CharacterControllerMovementComponent>().characterController.transform.position - playerPosition;
            vectorFromPlayerToEnemy.y = 0;

            if (closestDistance <= playerAttackComponent.attackRange)
            {
                var projectile = _projectileFactory.Create();
                projectile.transform.position = shootPointPosition;
                projectile.transform.forward = vectorFromPlayerToEnemy.normalized;
            }
        }
    }
}