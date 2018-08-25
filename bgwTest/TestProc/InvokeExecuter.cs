using System;
using System.Threading;
using System.Windows.Forms;

namespace bgwTest.TestProc
{
	/// <summary>
	///　InvokeCallbackを用いた例
	///　　FrameWork Ver1.1 当時の状況に合わせたコーディング
	/// </summary>
	class InvokeExecuter : IMultiThreadTest
	{
		#region メンバ変数
		bool m_bCancel = false; // キャンセル状態
		bool m_bComplete; // 完了フラグ
		int m_nExecId; // 実行ID
		int m_nLoopCycle; // ループ回数
		ProgressBar m_objPBar; // プログレスバー

		delegate void Action( ); // System.Action があるバージョンでは不要

		#endregion
		#region プロパティ

		// 完了フラグ
		public bool Complete
		{
			get { return m_bComplete; }
		}

		// プログレスバーコントロール
		public ProgressBar ProgressCtrl
		{
			get { return m_objPBar; }
		}

		// 実行ID
		public int ExecuteId
		{
			get { return m_nExecId; }
		}

		#endregion

		#region メソッド

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="a_nId">スレッドID</param>
		/// <param name="a_nLoopCycle">スレッド内のループ回数</param>
		public InvokeExecuter( int a_nId, int a_nLoopCycle )
		{
			m_nExecId = a_nId;
			m_nLoopCycle = a_nLoopCycle;

			// プログレスバー生成
			m_objPBar = new ProgressBar( );
			m_objPBar.Maximum = m_nLoopCycle;

		}


		// キャンセル実行
		public void CancelAsync( )
		{
			m_bCancel = true;
		}

		// 実行
		public void ExecuteAsync( )
		{

			Action m_Main = new Action( Executer );
			m_Main.BeginInvoke( RunWorkerCompleted, null );
		}

		// 主実行
		private void Executer( )
		{

			// なにか重い処理。。。
			for( int nLine = 0; nLine < m_nLoopCycle; nLine++ )
			{
				Thread.Sleep( ThreadTestConst.SleepTime );
				// キャンセルされたらbreak;
				if( m_bCancel )
				{
					break;
				}
				Invoker( ProgressChanged );
			}
		}

		// 実行完了イベント
		void RunWorkerCompleted( IAsyncResult a_Task )
		{
			// プログレスバーを削除する
			Invoker( new Action(ProgressDispose) );
			m_bComplete = true;
		}

		// コントロール操作ハンドラ
		private void Invoker( Action a_Action )
		{
			// (適当な)コントロールのInvokeに処理を渡す
			ProgressCtrl.Invoke( a_Action );
		}


		// プログレスバー変更
		void ProgressChanged( )
		{
			ProgressCtrl.Value++;
		}

		// プログレスバーを廃棄
		void ProgressDispose( )
		{
			ProgressCtrl.Dispose( );
		}


		#endregion
	}
}
