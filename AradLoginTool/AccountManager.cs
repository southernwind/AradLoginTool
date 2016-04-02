using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AradLoginTool {
	class AccountManager {

		private static string _fileName = "./op.cnf";
		private static List<Account> _value;
		internal static IEnumerable<Account> Value {
			get {
				return _value;
			}
		}

		internal static void Add( Account account ) {
			_value.Add(account);
			Save();
		}
		internal static void Remove( int index ) {
			_value.RemoveAt(index);
			Save();
		}
		internal static void Load() {
			if( _value == null ) {
				_value = new List<Account>();
			}
			if( System.IO.File.Exists( _fileName ) ) {
				var serializer2 = new System.Xml.Serialization.XmlSerializer( typeof( List<Account> ) );
				var sr = new System.IO.StreamReader( _fileName, new UTF8Encoding( false ) );
				try {
					_value = (List<Account>)serializer2.Deserialize( sr );
				} catch( InvalidOperationException ) {
					MessageBox.Show( "op.cnfが壊れていて設定を読み込めませんでした。" );
				} finally {
					sr.Close();
				}
			}
		}

		internal static void Save() {
			var serializer1 = new System.Xml.Serialization.XmlSerializer( typeof( List<Account> ) );
			var sw = new System.IO.StreamWriter( _fileName, false, new UTF8Encoding( false ) );
			serializer1.Serialize( sw, _value );
			sw.Close();
		}
	}
	public class Account {

		public string nickname;
		public string id;
		public string pw;
		public string Nickname {
			get {
				if( this.nickname == "" ) {
					return this.id;
				}
				return this.nickname;
			}
		}
		public string Id {
			get {
				return this.id;
			}
		}
		public string Pw {
			get {
				return Cypher.DecryptString(this.pw);
			}
		}
		public Account() : this( "", "", "" ) {
		}

		public Account( string nickname, string id, string pw) {
			this.nickname = nickname;
			this.id = id;
			this.pw = Cypher.EncryptString( pw );
		}
	}
}
