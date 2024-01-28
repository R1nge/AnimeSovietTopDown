using UnityEngine;

namespace _Assets.Scripts.Enemies.States
{
    public class DeathState : IEnemyState
    {
        private readonly Animator _animator;

        public DeathState(Animator animator)
        {
            _animator = animator;
        }
        
        public void Enter()
        {
            Debug.LogError("Enter death state");
        }

        public void Update(float deltaTime)
        {
        }

        public void Exit()
        {
        }
    }
}