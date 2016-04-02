using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AradLoginTool {
	class OtpBenefit {

		private Hc _hc;

		private struct Charainfo {

			internal string name;
			internal string value;

		}

		private List<Charainfo> _charainfoList;
		private Dictionary<string,string> _parameters;

		internal OtpBenefit(CookieContainer cookies) {
			this._hc = new Hc();
			this._hc.Cookies = cookies;
		}

		internal async Task<string[]> GetParams() {
			await this._hc.Navigate( "http://arad.nexon.co.jp/" );
			var html = await this._hc.Navigate( "http://arad.nexon.co.jp/login/otpbenefit.aspx" );
			var select = Regex.Replace( html, "^.*?(id=('|\")charainfo('|\").*?</select>).*$", "$1", RegexOptions.Singleline | RegexOptions.IgnoreCase );
			var reg = new Regex( "<option.*?</option>", RegexOptions.Singleline | RegexOptions.IgnoreCase );
			var mc = reg.Matches( select );

			this._charainfoList = new List<Charainfo>();
			foreach( Match m in mc ) {
				var charainfo = new Charainfo();
				charainfo.name = Regex.Replace( m.Value , "<.*?>","", RegexOptions.Singleline | RegexOptions.IgnoreCase );
				charainfo.value = Regex.Replace( m.Value , "^.*?value=('|\")(.*?)('|\").*$", "$2", RegexOptions.Singleline | RegexOptions.IgnoreCase );
				this._charainfoList.Add( charainfo );
			}
			reg = new Regex( "<input.*?>", RegexOptions.Singleline | RegexOptions.IgnoreCase );
			mc = reg.Matches( html );

			this._parameters = new Dictionary<string, string>();
			foreach( Match m in mc ) {
				var name = Regex.Replace( m.Value, "^.*?name=('|\")(.*?)('|\").*$", "$2", RegexOptions.Singleline | RegexOptions.IgnoreCase );
				var value = Regex.Replace( m.Value, "^.*?value=('|\")(.*?)('|\").*$", "$2", RegexOptions.Singleline | RegexOptions.IgnoreCase );
				this._parameters.Add( name, value );
			}
			if( this._parameters["__EVENTTARGET"] == "" ) {
				this._parameters["__EVENTTARGET"] = "ctl00$contents_main$linkBtnReceive";
			}


			return ( from Charainfo charainfo in this._charainfoList select charainfo.name ).ToArray();
		}

		internal async Task<string> GetOtpBenefit(string name) {
			var charainfo = this._charainfoList.Where( x => x.name == name ).Select( x => x.value ).First();

			var dPost = new Dictionary<string,string>(this._parameters);
			dPost.Add( "charainfo", charainfo );
			var html = await this._hc.Navigate( "http://arad.nexon.co.jp/login/otpbenefit.aspx", dPost );
			var message = Regex.Replace( html, "^.*?alert\\('(.*?)'\\);.*$", "$1", RegexOptions.Singleline | RegexOptions.IgnoreCase );
			return message;
		}
	}
}
