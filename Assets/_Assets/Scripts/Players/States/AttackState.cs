using UnityEngine;

namespace _Assets.Scripts.Players.States
{
    public class AttackState : IPlayerState
    {
        private readonly Animator _animator;

        public AttackState(Animator animator)
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