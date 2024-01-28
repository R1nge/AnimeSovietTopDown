using UnityEngine;

namespace _Assets.Scripts.Enemies.States
{
    public class RoamingState : IEnemyState
    {
        private readonly Animator _animator;

        public RoamingState(Animator animator)
        {
            _animator = animator;
        }
        
        public void Enter()
        {
            throw new System.NotImplementedException();
        }

        public void Update(float deltaTime)
        {
            throw new System.NotImplementedException();
        }

        public void Exit()
        {
            throw new System.NotImplementedException();
        }
    }
}