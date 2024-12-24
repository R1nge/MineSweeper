using System;
using Random = UnityEngine.Random;

namespace _Assets.Scripts.Gameplay
{
    public class GridGenerator
    {
        private CellType[,] _cells;
        public CellType[,] Cells => _cells;
        public CellType[,] Generate(int width, int height)
        {
            _cells = new CellType[width, height];
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    _cells[x, y] = CellType.Empty;
                }
            }

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (Random.Range(0, 50) == 0)
                    {
                        _cells[x, y] = CellType.Mine;
                    }
                }
            }

            return _cells;
        }

        private CellType GetRandomCellType()
        {
            return (CellType)Random.Range(0, Enum.GetNames(typeof(CellType)).Length);
        }
    }
}