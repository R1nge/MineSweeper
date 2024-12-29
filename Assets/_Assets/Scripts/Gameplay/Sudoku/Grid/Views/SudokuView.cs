using TMPro;
using UnityEngine;

namespace _Assets.Scripts.Gameplay.Sudoku.Grid.Views
{
    public class SudokuView : MonoBehaviour, ISudokuCellView
    {
        [SerializeField] private TextMeshProUGUI numberText;

        public int X { get; private set; }
        public int Y { get; private set; }
        public int Number { get; private set; }

        public void Init(int x, int y, int number)
        {
            X = x;
            Y = y;
            Number = number;

            SetNumberText(number);
        }

        public void SetNumber(int number)
        {
            Number = number;
            SetNumberText(Number);
        }

        public GameObject GameObject => gameObject;

        private void SetNumberText(int number)
        {
            if (number == 0)
            {
                numberText.text = string.Empty;
            }
            else
            {
                numberText.text = number.ToString();
            }
        }
    }
}