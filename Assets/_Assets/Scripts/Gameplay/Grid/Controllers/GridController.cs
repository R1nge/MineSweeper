using System.Collections.Generic;
using _Assets.Scripts.Gameplay.Grid.Models;
using _Assets.Scripts.Gameplay.Grid.Views;
using _Assets.Scripts.Services.Grid;
using _Assets.Scripts.Services.StateMachine;
using UnityEngine;

namespace _Assets.Scripts.Gameplay.Grid.Controllers
{
    public class GridController
    {
        private readonly GridGenerator _gridGenerator;
        private readonly GameStateMachine _gameStateMachine;
        private GridModel _gridModel;
        private GridView _gridView;
        private bool _isFirstReveal;
        private bool _isGameOver;

        private readonly Dictionary<CellModel, CellType> _flaggedCells = new();

        public GridController(GridGenerator gridGenerator, GameStateMachine gameStateMachine)
        {
            _gridGenerator = gridGenerator;
            _gameStateMachine = gameStateMachine;
        }

        public void Init(GridView gridView)
        {
            var width = 8;
            var height = 6;

            _gridModel = _gridGenerator.GenerateEmpty(width, height);
            _gridView = gridView;
            _gridView.Init(_gridModel);
        }

        public void Dispose()
        {
            _gridModel = null;
            Object.Destroy(_gridView);
            _isFirstReveal = false;
            _isGameOver = false;
            _flaggedCells.Clear();
        }

        public bool TryFillWithMines(ICellView cellView)
        {
            if (_isFirstReveal)
            {
                return false;
            }

            _gridModel = _gridGenerator.FillWithMines(_gridModel.Width, _gridModel.Height, cellView.X, cellView.Y);
            _isFirstReveal = true;
            Reveal(cellView);
            _gridView.Init(_gridModel);
            return true;
        }

        public void Flag(ICellView cellView)
        {
            var model = _gridModel.Cells[cellView.X, cellView.Y];

            if (model.Revealed)
            {
                return;
            }

            if (model.Type == CellType.Flag)
            {
                if (_flaggedCells.TryGetValue(model, out var type))
                {
                    model.SetType(type);
                    cellView.UnFlag();
                    _flaggedCells.Remove(model);
                }
            }
            else
            {
                if (_flaggedCells.TryAdd(model, model.Type))
                {
                    _gridModel.Cells[cellView.X, cellView.Y].SetType(CellType.Flag);
                    cellView.Flag();
                }
            }
        }

        public void Reveal(ICellView cellView)
        {
            if (_gridModel.Cells[cellView.X, cellView.Y].Revealed ||
                _gridModel.Cells[cellView.X, cellView.Y].Type == CellType.Flag)
            {
                CheckWin();
                return;
            }

            var x = cellView.X;
            var y = cellView.Y;
            _gridModel.Cells[x, y].Reveal();
            cellView.Reveal(_gridModel.Cells[x, y].Type, _gridModel.Cells[x, y].NeighboursCount);

            if (_gridModel.Cells[x, y].Type == CellType.Mine)
            {
                if (!_isGameOver)
                {
                    _isGameOver = true;
                    Debug.LogError("game over");
                    _gameStateMachine.SwitchState(GameStateType.Game);
                    return;
                }
            }

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


            CheckWin();
        }

        private void CheckWin()
        {
            if (GridHelper.CheckWin(_gridModel.Cells))
            {
                if (!_isGameOver)
                {
                    _isGameOver = true;
                    Debug.LogError("win");
                    _gameStateMachine.SwitchState(GameStateType.Game);
                }
            }
        }
    }
}