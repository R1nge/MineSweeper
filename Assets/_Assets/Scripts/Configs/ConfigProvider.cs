using _Assets.Scripts.Gameplay.Minesweeper.Grid.Views;
using UnityEngine;

namespace _Assets.Scripts.Configs
{
    public class ConfigProvider : MonoBehaviour
    {
        [SerializeField] private UIConfig uiConfig;

        [SerializeField] private MineSweeperGridView mineSweeperGridView;

        public UIConfig UIConfig => uiConfig;
        public MineSweeperGridView MineSweeperGridView => mineSweeperGridView;
    }
}