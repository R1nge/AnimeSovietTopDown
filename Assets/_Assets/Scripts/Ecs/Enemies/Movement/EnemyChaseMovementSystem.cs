﻿using _Assets.Scripts.Ecs.Enemies.Detection;
using _Assets.Scripts.Ecs.Movement;
using _Assets.Scripts.Ecs.Player;
using _Assets.Scripts.Enemies;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Systems;
using UnityEngine;

namespace _Assets.Scripts.Ecs.Enemies.Movement
{
    [CreateAssetMenu(menuName = "ECS/Systems/" + nameof(EnemyChaseMovementSystem))]
    public sealed class EnemyChaseMovementSystem : UpdateSystem
    {
        private Filter _enemy;
        private Filter _player;

        public override void OnAwake()
        {
            _enemy = World.Filter.With<EnemyPlayerDetectionComponent>().With<MovementComponent>().Build();
            _player = World.Filter.With<PlayerMarkerComponent>().With<MovementComponent>().Build();
        }

        public override void OnUpdate(float deltaTime)
        {
            var player = _player.First();
            var playerPosition = player.GetComponent<MovementComponent>().characterController.transform.position;
            
            foreach (var entity in _enemy)
            {
                ref var movement = ref entity.GetComponent<MovementComponent>();
                var enemy = entity.GetComponent<EnemyPlayerDetectionComponent>();

                if (enemy.enemyController.EnemyStateMachine.CurrentStateType == EnemyStateMachine.EnemyStatesType.Chasing)
                {
                    var enemyPosition = movement.characterController.transform.position;
                    var vectorFromEnemyToPlayer = playerPosition - enemyPosition;
                    movement.direction = vectorFromEnemyToPlayer;
                }
            }
        }
    }
}