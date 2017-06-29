using Newtonsoft.Json;
using Resfull.Models;
using RestSharp;
using SELClient.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SELClient
{
    /// <summary>
    /// Interaction logic for OptionsAccounts.xaml
    /// </summary>
    /// 
    
    public partial class OptionsAccounts : Window
    {
        string userNick;
        Users user;
        //public string _userNickname
        //{
        //    set { userNick = value; }
        //}

        public OptionsAccounts()
        {
            userNick = ((MainWindow)Application.Current.MainWindow).textBox.Text;
            InitializeComponent();
            RestClient client = new RestClient("http://localhost:4249/api/");
            var request = new RestRequest("Users", Method.GET);
            var response = client.Execute(request);
            List<Users> items = JsonConvert.DeserializeObject<List<Users>>(response.Content);
            user = items.Find(u => u.UserNick == userNick);
            
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            AddAccount acc = new AddAccount();
            acc.Add(comboBox.SelectionBoxItem.ToString(),textBoxAccName.Text,user);
        }

    }
}
