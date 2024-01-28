using UnityEngine;

namespace _Assets.Scripts.Enemies.States
{
    public class ChasingState : IEnemyState
    {
        public void Enter()
        {
            Debug.Log("Enter Chasing State");
        }

        public void Exit()
        {
            Debug.Log("Exit Chasing State");
        }
    }
}