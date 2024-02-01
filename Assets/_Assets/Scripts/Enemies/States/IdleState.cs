using _Assets.Scripts.Misc;
using UnityEngine;

namespace _Assets.Scripts.Enemies.States
{
    public class IdleState : IEnemyState
    {
        private readonly Animator _animator;
        private readonly IMyLogger _logger;

        public IdleState(Animator animator, IMyLogger logger)
        {
            _animator = animator;
            _logger = logger;
        }
        
        public void Enter()
        {
        }

        public void Update(float deltaTime)
        {
            
        }

        public void Exit()
        {
        }
    }
}