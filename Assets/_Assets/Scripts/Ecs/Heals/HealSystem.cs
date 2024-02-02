using _Assets.Scripts.Ecs.Healths;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Systems;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace _Assets.Scripts.Ecs.Heals
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    [CreateAssetMenu(menuName = "ECS/Systems/" + nameof(HealSystem))]
    public class HealSystem : UpdateSystem
    {
        private Request<HealRequest> _healRequest;
        private Event<HealedEvent> _healedEvent;

        public override void OnAwake()
        {
            _healRequest = World.GetRequest<HealRequest>();
            _healedEvent = World.GetEvent<HealedEvent>();
        }

        public override void OnUpdate(float deltaTime)
        {
            foreach (var request in _healRequest.Consume())
            {
                ApplyHeal(request.TargetEntityId, request.Heal);

                _healedEvent.NextFrame(new HealedEvent
                {
                    TargetEntityId = request.TargetEntityId,
                });
            }
        }

        private void ApplyHeal(EntityId target, int heal)
        {
            if (World.TryGetEntity(target, out var entity))
            {
                ref var health = ref entity.GetComponent<HealthComponent>();
                health.health = Mathf.Clamp(health.health + heal, 0, health.maxHealth);
            }
        }
    }
}