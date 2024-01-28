using UnityEngine;

namespace _Assets.Scripts.Configs
{
    [CreateAssetMenu(fileName = "Projectile Config", menuName = "Configs/Projectile Config")]
    public class ProjectileConfig : ScriptableObject
    {
        [SerializeField] private GameObject playerProjectilePrefab;
        [SerializeField] private GameObject enemyProjectilePrefab;
        public GameObject PlayerProjectilePrefab => playerProjectilePrefab;
        public GameObject EnemyProjectilePrefab => enemyProjectilePrefab;
    }
}