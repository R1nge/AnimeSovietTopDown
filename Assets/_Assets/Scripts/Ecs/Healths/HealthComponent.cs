using System;
using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;

namespace _Assets.Scripts.Ecs.Healths
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    [Serializable]
    public struct HealthComponent : IComponent
    {
        public int maxHealth;
        public int health;
    }
}