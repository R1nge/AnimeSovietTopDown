using System;
using _Assets.Scripts.Enemies;
using Scellecs.Morpeh;
using UnityEngine;

namespace _Assets.Scripts.Ecs.Enemies.Attack
{
    [Serializable]
    public struct EnemyAttackComponent : IComponent
    {
        public Transform shootPoint;
        public EnemyController enemyController;
        public int attackRange;
        public float cooldown, currentCoolDown;
    }
}