using _Assets.Scripts.Services.StateMachine;
using UnityEngine;
using VContainer;

namespace _Assets.Scripts.Misc
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] private bool isLogEnable;
        [Inject] private GameStateMachine _gameStateMachine;
        [Inject] private IMyLogger _myLogger;

        private void Start()
        {
            _gameStateMachine.SwitchState(GameStateType.Game);
            _myLogger.IsLogEnable = isLogEnable;
        }
    }
}