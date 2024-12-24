using _Assets.Scripts.Gameplay;
using _Assets.Scripts.Gameplay.Grid.Controllers;
using Cysharp.Threading.Tasks;

namespace _Assets.Scripts.Services.StateMachine.States
{
    public class GameState : IAsyncState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly GridController _gridController;

        public GameState(GameStateMachine stateMachine, GridController gridController)
        {
            _stateMachine = stateMachine;
            _gridController = gridController;
        }

        public async UniTask Enter()
        {
            _gridController.Init();
        }

        public async UniTask Exit() { }
    }
}