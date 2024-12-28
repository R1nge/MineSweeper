using _Assets.Scripts.Gameplay;
using _Assets.Scripts.Gameplay.Grid;
using _Assets.Scripts.Gameplay.Grid.Controllers;
using _Assets.Scripts.Services.Grid;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace _Assets.Scripts.Services.StateMachine.States
{
    public class GameState : IAsyncState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly GridController _gridController;
        private readonly PlayerInput _playerInput;
        private readonly GridViewFactory _gridViewFactory;

        public GameState(GameStateMachine stateMachine, GridController gridController, PlayerInput playerInput, GridViewFactory gridViewFactory)
        {
            _stateMachine = stateMachine;
            _gridController = gridController;
            _playerInput = playerInput;
            _gridViewFactory = gridViewFactory;
        }

        public async UniTask Enter()
        {
            var parent = GameObject.Find("GameUI(Clone)").transform;
            _playerInput.Init(parent.GetComponent<GraphicRaycaster>(), _gridController);
            var gridView = _gridViewFactory.Create(parent);
            _gridController.Init(gridView);

            await UniTask.DelayFrame(1);
            _playerInput.Enable();
        }

        public async UniTask Exit()
        {
            _playerInput.Disable();
            _gridController.Dispose();
        }
    }
}