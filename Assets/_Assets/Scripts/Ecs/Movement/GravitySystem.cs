using _Assets.Scripts.Ecs.Movement.Characters;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Systems;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace _Assets.Scripts.Ecs.Movement
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    [CreateAssetMenu(menuName = "ECS/Systems/" + nameof(GravitySystem))]
    public sealed class GravitySystem : UpdateSystem
    {
        private Filter _filter;
        
        public override void OnAwake()
        {
        }

        public override void OnUpdate(float deltaTime)
        {
            _filter = World.Filter.With<CharacterControllerMovementComponent>().Build();
            foreach (var entity in _filter)
            {
                ref var component = ref entity.GetComponent<CharacterControllerMovementComponent>();
                component.direction.y = Physics.gravity.y * deltaTime;
            }
        }
    }
}