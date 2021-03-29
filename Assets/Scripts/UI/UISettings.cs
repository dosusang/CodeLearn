using UnityEngine;
using UnityEngine.UI;
using QFramework;
using DG.Tweening;

namespace QFramework.Example
{
	public class UISettingsData : UIPanelData
	{
	}
	public partial class UISettings : UIPanel
	{
		[SerializeField]
		private Slider music_value;

		[SerializeField]
		private Slider sound_value;

		[SerializeField]
		private Toggle need_tips;

		protected override void ProcessMsg(int eventId, QMsg msg)
		{
			throw new System.NotImplementedException();
		}
		
		protected override void OnInit(IUIData uiData = null)
		{
			mData = uiData as UISettingsData ?? new UISettingsData();
			// please add init code here
		}
		
		protected override void OnOpen(IUIData uiData = null)
		{
			BackBtn.onClick.AddListener(() => {
				FadeClose();
				UIKit.OpenPanel<UIMenu>();
			});
			if (GameDataManager.GetFloat("FirstFlag") != 1) {
				GameDataManager.SetFloat("MucisValue", 1);
				GameDataManager.SetFloat("SoundValue", 1);
				GameDataManager.SetFloat("FirstFlag", 1);
				GameDataManager.SetBool("NeedTips", false);
			}
			music_value.value = GameDataManager.GetFloat("MucisValue");
			music_value.onValueChanged.AddListener((float value) => {
				AudioKit.MusicPlayer.SetVolume(value);
			});
			sound_value.onValueChanged.AddListener((float value) => {
				AudioKit.VoicePlayer.SetVolume(value);
			});
			sound_value.value = GameDataManager.GetFloat("SoundValue");
			need_tips.isOn = GameDataManager.GetBool("NeedTips");
		}

		public void FadeClose() {
			GameDataManager.SetFloat("MucisValue", music_value.value);
			GameDataManager.SetFloat("SoundValue", sound_value.value);
			GameDataManager.SetBool("NeedTips", need_tips.isOn);
			transform.DOScale(Vector3.zero, 0.3f).onComplete = () => {
				CloseSelf();
			};
		}

		protected override void OnShow() {
			AudioKit.PlayMusic(GameDefine.Instance.AudioPathPrefix + "8bitAdvantrue");
			//AudioKit.MusicPlayer.SetVolume(0.5f);无法生效
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
