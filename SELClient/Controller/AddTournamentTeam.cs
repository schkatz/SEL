using SELClient.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resfull.Models;
using RestSharp;
using System.Windows;

namespace SELClient.Controller
{
    class AddTournamentTeam : IAddTournamentTeam
    {
        public void AddTeam(List<Teams> teams, List<Tournaments> tournaments, string teamName, string tournamentName)
        {
            RestClient client = new RestClient("http://localhost:4249/api/");
            var request2 = new RestRequest("CheckIns", Method.POST);
            request2.RequestFormat = RestSharp.DataFormat.Json;
            var team = teams.Find(oe => oe.TeamName == teamName);
            var tournament = tournaments.Find(oe => oe.TournamentName == tournamentName);
            byte[] i = { 1 };
            if (team.TeamLeague_ID == tournament.TournamentLeague_ID)
            {
                request2.AddBody(new CheckIn
                {
                    CheckInTeam_ID = team.Team_ID,
                    CheckInTournament_ID = tournament.Tournament_ID,
                    CheckIn1 = i
                });

                client.Execute(request2);
            }
            else
            {
                MessageBox.Show("To nie drużyna dla tej ligi");

            }
        }

        public bool Check(List<Teams> teams, List<Tournaments> tournaments, List<CheckIn> checkins,string teamName,string tournamentName)
        {
            var query = from ci in checkins
                        join t in teams on ci.CheckInTeam_ID equals t.Team_ID
                        join T in tournaments on ci.CheckInTournament_ID equals T.Tournament_ID
                        where t.TeamName == teamName && T.TournamentName == tournamentName
                        select new
                        {
                            teamFind = t.TeamName
                        };
            var check = query.Count();
            if (check < 1)
            {
                return true;
            }
            return false;
        }
    }
}
