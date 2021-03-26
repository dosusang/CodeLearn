using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace QFramework.Example {
    public class SceneFxManager : MonoSingleton<SceneFxManager> {
        // Start is called before the first frame update
        public GameObject burst;
        public SceneFxManager() {

        }

        public void PlayBurst(Vector3 worldPos) {
            var fx = Instantiate(burst, worldPos, transform.rotation);
            this.Delay(0.5f, () => {
                Destroy(fx);
            });
        }
    }
}

