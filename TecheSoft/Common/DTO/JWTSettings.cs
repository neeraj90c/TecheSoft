using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class JWTSettings
    {
        public string EncryptionKey { get; set; }
        public string TokenExpiryMinute { get; set; }
        public string AppSecret { get; set; }
    }
}
