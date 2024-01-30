using _Assets.Scripts.Ecs.Enemies;
using _Assets.Scripts.Ecs.Healths;
using _Assets.Scripts.Ecs.Movement.Characters;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Systems;
using UnityEngine;

namespace _Assets.Scripts.Ecs.Damages.OnDamage
{
    [CreateAssetMenu(menuName = "ECS/Systems/" + nameof(OnDamageEnemyDeathSystem))]
    public sealed class OnDamageEnemyDeathSystem : UpdateSystem
    {
        private Event<DamagedEvent> _damagedEvent;

        public override void OnAwake() => _damagedEvent = World.GetEvent<DamagedEvent>();

        public override void OnUpdate(float deltaTime)
        {
            foreach (var damagedEvent in _damagedEvent.publishedChanges)
            {
                Death(damagedEvent.TargetEntityId);
            }
        }

        private void Death(EntityId entityId)
        {
            if (World.TryGetEntity(entityId, out var entity))
            {
                if (entity.Has<RangeEnemyComponent>() && !entity.Has<EnemyDeadMarker>())
                {
                    var healthComponent = entity.GetComponent<HealthComponent>();
                    if (healthComponent.health <= 0)
                    {
                        entity.GetComponent<CharacterControllerMovementComponent>().direction = Vector3.zero;
                        entity.AddComponent<EnemyDeadMarker>();
                        var enemyMarkerComponent = entity.GetComponent<RangeEnemyComponent>();
                        enemyMarkerComponent.Dispose();
                    }   
                }
            }
        }
    }
}