using System;
using _Assets.Scripts.Gameplay;
using _Assets.Scripts.Gameplay.Grid;
using _Assets.Scripts.Gameplay.Grid.Controllers;
using _Assets.Scripts.Services.Grid;
using _Assets.Scripts.Services.StateMachine.States;
using _Assets.Scripts.Services.UIs.StateMachine;

namespace _Assets.Scripts.Services.StateMachine
{
    public class MainMenuStatesFactory
    {
        private readonly UIStateMachine _uiStateMachine;
        private readonly GridController _gridController;
        private readonly PlayerInput _playerInput;
        private readonly GridViewFactory _gridViewFactory;

        private MainMenuStatesFactory(UIStateMachine uiStateMachine, GridController gridController, PlayerInput playerInput, GridViewFactory gridViewFactory)
        {
            _uiStateMachine = uiStateMachine;
            _gridController = gridController;
            _playerInput = playerInput;
            _gridViewFactory = gridViewFactory;
        }

        public IAsyncState CreateAsyncState(GameStateType gameStateType, GameStateMachine gameStateMachine)
        {
            switch (gameStateType)
            {
                case GameStateType.Init:
                    return new InitState(gameStateMachine, _uiStateMachine);
                case GameStateType.MineSweeper:
                    return new MineSweeperState(gameStateMachine, _gridController, _playerInput, _gridViewFactory);
                case GameStateType.Sudoku:
                    return new SudokuState();
                default:
                    throw new ArgumentOutOfRangeException(nameof(gameStateType), gameStateType, null);
            }
        }
    }
}