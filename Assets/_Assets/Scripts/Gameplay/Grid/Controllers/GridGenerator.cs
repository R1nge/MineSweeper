using _Assets.Scripts.Gameplay.Grid.Models;
using Random = UnityEngine.Random;

namespace _Assets.Scripts.Gameplay.Grid.Controllers
{
    public class GridGenerator
    {
        private GridModel _grid;

        public GridModel Generate(int width, int height)
        {
            _grid = new GridModel(width, height);
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    _grid.Cells[x, y].SetType(CellType.Empty);
                }
            }

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (Random.Range(0, 50) == 0)
                    {
                        _grid.Cells[x, y].SetType(CellType.Mine);
                    }
                }
            }


            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    var neighboursCount = GridHelper.CountNeighbors(_grid.Cells, x, y, CellType.Mine);
                    _grid.Cells[x, y].SetNeighboursNumber(neighboursCount);
                }
            }

            return _grid;
        }
    }
}