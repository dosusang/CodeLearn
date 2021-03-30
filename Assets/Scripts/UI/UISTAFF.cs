using UnityEngine;
using UnityEngine.UI;
using QFramework;
using DG.Tweening;

namespace QFramework.Example
{
	public class UISTAFFData : UIPanelData
	{
	}
	public partial class UISTAFF : UIPanel
	{
		protected override void ProcessMsg(int eventId, QMsg msg)
		{
			throw new System.NotImplementedException();
		}
		
		protected override void OnInit(IUIData uiData = null)
		{
			mData = uiData as UISTAFFData ?? new UISTAFFData();
			// please add init code here
		}
		
		protected override void OnOpen(IUIData uiData = null)
		{
			BackBtn.onClick.AddListener(() => {
				transform.DOScale(Vector3.zero, 0.3f).onComplete = () => {
					CloseSelf();
					UIKit.OpenPanel<UIMenu>();
				};
			});
		}
		
		protected override void OnShow()
		{
		}
		
		protected override void OnHide()
		{
		}
		
		protected override void OnClose()
		{
		}
	}
}
