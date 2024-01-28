using System;
using Scellecs.Morpeh;
using UnityEngine;
using Object = UnityEngine.Object;

namespace _Assets.Scripts.Ecs.Healths
{
    [Serializable]
    public struct HealthComponent : IComponent, IDisposable
    {
        public GameObject gameObject;
        public int maxHealth;
        public int health;

        public void Dispose() => Object.Destroy(gameObject);
    }
}