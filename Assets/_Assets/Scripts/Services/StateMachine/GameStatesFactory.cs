using _Assets.Scripts.Services.StateMachine.States;

namespace _Assets.Scripts.Services.StateMachine
{
    public class GameStatesFactory
    {
        private readonly PlayerFactory _playerFactory;

        private GameStatesFactory(PlayerFactory playerFactory)
        {
            _playerFactory = playerFactory;
        }
        
        public IGameState CreateGameState(GameStateMachine stateMachine)
        {
            return new GameState(stateMachine, _playerFactory);
        }
    }
}