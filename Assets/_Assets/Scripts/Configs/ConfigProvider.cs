using _Assets.Scripts.Gameplay;
using UnityEngine;

namespace _Assets.Scripts.Configs
{
    public class ConfigProvider : MonoBehaviour
    {
        [SerializeField] private UIConfig uiConfig;
        public UIConfig UIConfig => uiConfig;

        public GridView _GridView;
    }
}