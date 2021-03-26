using System;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace QFramework.Example
{
	// Generate Id:d288a5a0-a174-43b5-aebf-a6768b4cc6e9
	public partial class UIMenu
	{
		public const string Name = "UIMenu";
		
		[SerializeField]
		public UnityEngine.UI.Button Button;
		
		private UIMenuData mPrivateData = null;
		
		protected override void ClearUIComponents()
		{
			Button = null;
			
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
