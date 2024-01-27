using _Assets.Scripts.Configs;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace _Assets.Scripts.Services
{
    public class PlayerFactory
    {
        private readonly IObjectResolver _objectResolver;
        private readonly ConfigProvider _configProvider;

        private PlayerFactory(IObjectResolver objectResolver, ConfigProvider configProvider)
        {
            _objectResolver = objectResolver;
            _configProvider = configProvider;
        }

        public GameObject Create() => _objectResolver.Instantiate(_configProvider.PlayerConfig.PlayerPrefab);
    }
}