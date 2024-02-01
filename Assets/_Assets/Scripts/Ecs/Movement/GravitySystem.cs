using _Assets.Scripts.Ecs.Movement.Characters;
using UnityEngine;

namespace _Assets.Scripts.Ecs.Movement
{
    using Scellecs.Morpeh;

    [CreateAssetMenu(menuName = "ECS/Systems/" + nameof(GravitySystem))]
    public sealed class GravitySystem : Scellecs.Morpeh.Systems.UpdateSystem
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