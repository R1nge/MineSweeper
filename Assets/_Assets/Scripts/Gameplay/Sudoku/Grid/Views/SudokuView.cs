using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Assets.Scripts.Gameplay.Sudoku.Grid.Views
{
    public class SudokuView : MonoBehaviour, ISudokuCellView
    {
        [SerializeField] private TextMeshProUGUI numberText;
        [SerializeField] private RawImage image;
        [SerializeField] private Color color;

        public int X { get; private set; }
        public int Y { get; private set; }
        public int Number { get; private set; }

        public void Init(int x, int y, int number)
        {
            X = x;
            Y = y;
            Number = number;

            if (Number != 0)
            {
                SetNumber(Number);
            }

            var subGridX = x / 3;
            var subGridY = y / 3;

            const int offset = 1;
            if ((subGridX + subGridY) % 2 == offset)
            {
                image.color = color;
            }
        }

        public void SetNumber(int number)
        {
            Number = number;
            SetNumberText(Number);
        }

        public GameObject GameObject => gameObject;

        private void SetNumberText(int number)
        {
            numberText.text = number.ToString();
        }
    }
}