using System;
using _Assets.Scripts.Configs;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace _Assets.Scripts.Services
{
    public class ProjectileFactory
    {
        private readonly IObjectResolver _objectResolver;
        private readonly ConfigProvider _configProvider;
        
        private ProjectileFactory(IObjectResolver objectResolver, ConfigProvider configProvider)
        {
            _objectResolver = objectResolver;
            _configProvider = configProvider;
        }
        
        public GameObject Create(ProjectileType projectileType)
        {
            switch (projectileType)
            {
                case ProjectileType.Player:
                    return _objectResolver.Instantiate(_configProvider.ProjectileConfig.PlayerProjectilePrefab);
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