using UnityEngine;
using UnityEngine.UI;
using QFramework;
using DG.Tweening;

namespace QFramework.Example
{
	public class UIMainData : UIPanelData
	{
		public float start_time = 0;
		public int order_count = 0;
		public int run_count = 0;
		public float start_run_time = 0;
	}
	public partial class UIMain : UIPanel
	{
		private OrderHolder holder;

		protected override void ProcessMsg(int eventId, QMsg msg)
		{
			throw new System.NotImplementedException();
		}
		
		protected override void OnInit(IUIData uiData = null)
		{
			mData = uiData as UIMainData ?? new UIMainData();
			// please add init code here
		}
		
		protected override void OnOpen(IUIData uiData = null)
		{
			mData.start_time = Time.time;
			Start.onClick.AddListener(() => {
				mData.run_count++;
				mData.start_run_time = Time.time;
				mData.order_count = holder.m_order_list.Count;
				GameMode1Manager.Instance.Excuter.StartExcute();
			});
			Reset.onClick.AddListener(() => {
				GameMode1Manager.Instance.Excuter.ResetExcuter();
			});
			Quit.onClick.AddListener(() => {
				GameMode1Manager.Instance.QuitStage();
			});
			holder = transform.GetComponentInChildren<OrderHolder>();
		}

		public void UpdateLog(string text) {
			MyLogText.text = text;
        }

		public void SetStageName(string s) {
			StageName.text = s;
        }

		public void FadeClose() {
            transform.DOScale(Vector3.zero, 0.3f).onComplete = () => {
				CloseSelf();
			};
        }
		
		public void MoveLine(int nowpos) {
			LineSign.transform.DOLocalMove(holder.CaculPos(nowpos),  0.3f);
        }

		public UIMainData GetmData() {
			return mData;
        }
		public void SetRunCount(int n) {
			mData.run_count = n;
			mData.start_time = Time.time;
        }
		protected override void OnShow()
		{
			transform.localScale = Vector3.zero;
			transform.DOScale(Vector3.one, 0.3f);
		}
		
		protected override void OnHide()
		{
		}
		
		protected override void OnClose()
		{
		}
	}
}
