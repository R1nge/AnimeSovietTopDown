using _Assets.Scripts.Ecs.Damages;
using _Assets.Scripts.Ecs.Healths;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Providers;
using UnityEngine;

namespace _Assets.Scripts.Ecs.Movement.Projectile
{
    public class ProjectileMovementProvider : MonoProvider<ProjectileMovementComponent>
    {
        [SerializeField] private int damage;
        private Request<DamageRequest> _damageRequest;

        protected override void Initialize()
        {
            _damageRequest = World.Default.GetRequest<DamageRequest>();
            Destroy(gameObject, 10f);
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
            
            Destroy(gameObject);
        }
    }
}