using Cysharp.Threading.Tasks;
using UnityEngine;

namespace _Assets.Scripts.Services.StateMachine.States
{
    public class SudokuState : IAsyncState
    {
        public async UniTask Enter()
        {
            Debug.Log("sudoku");
        }

        public async UniTask Exit()
        {
        }
    }
}