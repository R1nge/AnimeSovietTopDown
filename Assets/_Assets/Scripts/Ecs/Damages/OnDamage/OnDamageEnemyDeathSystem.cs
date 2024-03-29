﻿using _Assets.Scripts.Ecs.Enemies;
using _Assets.Scripts.Ecs.Enemies.RangeEnemy.Attack;
using _Assets.Scripts.Ecs.Healths;
using _Assets.Scripts.Ecs.Movement.Characters;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Systems;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace _Assets.Scripts.Ecs.Damages.OnDamage
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    [CreateAssetMenu(menuName = "ECS/Systems/" + nameof(OnDamageEnemyDeathSystem))]
    public sealed class OnDamageEnemyDeathSystem : UpdateSystem
    {
        private Event<DamagedEvent> _damagedEvent;

        public override void OnAwake() => _damagedEvent = World.GetEvent<DamagedEvent>();

        public override void OnUpdate(float deltaTime)
        {
            foreach (var damagedEvent in _damagedEvent.publishedChanges)
            {
                Death(damagedEvent.TargetEntityId);
            }
        }

        private void Death(EntityId entityId)
        {
            if (World.TryGetEntity(entityId, out var entity))
            {
                if (entity.Has<EnemyBaseComponent>() && !entity.Has<EnemyDeadMarker>())
                {
                    var healthComponent = entity.GetComponent<HealthComponent>();
                    if (healthComponent.health <= 0)
                    {
                        entity.GetComponent<CharacterControllerMovementComponent>().direction = Vector3.zero;
                        entity.AddComponent<EnemyDeadMarker>();
                        entity.GetComponent<EnemyBaseComponent>().Dispose();
                    }   
                }
            }
        }
    }
}