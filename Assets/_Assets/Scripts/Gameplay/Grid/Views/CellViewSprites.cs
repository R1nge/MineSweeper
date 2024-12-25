using System;
using _Assets.Scripts.Gameplay.Grid.Models;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Assets.Scripts.Gameplay.Grid.Views
{
    public class CellViewSprites : MonoBehaviour, ICellView
    {
        [SerializeField] private Image image;
        [SerializeField] private Sprite unrevealed;
        [SerializeField] private Sprite empty, mine, flag;
        [SerializeField] private TextMeshProUGUI neighboursCount;

        public int X { get; private set; }
        public int Y { get; private set; }

        public void Reveal(CellType cellType, int neighboursCount)
        {
            switch (cellType)
            {
                case CellType.Empty:
                    image.sprite = empty;
                    break;
                case CellType.Flag:
                    image.sprite = flag;
                    break;
                case CellType.Mine:
                    image.sprite = mine;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(cellType), cellType, null);
            }
            
            UpdateNeighboursCount(neighboursCount);
        }

        public void Flag() => image.sprite = flag;

        public void UnFlag() => image.sprite = unrevealed;

        public void Init(int x, int y, CellType cellType, bool isRevealed, int neighboursCount)
        {
            X = x;
            Y = y;

            if (isRevealed)
            {
                switch (cellType)
                {
                    case CellType.Empty:
                        image.sprite = empty;
                        break;
                    case CellType.Flag:
                        image.sprite = flag;
                        break;
                    case CellType.Mine:
                        image.sprite = mine;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(cellType), cellType, null);
                }
            }
            else
            {
                image.sprite = unrevealed;
            }
            
            UpdateNeighboursCount(neighboursCount);
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