using UnityEngine;

namespace _Assets.Scripts.Services
{
    [CreateAssetMenu(menuName = "Configs/Enemy Wave")]
    public class EnemyWave : ScriptableObject
    {
        public GameObject[] prefabs;
        public float[] timeBetweenSpawn;
        public int[] spawnCount;
    }
}