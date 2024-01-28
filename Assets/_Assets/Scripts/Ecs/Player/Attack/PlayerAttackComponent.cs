using System;
using Scellecs.Morpeh;
using UnityEngine;

namespace _Assets.Scripts.Ecs.Player.Attack
{
    [Serializable]
    public struct PlayerAttackComponent : IComponent
    {
        public Transform shootPoint;
        public int attackRange;
        public float cooldown, currentCoolDown;
    }
}