using Scellecs.Morpeh;

namespace _Assets.Scripts.Ecs.Heals
{
    public struct HealedEvent : IEventData
    {
        public EntityId TargetEntityId;
    }
}