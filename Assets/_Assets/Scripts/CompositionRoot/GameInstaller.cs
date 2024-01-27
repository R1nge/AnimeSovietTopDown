using _Assets.Scripts.Services;
using _Assets.Scripts.Services.StateMachine;
using VContainer;
using VContainer.Unity;

namespace _Assets.Scripts.CompositionRoot
{
    public class GameInstaller : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<PlayerFactory>(Lifetime.Singleton);
            
            builder.Register<GameStatesFactory>(Lifetime.Singleton);
            builder.Register<GameStateMachine>(Lifetime.Singleton);
        }
    }
}