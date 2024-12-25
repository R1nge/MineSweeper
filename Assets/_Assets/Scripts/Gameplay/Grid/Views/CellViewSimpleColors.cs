using _Assets.Scripts.Gameplay.Grid.Models;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Assets.Scripts.Gameplay.Grid.Views
{
    public class CellViewSimpleColors : MonoBehaviour, ICellView
    {
        [SerializeField] private Image image;
        [SerializeField] private Color empty, mine, flag;
        [SerializeField] private TextMeshProUGUI neighboursCount;
        public int X { get; private set; }
        public int Y { get; private set; }

        public void Init(int x, int y, CellType cellType, bool isRevealed, int neighboursCount)
        {
            X = x;
            Y = y;

            if (isRevealed)
            {
                switch (cellType)
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
            else
            {
                image.color = empty;
            }
        }

        public GameObject GameObject => gameObject;

        public void Reveal(CellType cellType, int neighboursCount)
        {
            switch (cellType)
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

            this.neighboursCount.text = neighboursCount.ToString();
        }

        public void Flag() => image.color = flag;

        public void UnFlag() => image.color = empty;
    }
}