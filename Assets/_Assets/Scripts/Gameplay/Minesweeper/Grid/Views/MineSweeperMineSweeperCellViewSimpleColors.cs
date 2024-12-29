using _Assets.Scripts.Gameplay.Minesweeper.Grid.Models;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Assets.Scripts.Gameplay.Minesweeper.Grid.Views
{
    public class MineSweeperMineSweeperCellViewSimpleColors : MonoBehaviour, IMineSweeperCellView
    {
        [SerializeField] private Image image;
        [SerializeField] private Color empty, mine, flag;
        [SerializeField] private TextMeshProUGUI neighboursCount;
        public int X { get; private set; }
        public int Y { get; private set; }

        public void Init(int x, int y, MineSweeperCellType mineSweeperCellType, bool isRevealed, int neighboursCount)
        {
            X = x;
            Y = y;

            if (isRevealed)
            {
                switch (mineSweeperCellType)
                {
                    case MineSweeperCellType.Empty:
                        image.color = empty;
                        break;
                    case MineSweeperCellType.Mine:
                        image.color = mine;
                        break;
                    case MineSweeperCellType.Flag:
                        image.color = flag;
                        break;
                }
            }
            else
            {
                image.color = empty;
            }
        }

        public GameObject GameObject => gameObject;

        public void Reveal(MineSweeperCellType mineSweeperCellType, int neighboursCount)
        {
            switch (mineSweeperCellType)
            {
                case MineSweeperCellType.Empty:
                    image.color = empty;
                    break;
                case MineSweeperCellType.Mine:
                    image.color = mine;
                    break;
                case MineSweeperCellType.Flag:
                    image.color = flag;
                    break;
            }

            this.neighboursCount.text = neighboursCount.ToString();
        }

        public void Flag() => image.color = flag;

        public void UnFlag() => image.color = empty;
    }
}