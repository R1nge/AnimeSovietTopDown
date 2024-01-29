using UnityEngine;

namespace _Assets.Scripts.Services.StateMachine.States
{
    public class GameState : IGameState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly PlayerFactory _playerFactory;
        private readonly WaveSpawner _waveSpawner;

        public GameState(GameStateMachine stateMachine, PlayerFactory playerFactory, WaveSpawner waveSpawner)
        {
            _stateMachine = stateMachine;
            _playerFactory = playerFactory;
            _waveSpawner = waveSpawner;
        }

        public void Enter()
        {
            var player = _playerFactory.Create();
            _waveSpawner.Spawn();
        }

        public void Exit() { }
    }
}