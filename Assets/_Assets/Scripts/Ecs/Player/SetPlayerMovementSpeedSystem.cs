using _Assets.Scripts.Ecs.Movement.Characters;
using _Assets.Scripts.Services;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Systems;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;
using VContainer;

namespace _Assets.Scripts.Ecs.Player
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    [CreateAssetMenu(menuName = "ECS/Systems/Player/" + nameof(SetPlayerMovementSpeedSystem))]
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