namespace _Assets.Scripts.Gameplay
{
    public class Grid
    {
        private int _width, _height;
        private Cell[,] _cells;

        public Grid(int width, int height)
        {
            _width = width;
            _height = height;
            _cells = new Cell[width, height];
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    _cells[x, y] = new Cell();
                    _cells[x, y].SetPosition(x, y);
                }
            }
        }
    }
}