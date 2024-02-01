using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;

namespace _Assets.Scripts.Ecs.Player
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public struct PlayerProjectileMarkerComponent : IComponent
    {
    }
}