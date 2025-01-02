using _Assets.Scripts.Gameplay.Camera;
using _Assets.Scripts.Gameplay.Minesweeper;
using _Assets.Scripts.Gameplay.Minesweeper.Grid.Controllers;
using _Assets.Scripts.Misc;
using _Assets.Scripts.Services.Grid;
using _Assets.Scripts.Services.StateMachine;
using _Assets.Scripts.Services.StateMachine.StatesCreators;
using _Assets.Scripts.Services.UIs;
using _Assets.Scripts.Services.UIs.StateMachine;
using _Assets.Scripts.Services.UIs.StatesCreators;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace _Assets.Scripts.CompositionRoot
{
    public class MainSceneInstaller : LifetimeScope
    {
        [SerializeField] private CameraHandler cameraHandler;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterComponent(cameraHandler);
            builder.RegisterEntryPoint<CanvasScaler>().AsSelf();
            builder.RegisterEntryPoint<CameraZoomer>().AsSelf();

            MineSweeper(builder);
            builder.Register<GridViewFactory>(Lifetime.Singleton);

            builder.Register<MainMenuUIStatesFactory>(Lifetime.Singleton);
            builder.Register<MainMenuUIFactory>(Lifetime.Singleton);
            builder.Register<MainMenuStatesFactory>(Lifetime.Singleton);

            builder.Register<UIMainSceneStateCreator>(Lifetime.Singleton);
            builder.Register<MainSceneStateCreator>(Lifetime.Singleton);
        }

        private void MineSweeper(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<MineSweeperPlayerInput>().AsSelf();
            builder.Register<MineSweeperGridGenerator>(Lifetime.Singleton);
            builder.Register<MineSweeperGridController>(Lifetime.Singleton);
        }
    }
}