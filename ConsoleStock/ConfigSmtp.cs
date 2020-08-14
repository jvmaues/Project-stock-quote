using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleStock
{
    class ConfigSmtp
    {
        public string email { get; set; }
        public int port { get; set; }
        public string host { get; set; }
        public string emailcredencial { get; set; }
        public string password { get; set; }
    }
}
