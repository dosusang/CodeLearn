using DG.Tweening;
using UnityEngine;

namespace QFramework.Example {
    public class Tree : BaseEntity {
        private void OnTriggerEnter(Collider other) {
            Log.I("[Rock]OnTriggerEnter");
            other.transform.DOKill();
            var nowRotation = other.transform.rotation.eulerAngles;
            nowRotation.y += 45;
            var pos = other.transform.position;
            pos.x = Mathf.Round(pos.x);
            pos.z = Mathf.Round(pos.z);
            other.transform.DOMove(pos, 0.1f);
            other.transform.DORotate(nowRotation, 0.5f).onComplete = other.gameObject.GetComponent<BaseOrderExcuter>().onOrderComplete;
            SceneFxManager.Instance.PlayBurst(transform.position);
        }

        public override void OnStageEnd() {
            Destroy(gameObject);
        }
    }
}
