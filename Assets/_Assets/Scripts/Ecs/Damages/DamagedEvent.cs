using Scellecs.Morpeh;

namespace _Assets.Scripts.Ecs.Damages
{
    public struct DamagedEvent : IEventData
    {
        public EntityId TargetEntityId;
    }
}