using System;
using _Assets.Scripts.Gameplay;
using _Assets.Scripts.Gameplay.Grid;
using _Assets.Scripts.Gameplay.Grid.Controllers;
using _Assets.Scripts.Services.StateMachine.States;
using _Assets.Scripts.Services.UIs.StateMachine;

namespace _Assets.Scripts.Services.StateMachine
{
    public class MainMenuStatesFactory
    {
        private readonly UIStateMachine _uiStateMachine;
        private readonly GridController _gridController;
        private readonly PlayerInput _playerInput;

        private MainMenuStatesFactory(UIStateMachine uiStateMachine, GridController gridController, PlayerInput playerInput)
        {
            _uiStateMachine = uiStateMachine;
            _gridController = gridController;
            _playerInput = playerInput;
        }

        public IAsyncState CreateAsyncState(GameStateType gameStateType, GameStateMachine gameStateMachine)
        {
            switch (gameStateType)
            {
                case GameStateType.Init:
                    return new InitState(gameStateMachine, _uiStateMachine);
                case GameStateType.Game:
                    return new GameState(gameStateMachine, _gridController, _playerInput);
                default:
                    throw new ArgumentOutOfRangeException(nameof(gameStateType), gameStateType, null);
            }
        }
    }
}