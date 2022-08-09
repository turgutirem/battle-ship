using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Utilities
    {
        public static string getBinaryMessage(string message)
        {
            string binMessage = string.Empty;
            foreach (char ch in message)
            {
                binMessage += Convert.ToString((int)ch, 2).PadLeft(8, '0');
            }
            return binMessage;
        }
    }
}
