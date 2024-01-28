namespace _Assets.Scripts.Players
{
    public interface IPlayerState
    {
        void Enter();
        void Update(float deltaTime);
        void Exit();
    }
}