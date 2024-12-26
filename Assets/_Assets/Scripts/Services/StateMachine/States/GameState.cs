using _Assets.Scripts.Gameplay;
using _Assets.Scripts.Gameplay.Grid;
using _Assets.Scripts.Gameplay.Grid.Controllers;
using Cysharp.Threading.Tasks;

namespace _Assets.Scripts.Services.StateMachine.States
{
    public class GameState : IAsyncState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly GridController _gridController;
        private readonly PlayerInput _playerInput;

        public GameState(GameStateMachine stateMachine, GridController gridController, PlayerInput playerInput)
        {
            _stateMachine = stateMachine;
            _gridController = gridController;
            _playerInput = playerInput;
        }

        public async UniTask Enter()
        {
            _gridController.Init();
            _playerInput.Enable();
        }

        public async UniTask Exit()
        {
            _playerInput.Disable();
            _gridController.Dispose();
        }
    }
}