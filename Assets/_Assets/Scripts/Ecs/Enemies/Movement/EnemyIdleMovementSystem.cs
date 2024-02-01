using _Assets.Scripts.Ecs.Movement.Characters;
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
    [CreateAssetMenu(menuName = "ECS/Systems/" + nameof(EnemyIdleMovementSystem))]
    public class EnemyIdleMovementSystem : UpdateSystem
    {
        private Filter _enemy;

        public override void OnAwake() { }

        public override void OnUpdate(float deltaTime)
        {
            _enemy = World.Filter.With<EnemyBaseComponent>().With<CharacterControllerMovementComponent>().Build();
            
            foreach (var entity in _enemy)
            {
                ref var movement = ref entity.GetComponent<CharacterControllerMovementComponent>();
                var enemyBase = entity.GetComponent<EnemyBaseComponent>();

                if (enemyBase.enemyController.EnemyStateMachine.CurrentStateType == EnemyStateMachine.EnemyStatesType.Idle)
                {
                    movement.direction = Vector3.zero;
                }
            }
        }
    }
}