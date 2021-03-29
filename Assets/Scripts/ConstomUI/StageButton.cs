﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace QFramework.Example {
    public class StageButton : MonoBehaviour {
        private Button btn;
        [SerializeField]
        private Image tag;
        private Text text;

        [SerializeField]
        private int stageId = 0;
        private StageDefine.StageInfo info;
        void Start() {
            stageId = transform.GetSiblingIndex();
            btn = transform.GetComponent<Button>();
            text = transform.GetComponentInChildren<Text>();
            info = StageDefine.Instance.stages[stageId];
            text.text = info.StageName;
            tag.gameObject.SetActive(GameDataManager.GetBool(stageId + "cleared"));
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
