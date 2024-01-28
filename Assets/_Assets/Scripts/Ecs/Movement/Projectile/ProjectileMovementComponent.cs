using System;
using Scellecs.Morpeh;
using UnityEngine;

namespace _Assets.Scripts.Ecs.Movement.Projectile
{
    [Serializable]
    public struct ProjectileMovementComponent : IComponent
    {
        public Transform transform;
        public float speed;
    }
}