using System;
using _Assets.Scripts.Enemies;
using Scellecs.Morpeh;

namespace _Assets.Scripts.Ecs.Enemies.Detection
{
    [Serializable]
    public struct EnemyPlayerDetectionComponent : IComponent
    {
        public EnemyController enemyController;
        public float detectRange;
    }
}