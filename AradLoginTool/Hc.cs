using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace AradLoginTool {
	public class Hc {

		private HttpClient _hc;
		public int retryCount = 2;
		public int waitTime = 5000;

		public Hc() {
			this._hc = new HttpClient();
			this._hc.DefaultRequestHeaders.Add( "User-Agent", "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:29.0) Gecko/20100101 Firefox/29.0" );
			this._hc.DefaultRequestHeaders.Add( "Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8" );
			this._hc.DefaultRequestHeaders.Add( "Accept-Language", "ja,en-us;q=0.7,en;q=0.3" );
			this._hc.DefaultRequestHeaders.Add( "Accept-Encoding", "gzip, deflate" );
			this._hc.DefaultRequestHeaders.Add( "Connection", "keep-alive" );
		}

		public HttpRequestHeaders RequestHeader {
			get {
				return this._hc.DefaultRequestHeaders;
			}
		}

		public async Task<string> Navigate( string url ) {
			this._hc.DefaultRequestHeaders.Host = Url2Host( url );

			HttpResponseMessage hrm;
			for( var i = 0;; i++ ) {
				try {
					hrm = await this._hc.GetAsync( url );
					break;
				} catch {
					Thread.Sleep( this.waitTime );
					if( i > this.retryCount ) {
						return null;
					}
				}
			}
			var res = await Hrm2String( hrm );
			this._hc.DefaultRequestHeaders.Referrer = new Uri( url );
			return res;
		}

		public async Task<string> Navigate( string url, Dictionary<string, string> dPost ) {
			this._hc.DefaultRequestHeaders.Host = Url2Host( url );

			var fuec = new FormUrlEncodedContent( dPost );
			HttpResponseMessage hrm;
			for( var i = 0;; i++ ) {
				try {
					hrm = await this._hc.PostAsync( url, fuec );
					break;
				} catch {
					Thread.Sleep( this.waitTime );
					if( i > this.retryCount ) {
						return null;
					}
				}
			}
			var res = await Hrm2String( hrm );
			this._hc.DefaultRequestHeaders.Referrer = new Uri( url );
			return res;
		}

		private static async Task<string> Hrm2String( HttpResponseMessage hrm ) {
			try {
				if( hrm.Content.Headers.ContentEncoding.ToString() == "gzip" ) {
					var st = await hrm.Content.ReadAsStreamAsync();
					var gzip = new GZipStream( st, CompressionMode.Decompress );
					var sr = new StreamReader( gzip );
					return sr.ReadToEnd();
				}
				return await hrm.Content.ReadAsStringAsync();
			} catch {
				return null;
			}
		}

		private static string Url2Host( string url ) {
			return Regex.Replace( url, "(https?://)(.*?)(/.*$|$)", "$2" );
		}

	}
}