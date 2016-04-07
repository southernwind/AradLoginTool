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
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.splitContainer2 = new System.Windows.Forms.SplitContainer();
			this.btnLogin = new System.Windows.Forms.Button();
			this.lblOtpBenefitMessage = new System.Windows.Forms.Label();
			this.cmbOtpBenefit = new System.Windows.Forms.ComboBox();
			this.btnOtpBenefitGet = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.statusStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
			this.splitContainer2.Panel1.SuspendLayout();
			this.splitContainer2.SuspendLayout();
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
			this.statusStrip1.Size = new System.Drawing.Size(953, 22);
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
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.splitContainer1.IsSplitterFixed = true;
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.btnAdd);
			this.splitContainer1.Panel1.Controls.Add(this.btnDelete);
			this.splitContainer1.Panel1.Controls.Add(this.btnRestart);
			this.splitContainer1.Panel1.Controls.Add(this.lbId);
			this.splitContainer1.Panel1.Controls.Add(this.btnStart);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
			this.splitContainer1.Size = new System.Drawing.Size(953, 405);
			this.splitContainer1.SplitterDistance = 421;
			this.splitContainer1.TabIndex = 16;
			this.splitContainer1.TabStop = false;
			// 
			// splitContainer2
			// 
			this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.splitContainer2.IsSplitterFixed = true;
			this.splitContainer2.Location = new System.Drawing.Point(0, 0);
			this.splitContainer2.Name = "splitContainer2";
			this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer2.Panel1
			// 
			this.splitContainer2.Panel1.Controls.Add(this.btnLogin);
			this.splitContainer2.Panel1.Controls.Add(this.lblOtpBenefitMessage);
			this.splitContainer2.Panel1.Controls.Add(this.cmbOtpBenefit);
			this.splitContainer2.Panel1.Controls.Add(this.btnOtpBenefitGet);
			this.splitContainer2.Panel1.Controls.Add(this.label1);
			this.splitContainer2.Size = new System.Drawing.Size(528, 405);
			this.splitContainer2.SplitterDistance = 190;
			this.splitContainer2.TabIndex = 21;
			// 
			// btnLogin
			// 
			this.btnLogin.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.btnLogin.Location = new System.Drawing.Point(13, 9);
			this.btnLogin.Name = "btnLogin";
			this.btnLogin.Size = new System.Drawing.Size(198, 47);
			this.btnLogin.TabIndex = 16;
			this.btnLogin.Text = "LOGIN";
			this.btnLogin.UseVisualStyleBackColor = true;
			this.btnLogin.Click += new System.EventHandler(this.EventWebLogin);
			// 
			// lblOtpBenefitMessage
			// 
			this.lblOtpBenefitMessage.AutoSize = true;
			this.lblOtpBenefitMessage.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.lblOtpBenefitMessage.Location = new System.Drawing.Point(13, 124);
			this.lblOtpBenefitMessage.Name = "lblOtpBenefitMessage";
			this.lblOtpBenefitMessage.Size = new System.Drawing.Size(0, 18);
			this.lblOtpBenefitMessage.TabIndex = 20;
			// 
			// cmbOtpBenefit
			// 
			this.cmbOtpBenefit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbOtpBenefit.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.cmbOtpBenefit.FormattingEnabled = true;
			this.cmbOtpBenefit.Location = new System.Drawing.Point(222, 78);
			this.cmbOtpBenefit.Name = "cmbOtpBenefit";
			this.cmbOtpBenefit.Size = new System.Drawing.Size(198, 32);
			this.cmbOtpBenefit.TabIndex = 17;
			// 
			// btnOtpBenefitGet
			// 
			this.btnOtpBenefitGet.Enabled = false;
			this.btnOtpBenefitGet.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.btnOtpBenefitGet.Location = new System.Drawing.Point(426, 70);
			this.btnOtpBenefitGet.Name = "btnOtpBenefitGet";
			this.btnOtpBenefitGet.Size = new System.Drawing.Size(93, 47);
			this.btnOtpBenefitGet.TabIndex = 19;
			this.btnOtpBenefitGet.Text = "受け取る";
			this.btnOtpBenefitGet.UseVisualStyleBackColor = true;
			this.btnOtpBenefitGet.Click += new System.EventHandler(this.btnOtpBenefitGet_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.label1.Location = new System.Drawing.Point(14, 83);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(202, 24);
			this.label1.TabIndex = 18;
			this.label1.Text = "ワンタイムパスワード特典";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(953, 427);
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.statusStrip1);
			this.Name = "MainForm";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.Text = "アラド起動ツール";
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.splitContainer2.Panel1.ResumeLayout(false);
			this.splitContainer2.Panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
			this.splitContainer2.ResumeLayout(false);
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
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.Button btnLogin;
		private System.Windows.Forms.Button btnOtpBenefitGet;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox cmbOtpBenefit;
		private System.Windows.Forms.Label lblOtpBenefitMessage;
		private System.Windows.Forms.SplitContainer splitContainer2;
	}
}

