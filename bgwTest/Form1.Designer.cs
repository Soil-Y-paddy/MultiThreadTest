namespace bgwTest
{
	partial class Form1
	{
		/// <summary>
		/// 必要なデザイナー変数です。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 使用中のリソースをすべてクリーンアップします。
		/// </summary>
		/// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows フォーム デザイナーで生成されたコード

		/// <summary>
		/// デザイナー サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディターで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
			this.flowBars = new System.Windows.Forms.FlowLayoutPanel();
			this.numThreads = new System.Windows.Forms.NumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			this.numLoop = new System.Windows.Forms.NumericUpDown();
			this.label2 = new System.Windows.Forms.Label();
			this.btnExecute = new System.Windows.Forms.Button();
			this.cmbMode = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.numThreads)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numLoop)).BeginInit();
			this.SuspendLayout();
			// 
			// flowBars
			// 
			this.flowBars.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.flowBars.Location = new System.Drawing.Point(16, 115);
			this.flowBars.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.flowBars.Name = "flowBars";
			this.flowBars.Size = new System.Drawing.Size(496, 298);
			this.flowBars.TabIndex = 0;
			// 
			// numThreads
			// 
			this.numThreads.Location = new System.Drawing.Point(176, 55);
			this.numThreads.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.numThreads.Name = "numThreads";
			this.numThreads.Size = new System.Drawing.Size(80, 22);
			this.numThreads.TabIndex = 1;
			this.numThreads.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(63, 55);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(102, 15);
			this.label1.TabIndex = 2;
			this.label1.Text = "生成スレッド数：";
			// 
			// numLoop
			// 
			this.numLoop.Location = new System.Drawing.Point(176, 84);
			this.numLoop.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.numLoop.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
			this.numLoop.Name = "numLoop";
			this.numLoop.Size = new System.Drawing.Size(80, 22);
			this.numLoop.TabIndex = 1;
			this.numLoop.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(16, 86);
			this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(149, 15);
			this.label2.TabIndex = 2;
			this.label2.Text = "スレッド内のループ回数：";
			// 
			// btnExecute
			// 
			this.btnExecute.Location = new System.Drawing.Point(385, 55);
			this.btnExecute.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btnExecute.Name = "btnExecute";
			this.btnExecute.Size = new System.Drawing.Size(112, 29);
			this.btnExecute.TabIndex = 3;
			this.btnExecute.Text = "実行";
			this.btnExecute.UseVisualStyleBackColor = true;
			this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
			// 
			// cmbMode
			// 
			this.cmbMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbMode.FormattingEnabled = true;
			this.cmbMode.Location = new System.Drawing.Point(176, 26);
			this.cmbMode.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.cmbMode.Name = "cmbMode";
			this.cmbMode.Size = new System.Drawing.Size(160, 23);
			this.cmbMode.TabIndex = 4;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(83, 29);
			this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(82, 15);
			this.label3.TabIndex = 5;
			this.label3.Text = "テストモード：";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(541, 440);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.cmbMode);
			this.Controls.Add(this.btnExecute);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.numLoop);
			this.Controls.Add(this.numThreads);
			this.Controls.Add(this.flowBars);
			this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.Name = "Form1";
			this.Text = "Form1";
			((System.ComponentModel.ISupportInitialize)(this.numThreads)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numLoop)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.FlowLayoutPanel flowBars;
		private System.Windows.Forms.NumericUpDown numThreads;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.NumericUpDown numLoop;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnExecute;
		private System.Windows.Forms.ComboBox cmbMode;
		private System.Windows.Forms.Label label3;
	}
}

