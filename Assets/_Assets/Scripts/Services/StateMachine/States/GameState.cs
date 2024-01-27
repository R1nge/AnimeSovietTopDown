namespace _Assets.Scripts.Services.StateMachine.States
{
    public class GameState : IGameState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly PlayerFactory _playerFactory;

        public GameState(GameStateMachine stateMachine, PlayerFactory playerFactory)
        {
            _stateMachine = stateMachine;
            _playerFactory = playerFactory;
        }

        public void Enter()
        {
            var player = _playerFactory.Create();
        }

        public void Exit() { }
    }
}