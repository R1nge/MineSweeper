﻿namespace _Assets.Scripts.Gameplay.Grid
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
    }
}