﻿namespace _Assets.Scripts.Services
{
    public class PlayerStatsService
    {
        private PlayerStats _playerStats = new(100, 360, 10, 5f, 1f, 10, 5f);
        public PlayerStats PlayerStats => _playerStats;
    }

    public struct PlayerStats
    {
        public int MaxHealth;
        public int FireRatePerMinute;
        public int Damage;
        public float ProjectileSpeed;
        public float ProjectileSize;
        public int AttackRange;
        public float MoveSpeed;

        public PlayerStats(int maxHealth, int fireRatePerMinute, int damage, float projectileSpeed, float projectileSize, int attackRange, float moveSpeed)
        {
            MaxHealth = maxHealth;
            FireRatePerMinute = fireRatePerMinute;
            Damage = damage;
            ProjectileSpeed = projectileSpeed;
            ProjectileSize = projectileSize;
            AttackRange = attackRange;
            MoveSpeed = moveSpeed;
        }
    }
}