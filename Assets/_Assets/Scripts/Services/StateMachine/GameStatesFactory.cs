using _Assets.Scripts.Services.StateMachine.States;

namespace _Assets.Scripts.Services.StateMachine
{
    public class GameStatesFactory
    {
        private readonly PlayerFactory _playerFactory;
        private readonly WaveSpawner _waveSpawner;

        private GameStatesFactory(PlayerFactory playerFactory, WaveSpawner waveSpawner)
        {
            _playerFactory = playerFactory;
            _waveSpawner = waveSpawner;
        }
        
        public IGameState CreateGameState(GameStateMachine stateMachine)
        {
            return new GameState(stateMachine, _playerFactory, _waveSpawner);
        }
    }
}