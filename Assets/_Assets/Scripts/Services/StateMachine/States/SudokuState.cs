using _Assets.Scripts.Gameplay.Sudoku;
using _Assets.Scripts.Gameplay.Sudoku.Grid.Controllers;
using _Assets.Scripts.Services.Grid;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace _Assets.Scripts.Services.StateMachine.States
{
    public class SudokuState : IAsyncState
    {
        private readonly SudokuGridController _sudokuGridController;
        private readonly GridViewFactory _gridViewFactory;
        private readonly SudokuPlayerInput _sudokuPlayerInput;

        public SudokuState(SudokuGridController sudokuGridController, GridViewFactory gridViewFactory, SudokuPlayerInput sudokuPlayerInput)
        {
            _sudokuGridController = sudokuGridController;
            _gridViewFactory = gridViewFactory;
            _sudokuPlayerInput = sudokuPlayerInput;
        }
        
        public async UniTask Enter()
        {
            var parent = GameObject.Find("GameUI(Clone)").transform;
            _sudokuPlayerInput.Init(parent.GetComponent<GraphicRaycaster>(), _sudokuGridController);
            var gridView = _gridViewFactory.CreateSudoku(parent);
            _sudokuGridController.Init(gridView);

            await UniTask.DelayFrame(1);
        }

        public async UniTask Exit()
        {
        }
    }
}