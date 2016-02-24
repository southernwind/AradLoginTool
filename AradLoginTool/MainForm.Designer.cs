namespace AradLoginTool {
	partial class MainForm {
		/// <summary>
		/// 必要なデザイナー変数です。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 使用中のリソースをすべてクリーンアップします。
		/// </summary>
		/// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
		protected override void Dispose( bool disposing ) {
			if( disposing && ( components != null ) ) {
				components.Dispose();
			}
			base.Dispose( disposing );
		}

		#region Windows フォーム デザイナーで生成されたコード

		/// <summary>
		/// デザイナー サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディターで変更しないでください。
		/// </summary>
		private void InitializeComponent() {
			this.components = new System.ComponentModel.Container();
			this.btnRestart = new System.Windows.Forms.Button();
			this.lbId = new System.Windows.Forms.ListBox();
			this.btnStart = new System.Windows.Forms.Button();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.tsslbl = new System.Windows.Forms.ToolStripStatusLabel();
			this.tsslStatus = new System.Windows.Forms.ToolStripStatusLabel();
			this.btnAdd = new System.Windows.Forms.Button();
			this.btnDelete = new System.Windows.Forms.Button();
			this.timerUpdateSession = new System.Windows.Forms.Timer(this.components);
			this.statusStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnRestart
			// 
			this.btnRestart.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.btnRestart.Location = new System.Drawing.Point(216, 348);
			this.btnRestart.Name = "btnRestart";
			this.btnRestart.Size = new System.Drawing.Size(193, 47);
			this.btnRestart.TabIndex = 10;
			this.btnRestart.UseVisualStyleBackColor = true;
			this.btnRestart.Visible = false;
			this.btnRestart.Click += new System.EventHandler(this.btnRestart_Click);
			// 
			// lbId
			// 
			this.lbId.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.lbId.FormattingEnabled = true;
			this.lbId.ItemHeight = 24;
			this.lbId.Location = new System.Drawing.Point(12, 60);
			this.lbId.Name = "lbId";
			this.lbId.Size = new System.Drawing.Size(397, 268);
			this.lbId.TabIndex = 11;
			this.lbId.DoubleClick += new System.EventHandler(this.EventGameLogin);
			// 
			// btnStart
			// 
			this.btnStart.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.btnStart.Location = new System.Drawing.Point(12, 348);
			this.btnStart.Name = "btnStart";
			this.btnStart.Size = new System.Drawing.Size(198, 47);
			this.btnStart.TabIndex = 12;
			this.btnStart.Text = "START";
			this.btnStart.UseVisualStyleBackColor = true;
			this.btnStart.Click += new System.EventHandler(this.EventGameLogin);
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslbl,
            this.tsslStatus});
			this.statusStrip1.Location = new System.Drawing.Point(0, 405);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(421, 22);
			this.statusStrip1.TabIndex = 13;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// tsslbl
			// 
			this.tsslbl.Name = "tsslbl";
			this.tsslbl.Size = new System.Drawing.Size(0, 17);
			// 
			// tsslStatus
			// 
			this.tsslStatus.Name = "tsslStatus";
			this.tsslStatus.Size = new System.Drawing.Size(0, 17);
			// 
			// btnAdd
			// 
			this.btnAdd.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.btnAdd.Location = new System.Drawing.Point(211, 7);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(198, 47);
			this.btnAdd.TabIndex = 14;
			this.btnAdd.Text = "アカウント追加";
			this.btnAdd.UseVisualStyleBackColor = true;
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// btnDelete
			// 
			this.btnDelete.Location = new System.Drawing.Point(13, 13);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(88, 23);
			this.btnDelete.TabIndex = 15;
			this.btnDelete.Text = "アカウント削除";
			this.btnDelete.UseVisualStyleBackColor = true;
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			// 
			// timerUpdateSession
			// 
			this.timerUpdateSession.Interval = 30000;
			this.timerUpdateSession.Tick += new System.EventHandler(this.timerUpdateSession_Tick);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(421, 427);
			this.Controls.Add(this.btnDelete);
			this.Controls.Add(this.btnAdd);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.btnStart);
			this.Controls.Add(this.lbId);
			this.Controls.Add(this.btnRestart);
			this.Name = "MainForm";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.Text = "アラド起動ツール";
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnRestart;
		private System.Windows.Forms.ListBox lbId;
		private System.Windows.Forms.Button btnStart;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel tsslbl;
		private System.Windows.Forms.ToolStripStatusLabel tsslStatus;
		private System.Windows.Forms.Button btnAdd;
		private System.Windows.Forms.Button btnDelete;
		private System.Windows.Forms.Timer timerUpdateSession;
	}
}

