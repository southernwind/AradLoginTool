using System;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;

namespace AradLoginTool {
	internal class Cypher {
		private static string _password = "ala@:40iokya4oaymy82yah1j2baklm/;lkqaj/au3mjauo;any3avpruiea:p08um539ua3:uba:eonabryehvwrklaSELECT*FROMmaplestoryWHEREadmin=1ldoajgij";
		internal static string EncryptString( string sourceString ) {
			var rijndael = new RijndaelManaged();
			byte[] key, iv;
			GenerateKeyFromPassword( _password, rijndael.KeySize, out key, rijndael.BlockSize, out iv );
			rijndael.Key = key;
			rijndael.IV = iv;
			var strBytes = Encoding.UTF8.GetBytes( sourceString );
			var encryptor = rijndael.CreateEncryptor();
			var encBytes = encryptor.TransformFinalBlock( strBytes, 0, strBytes.Length );
			encryptor.Dispose();
			return Convert.ToBase64String( encBytes );
		}
		
		internal static string DecryptString( string sourceString ) {
			var rijndael = new RijndaelManaged();
			byte[] key, iv;
			GenerateKeyFromPassword( _password, rijndael.KeySize, out key, rijndael.BlockSize, out iv );
			rijndael.Key = key;
			rijndael.IV = iv;
			var strBytes = Convert.FromBase64String( sourceString );
			var decryptor = rijndael.CreateDecryptor();
			var decBytes = decryptor.TransformFinalBlock( strBytes, 0, strBytes.Length );
			decryptor.Dispose();
			return Encoding.UTF8.GetString( decBytes );
		}
		
		private static void GenerateKeyFromPassword( string password, int keySize, out byte[] key, int blockSize, out byte[] iv ) {
			var sid = WindowsIdentity.GetCurrent();
			var salt = Encoding.UTF8.GetBytes( "q;:i3on5aq;imuaijfuab;l.;/23o"+ sid?.User + "itga;ipm;j83h;auhnwefn;ayg3;hqaa" );
			var deriveBytes = new Rfc2898DeriveBytes( password, salt );
			deriveBytes.IterationCount = 1000;
			key = deriveBytes.GetBytes( keySize / 8 );
			iv = deriveBytes.GetBytes( blockSize / 8 );
		}

	}
}