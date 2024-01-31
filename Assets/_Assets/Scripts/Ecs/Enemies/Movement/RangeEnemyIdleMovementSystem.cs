using _Assets.Scripts.Ecs.Enemies.Attack;
using _Assets.Scripts.Ecs.Movement.Characters;
using _Assets.Scripts.Enemies;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Systems;
using UnityEngine;

namespace _Assets.Scripts.Ecs.Enemies.Movement
{
    [CreateAssetMenu(menuName = "ECS/Systems/" + nameof(RangeEnemyIdleMovementSystem))]
    public class RangeEnemyIdleMovementSystem : UpdateSystem
    {
        private Filter _enemy;

        public override void OnAwake() { }

        public override void OnUpdate(float deltaTime)
        {
            _enemy = World.Filter.With<RangeEnemyAttackComponent>().With<RangeEnemyAttackComponent>().With<CharacterControllerMovementComponent>().Build();
            
            foreach (var entity in _enemy)
            {
                ref var movement = ref entity.GetComponent<CharacterControllerMovementComponent>();
                var enemy = entity.GetComponent<RangeEnemyAttackComponent>();

                if (enemy.enemyController.EnemyStateMachine.CurrentStateType == EnemyStateMachine.EnemyStatesType.Idle)
                {
                    movement.direction = Vector3.zero;
                }
            }
        }
    }
}