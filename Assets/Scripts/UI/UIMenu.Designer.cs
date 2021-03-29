using System;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace QFramework.Example
{
	// Generate Id:a93f0bdf-a7ef-4560-99a7-5ae55da55106
	public partial class UIMenu
	{
		public const string Name = "UIMenu";
		
		[SerializeField]
		public UnityEngine.UI.Button Button;
		[SerializeField]
		public UnityEngine.UI.Button ButtonClr;
		[SerializeField]
		public UnityEngine.UI.Button ButtonSetting;
		[SerializeField]
		public UnityEngine.UI.Button ButtonAC;
		[SerializeField]
		public UnityEngine.UI.Button ButtonSTAFF;
		
		private UIMenuData mPrivateData = null;
		
		protected override void ClearUIComponents()
		{
			Button = null;
			ButtonClr = null;
			ButtonSetting = null;
			ButtonAC = null;
			ButtonSTAFF = null;
			
			mData = null;
		}
		
		public UIMenuData Data
		{
			get
			{
				return mData;
			}
		}
		
		UIMenuData mData
		{
			get
			{
				return mPrivateData ?? (mPrivateData = new UIMenuData());
			}
			set
			{
				mUIData = value;
				mPrivateData = value;
			}
		}
	}
}
