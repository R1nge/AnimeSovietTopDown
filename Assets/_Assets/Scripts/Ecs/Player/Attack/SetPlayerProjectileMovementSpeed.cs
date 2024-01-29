using _Assets.Scripts.Ecs.Movement.Projectile;
using _Assets.Scripts.Services;
using UnityEngine;
using VContainer;

namespace _Assets.Scripts.Ecs.Player.Attack
{
    using Scellecs.Morpeh;

    [CreateAssetMenu(menuName = "ECS/Systems/" + nameof(SetPlayerProjectileMovementSpeed))]
    public sealed class SetPlayerProjectileMovementSpeed : Scellecs.Morpeh.Systems.UpdateSystem
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