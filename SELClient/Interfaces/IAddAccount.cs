using Resfull.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SELClient.Interfaces
{
   public interface IAddAccount
    {
         void Add(string cb, string tb, Users user);
    }
}
