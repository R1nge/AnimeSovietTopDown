using _Assets.Scripts.Ecs.Movement.Projectile;
using UnityEngine;

namespace _Assets.Scripts.Configs
{
    [CreateAssetMenu(fileName = "Projectile Config", menuName = "Configs/Projectile Config")]
    public class ProjectileConfig : ScriptableObject
    {
        [SerializeField] private ProjectileMovementProvider playerProjectilePrefab;
        [SerializeField] private ProjectileMovementProvider enemyProjectilePrefab;
        public ProjectileMovementProvider PlayerProjectilePrefab => playerProjectilePrefab;
        public ProjectileMovementProvider EnemyProjectilePrefab => enemyProjectilePrefab;
    }
}