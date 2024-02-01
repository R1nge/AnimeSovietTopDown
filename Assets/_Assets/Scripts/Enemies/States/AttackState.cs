using _Assets.Scripts.Misc;
using UnityEngine;

namespace _Assets.Scripts.Enemies.States
{
    public class AttackState : IEnemyState
    {
        private readonly Animator _animator;
        private readonly IMyLogger _logger;
        
        public AttackState(Animator animator, IMyLogger logger)
        {
            _animator = animator;
            _logger = logger;
        }
        
        public void Enter()
        {
           _logger.Log("Enter attack state");
        }

        public void Update(float deltaTime)
        {
            
        }

        public void Exit()
        {
            _logger.Log("Exit attack state");
        }
    }
}