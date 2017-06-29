using Resfull.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SELClient.Interfaces
{
   public interface IAddPlayerTeams
    {
        void AddTeam(string teamName, Teams team, Users user, int teamLeagueID);
        void AddPlayer(string teamName, Teams team, Users user, int teamLeagueID);
    }
}
