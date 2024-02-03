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
    [CreateAssetMenu(menuName = "ECS/Systems/Player/" + nameof(SetPlayerFireRate))]
    public sealed class SetPlayerFireRate : UpdateSystem
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