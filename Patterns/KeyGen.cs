/*
PoL - The polyhedral card game simulator
Copyright (C) 2011 Andrea Biagini

This program is free software; you can redistribute it and/or
modify it under the terms of the GNU General Public License
as published by the Free Software Foundation; either version 2
of the License, or (at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program; if not, write to the Free Software
Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
*/

using System;
using System.Security.Cryptography;

namespace Patterns
{
	/// <summary>
	/// make a key out of a password
	/// </summary>
	public sealed class KeyGen
	{
		private KeyGen()
		{}

		/// <summary>
		/// safe method to generate a key
		/// see the next override for more info
		/// </summary>
		public static byte[] DeriveKey(string password, int keySize, byte[] salt)
		{
			return DeriveKey(password, keySize, salt, 1024);
		}

		/// <summary>
		/// make a key out of a string password
		/// based on PBKDF1 (PKCS #5 v1.5)
		/// see http://www.faqs.org/rfcs/rfc2898.html
		/// if you do not want a salt set it to null
		/// recomended salt length must be between 8 and 16 bytes
		/// This implementation support keySize up to 32 bytes
		/// use salt = null, iterationCount = 1 for minimal strength
		/// </summary>
		public static byte[] DeriveKey(string password, int keySize, byte[] salt, int iterationCount)
		{
			if(keySize > 32) keySize = 32;
			byte[] data = ASCIIEncoder(password);
			if(salt != null)
			{
				byte[] temp = new byte[data.Length + salt.Length];
				Array.Copy(data, 0, temp, 0, data.Length);
				Array.Copy(salt, 0, temp, data.Length, salt.Length);
				data = temp;
			}
      var sha = SHA256Managed.Create();
			if(iterationCount <= 0) iterationCount = 1;
			for(int i = 0; i < iterationCount; i++)
			{
				data = sha.ComputeHash(data);
			}
      sha.Clear();
			byte[] key = new byte[keySize];
			Array.Copy(data, 0, key, 0, keySize);
			return key;
		}

		/// <summary>
		/// helper function not to rely on System.Text.ASCIIEncoder
		/// </summary>
		public static byte[] ASCIIEncoder(string s)
		{
			byte[] ascii = new byte[s.Length];
			for(int i = 0; i < s.Length; i++)
			{
				ascii[i] = (byte)s[i];
			}
			return ascii;
		}

	}//EPC
}
