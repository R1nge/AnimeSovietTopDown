using Scellecs.Morpeh;
using VContainer;

namespace _Assets.Scripts.Ecs
{
    public class InjectableInstaller : Installer
    {
        [Inject] private IObjectResolver _objectResolver;
        
        private void Start()
        {
            foreach (var initializer in initializers)
            {
                _objectResolver.Inject(initializer);
            }

            foreach (var updateSystem in updateSystems)
            {
                _objectResolver.Inject(updateSystem.System);
            }

            foreach (var fixedUpdateSystem in fixedUpdateSystems)
            {
                _objectResolver.Inject(fixedUpdateSystem.System);
            }

            foreach (var lateUpdateSystem in lateUpdateSystems)
            {
                _objectResolver.Inject(lateUpdateSystem.System);
            }

            foreach (var cleanupSystem in cleanupSystems)
            {
                _objectResolver.Inject(cleanupSystem.System);
            }
        }
    }
}