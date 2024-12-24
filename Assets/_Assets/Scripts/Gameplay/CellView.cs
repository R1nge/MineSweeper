using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Assets.Scripts.Gameplay
{
    public class CellView : MonoBehaviour
    {
        [SerializeField] private Image image;
        [SerializeField] private Color empty, mine, flag;
        [SerializeField] private TextMeshProUGUI neighboursCount;
        private CellType _cellType;
        public CellType CellType => _cellType;

        public void Init(CellType cellType)
        {
            _cellType = cellType;
            switch (cellType)
            {
                case CellType.Empty:
                    image.color = empty;
                    break;
                case CellType.Flag:
                    image.color = flag;
                    break;
                case CellType.Mine:
                    image.color = mine;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(cellType), cellType, null);
            }
        }

        public void SetNeighboursNumber(int count)
        {
            if (count == 0)
            {
                neighboursCount.text = string.Empty;
            }
            else
            {
                neighboursCount.text = count.ToString();
            }
        }
    }
}