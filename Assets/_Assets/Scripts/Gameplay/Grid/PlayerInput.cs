using System;
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
        [SerializeField] private GraphicRaycaster raycaster;
        [Inject] private GridController _gridController;

        private void Awake()
        {
            raycaster = GetComponentInParent<GraphicRaycaster>();
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
                pointerEventData.position = Input.mousePosition;

                List<RaycastResult> results = new List<RaycastResult>();
                raycaster.Raycast(pointerEventData, results);

                foreach (RaycastResult result in results)
                {
                    Debug.Log("Hit " + result.gameObject.name);

                    if (result.gameObject.TryGetComponent(out CellView cellView))
                    {
                        _gridController.Reveal(cellView);
                    }
                }
            }
            else if (Input.GetMouseButtonDown(1))
            {
                PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
                pointerEventData.position = Input.mousePosition;

                List<RaycastResult> results = new List<RaycastResult>();
                raycaster.Raycast(pointerEventData, results);

                foreach (RaycastResult result in results)
                {
                    Debug.Log("Hit " + result.gameObject.name);

                    if (result.gameObject.TryGetComponent(out CellView cellView))
                    {
                        _gridController.Flag(cellView);
                    }
                }
            }
        }
    }
}