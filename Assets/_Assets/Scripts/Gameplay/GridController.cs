using _Assets.Scripts.Configs;
using UnityEngine;

namespace _Assets.Scripts.Gameplay
{
    public class GridController
    {
        private readonly ConfigProvider _configProvider;
        private readonly GridGenerator _gridGenerator;
        private Grid _grid;
        private GridView _gridView;

        public GridController(ConfigProvider configProvider,GridGenerator gridGenerator)
        {
            _configProvider = configProvider;
            _gridGenerator = gridGenerator;
        }

        public void Init()
        {
            _grid = new Grid(20, 20);
            var parent = GameObject.Find("GameUI(Clone)").transform;
            _gridView = Object.Instantiate(_configProvider._GridView, parent);
            _gridView.Init(20,20);
        }
    }
}