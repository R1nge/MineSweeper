using System;

namespace _Assets.Scripts.Gameplay
{
    [Serializable]
    public class Cell
    {
        public int X;
        public int Y;
        public CellType Type;

        public void SetPosition(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void SetType(CellType cellType)
        {
            Type = cellType;
        }
    }
}