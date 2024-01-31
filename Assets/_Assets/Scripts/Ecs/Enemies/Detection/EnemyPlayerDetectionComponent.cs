using System;
using Scellecs.Morpeh;

namespace _Assets.Scripts.Ecs.Enemies.Detection
{
    [Serializable]
    public struct EnemyPlayerDetectionComponent : IComponent
    {
        public float detectRange;
    }
}