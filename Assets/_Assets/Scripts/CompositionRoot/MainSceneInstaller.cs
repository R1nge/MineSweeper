using _Assets.Scripts.Gameplay;
using _Assets.Scripts.Gameplay.Grid;
using _Assets.Scripts.Gameplay.Grid.Controllers;
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
        [SerializeField]
        private PlayerInput playerInput;
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterComponent(playerInput);
            
            builder.Register<GridGenerator>(Lifetime.Singleton);
            builder.Register<GridController>(Lifetime.Singleton);
            
            
            builder.Register<MainMenuUIStatesFactory>(Lifetime.Singleton);
            builder.Register<MainMenuUIFactory>(Lifetime.Singleton);
            builder.Register<MainMenuStatesFactory>(Lifetime.Singleton);

            builder.Register<UIMainSceneStateCreator>(Lifetime.Singleton);
            builder.Register<MainSceneStateCreator>(Lifetime.Singleton);
        }
    }
}