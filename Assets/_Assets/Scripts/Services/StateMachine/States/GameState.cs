using UnityEngine;

namespace _Assets.Scripts.Services.StateMachine.States
{
    public class GameState : IGameState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly PlayerFactory _playerFactory;
        private readonly EnemyFactory _enemyFactory;

        public GameState(GameStateMachine stateMachine, PlayerFactory playerFactory, EnemyFactory enemyFactory)
        {
            _stateMachine = stateMachine;
            _playerFactory = playerFactory;
            _enemyFactory = enemyFactory;
        }

        public void Enter()
        {
            var player = _playerFactory.Create();
            var enemy = _enemyFactory.Create();
            enemy.transform.position = new Vector3(0, 0, 10);
        }

        public void Exit() { }
    }
}