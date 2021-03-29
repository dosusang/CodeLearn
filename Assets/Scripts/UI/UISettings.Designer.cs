using System;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace QFramework.Example
{
	// Generate Id:3242bb11-9b21-4543-81d2-c1abdcf30f5f
	public partial class UISettings
	{
		public const string Name = "UISettings";
		
		[SerializeField]
		public UnityEngine.UI.Button BackBtn;
		
		private UISettingsData mPrivateData = null;
		
		protected override void ClearUIComponents()
		{
			BackBtn = null;
			
			mData = null;
		}
		
		public UISettingsData Data
		{
			get
			{
				return mData;
			}
		}
		
		UISettingsData mData
		{
			get
			{
				return mPrivateData ?? (mPrivateData = new UISettingsData());
			}
			set
			{
				mUIData = value;
				mPrivateData = value;
			}
		}
	}
}
