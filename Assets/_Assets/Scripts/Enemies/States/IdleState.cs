using UnityEngine;

namespace _Assets.Scripts.Enemies.States
{
    public class IdleState : IEnemyState
    {
        public void Enter()
        {
            Debug.Log("Enter Idle State");
        }

        public void Exit()
        {
            Debug.Log("Exit Idle State");
        }
    }
}