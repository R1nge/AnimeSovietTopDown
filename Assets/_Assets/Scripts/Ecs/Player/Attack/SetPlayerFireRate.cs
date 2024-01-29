using _Assets.Scripts.Services;
using UnityEngine;
using VContainer;

namespace _Assets.Scripts.Ecs.Player.Attack
{
    using Scellecs.Morpeh;

    [CreateAssetMenu(menuName = "ECS/Systems/" + nameof(SetPlayerFireRate))]
    public sealed class SetPlayerFireRate : Scellecs.Morpeh.Systems.UpdateSystem
    {
        [Inject] private PlayerStatsService _playerStatsService;
        private Filter _filter;

        public override void OnAwake()
        {
            _filter = World.Filter.With<PlayerAttackComponent>().Build();
        }

        public override void OnUpdate(float deltaTime)
        {
            var player = _filter.First();
            player.GetComponent<PlayerAttackComponent>().cooldown = 60f / _playerStatsService.PlayerStats.FireRatePerMinute;
        }
    }
}