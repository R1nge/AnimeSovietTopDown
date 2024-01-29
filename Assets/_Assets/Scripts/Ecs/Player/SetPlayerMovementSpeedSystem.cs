using _Assets.Scripts.Ecs.Movement.Characters;
using _Assets.Scripts.Services;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Systems;
using UnityEngine;
using VContainer;

namespace _Assets.Scripts.Ecs.Player
{
    [CreateAssetMenu(menuName = "ECS/Systems/" + nameof(SetPlayerMovementSpeedSystem))]
    public sealed class SetPlayerMovementSpeedSystem : UpdateSystem
    {
        [Inject] private PlayerStatsService _playerStatsService;
        private Filter _filter;

        public override void OnAwake()
        {
            _filter = World.Filter.With<PlayerMarkerComponent>().With<CharacterControllerMovementComponent>().Build();
        }

        public override void OnUpdate(float deltaTime)
        {
            var player = _filter.First();
            ref var movement = ref player.GetComponent<CharacterControllerMovementComponent>().speed;
            movement  = _playerStatsService.PlayerStats.MoveSpeed;
        }
    }
}