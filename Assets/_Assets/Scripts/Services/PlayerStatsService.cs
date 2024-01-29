namespace _Assets.Scripts.Services
{
    public class PlayerStatsService
    {
        private PlayerStats _playerStats = new(100, 120, 1, 5f, 1f, 5f, 5f);
        public PlayerStats PlayerStats => _playerStats;
    }

    public struct PlayerStats
    {
        public int MaxHealth;
        public int FireRate;
        public int Damage;
        public float ProjectileSpeed;
        public float ProjectileSize;
        public float AttackRange;
        public float MoveSpeed;

        public PlayerStats(int maxHealth, int fireRate, int damage, float projectileSpeed, float projectileSize, float attackRange, float moveSpeed)
        {
            MaxHealth = maxHealth;
            FireRate = fireRate;
            Damage = damage;
            ProjectileSpeed = projectileSpeed;
            ProjectileSize = projectileSize;
            AttackRange = attackRange;
            MoveSpeed = moveSpeed;
        }
    }
}