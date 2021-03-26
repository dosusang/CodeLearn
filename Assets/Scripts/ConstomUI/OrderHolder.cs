using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QFramework.Example {
    public class OrderHolder : MonoBehaviour {

        [SerializeField]
        private int spacing = 150;
        [SerializeField]
        private int upspacing = -100;
        [SerializeField]
        private int axis = 200;

        private int startPos { get { return spacing + upspacing; } }
        private int contentHeight { get { return Math.Max(upspacing + spacing * (m_order_list.Count + 1), 1080); } }

        private Vector3 BADPOS = new Vector3(999, 999, 999);

        public List<BaseOrder> m_order_list = new List<BaseOrder>();

        public BaseOrder SpOrder = null;
        public OrderHolderStatus stat = OrderHolderStatus.NORMAL;
       
        public void SpMode(BaseOrder order) {
            stat = OrderHolderStatus.SP;
            SpOrder = order;
            //some notice
        }

        public void NormalMode() {
            stat = OrderHolderStatus.NORMAL;
            SpOrder = null;
            //some notice
        }
        public BaseOrder GetOrderByPos(int pos) {
            if (pos >= m_order_list.Count) return null;
            return m_order_list[pos];
        }

        public void TryInsert(GameObject obj) {
            var obj_base_order = obj.GetComponent<BaseOrder>();
            var rect = gameObject.GetComponent<RectTransform>();
            if (!RectTransformUtility.RectangleContainsScreenPoint(rect, obj.transform.position)) {
                Destroy(obj);
                m_order_list.Remove(obj_base_order);
            }
            FormatPos();
        }

        public void PreInsert(BaseOrder obj_base_order) {
            obj_base_order.gameObject.transform.SetParent(transform);
            if (m_order_list.Contains(obj_base_order)) return;
            m_order_list.Add(obj_base_order);
        }

        public void FormatPos(BaseOrder order = null) {
            m_order_list.Sort();
            Vector3 temp_pos;
            BaseOrder temp_order;
            for (int idx = 0; idx < m_order_list.Count; idx++) {
                temp_pos = CaculPos(idx);
                temp_order = m_order_list[idx];
                temp_order.PosInList = idx;
                if (order == temp_order || temp_order.holderPos == temp_pos || Vector3.Distance(temp_pos, temp_order.transform.localPosition) <= 1) continue;
                temp_order.holderPos = temp_pos;
                MoveOrder(temp_order, temp_pos);
            }
            var rect = transform as RectTransform;
            if (rect.sizeDelta.y != contentHeight) {
                rect.sizeDelta = new Vector2(rect.sizeDelta.x, contentHeight);
            }
        }
        
        private void MoveOrder(BaseOrder order, Vector3 pos) {
            order.OnTweenMovePos(pos);
        }

        public Vector3 CaculPos(int idx) {
            int y_pos = -(startPos + idx * spacing);
            var temp_pos = Vector3.zero;
            temp_pos.Set(axis, y_pos, 0);
            return temp_pos;
        }

        public void OnReset() {
            foreach(BaseOrder o in m_order_list) {
                o.OnReset();
            }
        }
    }
}
