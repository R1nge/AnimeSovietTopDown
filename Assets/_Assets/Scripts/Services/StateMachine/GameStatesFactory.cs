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

        public IGameState CreateInitState(GameStateMachine gameStateMachine)
        {
            return new InitState();
        }
        
        public IGameState CreateGameState(GameStateMachine stateMachine)
        {
            return new GameState(stateMachine, _playerFactory, _waveSpawner);
        }

        public IGameState CreateWaveStartedState(GameStateMachine gameStateMachine)
        {
            return new WaveStartedState(_waveSpawner);
        }

        public IGameState CreateWaveEndedState(GameStateMachine gameStateMachine)
        {
            return new WaveEndedState();
        }

        public IGameState CreateGameOverState(GameStateMachine gameStateMachine)
        {
            return new GameOverState();
        }
    }
}