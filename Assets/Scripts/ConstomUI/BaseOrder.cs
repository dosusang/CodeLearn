using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace QFramework.Example {
    public class BaseOrder : DragableObj, IBeginDragHandler, IEndDragHandler, IComparable<BaseOrder>{
        public OrderHolder tarRoot;
        public int PosInList;
        public Vector3 holderPos = Vector3.zero; 
        public OrderStatus m_status = OrderStatus.IS_BASE;
        public OrderType order = OrderType.NONE;

        public virtual void OnBeginDrag(PointerEventData eventData) {
            if (m_status == OrderStatus.IS_BASE) {
                var obj_clone = Instantiate(gameObject, transform.position, transform.rotation);
                obj_clone.name = gameObject.name;
                obj_clone.transform.SetParent(transform.parent);
                obj_clone.transform.localScale = Vector3.one;
                m_status = OrderStatus.IN_AIR;
                if (tarRoot != null) {
                    tarRoot.PreInsert(this);
                }
            } else if (m_status == OrderStatus.IN_HOLDER) {
                m_status = OrderStatus.IN_AIR;
            }
        }

        public virtual void OnEndDrag(PointerEventData eventData) {
            if (tarRoot != null) {
                tarRoot.TryInsert(gameObject);
            } else {
                Destroy(gameObject);
            }
        }

        public override void OnDrag(PointerEventData eventData) {
            base.OnDrag(eventData);
            if (tarRoot != null) {
                tarRoot.FormatPos(this);
            }
        }

        public virtual void OnTweenMovePos(Vector3 pos) {
            var tween = transform.DOLocalMove(pos, (float)0.3);
            tween.onComplete = () => {
                holderPos = GameDefine.Instance.BAD_POS;
                m_status = OrderStatus.IN_HOLDER;
            };
        }

        public virtual void OnReset() {

        }
        public int CompareTo(BaseOrder other) {
            return (int)-(this.transform.localPosition.y - other.transform.localPosition.y);
        }
    }

}
