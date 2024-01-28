using UnityEngine;

namespace _Assets.Scripts.Enemies
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        private EnemyStateMachine _enemyStateMachine;
        public EnemyStateMachine EnemyStateMachine => _enemyStateMachine;

        private void Start()
        {
            _enemyStateMachine = new EnemyStateMachine(animator);
        }

        private void Update()
        {
            _enemyStateMachine.Update(Time.deltaTime);
        }
    }
}