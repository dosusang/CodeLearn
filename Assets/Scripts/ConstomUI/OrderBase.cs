using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace QFramework.Example {
    public class OrderBase : MonoBehaviour {
        [SerializeField]
        private int ySpace = 80;

        [SerializeField]
        private int xAxis = 20;
        public void SortOrder() {
            int count = 1;
            for (int i = 0; i < transform.childCount; i++) {
                var t = (RectTransform)transform.GetChild(i);
                if (t.gameObject.activeInHierarchy) {
                    t.anchoredPosition = new Vector3(xAxis,-ySpace * count);
                    count++;
                }
            }
        }

        public void CheckOrders(OrderType[] orders) {
            for (int i = 0; i < transform.childCount; i++) {
                transform.GetChild(i).gameObject.SetActive(false);
            }
            for (int i = 0; i < orders.Length; i++) {
                var t = GetOrderByType(orders[i]);
                t.gameObject.SetActive(true);
            }
            SortOrder();
        }

        private Transform GetOrderByType(OrderType t) {
            for (int i = 0; i < transform.childCount; i++) {
                if (transform.GetChild(i).GetComponent<BaseOrder>().order == t) return transform.GetChild(i); 
            }
            return null;
        }
    }
}
