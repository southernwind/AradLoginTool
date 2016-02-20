using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AradLoginTool {
	class AccountManager {

		public static List<Account> value = new List<Account>();

		internal static void Add( Account account ) {
			value.Add(account);
		}
		internal static void Load() {
			value.Add(new Account("",""));
		}
	}
	internal class Account {
		private string _id;
		internal string Id {
			get {
				return this._id;
			}
		}
		private string _pw;
		internal string Pw {
			get {
				return this._pw;
			}
		}

		internal Account( string id, string pw) {
			this._id = id;
			this._pw = pw;
		}
	}
}
