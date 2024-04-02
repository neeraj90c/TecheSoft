using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptDecrypt.Interface
{
    public interface IEncryptDecrypt
    {
        string EncryptValue(string inputValue);
        string EncryptValue(string inputValue, string encryptionKey);
        string DecryptValue(string inputValue);
        string DecryptValue(string inputValue, string encryptionKey);
    }
}
