using UnityEngine;
using UnityEngine.UI;
using QFramework;
using DG.Tweening;

namespace QFramework.Example
{
	public class UISelectStageData : UIPanelData
	{
	}
	public partial class UISelectStage : UIPanel
	{
		protected override void ProcessMsg(int eventId, QMsg msg)
		{
			throw new System.NotImplementedException();
		}
		
		protected override void OnInit(IUIData uiData = null)
		{
			mData = uiData as UISelectStageData ?? new UISelectStageData();
			// please add init code here
		}
		
		protected override void OnOpen(IUIData uiData = null)
		{
			BackBtn.onClick.AddListener(() => {
				CloseSelf();
				UIKit.OpenPanel<UIMenu>();
			});
		}
		public void FadeClose() {
			transform.DOScale(new Vector3(1,0,0), 0.3f).onComplete = () => {
				CloseSelf();
				
			};
		}

		protected override void OnShow() {
			transform.localScale = new Vector3(1, 0, 0);
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
