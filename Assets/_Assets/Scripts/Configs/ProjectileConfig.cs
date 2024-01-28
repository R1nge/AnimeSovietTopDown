using UnityEngine;

namespace _Assets.Scripts.Configs
{
    [CreateAssetMenu(fileName = "Projectile Config", menuName = "Configs/Projectile Config")]
    public class ProjectileConfig : ScriptableObject
    {
        [SerializeField] private GameObject projectilePrefab;
        public GameObject ProjectilePrefab => projectilePrefab;
    }
}