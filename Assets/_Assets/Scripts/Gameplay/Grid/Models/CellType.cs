using System;

namespace _Assets.Scripts.Gameplay.Grid.Models
{
    [Serializable]
    public enum CellType : byte
    {
        Empty = 0,
        Flag = 1,
        Mine = 2
    }
}