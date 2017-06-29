using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SELClient.Interfaces
{
   public interface ILogin
    {
        bool LogIn(string nick, string pw);
    }
}
