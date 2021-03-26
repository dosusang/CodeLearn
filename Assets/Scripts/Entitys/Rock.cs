using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QFramework.Example {
    public class Rock : BaseEntity {
        private int life = 9;
        private void OnTriggerEnter(Collider other) {
            Log.I("[Rock]OnTriggerEnter");
            other.transform.DOKill();
            other.transform.DOMove(other.transform.position + other.transform.forward, 0.5f).onComplete = other.gameObject.GetComponent<BaseOrderExcuter>().onOrderComplete;
            SceneFxManager.Instance.PlayBurst(transform.position);
            life--;
            if (life == 0) {
                Destroy(gameObject);
            }
        }

        public override void OnStageEnd() {
            Destroy(gameObject);
        }
    }
}
