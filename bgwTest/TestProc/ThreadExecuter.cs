using System;
using System.Threading;
using System.Windows.Forms;

namespace bgwTest.TestProc
{
	/// <summary>
	///　Threadクラスを用いた例
	///　　FrameWork Ver1.1 当時の状況に合わせたコーディング
	/// </summary>
	class ThreadExecuter : IMultiThreadTest
	{
		#region メンバ変数

		bool m_bComplete = false; // 完了フラグ
		bool m_bCancel = false; // キャンセルフラグ
		int m_nExecId; // 実行ID
		int m_nLoopCycle; // ループ回数
		ProgressBar m_objPBar; // プログレスバー
		Thread m_objMain; // 実行スレッド
		Thread m_objObs; // 監視スレッド

		delegate void Action( ); // ver1.1は、System.Actionがない模様

		#endregion

		#region プロパティ

		/// <summary>
		/// 完了フラグ
		/// </summary>
		public bool Complete
		{
			get { return m_bComplete; }
		}

		/// <summary>
		/// 進捗状況表示
		/// </summary>
		public ProgressBar ProgressCtrl
		{
			get { return m_objPBar; }
		}

		/// <summary>
		/// 実行ID
		/// </summary>
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
		public ThreadExecuter( int a_nId, int a_nLoopCycle )
		{
			m_nExecId = a_nId;
			m_nLoopCycle = a_nLoopCycle;

			m_objPBar = new ProgressBar( );
			m_objPBar.Maximum = m_nLoopCycle;

			m_objMain = new Thread( new ThreadStart( Executer ) ); // 主実行スレッド
			m_objObs = new Thread( new ThreadStart( Observer ) ); // 監視スレッド


			
		}

		/// <summary>
		/// 実行キャンセル
		/// </summary>
		public void CancelAsync( )
		{
			m_bCancel = true;
		}

		/// <summary>
		///  実行
		/// </summary>
		public void ExecuteAsync( )
		{
			m_objMain.Start( ); // 主実行スレッド開始
			m_objObs.Start( ); // 監視スレッド開始
		}

		// コントロール操作ハンドラ
		private void Invoker( Action a_Action )
		{
			// (適当な)コントロールのInvokeに処理を渡す
			ProgressCtrl.Invoke( a_Action );
		}


		// 進捗状況更新イベント
		void ProgressChanged(  )
		{
			ProgressCtrl.Value++;
		}

		//主実行メソッド
		void Executer(  )
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
				// 進捗状況を更新する(プログレスバーを直接いじらない
				Invoker( new Action( ProgressChanged ) );
			}
		}

		// 監視メソッド
		// Threadには実行が完了したときのコールバックを呼ぶ仕組みがないため
		// 別の監視スレッドで主実行スレッドを待つ必要がある。
		void Observer( )
		{
			// 主実行が完了するまで待つ
			m_objMain.Join( );
			// 完了後の処理を実行する
			Invoker( new Action( RunWorkerCompleted ) );
		}

		// 実行完了イベント
		void RunWorkerCompleted( )
		{
			// プログレスバーを削除する
			ProgressCtrl.Dispose( );
			m_bComplete = true;
		}


		#endregion
	}

}
