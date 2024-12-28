using _Assets.Scripts.Gameplay.Grid.Models;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace _Assets.Scripts.Gameplay.Grid.Views
{
    public class GridView : MonoBehaviour
    {
        [SerializeField] private GameObject cellView;
        [SerializeField] private Transform cellsParent;
        [Inject] private IObjectResolver _objectResolver;
        private ICellView[,] _cells;

        public void Init(GridModel gridModel)
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
            
            _cells = new ICellView[gridModel.Width, gridModel.Height];
            for (int y = 0; y < gridModel.Height; y++)
            {
                for (int x = 0; x < gridModel.Width; x++)
                {
                    var cell = _objectResolver.Instantiate(cellView, cellsParent);
                    _cells[x, y] = cell.GetComponent<ICellView>();
                    var cellData = gridModel.Cells[x, y];
                    _cells[x, y].Init(x, y, cellData.Type, cellData.Revealed, cellData.NeighboursCount);
                }
            }

            for (int y = 0; y < gridModel.Height; y++)
            {
                for (int x = 0; x < gridModel.Width; x++)
                {
                    _cells[x, y].GameObject.transform.localPosition = new Vector3(x * 50, y * 50, 0);
                }
            }
            
            cellsParent.transform.localPosition = new Vector3((-gridModel.Width + 1) * 25, (-gridModel.Height + 1) * 25, 0);
        }
        
        public ICellView GetCellView(int x, int y) => _cells[x, y];
    }
}