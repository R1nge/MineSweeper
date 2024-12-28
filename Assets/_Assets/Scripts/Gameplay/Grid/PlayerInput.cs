using System.Collections.Generic;
using _Assets.Scripts.Gameplay.Grid.Controllers;
using _Assets.Scripts.Gameplay.Grid.Views;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using VContainer;

namespace _Assets.Scripts.Gameplay.Grid
{
    public class PlayerInput : MonoBehaviour
    {
        private GraphicRaycaster _raycaster;
        private GridController _gridController;
        private bool _enabled;

        public void Init(GraphicRaycaster raycaster, GridController gridController)
        {
            _raycaster = raycaster;
            _gridController = gridController;
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
                    if (result.gameObject.TryGetComponent(out ICellView cellView))
                    {
                        if (!_enabled)
                        {
                            break;
                        }
                        if (!_gridController.TryFillWithMines(cellView))
                        {
                            _gridController.Reveal(cellView);
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

                    if (result.gameObject.TryGetComponent(out ICellView cellView))
                    {
                        _gridController.Flag(cellView);
                    }
                }
            }
        }

        public void Enable() => _enabled = true;

        public void Disable() => _enabled = false;
    }
}