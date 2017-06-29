using Resfull.Models;
using SELClient.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace SELClient
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Window
    {
        public List<Tournaments> ListaTurniejow;
        public List<Tournaments> ListaTurniejowLol;
        public List<Tournaments> ListaTurniejowCs;
        public List<Tournaments> ListaTurniejowHs;
        private string sqlFormattedDate;
        private DateTime myDateTime;

        public MainMenu()
        {
            InitializeComponent();

            GetTables table = new GetTables();
            var items = table.GetTournaments();

            ListaTurniejow = items.FindAll(oElement => oElement.TournamentDate >= DateTime.Now).OrderBy(oElement =>
            oElement.TournamentDate).Cast<Tournaments>().ToList();
            foreach (var lista in ListaTurniejow)
            {
                DateTime myDateTime = (DateTime)lista.TournamentDate;
                sqlFormattedDate = myDateTime.ToString("dd-MM-yyyy");
                listBox.Items.Add(lista.TournamentName + " Data: " + sqlFormattedDate);
            }

            ListaTurniejowLol = items.FindAll(oElement => oElement.TournamentLeague_ID.Equals(1)
            && oElement.TournamentDate >= DateTime.Now).OrderBy(oElement =>
            oElement.TournamentDate).Cast<Tournaments>().ToList();

            ListaTurniejowCs = items.FindAll(oElement => oElement.TournamentLeague_ID.Equals(2)
            && oElement.TournamentDate >= DateTime.Now).OrderBy(oElement =>
            oElement.TournamentDate).Cast<Tournaments>().ToList();

            ListaTurniejowHs = items.FindAll(oElement => oElement.TournamentLeague_ID.Equals(3)
            && oElement.TournamentDate >= DateTime.Now).OrderBy(oElement =>
            oElement.TournamentDate).Cast<Tournaments>().ToList();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ListBoxItem_Selected(object sender, RoutedEventArgs e)
        {
            listBox.Items.Clear();
            foreach (var lista in ListaTurniejowLol)
            {
                myDateTime = (DateTime)lista.TournamentDate;
                sqlFormattedDate = myDateTime.ToString("dd-MM-yyyy");
                listBox.Items.Add(lista.TournamentName + " Data: " + sqlFormattedDate);
            }
        }

        private void ListBoxItem_Selected_1(object sender, RoutedEventArgs e)
        {
            listBox.Items.Clear();
            foreach (var lista in ListaTurniejowCs)
            {
                myDateTime = (DateTime)lista.TournamentDate;
                sqlFormattedDate = myDateTime.ToString("dd-MM-yyyy");
                listBox.Items.Add(lista.TournamentName + " Data: " + sqlFormattedDate);
            }
        }

        private void ListBoxItem_Selected_2(object sender, RoutedEventArgs e)
        {
            listBox.Items.Clear();
            foreach (var lista in ListaTurniejowHs)
            {
                myDateTime = (DateTime)lista.TournamentDate;
                sqlFormattedDate = myDateTime.ToString("dd-MM-yyyy");
                listBox.Items.Add(lista.TournamentName + " Data: " + sqlFormattedDate);
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            OptionsAccounts oa = new OptionsAccounts();
            oa.Show();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            OptionsTeams ot = new OptionsTeams();
            ot.Show();
        }

        private void listBox_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            TournamentWindow tw = new TournamentWindow();
            int index = listBox.Items.IndexOf(listBox.SelectedValue.ToString());
            tw.tournyName = ListaTurniejow[index].TournamentName;
            tw.tournamentName.Content = tw.tournyName;
            myDateTime = (DateTime)ListaTurniejow[index].TournamentDate;
            sqlFormattedDate = myDateTime.ToString("dd-MM-yyyy");
            tw.labelOfTournamentDate.Content += " " + sqlFormattedDate;
            tw.labelOfTime.Content += " " + ListaTurniejow[index].TournamentTime;
            int policz = tw.checkIn.Count(oe => oe.Tournaments.TournamentName == tw.tournyName);
            tw.labelOfTeamsPart.Content += " " + policz;
            var query = from T in tw.teams
                        join Ci in tw.checkIn on T.Team_ID equals Ci.CheckInTeam_ID
                        join torney in tw.turney on Ci.CheckInTournament_ID equals torney.Tournament_ID
                        where torney.Tournament_ID == ListaTurniejow[index].Tournament_ID
                        select new
                        {
                            teamName = T.TeamName
                        };
            var list = query.Select(oe => oe.teamName).ToList();
            foreach (string items in list)
            {
                tw.listBoxTeams.Items.Add(items);
            }
            tw.Show();
        }
    }
}