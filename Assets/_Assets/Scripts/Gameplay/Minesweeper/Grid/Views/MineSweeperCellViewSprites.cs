using System;
using _Assets.Scripts.Gameplay.Minesweeper.Grid.Models;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Assets.Scripts.Gameplay.Minesweeper.Grid.Views
{
    public class MineSweeperCellViewSprites : MonoBehaviour, IMineSweeperCellView
    {
        [SerializeField] private Image image;
        [SerializeField] private Sprite unrevealed;
        [SerializeField] private Sprite empty, mine, flag;
        [SerializeField] private TextMeshProUGUI neighboursCount;

        public int X { get; private set; }
        public int Y { get; private set; }

        public void Reveal(MineSweeperCellType mineSweeperCellType, int neighboursCount)
        {
            switch (mineSweeperCellType)
            {
                case MineSweeperCellType.Empty:
                    image.sprite = empty;
                    break;
                case MineSweeperCellType.Flag:
                    image.sprite = flag;
                    break;
                case MineSweeperCellType.Mine:
                    image.sprite = mine;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(mineSweeperCellType), mineSweeperCellType, null);
            }

            UpdateNeighboursCount(neighboursCount);
        }

        public void Flag() => image.sprite = flag;

        public void UnFlag() => image.sprite = unrevealed;

        public void Init(int x, int y, MineSweeperCellType mineSweeperCellType, bool isRevealed, int neighboursCount)
        {
            X = x;
            Y = y;

            if (isRevealed)
            {
                switch (mineSweeperCellType)
                {
                    case MineSweeperCellType.Empty:
                        image.sprite = empty;
                        break;
                    case MineSweeperCellType.Flag:
                        image.sprite = flag;
                        break;
                    case MineSweeperCellType.Mine:
                        image.sprite = mine;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(mineSweeperCellType), mineSweeperCellType, null);
                }

                UpdateNeighboursCount(neighboursCount);
            }
            else
            {
                image.sprite = unrevealed;
            }
        }

        public GameObject GameObject => gameObject;

        private void UpdateNeighboursCount(int neighboursCount)
        {
            if (neighboursCount == 0)
            {
                this.neighboursCount.text = String.Empty;
            }
            else
            {
                this.neighboursCount.text = neighboursCount.ToString();
            }
        }
    }
}