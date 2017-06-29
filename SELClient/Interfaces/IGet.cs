using Resfull.Models;
using RestSharp;
using System.Collections.Generic;

namespace SELClient.Interfaces
{
    public interface IGet
    {
        List<Users> GetUsers();

        List<Tournaments> GetTournaments();

        List<Teams> GetTeams();

        List<Accounts> GetAccounts();
        List<CheckIn> GetCheckIn();
        List<PlayerTeams> GetPlayerTeams();
    }
}