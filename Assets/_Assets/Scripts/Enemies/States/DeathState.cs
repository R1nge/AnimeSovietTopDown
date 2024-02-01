using UnityEngine;

namespace _Assets.Scripts.Enemies.States
{
    public class DeathState : IEnemyState
    {
        private readonly Animator _animator;
        private readonly EnemyDeathController _enemyDeathController;

        public DeathState(Animator animator, EnemyDeathController enemyDeathController)
        {
            _animator = animator;
            _enemyDeathController = enemyDeathController;
        }
        
        public void Enter()
        {
            _enemyDeathController.Die();
            _animator.enabled = false;
            //TODO: stop animations
            //TODO: ragdoll?
        }

        public void Update(float deltaTime)
        {
        }

        public void Exit()
        {
        }
    }
}