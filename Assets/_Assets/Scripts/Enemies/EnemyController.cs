using UnityEngine;

namespace _Assets.Scripts.Enemies
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private EnemyDeathController enemyDeathController;
        private EnemyStateMachine _enemyStateMachine;
        public EnemyStateMachine EnemyStateMachine => _enemyStateMachine;

        private void Start()
        {
            _enemyStateMachine = new EnemyStateMachine(animator, enemyDeathController);
        }

        private void Update()
        {
            _enemyStateMachine.Update(Time.deltaTime);
        }
    }
}