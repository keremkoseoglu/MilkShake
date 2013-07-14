using System;
using System.IO;
using System.Security;
using System.Security.Cryptography;
using System.Text;

namespace MilkShakeEngine
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Engine
	{
		public string key;

		private string timeStamp;

		private int isec = 0;
		private int imin = 0;
		private int ihou = 0;
		private int iday = 0;
		private int imon = 0;
		private int iyea = 0;

		// Spicing
		private string despiceKey;
		private string enspiceKey;
		

		private enum TASK: long {ENCRYPTION, DECRYPTION};

		public Engine()
		{
			key = "1234567890 qwertyuopasdfghjklizxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM";
		}

		public Engine(string Key)
		{
			if (!validateKey(Key))
			{
				throw new Exception("Key not valid! Duplicate characters detected!");
			}

			if (Key.Length < 3)
			{
				throw new Exception("Key not valid! At least 3 characters required!");
			}

			key = Key;
		}

		public string encrypt(string Text)
		{
			string ret = "";

			if (Text.Length <= 0) return Text;

			ret = Text;
			spiceText(ref ret, TASK.ENCRYPTION);
			ret = encryptTripleDes(ret, key);

			return ret;
		}

		public string decrypt(string Text)
		{
			string ret = "";

			if (Text.Length <= 0) return Text;

			ret = Text;
			ret = decryptTripleDes(ret, key);
			spiceText(ref ret, TASK.DECRYPTION);

			return ret;
		}

		private bool validateKey(string Key)
		{
			bool b = true;

			for (int n = 0; n < Key.Length; n++)
			{
				for (int m = n + 1; m < Key.Length; m++)
				{
					if (Key.Substring(n, 1) == Key.Substring(m, 1)) b = false;
				}
			}

			return b;
		}

		private void spiceText(ref string Text, TASK Task)
		{
			bool found;
			string s	= "";
			string key1	= "";
			string key2	= "";

			if (Text.Length <= 0) return;

			switch (Task)
			{
				case TASK.ENCRYPTION:
					packTimeStamp();
					buildKeys();
					key1 = enspiceKey;
					key2 = despiceKey;
					shiftLeft(ref Text, key1.Length);
					break;
				case TASK.DECRYPTION:
					unpackTimeStamp(ref Text);
					buildKeys();
					key1 = despiceKey;
					key2 = enspiceKey;
					shiftRight(ref Text, key1.Length);
					break;
			}

			for (int n = 0; n < Text.Length; n++)
			{
				found = false;

				for (int m = 0; m < key1.Length; m++)
				{
					if (Text.Substring(n, 1) == key1.Substring(m, 1))
					{
						found = true;
						s += key2.Substring(m, 1);
					}
				}

				if (!found) s += Text.Substring(n, 1);
			}			

			if (Task == TASK.ENCRYPTION)
			{
				s = timeStamp + s;
			}

			Text = s;
		}

		private void packTimeStamp()
		{

			isec = getRandomNumber(-1);
			imin = getRandomNumber(isec);
			ihou = getRandomNumber(imin);
			iday = getRandomNumber(ihou);
			imon = getRandomNumber(iday);
			iyea = getRandomNumber(imon);
					
			timeStamp = key.Substring(iyea, 1) + timeStamp;
			timeStamp = key.Substring(imon, 1) + timeStamp;
			timeStamp = key.Substring(iday, 1) + timeStamp;
			timeStamp = key.Substring(ihou, 1) + timeStamp;
			timeStamp = key.Substring(imin, 1) + timeStamp;
			timeStamp = key.Substring(isec, 1) + timeStamp;
		}

		private int getRandomNumber(int Previous)
		{
			int r = Previous;
			System.Random rnd = new Random(System.DateTime.Now.Millisecond);
			
			while (r == Previous)
			{
				r = rnd.Next(key.Length - 1);
			}

			return r;
		}

		private void unpackTimeStamp(ref string Text)
		{
			string sec = "";
			string min = "";
			string hou = "";
			string day = "";
			string mon = "";
			string yea = "";

			timeStamp = Text.Substring(0, 6);
			sec = timeStamp.Substring(0, 1); getDatePart(sec, ref isec);
			min = timeStamp.Substring(1, 1); getDatePart(min, ref imin);
			hou = timeStamp.Substring(2, 1); getDatePart(hou, ref ihou);
			day = timeStamp.Substring(3, 1); getDatePart(day, ref iday);
			mon = timeStamp.Substring(4, 1); getDatePart(mon, ref imon);
			yea = timeStamp.Substring(5, 1); getDatePart(yea, ref iyea);

			Text = Text.Substring(6, Text.Length - 6);
		}


		private void getDatePart(string Part, ref int Number)
		{
			for (int n = 0; n < key.Length; n++)
			{
				if (key.Substring(n, 1) == Part) 
				{
					Number = n;
				}
			}
		}

		private void buildKeys()
		{
			// Keys
			despiceKey = "";
			enspiceKey = "";
			for (int n = 0; n < key.Length; n++)
			{
				despiceKey += key.Substring(n, 1);
				enspiceKey += key.Substring(key.Length - n - 1, 1);
			}

			shiftLeft(ref despiceKey	, isec)	; shiftRight(ref enspiceKey	, isec)	;
			shiftLeft(ref despiceKey	, imin)	; shiftRight(ref enspiceKey	, imin)	;
			shiftLeft(ref despiceKey	, ihou)	; shiftRight(ref enspiceKey	, ihou)	;
			shiftLeft(ref despiceKey	, iday)	; shiftRight(ref enspiceKey	, iday)	;
			shiftLeft(ref despiceKey	, imon)	; shiftRight(ref enspiceKey	, imon)	;
			shiftLeft(ref despiceKey	, iyea)	; shiftRight(ref enspiceKey	, iyea)	;

		}

		private void shiftLeft(ref string Text, int Times)
		{
			for (int n = 1; n <= Times; n++)
			{
				Text = Text.Substring(1, Text.Length - 1) + Text.Substring(0, 1);
			}
		}

		private void shiftRight(ref string Text, int Times)
		{
			for (int n = 1; n <= Times; n++)
			{
				Text = Text.Substring(Text.Length - 1, 1) + Text.Substring(0, Text.Length - 1);
			}
		}
		private string encryptTripleDes(string plainMessage, string Password)
		{
			string password = Password;
			shiftLeft(ref password, 7);

			TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
			des.IV = new byte[8];
			PasswordDeriveBytes pdb = new PasswordDeriveBytes(password, new byte[0]);
			des.Key = pdb.CryptDeriveKey("RC2", "MD5", 128, new byte[8]);
			MemoryStream ms = new MemoryStream(plainMessage.Length * 2);
			CryptoStream encStream = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);
			byte[] plainBytes = Encoding.UTF8.GetBytes(plainMessage);
			encStream.Write(plainBytes, 0, plainBytes.Length);
			encStream.FlushFinalBlock();
			byte[] encryptedBytes = new byte[ms.Length];
			ms.Position = 0;
			ms.Read(encryptedBytes, 0, (int)ms.Length);
			encStream.Close();
			return Convert.ToBase64String(encryptedBytes);
		}

		private string decryptTripleDes(string encryptedBase64, string Password)
		{
			string password = Password;
			shiftLeft(ref password, 7);

			TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
			des.IV = new byte[8];
			PasswordDeriveBytes pdb = new PasswordDeriveBytes(password, new byte[0]);
			des.Key = pdb.CryptDeriveKey("RC2", "MD5", 128, new byte[8]);
			byte[] encryptedBytes = Convert.FromBase64String(encryptedBase64);
			MemoryStream ms = new MemoryStream(encryptedBase64.Length);
			CryptoStream decStream = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);
			decStream.Write(encryptedBytes, 0, encryptedBytes.Length);
			decStream.FlushFinalBlock();
			byte[] plainBytes = new byte[ms.Length];
			ms.Position = 0;
			ms.Read(plainBytes, 0, (int)ms.Length);
			decStream.Close();
			return Encoding.UTF8.GetString(plainBytes);
		}		

	}
}
