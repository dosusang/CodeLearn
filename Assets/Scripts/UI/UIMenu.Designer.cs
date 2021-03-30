using System;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace QFramework.Example
{
	// Generate Id:03470bc4-ed9d-42e2-a78c-20787fd5942c
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
		[SerializeField]
		public UnityEngine.UI.Button ButtonQuit;
		
		private UIMenuData mPrivateData = null;
		
		protected override void ClearUIComponents()
		{
			Button = null;
			ButtonClr = null;
			ButtonSetting = null;
			ButtonAC = null;
			ButtonSTAFF = null;
			ButtonQuit = null;
			
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
