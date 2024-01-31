using System;
using Scellecs.Morpeh;
using UnityEngine;

namespace _Assets.Scripts.Ecs.Enemies.RangeEnemy.Attack
{
    [Serializable]
    public struct RangeEnemyAttackComponent : IComponent
    {
        public float cooldown, maxCooldown;
        public float attackRange;
        public int damage;
        public Transform shootPoint;
    }
}