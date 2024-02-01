using _Assets.Scripts.Ecs.Enemies.RangeEnemy.Attack;
using _Assets.Scripts.Ecs.Movement.Characters;
using _Assets.Scripts.Ecs.Player;
using _Assets.Scripts.Enemies;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Systems;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace _Assets.Scripts.Ecs.Enemies.Movement
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    [CreateAssetMenu(menuName = "ECS/Systems/" + nameof(EnemyChaseMovementSystem))]
    public sealed class EnemyChaseMovementSystem : UpdateSystem
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
            
            _enemy = World.Filter.With<EnemyBaseComponent>().With<CharacterControllerMovementComponent>().Without<EnemyDeadMarker>().Build();

            foreach (var entity in _enemy)
            {
                ref var movement = ref entity.GetComponent<CharacterControllerMovementComponent>();
                var enemy = entity.GetComponent<RangeEnemyAttackComponent>();
                var enemyBase = entity.GetComponent<EnemyBaseComponent>();

                if (enemyBase.enemyController.EnemyStateMachine.CurrentStateType == EnemyStateMachine.EnemyStatesType.Chase)
                {
                    var enemyPosition = movement.characterController.transform.position;
                    var vectorFromEnemyToPlayer = playerPosition - enemyPosition;
                    movement.direction = vectorFromEnemyToPlayer;
                }
            }
        }
    }
}