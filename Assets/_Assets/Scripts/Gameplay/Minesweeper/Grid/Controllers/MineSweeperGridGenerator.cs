using _Assets.Scripts.Gameplay.Minesweeper.Grid.Models;
using UnityEngine;

namespace _Assets.Scripts.Gameplay.Minesweeper.Grid.Controllers
{
    public class MineSweeperGridGenerator
    {
        private MineSweeperGridModel _mineSweeperGrid;

        public MineSweeperGridModel Generate(int width, int height)
        {
            _mineSweeperGrid = new MineSweeperGridModel(width, height);
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    _mineSweeperGrid.Cells[x, y].SetType(MineSweeperCellType.Empty);
                }
            }

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (Random.Range(0, 5) == 0)
                    {
                        _mineSweeperGrid.Cells[x, y].SetType(MineSweeperCellType.Mine);
                    }
                }
            }

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    var neighboursCount =
                        MineSweeperGridHelper.CountNeighbors(_mineSweeperGrid.Cells, x, y, MineSweeperCellType.Mine);
                    _mineSweeperGrid.Cells[x, y].SetNeighboursNumber(neighboursCount);
                }
            }

            return _mineSweeperGrid;
        }

        public MineSweeperGridModel GenerateEmpty(int width, int height)
        {
            _mineSweeperGrid = new MineSweeperGridModel(width, height);
            return _mineSweeperGrid;
        }

        public MineSweeperGridModel FillWithMines(int width, int height, int clickedX, int clickedY)
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    _mineSweeperGrid.Cells[x, y].SetType(MineSweeperCellType.Empty);
                }
            }

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (Random.Range(0, 25) == 0)
                    {
                        _mineSweeperGrid.Cells[x, y].SetType(MineSweeperCellType.Mine);
                    }
                }
            }

            _mineSweeperGrid.Cells[clickedX, clickedY].SetType(MineSweeperCellType.Empty);

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    var neighboursCount =
                        MineSweeperGridHelper.CountNeighbors(_mineSweeperGrid.Cells, x, y, MineSweeperCellType.Mine);
                    _mineSweeperGrid.Cells[x, y].SetNeighboursNumber(neighboursCount);
                }
            }

            return _mineSweeperGrid;
        }
    }
}