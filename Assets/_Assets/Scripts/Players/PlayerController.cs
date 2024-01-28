using UnityEngine;

namespace _Assets.Scripts.Players
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        private PlayerStateMachine _playerStateMachine;

        private void Start()
        {
            _playerStateMachine = new PlayerStateMachine(animator);
        }
    }
}