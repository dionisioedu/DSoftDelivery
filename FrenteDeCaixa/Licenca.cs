using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using DSKey;
using DSoftLogger;
using DSoftModels;

namespace FrenteDeCaixa
{
	public static class Crypto
	{
		#region Fields

		private static readonly byte[] salt = Encoding.ASCII.GetBytes("Ent3r your oWn S@lt v@lu# h#r3");

		#endregion Fields

		#region Methods

		public static byte[] Decrypt(byte[] encryptedObject, string encryptionPassword)
		{
			var algorithm = GetAlgorithm(encryptionPassword);

			byte[] descryptedBytes;
			using (ICryptoTransform decryptor = algorithm.CreateDecryptor(algorithm.Key, algorithm.IV))
			{
				descryptedBytes = InMemoryCrypt(encryptedObject, decryptor);
			}

			return descryptedBytes;
		}

		public static byte[] Encrypt(byte[] objectToEncrypt, string encryptionPassword)
		{
			var algorithm = GetAlgorithm(encryptionPassword);

			byte[] encryptedBytes;
			using (ICryptoTransform encryptor = algorithm.CreateEncryptor(algorithm.Key, algorithm.IV))
			{
				encryptedBytes = InMemoryCrypt(objectToEncrypt, encryptor);
			}

			return encryptedBytes;
		}

		// Defines a RijndaelManaged algorithm and sets its key and Initialization Vector (IV)
		// values based on the encryptionPassword received.
		private static RijndaelManaged GetAlgorithm(string encryptionPassword)
		{
			// Create an encryption key from the encryptionPassword and salt.
			var key = new Rfc2898DeriveBytes(encryptionPassword, salt);

			// Declare that we are going to use the Rijndael algorithm with the key that we've just got.
			var algorithm = new RijndaelManaged();
			int bytesForKey = algorithm.KeySize / 8;
			int bytesForIV = algorithm.BlockSize / 8;
			algorithm.Key = key.GetBytes(bytesForKey);
			algorithm.IV = key.GetBytes(bytesForIV);

			return algorithm;
		}

		// Performs an in-memory encrypt/decrypt transformation on a byte array.
		private static byte[] InMemoryCrypt(byte[] data, ICryptoTransform transform)
		{
			MemoryStream memory = new MemoryStream();
			using (Stream stream = new CryptoStream(memory, transform, CryptoStreamMode.Write))
			{
				stream.Write(data, 0, data.Length);
			}

			return memory.ToArray();
		}

		#endregion Methods
	}

	public class Licenca : ILicenca
	{
		#region Fields

		private static Licenca _instance;

		private DSKey.DSKey dskey;
		private bool _demo = true;

		#endregion Fields

		#region Constructors

		public Licenca()
		{
			LerLicenca();
		}

		#endregion Constructors

		#region Properties

		public static Licenca Instance
		{
			get
			{
				if (_instance == null)
					_instance = new Licenca();

				return _instance;
			}
		}

		public string CNPJ
		{
			get { return dskey.CNPJ; }
		}

		public bool Demo
		{
			get { return _demo; }
		}

		public int DiasRestantes
		{
			get
			{
				return (Validade - DateTime.Now).Days;
			}
		}

		public string Endereco
		{
			get { return dskey.Endereco; }
		}

		public bool Expirou
		{
			get
			{
				return DateTime.Now > Validade;
			}
		}

		public string Nome
		{
			get { return dskey.Nome; }
		}

		public int Numero
		{
			get { return dskey.Numero; }
		}

		public string Telefone
		{
			get { return dskey.Telefone; }
		}

		public DateTime Validade
		{
			get { return dskey.Validade; }
		}

		#endregion Properties

		#region Methods

		public void LerLicenca()
		{
			dskey = Generator.Read();

			if (dskey != null)
				_demo = false;
		}

		#endregion Methods
	}

	class Generator
	{
		#region Fields

		private static string password = "dsoft2008";
		private static string path = "C:\\DSoft\\Key\\dsoft.key";

		#endregion Fields

		#region Methods

		public static bool Generate(DSKey.DSKey key)
		{
			byte[] encrypted = Crypto.Encrypt(ObjectToByteArray((Object)key), password);

			File.WriteAllBytes(path, encrypted);

			return true;
		}

		public static DSKey.DSKey Read()
		{
			try
			{
				byte[] encrypted = File.ReadAllBytes(path);

				byte[] bytes = Crypto.Decrypt(encrypted, password);

				return (DSKey.DSKey)ByteArrayToObject(bytes);
			}
			catch (Exception e)
			{
				Logger.Instance.Error(e);

				return null;
			}
		}

		// Convert a byte array to an Object
		private static Object ByteArrayToObject(byte[] arrBytes)
		{
			MemoryStream memStream = new MemoryStream();

			BinaryFormatter binForm = new BinaryFormatter();

			memStream.Write(arrBytes, 0, arrBytes.Length);

			memStream.Seek(0, SeekOrigin.Begin);

			Object obj = (Object)binForm.Deserialize(memStream);

			return obj;
		}

		// Convert an object to a byte array
		private static byte[] ObjectToByteArray(Object obj)
		{
			if(obj == null)
				return null;

			BinaryFormatter bf = new BinaryFormatter();

			MemoryStream ms = new MemoryStream();

			bf.Serialize(ms, obj);

			return ms.ToArray();
		}

		#endregion Methods
	}
}