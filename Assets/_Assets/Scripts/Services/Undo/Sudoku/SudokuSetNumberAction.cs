using _Assets.Scripts.Gameplay.Sudoku.Grid.Models;
using _Assets.Scripts.Gameplay.Sudoku.Grid.Views;

namespace _Assets.Scripts.Services.Undo.Sudoku
{
    public class SudokuSetNumberAction : IUndoableAction
    {
        private readonly ISudokuCellView _cellView;
        private readonly SudokuGridModel _model;
        private readonly int _number;
        private readonly int _x, _y;
        private int _previousValue;

        public SudokuSetNumberAction(SudokuGridModel model, int x, int y, ISudokuCellView cellView, int number)
        {
            _model = model;
            _x = x;
            _y = y;
            _cellView = cellView;
            _number = number;
        }

        public void Execute()
        {
            _previousValue = _model.GetCell(_x, _y).Number;
            _model.SetNumber(_x, _y, _number);
            _cellView.SetNumber(_number);
        }

        public void Undo()
        {
            _model.SetNumber(_x, _y, _previousValue);
            _cellView.SetNumber(_previousValue);
        }
    }
}