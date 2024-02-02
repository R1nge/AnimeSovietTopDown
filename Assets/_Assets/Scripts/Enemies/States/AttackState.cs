using _Assets.Scripts.Misc;
using UnityEngine;

namespace _Assets.Scripts.Enemies.States
{
    public class AttackState : IEnemyState
    {
        private readonly Animator _animator;

        public AttackState(Animator animator)
        {
            _animator = animator;
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