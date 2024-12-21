using _Assets.Scripts.Configs;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace _Assets.Scripts.Gameplay
{
    public class GridController
    {
        private readonly ConfigProvider _configProvider;
        private readonly GridGenerator _gridGenerator;
        private readonly IObjectResolver _objectResolver;
        private Grid _grid;
        private GridView _gridView;

        public GridController(ConfigProvider configProvider, GridGenerator gridGenerator,
            IObjectResolver objectResolver)
        {
            _configProvider = configProvider;
            _gridGenerator = gridGenerator;
            _objectResolver = objectResolver;
        }

        public void Init()
        {
            var width = 20;
            var height = 20;
            _grid = new Grid(width, height);
            _gridGenerator.Generate(width, height);
            var parent = GameObject.Find("GameUI(Clone)").transform;
            _gridView = _objectResolver.Instantiate(_configProvider._GridView, parent);
            _gridView.Init(width, height);
        }
    }
}