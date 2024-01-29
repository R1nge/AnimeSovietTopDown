using System;
using _Assets.Scripts.Services;
using _Assets.Scripts.Services.Inputs;
using _Assets.Scripts.Services.StateMachine;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace _Assets.Scripts.CompositionRoot
{
    public class GameInstaller : LifetimeScope
    {
        [SerializeField] private EnemyWavesService enemyWavesService;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterComponent(enemyWavesService);
            
            builder.Register<InputService>(Lifetime.Singleton);

            builder.Register<EnemyFactory>(Lifetime.Singleton);

            builder.Register<PlayerStatsService>(Lifetime.Singleton);
            builder.Register<PlayerFactory>(Lifetime.Singleton);

            builder.Register<ProjectileFactory>(Lifetime.Singleton);

            builder.Register<GameStatesFactory>(Lifetime.Singleton);
            builder.Register<GameStateMachine>(Lifetime.Singleton);
        }
    }
}