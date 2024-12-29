using _Assets.Scripts.Gameplay;
using _Assets.Scripts.Gameplay.Minesweeper.Grid.Views;
using UnityEngine;

namespace _Assets.Scripts.Configs
{
    public class ConfigProvider : MonoBehaviour
    {
        [SerializeField] private UIConfig uiConfig;
        public UIConfig UIConfig => uiConfig;

        public MineSweeperGridView mineSweeperGridView;
    }
}