using _Assets.Scripts.Gameplay.Grid.Models;
using UnityEngine;

namespace _Assets.Scripts.Gameplay.Grid.Views
{
    public interface ICellView
    {
        public int X { get; }
        public int Y { get; }
        public void Reveal(CellType cellType, int neighboursCount);
        public void Flag();
        public void UnFlag();
        public void Init(int x, int y, CellType cellType, bool isRevealed, int neighboursCount);
        public GameObject GameObject { get; }
    }
}