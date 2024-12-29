using _Assets.Scripts.Gameplay.Sudoku.Grid.Models;
using _Assets.Scripts.Gameplay.Sudoku.Grid.Views;
using _Assets.Scripts.Services.Undo.Sudoku;
using UnityEngine;

namespace _Assets.Scripts.Gameplay.Sudoku.Grid.Controllers
{
    public class SudokuGridController
    {
        private readonly Sudoku _sudoku;
        private SudokuGridModel _gridModel;
        private SudokuGridView _gridView;
        private SudokuUndoHistory _sudokuUndoHistory;

        public SudokuGridController(Sudoku sudoku)
        {
            _sudoku = sudoku;
        }

        public void Init(SudokuGridView sudokuGridView)
        {
            _sudokuUndoHistory = new SudokuUndoHistory();

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
            if (_gridModel.Cells[x, y].IsChangeable)
            {
                _sudokuUndoHistory.Do(new SudokuIncreaseNumberAction(_gridModel, x, y, sudokuView));
                CheckWin();
            }
        }

        public void Undo()
        {
            _sudokuUndoHistory.Undo();
        }

        public void DecreaseNumber(ISudokuCellView sudokuView)
        {
            var x = sudokuView.X;
            var y = sudokuView.Y;
            if (_gridModel.Cells[x, y].IsChangeable)
            {
                _sudokuUndoHistory.Do(new SudokuDecreaseNumberAction(_gridModel, x, y, sudokuView));
                CheckWin();
            }
        }

        private void CheckWin()
        {
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