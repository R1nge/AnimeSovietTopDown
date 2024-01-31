using System;
using _Assets.Scripts.Enemies;
using Scellecs.Morpeh;
using UnityEngine;

namespace _Assets.Scripts.Ecs.Enemies.Attack
{
    [Serializable]
    public struct RangeEnemyAttackComponent : IComponent
    {
        public float cooldown, maxCooldown;
        public float attackRange;
        public int damage;
        public Transform shootPoint;
        public EnemyController enemyController;
    }
}