using _Assets.Scripts.Gameplay.Minesweeper;
using _Assets.Scripts.Gameplay.Minesweeper.Grid.Controllers;
using _Assets.Scripts.Gameplay.Sudoku;
using _Assets.Scripts.Gameplay.Sudoku.Grid.Controllers;
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
        [SerializeField] private MineSweeperPlayerInput mineSweeperPlayerInput;
        [SerializeField] private SudokuPlayerInput sudokuPlayerInput;

        protected override void Configure(IContainerBuilder builder)
        {
            MineSweeper(builder);
            Sudoku(builder);
            builder.Register<GridViewFactory>(Lifetime.Singleton);

            builder.Register<MainMenuUIStatesFactory>(Lifetime.Singleton);
            builder.Register<MainMenuUIFactory>(Lifetime.Singleton);
            builder.Register<MainMenuStatesFactory>(Lifetime.Singleton);

            builder.Register<UIMainSceneStateCreator>(Lifetime.Singleton);
            builder.Register<MainSceneStateCreator>(Lifetime.Singleton);
        }

        private void MineSweeper(IContainerBuilder builder)
        {
            builder.RegisterComponent(mineSweeperPlayerInput);
            builder.Register<MineSweeperGridGenerator>(Lifetime.Singleton);
            builder.Register<MineSweeperGridController>(Lifetime.Singleton);
        }

        private void Sudoku(IContainerBuilder builder)
        {
            builder.Register<Sudoku>(Lifetime.Singleton);
            builder.RegisterComponent(sudokuPlayerInput);
            builder.Register<SudokuGridController>(Lifetime.Singleton);
        }
    }
}