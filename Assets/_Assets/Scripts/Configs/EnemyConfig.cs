using UnityEngine;

namespace _Assets.Scripts.Configs
{
    [CreateAssetMenu(fileName = "Enemy Config", menuName = "Configs/Enemy Config")]
    public class EnemyConfig : ScriptableObject
    {
        [SerializeField] private GameObject enemyPrefab;
        public GameObject EnemyPrefab => enemyPrefab;
    }
}