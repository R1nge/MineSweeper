using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace _Assets.Scripts.Gameplay
{
    public class GridView : MonoBehaviour
    {
        [SerializeField] private GameObject cellView;
        
        public void Init(int width, int height)
        {
            for (int y = -height / 2; y < height / 2; y++)
            {
                for (int x = - width / 2; x < width / 2; x++)
                {
                    var cell = Object.Instantiate(cellView, transform);
                    cell.transform.localPosition = new Vector3(x * 50, y * 50, 0);
                }
            }   
        }
    }
}