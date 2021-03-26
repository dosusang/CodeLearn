using System;
using UnityEngine;
namespace QFramework.Example {
    public class BaseEntity : MonoBehaviour {
        // Start is called before the first frame update
        public virtual void Start() {
            QEventSystem.RegisterEvent(EventDefine.MainGameEvent.StageEnd, OnEvent); 
        }

        private void OnEvent(int key, object[] param) {
            switch(key) {
                case (int)EventDefine.MainGameEvent.StageEnd:
                    Log.I("EventDefine.MainGameEvent.StageEnd");
                    OnStageEnd();
                    break;
            }
        }

        public virtual void OnStageEnd() {
            Log.I("BaseEntity OnStageEnd");
        }
        public virtual void OnDestroy() {
            QEventSystem.UnRegisterEvent(EventDefine.MainGameEvent.StageEnd, OnEvent);
        }
    }
}

