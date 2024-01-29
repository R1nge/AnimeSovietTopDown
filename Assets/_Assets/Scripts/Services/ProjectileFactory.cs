using System;
using _Assets.Scripts.Configs;
using _Assets.Scripts.Ecs.Movement.Projectile;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace _Assets.Scripts.Services
{
    public class ProjectileFactory
    {
        private readonly IObjectResolver _objectResolver;
        private readonly ConfigProvider _configProvider;
        private readonly PlayerStatsService _playerStatsService;
        
        private ProjectileFactory(IObjectResolver objectResolver, ConfigProvider configProvider, PlayerStatsService playerStatsService)
        {
            _objectResolver = objectResolver;
            _configProvider = configProvider;
            _playerStatsService = playerStatsService;
        }
        
        public ProjectileMovementProvider Create(ProjectileType projectileType)
        {
            switch (projectileType)
            {
                case ProjectileType.Player:
                    var projectile = _objectResolver.Instantiate(_configProvider.ProjectileConfig.PlayerProjectilePrefab);
                    projectile.SetDamage(_playerStatsService.PlayerStats.Damage);
                    return projectile;
                case ProjectileType.Enemy:
                    return _objectResolver.Instantiate(_configProvider.ProjectileConfig.EnemyProjectilePrefab);
                default:
                    throw new ArgumentOutOfRangeException(nameof(projectileType), projectileType, null);
            }
        }

        public enum ProjectileType
        {
            Player,
            Enemy
        } 
    }
}