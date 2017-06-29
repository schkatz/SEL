using Newtonsoft.Json;
using Registration.Model;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Registration
{
    public class Register : IExecute
    {
        public void Execute(string nick, string email, string pw, string pwcheck)
        {
            
            RestClient client = new RestClient("http://localhost:4249/api/");
            var request = new RestRequest("Users", Method.POST);
            request.RequestFormat = RestSharp.DataFormat.Json;
            var request2 = new RestRequest("Users", Method.GET);
            var response = client.Execute(request2);
            List<Users> items = JsonConvert.DeserializeObject<List<Users>>(response.Content);
            Users user = items.Find(u => u.UserNick == nick || u.UserEmailAdress == email);
            try
            {
                if (user.UserNick == nick)
                {
                    MessageBox.Show("Nick zajęty");
                }
                if (user.UserEmailAdress == email)
                {
                    MessageBox.Show("Email zajęty");
                }
            }
            catch (NullReferenceException)
            {
                if (pw == pwcheck)
                {
                    request.AddBody(new Users
                    {
                        UserRole_ID = 1,
                        UserNick = nick,
                        UserPassword = pw,
                        UserEmailAdress = email
                    });

                    client.Execute(request);
                    MessageBox.Show("Zarejestrowano");
                }
                else
                {
                    MessageBox.Show("Hasła się nie zgadzają");
                    
                }
            }
        }
    }
}
