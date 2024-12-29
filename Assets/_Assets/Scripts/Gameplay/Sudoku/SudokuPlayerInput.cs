using System.Collections.Generic;
using _Assets.Scripts.Gameplay.Minesweeper.Grid.Controllers;
using _Assets.Scripts.Gameplay.Minesweeper.Grid.Views;
using _Assets.Scripts.Gameplay.Sudoku.Grid.Controllers;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace _Assets.Scripts.Gameplay.Sudoku
{
    public class SudokuPlayerInput : MonoBehaviour
    {
        private GraphicRaycaster _raycaster;
        private SudokuGridController _sudokuGridController;
        private bool _enabled = false;

        public void Init(GraphicRaycaster raycaster, SudokuGridController sudokuGridController)
        {
            _raycaster = raycaster;
            _sudokuGridController = sudokuGridController;
        }

        private void Update()
        {
            if (!_enabled)
            {
                return;
            }
            
            if (Input.GetMouseButtonDown(0))
            {
                PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
                pointerEventData.position = Input.mousePosition;

                List<RaycastResult> results = new List<RaycastResult>();
                _raycaster.Raycast(pointerEventData, results);

                foreach (RaycastResult result in results)
                {
                    if (result.gameObject.TryGetComponent(out IMineSweeperCellView cellView))
                    {
                        if (!_enabled)
                        {
                            break;
                        }

                        //TODO: sudoku controller
                    }
                }
            }
        }

        public void Enable() => _enabled = true;

        public void Disable() => _enabled = false;
    }
}