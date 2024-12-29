using _Assets.Scripts.Gameplay.Minesweeper;
using _Assets.Scripts.Gameplay.Minesweeper.Grid.Controllers;
using _Assets.Scripts.Services.Grid;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using CanvasScaler = _Assets.Scripts.Misc.CanvasScaler;

namespace _Assets.Scripts.Services.StateMachine.States
{
    public class MineSweeperState : IAsyncState
    {
        private readonly CanvasScaler _canvasScaler;
        private readonly GridViewFactory _gridViewFactory;
        private readonly MineSweeperGridController _mineSweeperGridController;
        private readonly MineSweeperPlayerInput _mineSweeperPlayerInput;
        private readonly GameStateMachine _stateMachine;

        public MineSweeperState(GameStateMachine stateMachine, MineSweeperGridController mineSweeperGridController,
            MineSweeperPlayerInput mineSweeperPlayerInput, GridViewFactory gridViewFactory, CanvasScaler canvasScaler)
        {
            _stateMachine = stateMachine;
            _mineSweeperGridController = mineSweeperGridController;
            _mineSweeperPlayerInput = mineSweeperPlayerInput;
            _gridViewFactory = gridViewFactory;
            _canvasScaler = canvasScaler;
        }

        public async UniTask Enter()
        {
            var parent = GameObject.Find("GameUI(Clone)").transform;
            _mineSweeperPlayerInput.Init(parent.GetComponent<GraphicRaycaster>(), _mineSweeperGridController);
            var gridView = _gridViewFactory.CreateMineSweeper(parent);
            _canvasScaler.Init((RectTransform)gridView.transform);
            _mineSweeperGridController.Init(gridView);

            await UniTask.DelayFrame(1);
            _mineSweeperPlayerInput.Enable();
            _canvasScaler.Enable();
        }

        public async UniTask Exit()
        {
            _canvasScaler.Disable();
            _mineSweeperGridController.Dispose();
        }
    }
}