namespace _Assets.Scripts.Gameplay
{
    public class GridModel
    {
        public CellModel[,] Cells;
        public int Width => Cells.GetLength(0);
        public int Height => Cells.GetLength(1);

        public GridModel(int width, int height)
        {
            Cells = new CellModel[width, height];
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Cells[x, y] = new CellModel();
                    Cells[x, y].SetPosition(x, y);
                }
            }
        }
    }
}