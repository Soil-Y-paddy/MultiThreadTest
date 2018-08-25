using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace bgwTest
{
	// マルチスレッドの検討用IF
	interface IMultiThreadTest
	{

		#region プロパティ

		// 完了フラグ
		bool Complete{get;}

		// プログレスバーコントロール
		ProgressBar ProgressCtrl { get; }

		// 実行ID
		int ExecuteId { get; }

		#endregion

		#region メソッド

		// キャンセル実行
		void CancelAsync();
		// 実行
		void ExecuteAsync();

		#endregion

	}

	class ThreadTestConst
	{
		/// <summary>
		/// ループ内のスリープ時間(ms)
		/// </summary>
		public static int SleepTime = 1;


	}
}
