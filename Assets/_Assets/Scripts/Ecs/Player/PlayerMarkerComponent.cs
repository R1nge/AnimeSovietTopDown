using System;
using _Assets.Scripts.Services.UIs.HealthBar;
using Scellecs.Morpeh;

namespace _Assets.Scripts.Ecs.Player
{
    [Serializable]
    public struct PlayerMarkerComponent : IComponent
    {
        //TODO: create player heatlh bar component
        public HealthBarController healthBarController;
    }
}