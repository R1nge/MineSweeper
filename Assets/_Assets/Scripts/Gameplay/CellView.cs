using System;
using UnityEngine;
using UnityEngine.UI;

namespace _Assets.Scripts.Gameplay
{
    public class CellView : MonoBehaviour
    {
        [SerializeField] private Image image;
        [SerializeField] private Color empty, mine, flag;

        public void Init(CellType cellType)
        {
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
    }
}