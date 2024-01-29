using _Assets.Scripts.Ecs.Movement.Characters;
using UnityEngine;

namespace _Assets.Scripts.Ecs.Animations
{
    using Scellecs.Morpeh;

    [CreateAssetMenu(menuName = "ECS/Systems/Enemy/" + nameof(EnemyMovementAnimationSystem))]
    public sealed class EnemyMovementAnimationSystem : Scellecs.Morpeh.Systems.UpdateSystem
    {
        private Filter _animationFilter;
        private static readonly int Speed = Animator.StringToHash("Speed");

        public override void OnAwake()
        {
            _animationFilter = World.Filter.With<AnimationComponent>().With<CharacterControllerMovementComponent>().Build();
        }

        public override void OnUpdate(float deltaTime)
        {
            foreach (var entity in _animationFilter)
            {
                var animationComponent = entity.GetComponent<AnimationComponent>();
                var movementComponent = entity.GetComponent<CharacterControllerMovementComponent>();
                animationComponent.animator.SetFloat(Speed, movementComponent.characterController.velocity.magnitude);
            }
        }
    }
}