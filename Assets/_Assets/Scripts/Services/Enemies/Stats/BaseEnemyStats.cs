using System;

namespace _Assets.Scripts.Services.Enemies.Stats
{
    [Serializable]
    public struct BaseEnemyStats
    {
        public int maxHealth;
        public float speed;
        public int damage;
        public float detectRange;
        public float attackRange;
    }

    [Serializable]
    public struct RangeEnemyStats
    {
        public float projectileSpeed;
        public float projectileSize;
        public float maxCooldown, currentCooldown;
    }
}