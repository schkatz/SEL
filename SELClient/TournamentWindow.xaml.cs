using Resfull.Models;
using SELClient.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace SELClient
{
    /// <summary>
    /// Interaction logic for TournamentWindow.xaml
    /// </summary>
    public partial class TournamentWindow : Window
    {
        private GetTables table;
        private AddTournamentTeam aTt;
        private RoundRobin rr;
        private string nick;
        public string tournyName;
        public List<Users> users;
        public List<Tournaments> turney;
        public List<PlayerTeams> playerTeams;
        public List<CheckIn> checkIn;
        public List<Teams> teams;

        public TournamentWindow()
        {
            InitializeComponent();
            table = new GetTables();
            aTt = new AddTournamentTeam();
            rr = new RoundRobin();
            nick = ((MainWindow)Application.Current.MainWindow).textBox.Text;
            turney = table.GetTournaments();
            users = table.GetUsers();
            playerTeams = table.GetPlayerTeams();
            checkIn = table.GetCheckIn();
            teams = table.GetTeams();
            var query = from U in users
                        join PT in playerTeams on U.User_ID equals PT.PlayerTeamsUser_ID
                        join T in teams on PT.PlayerTeamsTeam_ID equals T.Team_ID
                        where U.UserNick == nick
                        select new
                        {
                            teamName = T.TeamName
                        };
            var lista = query.Select(oe => oe.teamName).ToList();
            foreach (string element in lista)
            {
                comboBoxTeams.Items.Add(element);
            }
        }

        private void Join_Click(object sender, RoutedEventArgs e)
        {
            string teamName = comboBoxTeams.SelectedValue.ToString();
            Task.Factory.StartNew(() =>
            {
                if (aTt.Check(teams, turney, checkIn, teamName, tournyName))
                {
                    aTt.AddTeam(teams, turney, teamName, tournyName);
                }
                else
                {
                    MessageBox.Show("Dana drużyna jest już zapisana w turnieju");
                }
            });

        }

        private void buttonRandomRounds_Click(object sender, RoutedEventArgs e)
        {
            var query = from ci in checkIn
                        join t in teams on ci.CheckInTeam_ID equals t.Team_ID
                        join T in turney on ci.CheckInTournament_ID equals T.Tournament_ID
                        where T.TournamentName == tournyName
                        select new
                        {
                            teamFind = t.TeamName
                        };
            int i = query.Count();
            var lista = query.Select(oe => oe.teamFind).ToArray();
            rr.RoundRobinGenerate(i, lista, listBoxRounds);
        }
    }
}