namespace _Assets.Scripts.Gameplay.Sudoku.Grid.Models
{
    public class SudokuGridModel
    {
        public SudokuCellModel[,] Cells;

        public SudokuGridModel(int width, int height)
        {
            Cells = new SudokuCellModel[width, height];
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Cells[x, y] = new SudokuCellModel();
                    Cells[x, y].SetPosition(x, y);
                }
            }
        }

        public int Width => Cells.GetLength(0);
        public int Height => Cells.GetLength(1);

        public void SetNumber(int x, int y, int number)
        {
            Cells[x, y].SetNumber(number);
        }

        public void IncreaseNumber(int x, int y)
        {
            var nextNumber = (Cells[x, y].Number + 1) % 10;

            if (nextNumber == 0)
            {
                nextNumber = 1;
            }

            Cells[x, y].SetNumber(nextNumber);
        }

        public void DecreaseNumber(int x, int y)
        {
            var prevNumber = (Cells[x, y].Number - 1 + 10) % 10;

            if (prevNumber == 0)
            {
                prevNumber = 9;
            }

            Cells[x, y].SetNumber(prevNumber);
        }
    }
}