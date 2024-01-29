using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace _Assets.Scripts.Services
{
    public class EnemyFactory
    {
        private readonly IObjectResolver _objectResolver;
        private readonly EnemyWavesService _enemyWavesService;

        public EnemyFactory(IObjectResolver objectResolver, EnemyWavesService enemyWavesService)
        {
            _objectResolver = objectResolver;
            _enemyWavesService = enemyWavesService;
        }
        
        public GameObject Create()
        {
            //TODO: spawner
            return _objectResolver.Instantiate(_enemyWavesService.Waves[0].waves[0].prefabs[0]);
        }
    }
}