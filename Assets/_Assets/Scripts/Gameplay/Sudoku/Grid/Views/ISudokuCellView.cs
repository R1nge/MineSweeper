using UnityEngine;

namespace _Assets.Scripts.Gameplay.Sudoku.Grid.Views
{
    public interface ISudokuCellView
    {
        public int X { get; }
        public int Y { get; }
        public int Number { get; }
        public void Init(int x, int y, int number);
        public GameObject GameObject { get; }
    }
}