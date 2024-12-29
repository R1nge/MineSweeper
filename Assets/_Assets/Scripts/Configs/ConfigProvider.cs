using _Assets.Scripts.Gameplay;
using _Assets.Scripts.Gameplay.Minesweeper.Grid.Views;
using _Assets.Scripts.Gameplay.Sudoku.Grid.Views;
using UnityEngine;

namespace _Assets.Scripts.Configs
{
    public class ConfigProvider : MonoBehaviour
    {
        [SerializeField] private UIConfig uiConfig;
        public UIConfig UIConfig => uiConfig;

        [SerializeField] private MineSweeperGridView mineSweeperGridView;
        public MineSweeperGridView MineSweeperGridView => mineSweeperGridView;

        [SerializeField] private SudokuGridView sudokuGridView;
        public SudokuGridView SudokuGridView => sudokuGridView;
    }
}