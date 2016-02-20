namespace AradLoginTool {
	partial class OneTimePassForm {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose( bool disposing ) {
			if( disposing && ( components != null ) ) {
				components.Dispose();
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.txtOtp = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// txtOtp
			// 
			this.txtOtp.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.txtOtp.Location = new System.Drawing.Point(28, 22);
			this.txtOtp.Name = "txtOtp";
			this.txtOtp.Size = new System.Drawing.Size(226, 31);
			this.txtOtp.TabIndex = 0;
			this.txtOtp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtOtp_KeyPress);
			// 
			// button1
			// 
			this.button1.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.button1.Location = new System.Drawing.Point(179, 79);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 28);
			this.button1.TabIndex = 1;
			this.button1.Text = "OK";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// OneTimePassForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 128);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.txtOtp);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "OneTimePassForm";
			this.ShowIcon = false;
			this.Text = "ワンタイムパスワードの要求";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txtOtp;
		private System.Windows.Forms.Button button1;
	}
}