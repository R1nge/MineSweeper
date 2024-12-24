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

        public void Init(CellModel cellModel)
        {
            switch (cellModel.Type)
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
                    throw new ArgumentOutOfRangeException(nameof(cellModel.Type), cellModel.Type, null);
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