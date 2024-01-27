using _Assets.Scripts.Ecs.Movement;
using _Assets.Scripts.Ecs.Player;
using _Assets.Scripts.Services.Inputs;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Systems;
using UnityEngine;
using VContainer;

namespace _Assets.Scripts.Ecs.Inputs
{
    [CreateAssetMenu(menuName = "ECS/Systems/PlayerInput", fileName = "PlayerInputSystem")]
    public class PlayerInputSystem : UpdateSystem
    {
        [Inject] private InputService _inputService;
        private Filter _filter;
        
        public override void OnAwake()
        {
            _filter = World.Filter.With<PlayerMarkerComponent>().With<MovementComponent>().Build();
        }

        public override void OnUpdate(float deltaTime)
        {
            var player = _filter.First();
            player.GetComponent<MovementComponent>().direction = _inputService.InputVector;
        }
    }
}