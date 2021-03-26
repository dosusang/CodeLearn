using System;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace QFramework.Example
{
	// Generate Id:fa3e0c6e-39a1-4ab9-8d20-05bf5337d973
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
