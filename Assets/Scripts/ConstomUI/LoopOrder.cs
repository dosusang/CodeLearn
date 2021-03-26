using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace QFramework.Example {
    public class LoopOrder : BaseOrder {
        public int MaxLoop = 10;
        private Button selfBtn;
        private Button tailBtn;
        private Text selfText;
        private int loopCount = 0;
        private int selectedCount = 0;
        [SerializeField]
        private GameObject lineGrid;
        [SerializeField]
        private int LinePointCount = 10;
        private GameObject[] lines = new GameObject[11];


        public LoopOrder Another = null;
        private void Awake() {
            InitSelf();
        }
        void InitSelf() {
            selfBtn = transform.GetComponent<Button>();
            CheckNull(selfBtn);
            tailBtn = transform.GetChild(0).GetComponent<Button>();
            CheckNull(selfBtn);

            if (order == OrderType.LOOP_MAIN) {
                selfBtn.onClick.AddListener(() => {
                    if (m_status != OrderStatus.IN_HOLDER) return;
                    ChangeCountWithAnother();
                    selectedCount = loopCount;
                    if (Another != null) Another.selectedCount = loopCount;
                });
                tailBtn.onClick.AddListener(() => {
                    if (m_status != OrderStatus.IN_HOLDER) return;
                    Log.I("SPTEST spmode");
                    tarRoot.SpMode(this);//orderholder进入特殊模式，选择等待
                });
            } else if (order == OrderType.LOOP_TAIL) {
                selfBtn.onClick.AddListener(() => {
                    if (m_status != OrderStatus.IN_HOLDER) return;
                    if (tarRoot.stat == OrderHolderStatus.NORMAL) {
                        ChangeCountWithAnother();
                    } else if(tarRoot.stat == OrderHolderStatus.SP) {
                        BindAnother();
                    }
                });
            }

            selfText = transform.GetComponentInChildren<Text>();
            CheckNull(selfText);
            loopCount = 0;
            selfText.text = loopCount.ToString();
            CheckNull(lineGrid);

            if (order == OrderType.LOOP_TAIL) {
                for (int i = 0; i <= LinePointCount; i++) {
                    lines[i] = Instantiate(lineGrid);
                    lines[i].transform.SetParent(transform);
                    lines[i].transform.localScale = Vector3.one / 3;
                    lines[i].SetActive(false);
                }
            }
        }

        private void SetLineActive(bool pram) {
            for (int i = 0; i <= LinePointCount; i++) {
                lines[i].SetActive(pram);
            }
        }


        private void BindAnother() {
            var loopMain = (LoopOrder)tarRoot.SpOrder;
            if (loopMain.Another != null) {//若已经存在链接 则先断开上一步链接
                loopMain.Another.SetLineActive(false);
                loopMain.Another.tailBtn.image.color = Color.red;
                loopMain.Another.Another = null;
            }
            if (Another != null) {
                Another.tailBtn.image.color = Color.red;
            }
            loopMain.Another = this;
            this.Another = loopMain;
            ChangeLoopCount(loopMain.loopCount);

            tailBtn.image.color = Color.green;
            Another.tailBtn.image.color = Color.green;
            tarRoot.NormalMode();//选择完成，进入普通模式

            DrawLine();
            SetLineActive(true);
        }

        private void DrawLine() {
            if (Another == null) return;
            if (order == OrderType.LOOP_MAIN) {
                Another.DrawLine();
                return;
            }
            var ctrlP = GameTools.GetCtrlPoint(transform.position, Another.transform.position);
            var points = GameTools.DrawBezier( transform.position, ctrlP, Another.transform.position, LinePointCount);
            for (int i = 0; i < points.Length; i++) {
                points[i].x += 0.75f;
                lines[i].transform.position = points[i];
            }
        }

        public override void OnDrag(PointerEventData eventData) {
            base.OnDrag(eventData);
            DrawLine();
        }

        public override void OnTweenMovePos(Vector3 pos) {
            var tween = transform.DOLocalMove(pos, (float)0.3);
            tween.onComplete = () => {
                holderPos = GameDefine.Instance.BAD_POS;
                m_status = OrderStatus.IN_HOLDER;
            };
            tween.onUpdate = () => {
                DrawLine();
            };
        }

        public bool Excute() {
            if (loopCount <= 1) {
                OnReset();
                return false;
            }
            ChangeCountWithAnother(-1);
            return true;
        }

        public override void OnReset() {
            ChangeCountWithAnother(selectedCount);
        }
        private void ChangeCountWithAnother(int pram = 1) {
            if (Another != null) {
                ChangeLoopCount(pram);
                Another.ChangeLoopCount(pram);
            }
        }

        private void ChangeLoopCount(int pram = 1) {
            if (Math.Abs(pram) == 1) {
                loopCount = (loopCount + pram) % MaxLoop;
            } else {
                loopCount = pram;
            }
            selfText.text = loopCount.ToString();
        }
        void CheckNull(UnityEngine.Object obj) {
            if (obj == null) {
                Debug.LogError("Obj is Null");
            }
        }
        
        private void OnDestroy() {
            if (Another != null) {
                Another.Another = null;
                Another.tailBtn.image.color = Color.red;
            }
            if (order == OrderType.LOOP_TAIL) {
                for (int i = 0; i <= LinePointCount; i++) {
                    Destroy(lines[i]);
                }
            } else if(order == OrderType.LOOP_MAIN) {
                if (Another) {
                    Another.SetLineActive(false);
                }
            }
            selfBtn.onClick.RemoveAllListeners();
            tailBtn.onClick.RemoveAllListeners();
        }
        
    }

}
