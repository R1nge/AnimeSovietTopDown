namespace _Assets.Scripts.Services.StateMachine.States
{
    public class WaveStartedState : IGameState
    {
        private readonly WaveSpawner _waveSpawner;

        public WaveStartedState(WaveSpawner waveSpawner)
        {
            _waveSpawner = waveSpawner;
        }
        
        public async void Enter()
        {
            await _waveSpawner.Spawn();
        }

        public void Exit()
        {
        }
    }
}