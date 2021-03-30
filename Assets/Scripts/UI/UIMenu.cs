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
			ButtonClr.onClick.AddListener(() => {
				GameDataManager.Clear();
			});
			ButtonSetting.onClick.AddListener(() => {
				FadeClose();
				UIKit.OpenPanel<UISettings>();
			});
			ButtonSTAFF.onClick.AddListener(() => {
				FadeClose();
				UIKit.OpenPanel<UISTAFF>();
			});
			ButtonQuit.onClick.AddListener(() => {
#if UNITY_EDITOR
				UnityEditor.EditorApplication.isPlaying = false;
#else
				Application.Quit();
#endif
			});
		}
		public void FadeClose() {
			transform.DOScale(Vector3.zero, 0.3f).onComplete = () => {
				CloseSelf();
			};
		}

		protected override void OnShow() {
			AudioKit.PlayMusic(GameDefine.Instance.AudioPathPrefix + "8bitAdvantrue");
			this.Delay(0.1f, () => {
				AudioKit.MusicPlayer.SetVolume(GameDataManager.GetFloat("MusicValue"));
				AudioKit.VoicePlayer.SetVolume(GameDataManager.GetFloat("SoundValue"));
			});
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
