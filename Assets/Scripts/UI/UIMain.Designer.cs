using System;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace QFramework.Example
{
	// Generate Id:c8305d1d-6476-4ff7-bd84-4d0038e37dcc
	public partial class UIMain
	{
		public const string Name = "UIMain";
		
		[SerializeField]
		public UnityEngine.UI.Text MyLogText;
		[SerializeField]
		public UnityEngine.UI.Image OrderBase;
		[SerializeField]
		public UnityEngine.UI.Image LineSign;
		[SerializeField]
		public UnityEngine.UI.Button Quit;
		[SerializeField]
		public UnityEngine.UI.Button Reset;
		[SerializeField]
		public UnityEngine.UI.Button Start;
		[SerializeField]
		public UnityEngine.UI.Text StageName;
		
		private UIMainData mPrivateData = null;
		
		protected override void ClearUIComponents()
		{
			MyLogText = null;
			OrderBase = null;
			LineSign = null;
			Quit = null;
			Reset = null;
			Start = null;
			StageName = null;
			
			mData = null;
		}
		
		public UIMainData Data
		{
			get
			{
				return mData;
			}
		}
		
		UIMainData mData
		{
			get
			{
				return mPrivateData ?? (mPrivateData = new UIMainData());
			}
			set
			{
				mUIData = value;
				mPrivateData = value;
			}
		}
	}
}
