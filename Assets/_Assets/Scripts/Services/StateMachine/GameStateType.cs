namespace _Assets.Scripts.Services.StateMachine
{
    public enum GameStateType : byte
    {
        None = 0,
        Init = 1,
        Game = 2,
        WaveStarted = 3,
        WaveEnded = 4,
        GameOver = 5
    }
}