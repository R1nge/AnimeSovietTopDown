using Scellecs.Morpeh;

namespace _Assets.Scripts.Ecs.Heals
{
    public struct HealRequest : IRequestData
    {
        public EntityId TargetEntityId;
        public int Heal;
    }
}