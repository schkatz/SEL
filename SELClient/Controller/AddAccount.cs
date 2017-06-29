using Newtonsoft.Json;
using Resfull.Models;
using RestSharp;
using SELClient.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SELClient.Controller
{
   public class AddAccount : IAddAccount
    {
        public void Add(string cb,string tb,Users user)
        {
            string gameName = cb;
            RestClient client = new RestClient("http://localhost:4249/api/");
            var request = new RestRequest("Games", Method.POST);
            request.RequestFormat = RestSharp.DataFormat.Json;
            request.AddBody(new Games
            {
                GameNick = tb,
                GameName = gameName

            });
            client.Execute(request);

            var request3 = new RestRequest("Games", Method.GET);

            var response = client.Execute(request3);
            List<Games> items = JsonConvert.DeserializeObject<List<Games>>(response.Content);
            Games game = items.Find(g => g.GameName == gameName && g.GameNick == tb);
            var request2 = new RestRequest("Accounts", Method.POST);
            request2.RequestFormat = RestSharp.DataFormat.Json;
            request2.AddBody(new Accounts
            {
                AccountUser_ID = user.User_ID,
                AccountGame_ID = game.Game_ID
            });

            client.Execute(request2);
        }
    }
}
