using UnityEngine;

namespace _Assets.Scripts.Players.States
{
    public class MovingState : IPlayerState
    {
        private readonly Animator _animator;

        public MovingState(Animator animator)
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