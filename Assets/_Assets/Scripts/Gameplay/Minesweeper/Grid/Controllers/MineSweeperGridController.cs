using System;
using System.Collections.Generic;
using _Assets.Scripts.Gameplay.Minesweeper.Grid.Models;
using _Assets.Scripts.Gameplay.Minesweeper.Grid.Views;
using _Assets.Scripts.Services.StateMachine;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Object = UnityEngine.Object;

namespace _Assets.Scripts.Gameplay.Minesweeper.Grid.Controllers
{
    public class MineSweeperGridController
    {
        private readonly Dictionary<MineSweeperCellModel, MineSweeperCellType> _flaggedCells = new();
        private readonly GameStateMachine _gameStateMachine;
        private readonly MineSweeperGridGenerator _mineSweeperGridGenerator;
        private readonly MineSweeperPlayerInput _mineSweeperPlayerInput;
        private float _delayBeforeRestart = 2;
        private bool _isFirstReveal;
        private bool _isGameOver;
        private MineSweeperGridModel _mineSweeperGridModel;
        private MineSweeperGridView _mineSweeperGridView;

        public MineSweeperGridController(MineSweeperGridGenerator mineSweeperGridGenerator,
            GameStateMachine gameStateMachine, MineSweeperPlayerInput mineSweeperPlayerInput)
        {
            _mineSweeperGridGenerator = mineSweeperGridGenerator;
            _gameStateMachine = gameStateMachine;
            _mineSweeperPlayerInput = mineSweeperPlayerInput;
        }

        public void Init(MineSweeperGridView mineSweeperGridView)
        {
            const int width = 9;
            const int height = 9;

            _mineSweeperGridModel = _mineSweeperGridGenerator.GenerateEmpty(width, height);
            _mineSweeperGridView = mineSweeperGridView;
            _mineSweeperGridView.Init(_mineSweeperGridModel);
        }

        public void Dispose()
        {
            _mineSweeperGridModel = null;
            Object.Destroy(_mineSweeperGridView.gameObject);
            _isFirstReveal = false;
            _isGameOver = false;
            _flaggedCells.Clear();
        }

        public bool TryFillWithMines(IMineSweeperCellView mineSweeperCellView)
        {
            if (_isFirstReveal)
            {
                return false;
            }

            _mineSweeperGridModel = _mineSweeperGridGenerator.FillWithMines(_mineSweeperGridModel.Width,
                _mineSweeperGridModel.Height, mineSweeperCellView.X, mineSweeperCellView.Y);
            _isFirstReveal = true;
            Reveal(mineSweeperCellView);
            _mineSweeperGridView.Init(_mineSweeperGridModel);
            return true;
        }

        public void Flag(IMineSweeperCellView mineSweeperCellView)
        {
            var model = _mineSweeperGridModel.Cells[mineSweeperCellView.X, mineSweeperCellView.Y];

            if (model.Revealed)
            {
                return;
            }

            if (model.Type == MineSweeperCellType.Flag)
            {
                if (_flaggedCells.TryGetValue(model, out var type))
                {
                    model.SetType(type);
                    mineSweeperCellView.UnFlag();
                    _flaggedCells.Remove(model);
                }
            }
            else
            {
                if (_flaggedCells.TryAdd(model, model.Type))
                {
                    _mineSweeperGridModel.Cells[mineSweeperCellView.X, mineSweeperCellView.Y]
                        .SetType(MineSweeperCellType.Flag);
                    mineSweeperCellView.Flag();
                }
            }
        }

        public async void Reveal(IMineSweeperCellView mineSweeperCellView)
        {
            if (_mineSweeperGridModel.Cells[mineSweeperCellView.X, mineSweeperCellView.Y].Revealed ||
                _mineSweeperGridModel.Cells[mineSweeperCellView.X, mineSweeperCellView.Y].Type ==
                MineSweeperCellType.Flag)
            {
                await CheckWin();
                return;
            }

            var x = mineSweeperCellView.X;
            var y = mineSweeperCellView.Y;
            _mineSweeperGridModel.Cells[x, y].Reveal();
            mineSweeperCellView.Reveal(_mineSweeperGridModel.Cells[x, y].Type,
                _mineSweeperGridModel.Cells[x, y].NeighboursCount);

            if (_mineSweeperGridModel.Cells[x, y].Type == MineSweeperCellType.Mine)
            {
                if (!_isGameOver)
                {
                    _isGameOver = true;
                    Debug.LogError("game over");
                    _mineSweeperPlayerInput.Disable();
                    await UniTask.Delay(TimeSpan.FromSeconds(_delayBeforeRestart));
                    await _gameStateMachine.SwitchState(GameStateType.MineSweeper);
                    return;
                }
            }

            var neighbors = MineSweeperGridHelper.GetNeighbors(_mineSweeperGridModel.Cells, x, y);
            foreach (var neighbor in neighbors)
            {
                if (neighbor.Type == MineSweeperCellType.Empty)
                {
                    if (!neighbor.Revealed)
                    {
                        Reveal(_mineSweeperGridView.GetCellView(neighbor.X, neighbor.Y));
                    }
                }
                else
                {
                    break;
                }
            }


            await CheckWin();
        }

        private async UniTask CheckWin()
        {
            if (MineSweeperGridHelper.CheckWin(_mineSweeperGridModel.Cells))
            {
                if (!_isGameOver)
                {
                    _isGameOver = true;
                    _mineSweeperPlayerInput.Disable();
                    await UniTask.Delay(TimeSpan.FromSeconds(_delayBeforeRestart));
                    //await _gameStateMachine.SwitchState(GameStateType.Sudoku);
                }
            }
        }
    }
}