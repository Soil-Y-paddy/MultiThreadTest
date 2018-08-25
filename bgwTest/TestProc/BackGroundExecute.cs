using System.Windows.Forms;
using System.ComponentModel;
using System.Threading;

namespace bgwTest
{
	/// <summary>
	/// BackgroundWorkerで実行するサンプル
	/// </summary>
	public class BackGroundExecute : IMultiThreadTest
	{
		#region メンバー変数

		int m_nLoopCnt;//ループ数
		BackgroundWorker m_bgw;//サブスレッド

		#endregion

		#region プロパティ

		// 完了時true
		public bool Complete
		{
			get;
			private set;
		}

		// プログレスバー
		public ProgressBar ProgressCtrl
		{
			get;
			private set;
		}

		public int ExecuteId
		{
			get;
			private set;
		}

		#endregion

		#region メソッド


		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="a_nId">スレッドID</param>
		/// <param name="a_nLoopCycle">スレッド内のループ回数</param>
		public BackGroundExecute(int a_nNo, int a_nLoop)
		{
			m_nLoopCnt = a_nLoop;
			ExecuteId = a_nNo;

			// プログレスバーを生成
			ProgressCtrl = new ProgressBar();
			ProgressCtrl.Maximum = m_nLoopCnt;

			// BackgroundWorkerを生成します。
			m_bgw = new BackgroundWorker();
			// キャンセル機能を許可する
			m_bgw.WorkerSupportsCancellation = true;
			// 進捗更新機能を許可する
			m_bgw.WorkerReportsProgress = true;
			// 主実行関数を設定
			m_bgw.DoWork += Executer;
			// 主実行が完了したら呼び出される
			m_bgw.RunWorkerCompleted += RunWorkerCompleted;
			// 進捗状況を更新する
			m_bgw.ProgressChanged += ProgressChanged;


		}
		// 実行開始
		public void ExecuteAsync()
		{
			m_bgw.RunWorkerAsync();
		}

		// キャンセル処理
		public void CancelAsync()
		{
			m_bgw.CancelAsync();
		}


		// 進捗状況更新イベント
		void ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			ProgressCtrl.Value++;
		}

		//主実行イベント
		void Executer(object sender, DoWorkEventArgs e)
		{
			// なにか重い処理。。。
			for (int nLine = 0; nLine < m_nLoopCnt; nLine++)
			{
				Thread.Sleep( ThreadTestConst.SleepTime );
				// キャンセルされたらbreak;
				if (m_bgw.CancellationPending)
				{
					break;
				}
				// 進捗状況を更新する(プログレスバーを直接いじらない
				m_bgw.ReportProgress(nLine);
			}
		}

		// 実行完了イベント
		void RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			// プログレスバーを削除する
			ProgressCtrl.Dispose();
			Complete = true;
			// バックグランドワーカーを除去
			m_bgw.Dispose();
		}


		#endregion


	}
}
