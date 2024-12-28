﻿using _Assets.Scripts.Configs;
using _Assets.Scripts.Gameplay.Grid.Views;
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
        
        public GridView Create(Transform parent)
        {
            return _objectResolver.Instantiate(_configProvider._GridView, parent);
        }
    }
}