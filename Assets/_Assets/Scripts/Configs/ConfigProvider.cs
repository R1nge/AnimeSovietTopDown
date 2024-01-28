using UnityEngine;

namespace _Assets.Scripts.Configs
{
    public class ConfigProvider : MonoBehaviour
    {
        [SerializeField] private PlayerConfig playerConfig;
        [SerializeField] private ProjectileConfig projectileConfig;
        [SerializeField] private EnemyConfig enemyConfig;
        public PlayerConfig PlayerConfig => playerConfig;
        public ProjectileConfig ProjectileConfig => projectileConfig;
        public EnemyConfig EnemyConfig => enemyConfig;
    }
}