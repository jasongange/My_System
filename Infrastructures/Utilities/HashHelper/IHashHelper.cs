using System.IO;

namespace Infrastructures.Utilities.HashHelper
{
    public interface IHashHelper
    {
        string ComputeHash(string input);
        string ComputeHash(Stream inputStream);
        string ComputeHash(byte[] inputStream);

        bool VerifyHash(string input, string hash);
        bool VerifyHash(Stream inputStream, string hash);
        bool VerifyHash(byte[] buffer, string hash);
    }
}
