using Newtonsoft.Json;
using Resfull.Models;
using RestSharp;
using SELClient.Interfaces;
using System;
using System.Collections.Generic;
using System.Windows;

namespace SELClient.Controller
{
    public class Login : ILogin
    {
        public bool LogIn(string nick, string pw)
        {
            GetTables kappa = new GetTables();
            var items = kappa.GetUsers();
            Users user = items.Find(oElement => oElement.UserNick == nick && oElement.UserPassword == pw);
            int iduser = user.User_ID;
            try
            {
                if (user.UserNick == nick && user.UserPassword == pw)
                {
                    MessageBox.Show("Witaj " + user.UserNick);
                    return true;
                }
                return false;
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Błędny Login lub Hasło");
                return false;
            }
        }
    }
}