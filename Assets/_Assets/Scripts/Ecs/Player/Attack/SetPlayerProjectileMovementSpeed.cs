﻿using _Assets.Scripts.Ecs.Movement.Projectile;
using _Assets.Scripts.Services;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Systems;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;
using VContainer;

namespace _Assets.Scripts.Ecs.Player.Attack
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    [CreateAssetMenu(menuName = "ECS/Systems/" + nameof(SetPlayerProjectileMovementSpeed))]
    public sealed class SetPlayerProjectileMovementSpeed : UpdateSystem
    {
        [Inject] private PlayerStatsService _playerStatsService;
        private Filter _filter;

        public override void OnAwake()
        {
            _filter = World.Filter.With<ProjectileMovementComponent>().With<PlayerProjectileMarkerComponent>().Build();
        }

        public override void OnUpdate(float deltaTime)
        {
            foreach (var entity in _filter)
            {
                entity.GetComponent<ProjectileMovementComponent>().speed = _playerStatsService.PlayerStats.ProjectileSpeed;
            }
        }
    }
}