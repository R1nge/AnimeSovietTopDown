﻿using _Assets.Scripts.Services;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Systems;
using UnityEngine;
using VContainer;

namespace _Assets.Scripts.Ecs.Player.Attack
{
    [CreateAssetMenu(menuName = "ECS/Systems/" + nameof(SetPlayerAttackRangeSystem))]
    public sealed class SetPlayerAttackRangeSystem : UpdateSystem
    {
        [Inject] private PlayerStatsService _playerStatsService;
        private Filter _playerFilter;
        public override void OnAwake()
        {
            _playerFilter = World.Filter.With<PlayerAttackComponent>().Build();
        }

        public override void OnUpdate(float deltaTime)
        {
            var player = _playerFilter.First();
            player.GetComponent<PlayerAttackComponent>().attackRange = _playerStatsService.PlayerStats.AttackRange; 
        }
    }
}