using System;
using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace _Assets.Scripts.Ecs.Enemies.RangeEnemy.Attack
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    [Serializable]
    public struct RangeEnemyAttackComponent : IComponent
    {
        public float cooldown, maxCooldown;
        public float attackRange;
        public int damage;
        public Transform shootPoint;
    }
}