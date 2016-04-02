using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using Microsoft.CSharp.RuntimeBinder;

namespace AradLoginTool {
	public partial class MainForm : Form {

		private string _loginId;
		private Hc _hc;
		private OtpBenefit _otpBenefit;

		public MainForm() {
			InitializeComponent();
			AccountManager.Load();
			UpdateListBox();
		}

		private async void EventGameLogin( object sender, EventArgs e ) {
			if( this.lbId.SelectedIndex < 0 ) {
				return;
			}
			var account = AccountManager.Value.ToArray()[this.lbId.SelectedIndex];
			if( !await Login( account ) ) {
				return;
			}
			if( await GameStart( account.Id ) ) {
				this.btnRestart.Visible = true;
				this._loginId = account.Id;
				this.btnRestart.Text = account.Id + " Game Start";
			}
			this.timerUpdateSession.Start();

			OtpBenefitView();
		}

		private async void EventWebLogin( object sender, EventArgs e ) {
			if( this.lbId.SelectedIndex < 0 ) {
				return;
			}
			var account = AccountManager.Value.ToArray()[this.lbId.SelectedIndex];
			if( !await Login( account ) ) {
				return;
			}
			this.btnRestart.Visible = true;
			this._loginId = account.Id;
			this.btnRestart.Text = account.Id + " Game Start";
			this.timerUpdateSession.Start();

			OtpBenefitView();
		}

		private async void OtpBenefitView() {
			try {

				this._otpBenefit = new OtpBenefit( this._hc.Cookies );
				var characters = await this._otpBenefit.GetParams();
				if( characters.Length != 0 ) {
					this.cmbOtpBenefit.Items.Clear();
					this.cmbOtpBenefit.Items.AddRange( characters );
					this.cmbOtpBenefit.SelectedIndex = 0;
					this.lblOtpBenefitMessage.Text = "";
					this.btnOtpBenefitGet.Enabled = true;
				}
			} catch( Exception ) {
				this.tsslStatus.Text = "ワンタイムパスワード特典取得失敗";
			}
		}

		private async void btnOtpBenefitGet_Click( object sender, EventArgs e ) {
			if( this.cmbOtpBenefit.SelectedIndex < 0 ) {
				return;
			}
			var message = await this._otpBenefit.GetOtpBenefit(this.cmbOtpBenefit.SelectedItem.ToString());
			this.lblOtpBenefitMessage.Text = message;
		}

		private async void btnRestart_Click( object sender, EventArgs e ) {
			await GameStart( this._loginId );
		}

		private async Task<bool> Login( Account account) {
			this.timerUpdateSession.Stop();
			try {
				this._hc = new Hc();
				this._hc.RequestHeader.Referrer = new Uri( "http://arad.nexon.co.jp/" );
				var html = await this._hc.Navigate( "https://www.nexon.co.jp/login/" );
				this.tsslStatus.Text = account.Id;


				if( !Regex.IsMatch( html, "^.*\\$\\(\"#(i\\d+)\"\\).focus\\(\\);.*$", RegexOptions.Singleline ) || !Regex.IsMatch(html, "^.*name=(\"|')entm(\"|') value=(\"|')(.*?)(\"|').*$", RegexOptions.Singleline ) ) {
					this.tsslStatus.Text = account.Id + "ログイン失敗(code:4)";
					return false;
				}

				var uniqueId = Regex.Replace( html, "^.*\\$\\(\"#(i\\d+)\"\\).focus\\(\\);.*$", "$1", RegexOptions.Singleline );
				var uniquePassword = Regex.Replace( uniqueId, "^i", "p" );
				var entm = Regex.Replace( html,"^.*name=(\"|')entm(\"|') value=(\"|')(.*?)(\"|').*$","$4", RegexOptions.Singleline );

				var data = new Dictionary<string, string>();

				data.Add( "entm", entm );
				data.Add( uniqueId, account.Id );
				data.Add( uniquePassword, account.Pw );
				data.Add( "onetimepass", "" );
				data.Add( "HiddenUrl", "http://arad.nexon.co.jp/" );
				data.Add( "otp", "" );
				this._hc.RequestHeader.Referrer = new Uri( "https://login.nexon.co.jp/login/?gm=arad" );
				html = await this._hc.Navigate( "https://login.nexon.co.jp/login/login_process1.aspx", data );

				//ワンタイムパスワードが要求された場合
				if( html.Contains( "window.parent.location.replace(\"https://login.nexon.co.jp/login/otp/\");" ) ) {
					html = await this._hc.Navigate( "https://login.nexon.co.jp/login/otp/" );
					var otpf = new OneTimePassForm();
					otpf.ShowDialog();
					data = new Dictionary<string, string> {
						{
							"otp", otpf.otp
						}
					};
					html = await this._hc.Navigate( "https://login.nexon.co.jp/login/login_process2.aspx", data );
				}

				this.tsslStatus.Text = account.Id + "ログイン完了";

				return true;

			} catch( COMException ) {
				this.tsslStatus.Text = account.Id + "ログイン失敗(code:1)";
			} catch( RuntimeBinderException ) {
				this.tsslStatus.Text = account.Id + "ログイン失敗(code:2)";
			} catch( Exception ) {
				this.tsslStatus.Text = account.Id + "ログイン失敗(code:3)";
			}
			return false;
		}

		private async Task<bool> GameStart( string id = "" ) {
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
				return true;
			} catch( Exception ) {
				this.tsslStatus.Text = id + " 起動失敗";
				return false;
			}
		}

		private static string GetParamValue( string html, string key ) {
			if( !Regex.IsMatch( html, "\\[\"" + key + "\"\\] = \"(.*?)\"", RegexOptions.Singleline ) ) {
				throw new Exception();
			}
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
			AccountManager.Remove( this.lbId.SelectedIndex);
			UpdateListBox();
		}

		private void UpdateListBox() {
			this.lbId.Items.Clear();
			this.lbId.Items.AddRange( AccountManager.Value.Select( account => account.id ).ToArray() );
		}

		private void timerUpdateSession_Tick( object sender, EventArgs e ) {
			var unixEpoch = new DateTime( 1970, 1, 1, 9, 0, 0 );
			var cookieCollection = this._hc.Cookies.GetCookies( new Uri( "http://arad.nexon.co.jp" ) );
			foreach( Cookie cookie in cookieCollection ) {
				if( cookie.Name == "NPP" ) {
					var split = HttpUtility.UrlDecode(cookie.Value)?.Split(':');
					if( split?.Length > 1 ) {
						var rnd = new Random();
;						var callBackSerial = ( ( (DateTime.Now.Ticks - unixEpoch.Ticks ) / 10000 )% 1000000 ) * 100 + rnd.Next(0,100);
						var url = "http://" + split[1] + ".nexon.co.jp/Ajax/Default.aspx?_vb=UpdateSession&_cs="+callBackSerial;
						var t = this._hc.Navigate( url );
						break;
					}
				}
			}
		}
	}
}