using Scellecs.Morpeh;
using Scellecs.Morpeh.Systems;
using UnityEngine;

namespace _Assets.Scripts.Ecs.Rotation
{
    [CreateAssetMenu(menuName = "ECS/Systems/" + nameof(RotationSystem))]
    public class RotationSystem : UpdateSystem
    {
        private Filter _filter;
        
        public override void OnAwake()
        {
            _filter = World.Filter.With<RotationComponent>().Build();
        }
        public override void OnUpdate(float deltaTime)
        {
            foreach (var entity in _filter)
            {
                ref var rotation = ref entity.GetComponent<RotationComponent>();
                rotation.transform.rotation = rotation.rotation;
            }
        }
    }
}