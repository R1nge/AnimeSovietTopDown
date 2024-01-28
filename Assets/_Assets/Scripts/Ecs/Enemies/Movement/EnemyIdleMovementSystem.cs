using _Assets.Scripts.Ecs.Enemies.Detection;
using _Assets.Scripts.Ecs.Movement;
using _Assets.Scripts.Ecs.Movement.Characters;
using _Assets.Scripts.Enemies;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Systems;
using UnityEngine;

namespace _Assets.Scripts.Ecs.Enemies.Movement
{
    [CreateAssetMenu(menuName = "ECS/Systems/" + nameof(EnemyIdleMovementSystem))]
    public class EnemyIdleMovementSystem : UpdateSystem
    {
        private Filter _enemy;

        public override void OnAwake()
        {
            _enemy = World.Filter.With<EnemyMarkerComponent>().With<EnemyPlayerDetectionComponent>().With<CharacterControllerMovementComponent>().Build();
        }

        public override void OnUpdate(float deltaTime)
        {
            foreach (var entity in _enemy)
            {
                ref var movement = ref entity.GetComponent<CharacterControllerMovementComponent>();
                var enemy = entity.GetComponent<EnemyPlayerDetectionComponent>();

                if (enemy.enemyController.EnemyStateMachine.CurrentStateType == EnemyStateMachine.EnemyStatesType.Idle)
                {
                    movement.direction = Vector3.zero;
                }
            }
        }
    }
}