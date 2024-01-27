using UnityEngine;

namespace _Assets.Scripts.Configs
{
    public class ConfigProvider : MonoBehaviour
    {
        [SerializeField] private PlayerConfig playerConfig;
        public PlayerConfig PlayerConfig => playerConfig;
    }
}