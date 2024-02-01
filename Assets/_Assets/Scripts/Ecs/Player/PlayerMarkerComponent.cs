using System;
using _Assets.Scripts.Services.UIs.HealthBar;
using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;

namespace _Assets.Scripts.Ecs.Player
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    [Serializable]
    public struct PlayerMarkerComponent : IComponent
    {
        //TODO: create player heatlh bar component
        public HealthBarController healthBarController;
    }
}