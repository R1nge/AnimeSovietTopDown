namespace _Assets.Scripts.Services.StateMachine.States
{
    public class WaveStartedState : IGameState
    {
        private readonly WaveSpawner _waveSpawner;

        public WaveStartedState(WaveSpawner waveSpawner)
        {
            _waveSpawner = waveSpawner;
        }
        
        public void Enter()
        {
            _waveSpawner.Spawn();
        }

        public void Exit()
        {
        }
    }
}