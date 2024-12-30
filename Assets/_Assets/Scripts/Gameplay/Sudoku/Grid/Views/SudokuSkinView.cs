using _Assets.Scripts.Configs;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace _Assets.Scripts.Gameplay.Sudoku.Grid.Views
{
    public class SudokuSkinView : MonoBehaviour, ISudokuCellView
    {
        [SerializeField] private Color note;
        [SerializeField] private Image image;
        [Inject] private ConfigProvider _configProvider;
        private Color _defaultColor;

        private int _numberNote;

        public int X { get; private set; }
        public int Y { get; private set; }
        public int Number { get; private set; }
        public GameObject GameObject => gameObject;

        public void Init(int x, int y, int number)
        {
            _defaultColor = image.color;
            X = x;
            Y = y;
            Number = number;
            SetSprite(number);
        }

        public void SetNumber(int number)
        {
            _numberNote = 0;
            SetSprite(number);
        }

        public void SetNumberNote(int number)
        {
            _numberNote = number;
            SetSprite(number);
        }

        private void SetSprite(int number)
        {
            if (_numberNote != 0)
            {
                image.color = note;
            }
            else
            {
                image.color = _defaultColor;
            }

            if (number <= 0)
            {
                image.sprite = null;
            }
            else
            {
                image.sprite = _configProvider.SudokuSkin.Sprites[number];
            }
        }
    }
}