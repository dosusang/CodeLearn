using System;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace QFramework.Example
{
	// Generate Id:b69cbce3-505e-4738-bbd1-0da92575e9c8
	public partial class UIStageClear
	{
		public const string Name = "UIStageClear";
		
		[SerializeField]
		public UnityEngine.UI.Button ButtonNext;
		[SerializeField]
		public UnityEngine.UI.Button ButtonBack;
		[SerializeField]
		public UnityEngine.UI.Text OrderNum;
		[SerializeField]
		public UnityEngine.UI.Text RunCount;
		[SerializeField]
		public UnityEngine.UI.Text CodeTime;
		[SerializeField]
		public UnityEngine.UI.Text RunTime;
		
		private UIStageClearData mPrivateData = null;
		
		protected override void ClearUIComponents()
		{
			ButtonNext = null;
			ButtonBack = null;
			OrderNum = null;
			RunCount = null;
			CodeTime = null;
			RunTime = null;
			
			mData = null;
		}
		
		public UIStageClearData Data
		{
			get
			{
				return mData;
			}
		}
		
		UIStageClearData mData
		{
			get
			{
				return mPrivateData ?? (mPrivateData = new UIStageClearData());
			}
			set
			{
				mUIData = value;
				mPrivateData = value;
			}
		}
	}
}
