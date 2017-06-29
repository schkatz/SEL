using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SELClient.Interfaces
{
   public interface IRoundRobin
    {
        void RoundRobinGenerate(int num_teams, string[] lista, ListBox listBoxRounds);
        void RoundRobinRotateTeam(string[] lista);
    }
}
