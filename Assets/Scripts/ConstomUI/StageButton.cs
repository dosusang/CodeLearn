using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace QFramework.Example {
    public class StageButton : MonoBehaviour {
        private Button btn;
        private Text text;

        [SerializeField]
        private int stageId = 0;
        private StageDefine.StageInfo info;
        void Start() {
            btn = transform.GetComponent<Button>();
            text = transform.GetComponentInChildren<Text>();
            info = StageDefine.Instance.stages[stageId];
            text.text = info.StageName;
            btn.onClick.AddListener(() => {
                //切换到对应关卡
                UIKit.ClosePanel<UISelectStage>();
                GameMode1Manager.Instance.GameStart(stageId);
            });
        }

        private void OnDestroy() {
            btn.onClick.RemoveAllListeners();
        }
    }
}
