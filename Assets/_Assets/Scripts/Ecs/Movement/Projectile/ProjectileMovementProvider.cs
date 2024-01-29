using _Assets.Scripts.Ecs.Damages;
using _Assets.Scripts.Ecs.Healths;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Providers;
using UnityEngine;

namespace _Assets.Scripts.Ecs.Movement.Projectile
{
    public class ProjectileMovementProvider : MonoProvider<ProjectileMovementComponent>
    {
        public void SetDamage(int damage)
        {
            if (damage <= 0)
            {
                Debug.LogError("Trying to set damage to zero or less");
                return;
            }

            _damage = damage;
        }

        private int _damage;
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
                    Damage = _damage,
                    TargetEntityId = healthProvider.Entity.ID
                });
            }

            Destroy(gameObject);
        }
    }
}