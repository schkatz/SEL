using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Registration
{
    public interface IExecute
    {
        void Execute(string nick,string email, string pw, string pwcheck);
    }
}
