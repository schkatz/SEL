using SELClient.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Resfull.Models;
using Newtonsoft.Json;

namespace SELClient.Controller
{
    public class GetTables : IGet
    {
        public List<Users> GetUsers()
        {
            RestClient client = new RestClient("http://localhost:4249/api/");
            var request = new RestRequest("Users", Method.GET);
            var response = client.Execute(request);
            List<Users> items = JsonConvert.DeserializeObject<List<Users>>(response.Content);
            if (items.Count < 1)
                throw new ArgumentOutOfRangeException("brak danych w bazie");
            return items;
        }

        public List<Accounts> GetAccounts()
        {
            RestClient client = new RestClient("http://localhost:4249/api/");
            var request = new RestRequest("Accounts", Method.GET);
            var response = client.Execute(request);
            List<Accounts> items = JsonConvert.DeserializeObject<List<Accounts>>(response.Content);
            if (items.Count < 1)
                throw new ArgumentOutOfRangeException("brak danych w bazie");
            return items; 
        }

        public List<Teams> GetTeams()
        {
            RestClient client = new RestClient("http://localhost:4249/api/");
            var request = new RestRequest("Teams", Method.GET);
            var response = client.Execute(request);
            List<Teams> items = JsonConvert.DeserializeObject<List<Teams>>(response.Content);
            if (items.Count < 1)
                throw new ArgumentOutOfRangeException("brak danych w bazie");
            return items;
        }

        public List<Tournaments> GetTournaments()
        {
            RestClient client = new RestClient("http://localhost:4249/api/");
            var request = new RestRequest("Tournaments", Method.GET);
            var response = client.Execute(request);
            List<Tournaments> items = JsonConvert.DeserializeObject<List<Tournaments>>(response.Content);
            if (items.Count < 1)
                throw new ArgumentOutOfRangeException("brak danych w bazie");
            return items;
        }

        public List<CheckIn> GetCheckIn()
        {
            RestClient client = new RestClient("http://localhost:4249/api/");
            var request = new RestRequest("CheckIns", Method.GET);
            var response = client.Execute(request);
            List<CheckIn> items = JsonConvert.DeserializeObject<List<CheckIn>>(response.Content);
            if (items.Count < 1)
                throw new ArgumentOutOfRangeException("brak danych w bazie");
            return items;
        }

        public List<PlayerTeams> GetPlayerTeams()
        {
            RestClient client = new RestClient("http://localhost:4249/api/");
            var request = new RestRequest("PlayerTeams", Method.GET);
            var response = client.Execute(request);
            List<PlayerTeams> items = JsonConvert.DeserializeObject<List<PlayerTeams>>(response.Content);
            if (items.Count < 1)
                throw new ArgumentOutOfRangeException("brak danych w bazie");
            return items;
        }
    }
}
