using _Assets.Scripts.Configs;
using _Assets.Scripts.Gameplay.Minesweeper.Grid.Views;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace _Assets.Scripts.Services.Grid
{
    public class GridViewFactory
    {
        private readonly ConfigProvider _configProvider;
        private readonly IObjectResolver _objectResolver;

        private GridViewFactory(IObjectResolver objectResolver, ConfigProvider configProvider)
        {
            _objectResolver = objectResolver;
            _configProvider = configProvider;
        }

        public MineSweeperGridView CreateMineSweeper(Transform parent)
        {
            return _objectResolver.Instantiate(_configProvider.MineSweeperGridView, parent);
        }
    }
}