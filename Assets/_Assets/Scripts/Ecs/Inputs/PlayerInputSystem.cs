using _Assets.Scripts.Ecs.Movement;
using _Assets.Scripts.Ecs.Player;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Systems;
using UnityEngine;

namespace _Assets.Scripts.Ecs.Inputs
{
    [CreateAssetMenu(menuName = "ECS/Systems/PlayerInput", fileName = "PlayerInputSystem")]
    public class PlayerInputSystem : UpdateSystem
    {
        private Filter _filter;
        
        public override void OnAwake()
        {
            _filter = World.Filter.With<PlayerMarkerComponent>().With<MovementComponent>().Build();
        }

        public override void OnUpdate(float deltaTime)
        {
            var player = _filter.First();
            player.GetComponent<MovementComponent>().direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
        }
    }
}