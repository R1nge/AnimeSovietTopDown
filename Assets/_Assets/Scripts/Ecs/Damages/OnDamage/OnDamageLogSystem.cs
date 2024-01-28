using Scellecs.Morpeh;
using Scellecs.Morpeh.Systems;
using UnityEngine;

namespace _Assets.Scripts.Ecs.Damages.OnDamage
{
    [CreateAssetMenu(menuName = "ECS/Systems/OnDamageLog", fileName = "OnDamageLogSystem")]
    public class OnDamageLogSystem : UpdateSystem
    {
        private Event<DamagedEvent> _damagedEvent;

        public override void OnAwake()
        {
            _damagedEvent = World.GetEvent<DamagedEvent>();
        }

        public override void OnUpdate(float deltaTime)
        {
            foreach (var damagedEvent in _damagedEvent.publishedChanges)
            {
                Log(damagedEvent.TargetEntityId);    
            }
        }

        private void Log(EntityId entityId)
        {
            if (World.TryGetEntity(entityId, out var entity))
            {
                Debug.Log(entity.ToString());
            }
        }
    }
}