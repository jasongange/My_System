using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Infrastructures.Utilities.HashHelper
{
    public class HashHelper : IHashHelper
    {
        private readonly HashAlgorithm _hashAlgorithm;

        public HashHelper(HashAlgorithm hashAlgorithm)
        {
            _hashAlgorithm = hashAlgorithm;
        }

        public string ComputeHash(Stream inputStream)
        {
            return ByteArrayToHexadecimalString(_hashAlgorithm.ComputeHash(inputStream));
        }

        public string ComputeHash(byte[] buffer)
        {
            return ByteArrayToHexadecimalString(_hashAlgorithm.ComputeHash(buffer));
        }

        public string ComputeHash(string input)
        {
            return ByteArrayToHexadecimalString(_hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(input)));
        }

        public bool VerifyHash(string input, string hash)
        {
            return Compare(hash, ComputeHash(input));
        }

        public bool VerifyHash(Stream inputStream, string hash)
        {
            return Compare(hash, ComputeHash(inputStream));
        }

        public bool VerifyHash(byte[] buffer, string hash)
        {
            return Compare(hash, ComputeHash(buffer));
        }

        private bool Compare(string hash, string hashOfInput)
        {
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            return 0 == comparer.Compare(hashOfInput, hash);
        }

        private string ByteArrayToHexadecimalString(byte[] data)
        {
            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }
    }
}
