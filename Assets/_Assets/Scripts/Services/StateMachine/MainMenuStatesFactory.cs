using System;
using _Assets.Scripts.Gameplay;
using _Assets.Scripts.Gameplay.Minesweeper;
using _Assets.Scripts.Gameplay.Minesweeper.Grid.Controllers;
using _Assets.Scripts.Services.Grid;
using _Assets.Scripts.Services.StateMachine.States;
using _Assets.Scripts.Services.UIs.StateMachine;

namespace _Assets.Scripts.Services.StateMachine
{
    public class MainMenuStatesFactory
    {
        private readonly UIStateMachine _uiStateMachine;
        private readonly MineSweeperGridController _mineSweeperGridController;
        private readonly MineSweeperPlayerInput _mineSweeperPlayerInput;
        private readonly GridViewFactory _gridViewFactory;

        private MainMenuStatesFactory(UIStateMachine uiStateMachine, MineSweeperGridController mineSweeperGridController, MineSweeperPlayerInput mineSweeperPlayerInput, GridViewFactory gridViewFactory)
        {
            _uiStateMachine = uiStateMachine;
            _mineSweeperGridController = mineSweeperGridController;
            _mineSweeperPlayerInput = mineSweeperPlayerInput;
            _gridViewFactory = gridViewFactory;
        }

        public IAsyncState CreateAsyncState(GameStateType gameStateType, GameStateMachine gameStateMachine)
        {
            switch (gameStateType)
            {
                case GameStateType.Init:
                    return new InitState(gameStateMachine, _uiStateMachine);
                case GameStateType.MineSweeper:
                    return new MineSweeperState(gameStateMachine, _mineSweeperGridController, _mineSweeperPlayerInput, _gridViewFactory);
                case GameStateType.Sudoku:
                    return new SudokuState();
                default:
                    throw new ArgumentOutOfRangeException(nameof(gameStateType), gameStateType, null);
            }
        }
    }
}