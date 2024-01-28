using System;
using _Assets.Scripts.Enemies;
using Scellecs.Morpeh;

namespace _Assets.Scripts.Ecs.Enemies.Attack
{
    [Serializable]
    public struct EnemyAttackComponent : IComponent
    {
        public EnemyController enemyController;
        public int attackRange;
    }
}