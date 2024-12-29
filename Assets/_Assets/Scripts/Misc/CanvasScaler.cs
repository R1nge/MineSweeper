using UnityEngine;

namespace _Assets.Scripts.Misc
{
    public class CanvasScaler : MonoBehaviour
    {
        private bool _enabled = true;
        private RectTransform _rectTransform;

        public void Update()
        {
            if (Input.mouseScrollDelta.y > 0)
            {
                ZoomIn();
            }
            else if (Input.mouseScrollDelta.y < 0)
            {
                ZoomOut();
            }
        }

        public void Init(RectTransform rectTransform)
        {
            _rectTransform = rectTransform;
        }

        public void Enable() => _enabled = true;
        public void Disable() => _enabled = false;

        private void ZoomIn()
        {
            var scaleX = Mathf.Clamp(_rectTransform.localScale.x + 0.1f, 0.5f, 2f);
            var scaleY = Mathf.Clamp(_rectTransform.localScale.y + 0.1f, 0.5f, 2f);
            _rectTransform.localScale = new Vector2(scaleX, scaleY);
        }

        private void ZoomOut()
        {
            var scaleX = Mathf.Clamp(_rectTransform.localScale.x - 0.1f, 0.5f, 2f);
            var scaleY = Mathf.Clamp(_rectTransform.localScale.y - 0.1f, 0.5f, 2f);
            _rectTransform.localScale = new Vector2(scaleX, scaleY);
        }
    }
}