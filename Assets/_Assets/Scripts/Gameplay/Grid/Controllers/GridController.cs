using System.Collections.Generic;
using _Assets.Scripts.Configs;
using _Assets.Scripts.Gameplay.Grid.Models;
using _Assets.Scripts.Gameplay.Grid.Views;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace _Assets.Scripts.Gameplay.Grid.Controllers
{
    public class GridController
    {
        private readonly ConfigProvider _configProvider;
        private readonly GridGenerator _gridGenerator;
        private readonly IObjectResolver _objectResolver;
        private GridModel _gridModel;
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
            _gridModel = _gridGenerator.Generate(width, height);
            var parent = GameObject.Find("GameUI(Clone)").transform;
            _gridView = _objectResolver.Instantiate(_configProvider._GridView, parent);
            _gridView.Init(_gridModel);
        }

        public void Flag(CellView cellView)
        {
            if (_gridModel.Cells[cellView.X, cellView.Y].Revealed)
            {
                return;
            }
            
            if (_gridModel.Cells[cellView.X, cellView.Y].Type == CellType.Flag)
            {
                _gridModel.Cells[cellView.X, cellView.Y].SetType(CellType.Empty);
                cellView.UnFlag();
            }
            else
            {
                _gridModel.Cells[cellView.X, cellView.Y].SetType(CellType.Flag);
                cellView.Flag();
            }
        }

        public void Reveal(CellView cellView)
        {
            if (_gridModel.Cells[cellView.X, cellView.Y].Revealed || _gridModel.Cells[cellView.X, cellView.Y].Type == CellType.Flag)
            {
                return;
            }

            Debug.Log("reveal");
            var x = cellView.X;
            var y = cellView.Y;
            _gridModel.Cells[x, y].Reveal();
            cellView.Reveal(_gridModel.Cells[x, y].Type, _gridModel.Cells[x, y].NeighboursCount);

            var neighbors = GridHelper.GetNeighbors(_gridModel.Cells, x, y);


            foreach (var neighbor in neighbors)
            {
                if (neighbor.Type == CellType.Empty)
                {
                    if (!neighbor.Revealed)
                    {
                        Reveal(_gridView.GetCellView(neighbor.X, neighbor.Y));
                    }
                }
                else
                {
                    break;
                }
            }
        }
    }
}