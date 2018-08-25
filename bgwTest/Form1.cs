using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace bgwTest
{
	public partial class Form1 : Form
	{
		#region 定数
		const int TImerInterval = 10;
		#endregion

		#region メンバー変数

		List<IMultiThreadTest> m_lstBgw = new List<IMultiThreadTest>(); //並列処理オブジェクトのリスト
		bool m_bExecute = false; // 実行中true
		Timer m_Timer ; // 処理オブジェクトの完了待ちタイマー

		#endregion

		#region コンストラクタ

		public Form1()
		{
			InitializeComponent();

			// 監視タイマーの設定
			m_Timer = new System.Windows.Forms.Timer();
			m_Timer.Interval = TImerInterval;
			m_Timer.Tick += new EventHandler(Timer_Tick);
			
			// コンボボックス
			cmbMode.DataSource = Utility.GetClassesFromImpl(typeof(IMultiThreadTest));
			cmbMode.DisplayMember = "Name";

			cmbMode.SelectedIndex = 0;
		}

		#endregion

		#region イベント

		// タイマーによる監視
		void Timer_Tick(object sender, EventArgs e)
		{
			bool bAllComplete = false;
			// 実行が完了しているか監視する
			foreach (IMultiThreadTest objBge in m_lstBgw)
			{
				bAllComplete = objBge.Complete;
				// 未完了の場合
				if (!objBge.Complete)
				{
					break;
				}
			}
			if (bAllComplete)
			{
				Clear();
				MessageBox.Show("完了");
			}
		}

		// 実行ボタンを押したとき
		private void btnExecute_Click(object sender, EventArgs e)
		{
			if( m_bExecute){
				// キャンセル実行
				foreach (IMultiThreadTest objBge in m_lstBgw)
				{
					objBge.CancelAsync();
				}
				Clear();
				MessageBox.Show("キャンセル");

			}
			else
			{
				// 実行準備
				PreExecute();

				m_bExecute = true;
				// 実行
				foreach (IMultiThreadTest objBge in m_lstBgw)
				{
					objBge.ExecuteAsync();
				}
				// 監視タイマーON
				m_Timer.Start();
				btnExecute.Text = "停止";

			}
		}

		#endregion

		#region メソッド

		// 実行準備
		private void PreExecute()
		{
			// コンボボックスで指定したクラス
			Type tpMode = (Type)cmbMode.SelectedValue;

			for (int nLine = 0; nLine < numThreads.Value; nLine++)
			{
				// コンストラクタにわたす引数
				object[] aArgs = new object[]{ nLine, (int)numLoop.Value };

				IMultiThreadTest objExec = (IMultiThreadTest)Activator.CreateInstance(tpMode, aArgs);
				//BackGroundExecute objExec = new BackGroundExecute(nLine, (int)numLoop.Value);
				flowBars.Controls.Add(objExec.ProgressCtrl);
				m_lstBgw.Add(objExec);
			}

		}


		// 実行オブジェクトクリア
		private void Clear()
		{
			m_lstBgw.Clear();
			m_lstBgw.Capacity = 0;
			m_bExecute = false;
			btnExecute.Text = "実行";
			// 監視タイマーOFF
			m_Timer.Stop();

		}

		#endregion
	}



}
