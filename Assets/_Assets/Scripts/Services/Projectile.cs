using _Assets.Scripts.Ecs.Damages;
using _Assets.Scripts.Ecs.Healths;
using _Assets.Scripts.Ecs.Movement;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Providers;
using UnityEngine;

namespace _Assets.Scripts.Services
{
    public class Projectile : MonoProvider<CharacterControllerMovementComponent>
    {
        [SerializeField] private int damage;
        private Request<DamageRequest> _damageRequest;
        
        protected override void Initialize()
        {
            _damageRequest = World.Default.GetRequest<DamageRequest>();
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.TryGetComponent(out HealthProvider healthProvider))
            {
                _damageRequest.Publish(new DamageRequest
                {
                    Damage = damage,
                    TargetEntityId = healthProvider.Entity.ID
                });   
            }
        }
    }
}