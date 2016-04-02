using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AradLoginTool {
	public partial class RegistAccount :Form {
		public RegistAccount() {
			InitializeComponent();
		}

		private void btnOk_Click( object sender, EventArgs e ) {
			if( this.txtId.Text == "" || this.txtPw.Text == "" ) {
				MessageBox.Show("IDまたはパスワードが入力されていません。");
				return;
			}
			AccountManager.Add( new Account( this.txtNickname.Text, this.txtId.Text, this.txtPw.Text ) );
			Close();
		}

		private void btnCancel_Click( object sender, EventArgs e ) {
			Close();
		}
	}
}
