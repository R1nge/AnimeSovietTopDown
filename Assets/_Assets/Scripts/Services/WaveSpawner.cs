using UnityEngine;
using VContainer;

namespace _Assets.Scripts.Services
{
    public class WaveSpawner : MonoBehaviour
    {
        [Inject] private EnemyWavesService _enemyWavesService;
        [Inject] private EnemyFactory _enemyFactory;
        [SerializeField] private Transform[] spawnPoints;
        
        public void Spawn()
        {
            for (int i = 0; i < _enemyWavesService.Waves.Length; i++)
            {
                for (int j = 0; j < _enemyWavesService.Waves[i].waves.Length; j++)
                {
                    for (int k = 0; k < _enemyWavesService.Waves[i].waves[j].prefabs.Length; k++)
                    {
                        for (int l = 0; l < _enemyWavesService.Waves[i].waves[j].spawnCount[k]; l++)
                        {
                            var enemy = _enemyFactory.Create(_enemyWavesService.Waves[i].waves[j].prefabs[k]);
                            var position = spawnPoints[Random.Range(0, spawnPoints.Length)].position;
                            enemy.transform.position = position;
                        }
                    }
                }
            }
        }
    }
}