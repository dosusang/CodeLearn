using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SliderView : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler{
    private RectTransform rectTransform;
    private Vector3 scale;

    public bool Vertical = true;
    public bool Horizontal = false;

    public float damping = 1;

    private Vector2 speed = Vector2.zero;
    private Vector2 lastDelta = Vector2.zero;

    void Start() {
        rectTransform = transform as RectTransform;
        scale = transform.GetComponentInParent<Canvas>().transform.localScale;
    }
    public virtual void OnDrag(PointerEventData eventData) {
        var delta = eventData.delta;
        var temp_pos = rectTransform.position;
        lastDelta.Set(delta.x * scale.x, delta.y * scale.y);
        var x = temp_pos.x;
        if (Horizontal) x = temp_pos.x + lastDelta.x;
        var y = temp_pos.y;
        if (Vertical) y = temp_pos.y + lastDelta.y;
        temp_pos.Set(x, y, temp_pos.z);
        rectTransform.position = temp_pos;
    }

    public void OnBeginDrag(PointerEventData eventData) {
        speed = Vector2.zero;
    }
    public void OnEndDrag(PointerEventData eventData) {
        speed = lastDelta;
    }

    void Update() {
        if (speed.y > 0 || speed.x > 0) {
            var temp_pos = rectTransform.position;
            temp_pos.Set(temp_pos.x + speed.x, temp_pos.y + speed.y, temp_pos.z);
            rectTransform.position = temp_pos;
            speed.x = speed.x - damping * scale.x;
            speed.y = speed.y - damping * scale.y;

        }

    }


}