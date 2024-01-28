using _Assets.Scripts.Ecs.Healths;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Systems;
using UnityEngine;

namespace _Assets.Scripts.Ecs.Damages
{
    [CreateAssetMenu(menuName = "ECS/Systems/AttackEveryEntity", fileName = "AttackEveryEntitySystem")]
    public class AttackEveryEntitySystem : UpdateSystem
    {
        private Request<DamageRequest> _damageRequest;
        private Filter _filter;

        public override void OnAwake()
        {
            _filter = World.Filter.With<HealthComponent>().Build();
            _damageRequest = World.GetRequest<DamageRequest>();
        }

        public override void OnUpdate(float deltaTime)
        {
            foreach (var entity in _filter)
            {
                _damageRequest.Publish(new DamageRequest
                {
                    TargetEntityId = entity.ID,
                    Damage = 1
                });
            }
        }
    }
}