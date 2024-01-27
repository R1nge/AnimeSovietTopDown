using System;
using Scellecs.Morpeh;

namespace _Assets.Scripts.Ecs.Healths
{
    [Serializable]
    public struct HealthComponent : IComponent
    {
        public int health;
    }
}