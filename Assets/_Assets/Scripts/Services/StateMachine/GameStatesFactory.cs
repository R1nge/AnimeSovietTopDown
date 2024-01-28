using _Assets.Scripts.Services.StateMachine.States;

namespace _Assets.Scripts.Services.StateMachine
{
    public class GameStatesFactory
    {
        private readonly PlayerFactory _playerFactory;
        private readonly EnemyFactory _enemyFactory;

        private GameStatesFactory(PlayerFactory playerFactory, EnemyFactory enemyFactory)
        {
            _playerFactory = playerFactory;
            _enemyFactory = enemyFactory;
        }
        
        public IGameState CreateGameState(GameStateMachine stateMachine)
        {
            return new GameState(stateMachine, _playerFactory, _enemyFactory);
        }
    }
}