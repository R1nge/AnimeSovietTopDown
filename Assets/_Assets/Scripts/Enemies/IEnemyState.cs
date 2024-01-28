namespace _Assets.Scripts.Enemies
{
    public interface IEnemyState
    {
        void Enter();
        void Update(float deltaTime);
        void Exit();
    }
}