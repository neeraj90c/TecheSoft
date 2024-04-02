using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class APISettings
    {
        public string UploadPath { get; set; }
        public string ApiRootFolder { get; set; }
        public string UIRootFolder { get; set; }
        public string DocumentUploadBaseUrl { get; set; }
        public List<string> DriveLocations { get; set; }
    }
}
