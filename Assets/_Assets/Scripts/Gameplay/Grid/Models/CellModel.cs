using System;

namespace _Assets.Scripts.Gameplay.Grid.Models
{
    [Serializable]
    public class CellModel
    {
        public int X;
        public int Y;
        public CellType Type;
        public int NeighboursCount;
        public bool Revealed;

        public void SetPosition(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void SetType(CellType cellType) => Type = cellType;

        public void SetNeighboursNumber(int count) => NeighboursCount = count;

        public void Reveal() => Revealed = true;
    }
}