using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using QFramework;
using UnityEngine;
namespace QFramework.Example {
    public class BaseOrderExcuter : BaseEntity {
        private enum nowStatus {
            GETORDER,
            EXCUTING,
            READY,
            COMPELETED,
        };
        [SerializeField]
        private BaseOrder order = null;
        [SerializeField]
        private nowStatus status = nowStatus.COMPELETED;
        private OrderHolder holder = null;
        private UIMain form;


        private int nowLine = 0;
        private int tweenId = 0;

        private string str1 = "当前命令\n";
        private string str2 = "未完成";
        private string str3 = "循环命令错误";

        public override void OnStageEnd() {
            base.OnStageEnd();
            Destroy(gameObject);
        }
        public override void Start() {
            base.Start();
            ResetExcuter();
        }

        public void ResetExcuter() {
            DOTween.Kill(tweenId);
            status = nowStatus.COMPELETED;
            nowLine = 0;
            if (holder) {
                holder.OnReset();
            } else {
                Log.W("holder is null!!");
            }
            GameMode1Manager.Instance.CreateGrass();

            transform.rotation = Quaternion.Euler(GameDefine.Instance.CAR_FORWOARD);
            var r = GameDefine.Instance.MAP_RIDIS;
            transform.position = new Vector3(-r, 0, -r);
        }

        public void StartExcute() {
            if (form == null) {
                BindUI();
            }
            ResetExcuter();
            status = nowStatus.READY;
            SafeUpdateLog("开始执行", InfoTypes.Info);
        }

        private void BindUI () {
            form = (UIMain)UIKit.GetPanel("UIMain");
            holder = form.GetComponentInChildren<OrderHolder>();
        }

        public void SafeUpdateLog(string s, InfoTypes type) {
            //if (form != null) form.UpdateLogger(s, type);
        }

        void Update() {
            if (status == nowStatus.READY) {
                order = GetOrder();
                if (order != null) {
                    status = nowStatus.EXCUTING;
                    ExcuteOrder(order);
                }
            }
        }

        private void ExcuteOrder(BaseOrder order) {
            var nowRotation = transform.rotation.eulerAngles;
            form.UpdateLog(str1 + order.order.ToString());
            if (order.order == OrderType.MOVE_FORWARD) {
                var o_pos = -transform.forward + transform.position;
                var t = transform.DOMove(o_pos, 1);
                BindIdAndCallBack(t);
            } else if (order.order == OrderType.TRUN_LEFT) {
                nowRotation.y -= 90;
                var t = transform.DORotate(nowRotation, 1);
                BindIdAndCallBack(t);
            } else if (order.order == OrderType.TURN_RIGHT) {
                nowRotation.y += 90;
                var t = transform.DORotate(nowRotation, 1);
                BindIdAndCallBack(t);
            } else if (order.order == OrderType.LOOP_TAIL) {
                var loopOrder = (LoopOrder)order;
                if (loopOrder.PosInList < loopOrder.Another.PosInList) { //循环尾部要在循环顶部之前
                    endExcute();
                    form.UpdateLog(str3);
                    //报错【循环尾部要在循环顶部之前】
                } else {
                    if (loopOrder.Excute()) {
                        nowLine = loopOrder.Another.PosInList;
                    }
                    this.Delay(0.2f, onOrderComplete);
                }

            } else if (order.order == OrderType.LOOP_MAIN) {
                
                this.Delay(0.2f, onOrderComplete);
            }
        }

        private void BindIdAndCallBack(Tweener t) {
            t.onComplete = onOrderComplete;
            tweenId = t.intId;
        }

        public void onOrderComplete() {
            status = nowStatus.READY;
        }

        private void endExcute() {
            nowLine = 0;
            form.MoveLine(nowLine);
            status = nowStatus.COMPELETED;
            if (GameMode1Manager.Instance.CheckClear()) {
                GameDataManager.SetBool(GameMode1Manager.Instance.NowStage + "cleared", true);
                UIKit.OpenPanel<UIStageClear>();
            } else {
                form.UpdateLog(str2);
            }
        }
        private BaseOrder GetOrder() {
            if (nowLine == holder.transform.childCount) {
                endExcute();
                // SafeUpdateLog("运行完成", InfoTypes.Info);
                //outPutBox.CheckOutPut();
                return null;
            }
            form.MoveLine(nowLine);
            var o = holder.GetOrderByPos(nowLine);
            nowLine += 1;
            return o;
        }

    }
}

