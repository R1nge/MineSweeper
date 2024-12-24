﻿using _Assets.Scripts.Gameplay.Grid;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace _Assets.Scripts.Gameplay
{
    public class GridView : MonoBehaviour
    {
        [SerializeField] private CellView cellView;
        [Inject] private IObjectResolver _objectResolver;
        private CellView[,] _cells;

        public void Init(GridModel gridModel)
        {
            _cells = new CellView[gridModel.Width, gridModel.Height];
            for (int y = 0; y < gridModel.Height; y++)
            {
                for (int x = 0; x < gridModel.Width; x++)
                {
                    var cell = _objectResolver.Instantiate(cellView, transform);
                    _cells[x, y] = cell;
                    _cells[x, y].Init(gridModel.Cells[x, y]);
                }
            }

            for (int y = -gridModel.Height / 2; y < gridModel.Height / 2; y++)
            {
                for (int x = -gridModel.Width / 2; x < gridModel.Width / 2; x++)
                {
                    _cells[x + gridModel.Width / 2, y + gridModel.Width / 2].transform.localPosition =
                        new Vector3(x * 50, y * 50, 0);
                }
            }

            for (int y = 0; y < gridModel.Height; y++)
            {
                for (int x = 0; x < gridModel.Width; x++)
                {
                    if (gridModel.Cells[x, y].Revealed)
                    {
                        _cells[x, y].SetNeighboursNumber(gridModel.Cells[x, y].NeighboursCount);
                    }
                }
            }
        }
    }
}