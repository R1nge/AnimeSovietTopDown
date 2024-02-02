using System;
using _Assets.Scripts.Ecs.Healths;
using Scellecs.Morpeh.Providers;
using UnityEngine;

namespace _Assets.Scripts.Ecs.Heals
{
    public class HealProvider : MonoProvider<HealComponent>
    {
        private void OnTriggerEnter(Collider other)
        {
            Debug.LogError("Collision");
            if (other.TryGetComponent(out HealthProvider healthProvider))
            {
                Debug.LogError("Health provider collision");
                var data = healthProvider.GetData();
                Debug.LogError($"Health: {data.health} Max health: {data.maxHealth}");
                if (data.health != data.maxHealth)
                {
                    Debug.LogError("Health is not max");
                    healthProvider.Heal(GetData().amount);
                    Destroy(gameObject);
                }
            }
        }
    }
}