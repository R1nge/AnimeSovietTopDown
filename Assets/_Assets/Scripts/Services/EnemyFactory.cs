using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace _Assets.Scripts.Services
{
    public class EnemyFactory
    {
        private readonly IObjectResolver _objectResolver;

        public EnemyFactory(IObjectResolver objectResolver) => _objectResolver = objectResolver;

        public GameObject Create(GameObject prefab) => _objectResolver.Instantiate(prefab);
    }
}