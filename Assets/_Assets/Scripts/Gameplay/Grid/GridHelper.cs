using System.Collections.Generic;
using _Assets.Scripts.Gameplay.Grid.Models;

namespace _Assets.Scripts.Gameplay.Grid
{
    public static class GridHelper
    {
        public static int CountNeighbors(CellModel[,] _cells, int x, int y, CellType targetType)
        {
            int count = 0;
            int width = _cells.GetLength(0);
            int height = _cells.GetLength(1);

            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    if (i == 0 && j == 0)
                        continue;

                    int neighborX = x + i;
                    int neighborY = y + j;

                    if (neighborX >= 0 && neighborX < width && neighborY >= 0 && neighborY < height)
                    {
                        if (_cells[neighborX, neighborY].Type == targetType)
                        {
                            count++;
                        }
                    }
                }
            }

            return count;
        }

        public static List<CellModel> GetNeighbors(CellModel[,] _cells, int x, int y)
        {
            List<CellModel> neighbors = new List<CellModel>();
            int width = _cells.GetLength(0);
            int height = _cells.GetLength(1);

            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    if (i == 0 && j == 0)
                        continue;

                    int neighborX = x + i;
                    int neighborY = y + j;

                    if (neighborX >= 0 && neighborX < width && neighborY >= 0 && neighborY < height)
                    {
                        neighbors.Add(_cells[neighborX, neighborY]);
                    }
                }
            }

            return neighbors; 
        }

        public static bool CheckWin(CellModel[,] _cells)
        {
            for (int y = 0; y < _cells.GetLength(1); y++)
            {
                for (int x = 0; x < _cells.GetLength(0); x++)
                {
                    if (_cells[x, y].Type == CellType.Mine || _cells[x,y].Type == CellType.Flag)
                    {
                        if (_cells[x, y].Revealed)
                        {
                            return false;
                        }
                    }
                    else
                    {
                        if (!_cells[x, y].Revealed)
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }
    }
}