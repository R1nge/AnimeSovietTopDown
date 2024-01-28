using _Assets.Scripts.Ecs.Healths;
using _Assets.Scripts.Ecs.Player;
using Scellecs.Morpeh.Systems;
using UnityEngine;

namespace _Assets.Scripts.Ecs.Damages.OnDamage
{
    using Scellecs.Morpeh;

    [CreateAssetMenu(menuName = "ECS/Systems/" + nameof(UpdatePlayerHealthBarSystem))]
    public sealed class UpdatePlayerHealthBarSystem : UpdateSystem
    {
        private Filter _filter;

        public override void OnAwake()
        {
            _filter = World.Filter
                .With<PlayerMarkerComponent>()
                .With<HealthComponent>()
                .Build();
        }

        public override void OnUpdate(float deltaTime)
        {
            var player = _filter.First();
            var healthComponent = player.GetComponent<HealthComponent>();
            var markerComponent = player.GetComponent<PlayerMarkerComponent>();
            markerComponent.healthBarController.UpdateHealthBar(healthComponent.health, healthComponent.maxHealth);
        }
    }
}