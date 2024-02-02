using UnityEngine;

namespace _Assets.Scripts.Enemies
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private EnemyDeathController enemyDeathController;
        private EnemyStateMachine _enemyStateMachine;

        public EnemyStateMachine EnemyStateMachine
        {
            get
            {
                if (_enemyStateMachine == null)
                {
                    return _enemyStateMachine = new EnemyStateMachine(animator, enemyDeathController);
                }

                return _enemyStateMachine;
            }
        }
    }
}