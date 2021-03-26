using System;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace QFramework.Example
{
	// Generate Id:bfdf5dce-b27c-467d-8e80-aa17704774e1
	public partial class UISelectStage
	{
		public const string Name = "UISelectStage";
		
		[SerializeField]
		public UnityEngine.UI.Button BackBtn;
		
		private UISelectStageData mPrivateData = null;
		
		protected override void ClearUIComponents()
		{
			BackBtn = null;
			
			mData = null;
		}
		
		public UISelectStageData Data
		{
			get
			{
				return mData;
			}
		}
		
		UISelectStageData mData
		{
			get
			{
				return mPrivateData ?? (mPrivateData = new UISelectStageData());
			}
			set
			{
				mUIData = value;
				mPrivateData = value;
			}
		}
	}
}
