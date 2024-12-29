using System;

namespace _Assets.Scripts.Gameplay.Minesweeper.Grid.Models
{
    [Serializable]
    public enum MineSweeperCellType : byte
    {
        Empty = 0,
        Flag = 1,
        Mine = 2
    }
}