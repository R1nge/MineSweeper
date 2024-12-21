using System;

namespace _Assets.Scripts.Gameplay
{
    [Serializable]
    public enum CellType : byte
    {
        Empty = 0,
        Flag = 1,
        Mine = 2
    }
}