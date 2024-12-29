using System;

namespace _Assets.Scripts.Gameplay.Minesweeper.Grid.Models
{
    [Serializable]
    public class MineSweeperCellModel
    {
        public int X;
        public int Y;
        public MineSweeperCellType Type;
        public int NeighboursCount;
        public bool Revealed;

        public void SetPosition(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void SetType(MineSweeperCellType mineSweeperCellType) => Type = mineSweeperCellType;

        public void SetNeighboursNumber(int count) => NeighboursCount = count;

        public void Reveal() => Revealed = true;
    }
}