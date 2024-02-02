using _Assets.Scripts.Ecs.Healths;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Providers;
using UnityEngine;

namespace _Assets.Scripts.Ecs.Heals
{
    public class HealProvider : MonoProvider<HealComponent>
    {
        private Request<HealRequest> _healRequest;
        
        protected override void Initialize() => _healRequest = World.Default.GetRequest<HealRequest>();

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out HealthProvider healthProvider))
            {
                var data = healthProvider.GetData();
                if (data.health != data.maxHealth)
                {
                    _healRequest.Publish(new HealRequest
                    {
                        Heal = GetData().amount,
                        TargetEntityId = healthProvider.Entity.ID
                    });
                    
                    Destroy(gameObject);
                }
            }
        }
    }
}