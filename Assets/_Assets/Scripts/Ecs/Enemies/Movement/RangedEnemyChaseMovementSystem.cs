﻿using _Assets.Scripts.Ecs.Enemies.Attack;
using _Assets.Scripts.Ecs.Enemies.Detection;
using _Assets.Scripts.Ecs.Movement;
using _Assets.Scripts.Ecs.Movement.Characters;
using _Assets.Scripts.Ecs.Player;
using _Assets.Scripts.Enemies;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Systems;
using UnityEngine;

namespace _Assets.Scripts.Ecs.Enemies.Movement
{
    [CreateAssetMenu(menuName = "ECS/Systems/" + nameof(RangedEnemyChaseMovementSystem))]
    public sealed class RangedEnemyChaseMovementSystem : UpdateSystem
    {
        private Filter _enemy;
        private Filter _player;

        public override void OnAwake()
        {
            _player = World.Filter.With<PlayerMarkerComponent>().With<CharacterControllerMovementComponent>().Build();
        }

        public override void OnUpdate(float deltaTime)
        {
            var player = _player.First();
            var playerPosition = player.GetComponent<CharacterControllerMovementComponent>().characterController.transform.position;
            
            _enemy = World.Filter.With<RangeEnemyAttackComponent>().With<RangeEnemyAttackComponent>().With<CharacterControllerMovementComponent>().Without<EnemyDeadMarker>().Build();
            
            foreach (var entity in _enemy)
            {
                ref var movement = ref entity.GetComponent<CharacterControllerMovementComponent>();
                var enemy = entity.GetComponent<RangeEnemyAttackComponent>();

                if (enemy.enemyController.EnemyStateMachine.CurrentStateType == EnemyStateMachine.EnemyStatesType.Chase)
                {
                    var enemyPosition = movement.characterController.transform.position;
                    var vectorFromEnemyToPlayer = playerPosition - enemyPosition;
                    movement.direction = vectorFromEnemyToPlayer;
                }
            }
        }
    }
}