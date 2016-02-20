using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Microsoft.CSharp.RuntimeBinder;

namespace AradLoginTool {
	public partial class MainForm : Form {

		private Hc _hc;

		public MainForm() {
			InitializeComponent();
			this._hc = new Hc();
			AccountManager.Load();
		}

		private void lbId_DoubleClick( object sender, EventArgs e ) {
			if( this.lbId.SelectedIndex < 0 ) {
				return;
			}
			Login( AccountManager.value[this.lbId.SelectedIndex] );
		}

		private async void Login( Account account) {
			try {
				this._hc.RequestHeader.Referrer = new Uri( "http://arad.nexon.co.jp/" );
				var html = await this._hc.Navigate( "http://www.nexon.co.jp/login/" );
				this.tsslStatus.Text = account.Id;
				var uniqueId = new Regex( "return  document.getElementById\\('(.*?)'\\).value;" ).Matches( html )[0].Groups[1].Value;
				var uniquePassword = Regex.Replace( uniqueId, "^i", "p" );
				var entm = new Regex( "name=(\"|')entm(\"|') value=(\"|')(.*?)(\"|')" ).Matches( html )[0].Groups[4].Value;

				var data = new Dictionary<string, string>();

				data.Add( "entm", entm );
				data.Add( uniqueId, account.Id );
				data.Add( uniquePassword, account.Pw );
				data.Add( "onetimepass", "" );
				data.Add( "HiddenUrl", "http://arad.nexon.co.jp/" );
				data.Add( "otp", "" );
				html = await this._hc.Navigate( "https://www.nexon.co.jp/login/login_process1.aspx?iframe=true", data );

				//ワンタイムパスワードが要求された場合
				if( html.Contains( "location.replace(\"https://www.nexon.co.jp/login/otp/index.aspx" ) ) {
					html = await this._hc.Navigate( Regex.Replace( html, "^.*location\\.replace\\(\"(https://www.nexon.co.jp/login/otp/index\\.aspx.*?)\"\\).*$", "$1", RegexOptions.Singleline ) );
					var otpf = new OneTimePassForm();
					otpf.ShowDialog();
					data = new Dictionary<string, string> {
						{
							"otp", otpf.otp
						}
					};
					await this._hc.Navigate( Regex.Replace( html, "^.*action=\"(.*?)\" id=\"otploginform\".*$", "$1", RegexOptions.Singleline ), data );
				}

				this.tsslStatus.Text = account.Id + "ログイン完了";
				GameStart( account.Id );
				this.btnRestart.Visible = true;
				this.btnRestart.Text = account.Id + " Game Start";
			} catch( COMException ) {
				this.tsslStatus.Text = account.Id + "ログイン失敗(code:1)";
			} catch( RuntimeBinderException ) {
				this.tsslStatus.Text = account.Id + "ログイン失敗(code:2)";
			} catch( Exception ) {
				this.tsslStatus.Text = account.Id + "ログイン失敗(code:3)";
			}
		}

		private async void GameStart( string id = "" ) {
			try {
				var html = await this._hc.Navigate( "http://arad.nexon.co.jp/launcher/game/GameStart.aspx" );
				this.tsslStatus.Text = id + "startpage";

				var parameters = new List<string>();
				parameters.Add( GetParamValue( html, "ServerIP" ) );
				parameters.Add( GetParamValue( html, "ServerPort" ) );
				parameters.Add( GetParamValue( html, "ServerType" ) );
				parameters.Add( GetParamValue( html, "SiteType" ) );
				parameters.Add( GetParamValue( html, "UserId" ) );
				parameters.Add( GetParamValue( html, "PassportString" ) );
				parameters.Add( GetParamValue( html, "LauncherChecksum" ) );
				parameters.Add( GetParamValue( html, "CharCount" ) );

				Process.Start( "neoplecustomurl://" + string.Join( "/", parameters ) );
				this.tsslStatus.Text = id + "起動しました。";
			} catch( Exception ) {
				this.tsslStatus.Text = id + " 起動失敗";
			}
		}

		private static string GetParamValue( string html, string key ) {
			return Regex.Replace( html, "^.*\\[\"" + key + "\"\\] = \"(.*?)\".*$", "$1", RegexOptions.Singleline );
		}

		private void btnAdd_Click( object sender, EventArgs e ) {
			var rf = new RegistAccount();
			rf.ShowDialog();
			UpdateListBox();
		}

		private void btnDelete_Click( object sender, EventArgs e ) {
			if( this.lbId.SelectedIndex < 0 ) {
				return;
			}
			AccountManager.value.RemoveAt( this.lbId.SelectedIndex);
			UpdateListBox();
		}

		private void UpdateListBox() {
			this.lbId.Items.Clear();
			foreach( var account in AccountManager.value){
				this.lbId.Items.Add(account.Id);
			}
		}
	}
}