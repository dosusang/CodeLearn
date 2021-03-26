using UnityEngine;
using UnityEngine.UI;
using QFramework;
using DG.Tweening;

namespace QFramework.Example
{
	public class UIStageClearData : UIPanelData
	{
	}
	public partial class UIStageClear : UIPanel
	{
		protected override void ProcessMsg(int eventId, QMsg msg)
		{
			throw new System.NotImplementedException();
		}
		
		protected override void OnInit(IUIData uiData = null)
		{
			mData = uiData as UIStageClearData ?? new UIStageClearData();
			// please add init code here
		}
		
		protected override void OnOpen(IUIData uiData = null)
		{
			var data = UIKit.GetPanel<UIMain>().GetmData();
			OrderNum.text = data.order_count.ToString();
			RunCount.text = data.run_count.ToString();
			RunTime.text = (Time.time - data.start_run_time).ToString();
			CodeTime.text = (Time.time - data.start_time).ToString();

			ButtonBack.onClick.AddListener(() => {
				CloseSelf();
				UIKit.GetPanel<UIMain>().SetRunCount(0);
				GameMode1Manager.Instance.Excuter.ResetExcuter();
			});
			ButtonNext.onClick.AddListener(() => {
				CloseSelf();
				GameMode1Manager.Instance.NextStage();
			});
		}
		public void FadeClose() {
			transform.DOScale(Vector3.zero, 0.3f).onComplete = () => {
				CloseSelf();
			};
		}

		protected override void OnShow()
		{
			transform.localScale = Vector3.zero;
			var t = transform.DOScale(Vector3.one, 1f);
			t.SetEase(Ease.InOutExpo);
		}
		
		protected override void OnHide()
		{
		}
		
		protected override void OnClose()
		{
		}
	}
}
