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
        public int X { get; private set; }
        public int Y { get; private set; }

        public void Init(int x, int y)
        {
            image.color = empty;
            X = x;
            Y = y;
        }

        public void Reveal(CellModel cellModel)
        {
            switch (cellModel.Type)
            {
                case CellType.Empty:
                    image.color = empty;
                    break;
                case CellType.Mine:
                    image.color = mine;
                    break;
                case CellType.Flag:
                    image.color = flag;
                    break;
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