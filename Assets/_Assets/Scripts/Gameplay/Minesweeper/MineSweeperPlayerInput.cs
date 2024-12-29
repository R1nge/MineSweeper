using System.Collections.Generic;
using _Assets.Scripts.Gameplay.Minesweeper.Grid.Controllers;
using _Assets.Scripts.Gameplay.Minesweeper.Grid.Views;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using VContainer.Unity;

namespace _Assets.Scripts.Gameplay.Minesweeper
{
    public class MineSweeperPlayerInput : ITickable
    {
        private bool _enabled;
        private MineSweeperGridController _mineSweeperGridController;
        private GraphicRaycaster _raycaster;

        public void Tick()
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

                        if (!_mineSweeperGridController.TryFillWithMines(cellView))
                        {
                            _mineSweeperGridController.Reveal(cellView);
                        }
                    }
                }
            }
            else if (Input.GetMouseButtonDown(1))
            {
                PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
                pointerEventData.position = Input.mousePosition;

                List<RaycastResult> results = new List<RaycastResult>();
                _raycaster.Raycast(pointerEventData, results);

                foreach (RaycastResult result in results)
                {
                    if (!_enabled)
                    {
                        break;
                    }

                    if (result.gameObject.TryGetComponent(out IMineSweeperCellView cellView))
                    {
                        _mineSweeperGridController.Flag(cellView);
                    }
                }
            }
        }

        public void Init(GraphicRaycaster raycaster, MineSweeperGridController mineSweeperGridController)
        {
            _raycaster = raycaster;
            _mineSweeperGridController = mineSweeperGridController;
        }

        public void Enable() => _enabled = true;

        public void Disable() => _enabled = false;
    }
}