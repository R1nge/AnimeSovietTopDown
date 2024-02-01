using _Assets.Scripts.Misc;
using UnityEngine;
using VContainer;

namespace _Assets.Scripts.Enemies
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private EnemyDeathController enemyDeathController;
        [Inject] private IMyLogger _myLogger;
        private EnemyStateMachine _enemyStateMachine;
        public EnemyStateMachine EnemyStateMachine => _enemyStateMachine;

        private void Start()
        {
            _enemyStateMachine = new EnemyStateMachine(animator, enemyDeathController, _myLogger);
        }

        private void Update()
        {
            _enemyStateMachine.Update(Time.deltaTime);
        }
    }
}