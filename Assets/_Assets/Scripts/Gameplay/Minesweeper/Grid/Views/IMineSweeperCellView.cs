using _Assets.Scripts.Gameplay.Minesweeper.Grid.Models;
using UnityEngine;

namespace _Assets.Scripts.Gameplay.Minesweeper.Grid.Views
{
    public interface IMineSweeperCellView
    {
        public int X { get; }
        public int Y { get; }
        public void Reveal(MineSweeperCellType mineSweeperCellType, int neighboursCount);
        public void Flag();
        public void UnFlag();
        public void Init(int x, int y, MineSweeperCellType mineSweeperCellType, bool isRevealed, int neighboursCount);
        public GameObject GameObject { get; }
    }
}