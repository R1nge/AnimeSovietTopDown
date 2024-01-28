using UnityEngine;

namespace _Assets.Scripts.Enemies.States
{
    public class AttackState : IEnemyState
    {
        public void Enter()
        {
            Debug.Log("Enter attack state");
        }

        public void Exit()
        {
            Debug.Log("Exit attack state");
        }
    }
}