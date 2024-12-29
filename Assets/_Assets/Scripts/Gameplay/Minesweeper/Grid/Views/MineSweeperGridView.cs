using _Assets.Scripts.Gameplay.Minesweeper.Grid.Models;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace _Assets.Scripts.Gameplay.Minesweeper.Grid.Views
{
    public class MineSweeperGridView : MonoBehaviour
    {
        [SerializeField] private GameObject cellView;
        [SerializeField] private Transform cellsParent;
        [Inject] private IObjectResolver _objectResolver;
        private IMineSweeperCellView[,] _cells;

        public void Init(MineSweeperGridModel mineSweeperGridModel)
        {
            if (_cells != null)
            {
                for (int y = _cells.GetLength(1) - 1; y >= 0; y--)
                {
                    for (int x = _cells.GetLength(0) - 1; x >= 0; x--)
                    {
                        Destroy(_cells[x, y].GameObject);
                    }
                }
            }
            
            _cells = new IMineSweeperCellView[mineSweeperGridModel.Width, mineSweeperGridModel.Height];
            for (int y = 0; y < mineSweeperGridModel.Height; y++)
            {
                for (int x = 0; x < mineSweeperGridModel.Width; x++)
                {
                    var cell = _objectResolver.Instantiate(cellView, cellsParent);
                    _cells[x, y] = cell.GetComponent<IMineSweeperCellView>();
                    var cellData = mineSweeperGridModel.Cells[x, y];
                    _cells[x, y].Init(x, y, cellData.Type, cellData.Revealed, cellData.NeighboursCount);
                }
            }

            for (int y = 0; y < mineSweeperGridModel.Height; y++)
            {
                for (int x = 0; x < mineSweeperGridModel.Width; x++)
                {
                    _cells[x, y].GameObject.transform.localPosition = new Vector3(x * 50, y * 50, 0);
                }
            }
            
            cellsParent.transform.localPosition = new Vector3((-mineSweeperGridModel.Width + 1) * 25, (-mineSweeperGridModel.Height + 1) * 25, 0);
        }
        
        public IMineSweeperCellView GetCellView(int x, int y) => _cells[x, y];
    }
}