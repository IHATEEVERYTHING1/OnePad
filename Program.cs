using System;
using System.Security.Cryptography;

public class Program
{
	public static void Main()
	{
		/*var cypher = new OnePadCipher("2 1 2 1 2 15 9 12 9 11 5 2 15 9 12 9 11 5 2 15 9 12 9 11 5 2 1 2 1 2 15 9 12 9 11 5".ToCharArray());
		cypher.Encrypt();
		Console.WriteLine(cypher.Key);
		cypher.Decrypt();
  		*/
	}
}

public class OnePadCipher
{
	private char[] _plainText;
	private char[] _key;
	private char[] _cipherText;
	public OnePadCipher(char[] plainText)
	{
		_plainText = plainText;
	}

	public void Encrypt()
	{
		_cipherText = new char[_plainText.Length]; // define _cipherText array
		_key = new char[_plainText.Length]; // define _key array
		
		for (int i = 0; i < _key.Length; i++)
		{
			var bytes = RandomNumberGenerator.GetBytes(sizeof(char));
			_key[i] += BitConverter.ToChar(bytes); // assign random value to key at index i.
		}
		
		for(int i = 0; i < _cipherText.Length; i++)
		{
			_cipherText[i] += (char)(((int)_key[i] + (int)_plainText[i]) % Char.MaxValue);
		}
		Console.WriteLine(_cipherText);
	}
	public void Decrypt()
	{
		_plainText = new char[_cipherText.Length];
		for(int i = 0; i < _cipherText.Length; i++)
		{
			_plainText[i] = (char)(((int)_cipherText[i] - (int)_key[i]) % Char.MaxValue);
		}
		Console.WriteLine(_plainText);
	}
	
	public string Key
	{
		get
		{
			return new string(_key);
		}
	}
}
