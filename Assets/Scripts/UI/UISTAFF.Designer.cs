using System;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace QFramework.Example
{
	// Generate Id:1e1f6be4-f941-4f3f-b013-174fe875b5b4
	public partial class UISTAFF
	{
		public const string Name = "UISTAFF";
		
		[SerializeField]
		public UnityEngine.UI.Button BackBtn;
		
		private UISTAFFData mPrivateData = null;
		
		protected override void ClearUIComponents()
		{
			BackBtn = null;
			
			mData = null;
		}
		
		public UISTAFFData Data
		{
			get
			{
				return mData;
			}
		}
		
		UISTAFFData mData
		{
			get
			{
				return mPrivateData ?? (mPrivateData = new UISTAFFData());
			}
			set
			{
				mUIData = value;
				mPrivateData = value;
			}
		}
	}
}
