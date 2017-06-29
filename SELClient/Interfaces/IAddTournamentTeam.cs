using Resfull.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SELClient.Interfaces
{
    public interface IAddTournamentTeam
    {
        bool Check(List<Teams> teams, List<Tournaments> tournaments, List<CheckIn> checkins, string teamName, string tournamentName);
        void AddTeam(List<Teams> teams, List<Tournaments> tournaments, string teamName, string tournamentName);
    }
}
