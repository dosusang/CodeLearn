using UnityEngine;
using UnityEngine.EventSystems;

namespace QFramework.Example {
    /// <summary>
    /// 可拖动UI
    /// </summary>
    public class DragableObj : MonoBehaviour, IDragHandler {
        private RectTransform rectTransform;
        private Vector3 scale;
        
        void Start() {
            rectTransform = transform as RectTransform;
            rectTransform.anchorMin = new Vector2(0, 1);
            rectTransform.anchorMax = new Vector2(0, 1);
            scale = transform.GetComponentInParent<Canvas>().transform.localScale;
        }
        public virtual void OnDrag(PointerEventData eventData) {
            var delta = eventData.delta;
            var temp_pos = rectTransform.position;
            temp_pos.Set(temp_pos.x + delta.x*scale.x, temp_pos.y + delta.y*scale.y, temp_pos.z);
            rectTransform.position = temp_pos;
        }
    }
}
