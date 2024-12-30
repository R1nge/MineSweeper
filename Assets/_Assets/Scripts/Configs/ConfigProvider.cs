using _Assets.Scripts.Gameplay.Minesweeper.Grid.Views;
using _Assets.Scripts.Gameplay.Sudoku.Grid.Views;
using UnityEngine;

namespace _Assets.Scripts.Configs
{
    public class ConfigProvider : MonoBehaviour
    {
        [SerializeField] private UIConfig uiConfig;

        [SerializeField] private MineSweeperGridView mineSweeperGridView;

        [SerializeField] private SudokuGridView sudokuGridView;

        [SerializeField] private Sprite[] sudokuSkin;

        [SerializeField] private SudokuSelectionView sudokuSelectionView;
        public UIConfig UIConfig => uiConfig;
        public MineSweeperGridView MineSweeperGridView => mineSweeperGridView;
        public SudokuGridView SudokuGridView => sudokuGridView;
        public Sprite[] SudokuSkin => sudokuSkin;
        public SudokuSelectionView SudokuSelectionView => sudokuSelectionView;
    }
}