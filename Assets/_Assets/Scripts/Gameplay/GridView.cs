using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace _Assets.Scripts.Gameplay
{
    public class GridView : MonoBehaviour
    {
        [SerializeField] private CellView cellView;
        [Inject] private GridGenerator _gridGenerator;
        [Inject] private IObjectResolver _objectResolver;
        private CellView[,] _cells;

        public void Init(int width, int height)
        {
            _cells = new CellView[width, height];
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    var cell = _objectResolver.Instantiate(cellView, transform);
                    _cells[x, y] = cell;
                    _cells[x, y].Init(_gridGenerator.Cells[x, y]);
                }
            }

            for (int y = -height / 2; y < height / 2; y++)
            {
                for (int x = -width / 2; x < width / 2; x++)
                {
                    _cells[x + width / 2, y + width / 2].transform.localPosition = new Vector3(x * 50, y * 50, 0);
                }
            }
        }
    }
}