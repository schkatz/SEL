using Resfull.Models;
using RestSharp;
using SELClient.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SELClient.Controller
{
   public class AddPlayerTeams : IAddPlayerTeams
    {
        public void AddTeam(string teamName, Teams team, Users user, int teamLeagueID)
        {

            RestClient client = new RestClient("http://localhost:4249/api/");
            var request = new RestRequest("Teams", Method.POST);
            var request2 = new RestRequest("PlayerTeams", Method.POST);
            request.RequestFormat = RestSharp.DataFormat.Json;
            request2.RequestFormat = RestSharp.DataFormat.Json;
            request.AddBody(new Teams
            {

                TeamLeague_ID = teamLeagueID,
                TeamName = teamName,
            });
            client.Execute(request);
            GetTables tables = new GetTables();
            var items2 = tables.GetTeams();
            team = items2.Find(oElement => oElement.TeamName == teamName);
            request2.AddBody(new PlayerTeams
            {

                PlayerTeamsTeam_ID = team.Team_ID,
                PlayerTeamsUser_ID = user.User_ID

            });
            client.Execute(request2);
        }
        public void AddPlayer(string teamName, Teams team, Users user,int teamLeagueID)
        {
            RestClient client = new RestClient("http://localhost:4249/api/");
            GetTables tables = new GetTables();
            var request2 = new RestRequest("PlayerTeams", Method.POST);
            request2.RequestFormat = RestSharp.DataFormat.Json;
            var items2 = tables.GetTeams();
            team = items2.Find(oElement => oElement.TeamName == teamName && oElement.TeamLeague_ID == teamLeagueID);
            request2.AddBody(new PlayerTeams
            {

                PlayerTeamsTeam_ID = team.Team_ID,
                PlayerTeamsUser_ID = user.User_ID

            });
            client.Execute(request2);
        }
    }
}
