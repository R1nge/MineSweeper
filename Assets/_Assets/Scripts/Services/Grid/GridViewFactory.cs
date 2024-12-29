﻿using _Assets.Scripts.Configs;
using _Assets.Scripts.Gameplay.Minesweeper.Grid.Views;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace _Assets.Scripts.Services.Grid
{
    public class GridViewFactory
    {
        private readonly IObjectResolver _objectResolver;
        private readonly ConfigProvider _configProvider;

        private GridViewFactory(IObjectResolver objectResolver, ConfigProvider configProvider)
        {
            _objectResolver = objectResolver;
            _configProvider = configProvider;
        }
        
        public MineSweeperGridView Create(Transform parent)
        {
            return _objectResolver.Instantiate(_configProvider.mineSweeperGridView, parent);
        }
    }
}