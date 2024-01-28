using UnityEngine;

namespace _Assets.Scripts.Enemies.States
{
    public class IdleState : IEnemyState
    {
        private readonly Animator _animator;
        
        public IdleState(Animator animator)
        {
            _animator = animator;
        }
        
        public void Enter()
        {
            _animator.Play("");
            Debug.Log("Enter Idle State");
        }

        public void Update(float deltaTime)
        {
            
        }

        public void Exit()
        {
            Debug.Log("Exit Idle State");
        }
    }
}