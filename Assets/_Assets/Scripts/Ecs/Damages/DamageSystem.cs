using _Assets.Scripts.Ecs.Healths;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Systems;
using UnityEngine;

namespace _Assets.Scripts.Ecs.Damages
{
    [CreateAssetMenu(menuName = "ECS/Systems/Damage", fileName = "DamageSystem")]
    public class DamageSystem : UpdateSystem
    {
        private Request<DamageRequest> _damageRequest;
        private Event<DamagedEvent> _damagedEvent;

        public override void OnAwake()
        {
            _damageRequest = World.GetRequest<DamageRequest>();
            _damagedEvent = World.GetEvent<DamagedEvent>();
        }

        public override void OnUpdate(float deltaTime)
        {
            foreach (var request in _damageRequest.Consume())
            {
                ApplyDamage(request.TargetEntityId, request.Damage);

                _damagedEvent.NextFrame(new DamagedEvent
                {
                    TargetEntityId = request.TargetEntityId,
                });
            }
        }

        private void ApplyDamage(EntityId target, int damage)
        {
            if (World.TryGetEntity(target, out var entity))
            {
                var health = entity.GetComponent<HealthComponent>();
                health.health -= damage;
            }
        }
    }
}