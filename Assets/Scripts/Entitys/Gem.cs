using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QFramework.Example {
    public class Gem : BaseEntity {
        private void OnTriggerEnter(Collider other) {
            Log.I("[Gem]OnTriggerEnter");
            Destroy(gameObject);
            SceneFxManager.Instance.PlayBurst(transform.position);
        }

        public override void OnStageEnd() {
            Destroy(gameObject);
        }

    }
}
