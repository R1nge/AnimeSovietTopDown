using Scellecs.Morpeh;

namespace _Assets.Scripts.Ecs.Damages
{
    public struct DamageRequest : IRequestData
    {
        public EntityId TargetEntityId;
        public int Damage;
    }
}