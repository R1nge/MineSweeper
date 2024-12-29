using _Assets.Scripts.Gameplay;
using _Assets.Scripts.Gameplay.Minesweeper;
using _Assets.Scripts.Gameplay.Minesweeper.Grid.Controllers;
using _Assets.Scripts.Services.Grid;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace _Assets.Scripts.Services.StateMachine.States
{
    public class MineSweeperState : IAsyncState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly MineSweeperGridController _mineSweeperGridController;
        private readonly MineSweeperPlayerInput _mineSweeperPlayerInput;
        private readonly GridViewFactory _gridViewFactory;

        public MineSweeperState(GameStateMachine stateMachine, MineSweeperGridController mineSweeperGridController, MineSweeperPlayerInput mineSweeperPlayerInput, GridViewFactory gridViewFactory)
        {
            _stateMachine = stateMachine;
            _mineSweeperGridController = mineSweeperGridController;
            _mineSweeperPlayerInput = mineSweeperPlayerInput;
            _gridViewFactory = gridViewFactory;
        }

        public async UniTask Enter()
        {
            var parent = GameObject.Find("GameUI(Clone)").transform;
            _mineSweeperPlayerInput.Init(parent.GetComponent<GraphicRaycaster>(), _mineSweeperGridController);
            var gridView = _gridViewFactory.CreateMineSweeper(parent);
            _mineSweeperGridController.Init(gridView);

            await UniTask.DelayFrame(1);
            _mineSweeperPlayerInput.Enable();
        }

        public async UniTask Exit()
        {
            _mineSweeperGridController.Dispose();
        }
    }
}