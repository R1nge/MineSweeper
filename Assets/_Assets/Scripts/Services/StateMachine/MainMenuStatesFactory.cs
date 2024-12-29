using System;
using _Assets.Scripts.Gameplay.Minesweeper;
using _Assets.Scripts.Gameplay.Minesweeper.Grid.Controllers;
using _Assets.Scripts.Gameplay.Sudoku;
using _Assets.Scripts.Gameplay.Sudoku.Grid.Controllers;
using _Assets.Scripts.Misc;
using _Assets.Scripts.Services.Grid;
using _Assets.Scripts.Services.StateMachine.States;
using _Assets.Scripts.Services.UIs.StateMachine;

namespace _Assets.Scripts.Services.StateMachine
{
    public class MainMenuStatesFactory
    {
        private readonly CanvasScaler _canvasScaler;
        private readonly GridViewFactory _gridViewFactory;
        private readonly MineSweeperGridController _mineSweeperGridController;
        private readonly MineSweeperPlayerInput _mineSweeperPlayerInput;
        private readonly SudokuGridController _sudokuGridController;
        private readonly SudokuPlayerInput _sudokuPlayerInput;
        private readonly UIStateMachine _uiStateMachine;

        private MainMenuStatesFactory(UIStateMachine uiStateMachine,
            MineSweeperGridController mineSweeperGridController, MineSweeperPlayerInput mineSweeperPlayerInput,
            GridViewFactory gridViewFactory, SudokuGridController sudokuGridController,
            SudokuPlayerInput sudokuPlayerInput, CanvasScaler canvasScaler)
        {
            _uiStateMachine = uiStateMachine;
            _mineSweeperGridController = mineSweeperGridController;
            _mineSweeperPlayerInput = mineSweeperPlayerInput;
            _gridViewFactory = gridViewFactory;
            _sudokuGridController = sudokuGridController;
            _sudokuPlayerInput = sudokuPlayerInput;
            _canvasScaler = canvasScaler;
        }

        public IAsyncState CreateAsyncState(GameStateType gameStateType, GameStateMachine gameStateMachine)
        {
            switch (gameStateType)
            {
                case GameStateType.Init:
                    return new InitState(gameStateMachine, _uiStateMachine);
                case GameStateType.MineSweeper:
                    return new MineSweeperState(gameStateMachine, _mineSweeperGridController, _mineSweeperPlayerInput,
                        _gridViewFactory, _canvasScaler);
                case GameStateType.Sudoku:
                    return new SudokuState(_sudokuGridController, _gridViewFactory, _sudokuPlayerInput);
                default:
                    throw new ArgumentOutOfRangeException(nameof(gameStateType), gameStateType, null);
            }
        }
    }
}