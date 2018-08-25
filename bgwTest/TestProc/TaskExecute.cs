using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Threading;

namespace bgwTest
{
	/// <summary>
	/// Taskを使用した並列処理
	/// </summary>
	class TaskExecute : IMultiThreadTest
	{
		#region メンバ変数
		int m_nLoopCnt;//ループ数
		bool m_bCancel = false; // キャンセル状態

		#endregion
		#region プロパティ

		// 完了フラグ
		public bool Complete
		{
			get;private set;
		}

		// プログレスバーコントロール
		public ProgressBar ProgressCtrl
		{
			get;private set;
		}

		// 実行ID
		public int ExecuteId
		{
			get; private set;
		}

		#endregion

		#region メソッド

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="a_nId">スレッドID</param>
		/// <param name="a_nLoopCycle">スレッド内のループ回数</param>
		public TaskExecute(int a_nId, int a_nLoopCycle)
		{
			ExecuteId = a_nId;
			m_nLoopCnt = a_nLoopCycle;

			// プログレスバー生成
			ProgressCtrl = new ProgressBar();
			ProgressCtrl.Maximum = m_nLoopCnt;

		}
			

		// キャンセル実行
		public void CancelAsync()
		{
			m_bCancel = true;
		}

		// 実行
		public void ExecuteAsync()
		{
			Task m_objTask; // タスク
			m_objTask = Task.Factory.StartNew(Executer); 
			m_objTask.ContinueWith(RunWorkerCompleted );
		}

		// 主実行
		private void Executer()
		{
			for (int nLine = 0; nLine < m_nLoopCnt; nLine++)
			{
				Thread.Sleep( ThreadTestConst.SleepTime );
				// キャンセルされたらbreak;
				if (m_bCancel)
				{
					break;
				}
				Invoker(ProgressChanged);
			}
		}

		// コントロール操作ハンドラ
		private void Invoker(Action a_Action){
			// (適当な)コントロールのInvokeに処理を渡す
			ProgressCtrl.Invoke(a_Action);
		}


		// プログレスバー変更
		void ProgressChanged()
		{
			ProgressCtrl.Value++;
		}

		

		// 実行完了イベント
		void RunWorkerCompleted(Task a_Task)
		{
			// プログレスバーを削除する
			Invoker(() =>
			{
				ProgressCtrl.Dispose();
			}
			);
			Complete = true;
		}


		#endregion
	}
}
