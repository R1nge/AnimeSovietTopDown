using UnityEngine;

namespace _Assets.Scripts.Enemies
{
    public class EnemyController : MonoBehaviour
    {
        private EnemyStateMachine _enemyStateMachine;
        public EnemyStateMachine EnemyStateMachine => _enemyStateMachine;

        private void Start()
        {
            _enemyStateMachine = new EnemyStateMachine();
        }
    }
}