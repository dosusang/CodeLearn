using UnityEngine;
using UnityEngine.UI;
using QFramework;
using DG.Tweening;

namespace QFramework.Example
{
	public class UIMenuData : UIPanelData
	{
	}
	public partial class UIMenu : UIPanel
	{
		protected override void ProcessMsg(int eventId, QMsg msg)
		{
			throw new System.NotImplementedException();
		}
		
		protected override void OnInit(IUIData uiData = null)
		{
			mData = uiData as UIMenuData ?? new UIMenuData();
			// please add init code here
		}
		
		protected override void OnOpen(IUIData uiData = null)
		{
			Button.onClick.AddListener(() => {
				FadeClose();
				UIKit.OpenPanel<UISelectStage>();
			});
		}
		public void FadeClose() {
			transform.DOScale(Vector3.zero, 0.3f).onComplete = () => {
				CloseSelf();
			};
		}

		protected override void OnShow() {
			AudioKit.PlayMusic(GameDefine.Instance.AudioPathPrefix + "8bitAdvantrue");
			AudioKit.MusicPlayer.SetVolume(0.5f);
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
