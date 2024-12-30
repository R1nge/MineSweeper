using _Assets.Scripts.Configs;
using _Assets.Scripts.Gameplay.Sudoku.Grid.Controllers;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace _Assets.Scripts.Gameplay.Sudoku.Grid.Views
{
    public class SudokuSelectionView : MonoBehaviour
    {
        [SerializeField] private Image[] images;
        [SerializeField] private Button[] buttons;
        [Inject] private ConfigProvider _configProvider;
        private ISudokuCellView _sudokuCellView;
        [Inject] private SudokuGridController _sudokuGridController;

        private void Awake()
        {
            for (var i = 1; i < images.Length; i++)
            {
                images[i].sprite = _configProvider.SudokuSkin[i];
            }
        }

        private void OnDestroy()
        {
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].onClick.RemoveAllListeners();
            }
        }

        private void OnButtonClick(int i)
        {
            Debug.LogError($"Sub {i}");
            _sudokuGridController.SetNumber(_sudokuCellView, i);
        }

        public void Show(ISudokuCellView sudokuView)
        {
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].onClick.RemoveAllListeners();
            }

            var cellLocalPosition = sudokuView.GameObject.transform.localPosition;
            var cellPositionInGrid = sudokuView.GameObject.transform.parent.TransformPoint(cellLocalPosition);
            var newPosition = transform.parent.InverseTransformPoint(cellPositionInGrid);
            transform.localPosition = newPosition;

            _sudokuCellView = sudokuView;
            gameObject.SetActive(true);
            for (int i = 0; i < buttons.Length; i++)
            {
                var i1 = i;
                buttons[i].onClick.AddListener(() => OnButtonClick(i1));
            }
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}