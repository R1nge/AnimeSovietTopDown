using UnityEngine;

namespace _Assets.Scripts.Enemies.States
{
    public class ChasingState : IEnemyState
    {
        private readonly Animator _animator;

        public ChasingState(Animator animator)
        {
            _animator = animator;
        }
        
        public void Enter()
        {
            Debug.Log("Enter Chasing State");
        }

        public void Update(float deltaTime)
        {
            
        }

        public void Exit()
        {
            Debug.Log("Exit Chasing State");
        }
    }
}