using _Assets.Scripts.Ecs.Enemies;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Systems;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace _Assets.Scripts.Ecs.Movement.Characters
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    [CreateAssetMenu(menuName = "ECS/Systems/" + nameof(CharacterControllerMovementSystem), fileName = "MovementSystem")]
    public class CharacterControllerMovementSystem : UpdateSystem
    {
        private Filter _movementFilter;

        public override void OnAwake()
        {
        }

        public override void OnUpdate(float deltaTime)
        {
            _movementFilter = World.Filter.With<CharacterControllerMovementComponent>().Build(); //.Without<EnemyDeadMarker>().Build();

            foreach (var entity in _movementFilter)
            {
                var movement = entity.GetComponent<CharacterControllerMovementComponent>();

                if (movement.characterController.enabled)
                {
                    movement.characterController.Move(movement.direction * movement.speed * deltaTime);
                }
            }
        }
    }
}