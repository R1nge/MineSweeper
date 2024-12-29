namespace _Assets.Scripts.Gameplay.Minesweeper.Grid.Models
{
    public class MineSweeperGridModel
    {
        public MineSweeperCellModel[,] Cells;
        public int Width => Cells.GetLength(0);
        public int Height => Cells.GetLength(1);

        public MineSweeperGridModel(int width, int height)
        {
            Cells = new MineSweeperCellModel[width, height];
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Cells[x, y] = new MineSweeperCellModel();
                    Cells[x, y].SetPosition(x, y);
                }
            }
        }
    }
}