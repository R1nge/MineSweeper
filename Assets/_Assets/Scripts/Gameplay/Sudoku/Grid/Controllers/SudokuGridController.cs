using _Assets.Scripts.Gameplay.Sudoku.Grid.Models;
using _Assets.Scripts.Gameplay.Sudoku.Grid.Views;
using UnityEngine;

namespace _Assets.Scripts.Gameplay.Sudoku.Grid.Controllers
{
    public class SudokuGridController
    {
        private readonly Sudoku _sudoku;
        private SudokuGridModel _gridModel;
        private SudokuGridView _gridView;

        public SudokuGridController(Sudoku sudoku)
        {
            _sudoku = sudoku;
        }

        public void Init(SudokuGridView sudokuGridView)
        {
            const int width = 9;
            const int height = 9;

            _gridModel = new SudokuGridModel(width, height);
            _gridView = sudokuGridView;

            var board = _sudoku.Generate(width, height);

            for (int y = 0; y < board.GetLength(1); y++)
            {
                for (int x = 0; x < board.GetLength(0); x++)
                {
                    _gridModel.SetNumber(x, y, board[x, y]);
                }
            }


            _gridView.Init(_gridModel);
        }

        public void IncreaseNumber(ISudokuCellView sudokuView)
        {
            var x = sudokuView.X;
            var y = sudokuView.Y;
            _gridModel.IncreaseNumber(x, y);
            sudokuView.SetNumber(_gridModel.Cells[x, y].Number);

            CheckWin();
        }

        public void DecreaseNumber(ISudokuCellView sudokuCellView)
        {
            var x = sudokuCellView.X;
            var y = sudokuCellView.Y;
            _gridModel.DecreaseNumber(x, y);
            sudokuCellView.SetNumber(_gridModel.Cells[x, y].Number);

            CheckWin();
        }

        private void CheckWin()
        {
            //This won't work, checks only for uniqueness
            if (_sudoku.CheckWin(_gridModel.ToIntArray()))
            {
                Debug.LogError("Sudoku WIN");
            }

            else
            {
                Debug.LogError("Sudoku NOT WIN");
            }
        }
    }
}