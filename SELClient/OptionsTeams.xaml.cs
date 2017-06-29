using Resfull.Models;
using SELClient.Controller;
using System.Windows;

namespace SELClient
{
    /// <summary>
    /// Interaction logic for OptionsTeams.xaml
    /// </summary>
    public partial class OptionsTeams : Window
    {
        private Teams team;
        private string userNick;
        private Users user;
        private GetTables table;
        private AddPlayerTeams apt;

        public OptionsTeams()
        {
            InitializeComponent();
            table = new GetTables();
            userNick = ((MainWindow)Application.Current.MainWindow).textBox.Text;
            var users = table.GetUsers();
            user = users.Find(oElement => oElement.UserNick == userNick);
            apt = new AddPlayerTeams();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            var items = table.GetTeams();
            team = items.Find(o => o.TeamName == textBoxName.Text);
            if (team == null)
            {
                MessageBox.Show("Team: " + textBoxName.Text + " nie istnieje.");
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Chcesz dołączyć do drużyny? " + textBoxName.Text, "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    if (comboBoxGame.SelectionBoxItem.ToString() == "League of Legends")
                    {
                        apt.AddPlayer(textBoxName.Text, team, user, 1);
                    }
                    if (comboBoxGame.SelectionBoxItem.ToString() == "Counter-Strike: Global Offensive")
                    {
                        apt.AddPlayer(textBoxName.Text, team, user, 2);
                    }
                    if (comboBoxGame.SelectionBoxItem.ToString() == "Hearthstone")
                    {
                        apt.AddPlayer(textBoxName.Text, team, user, 3);
                    }
                }
            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            var items = table.GetTeams();
            team = items.Find(oElement => oElement.TeamName == textBoxNamesD.Text);
            if (team == null)
            {
                MessageBoxResult result = MessageBox.Show("Chcesz założyć drużynę? " + textBoxName.Text, "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    if (comboBoxGamesD.SelectionBoxItem.ToString() == "League of Legends")
                    {
                        apt.AddTeam(textBoxNamesD.Text, team, user, 1);
                    }
                    if (comboBoxGamesD.SelectionBoxItem.ToString() == "Counter-Strike: Global Offensive")
                    {
                        apt.AddTeam(textBoxNamesD.Text, team, user, 2);
                    }
                    if (comboBoxGamesD.SelectionBoxItem.ToString() == "Hearthstone")
                    {
                        apt.AddTeam(textBoxNamesD.Text, team, user, 3);
                    }
                }
            }
            else
            {
                MessageBox.Show("Dana drużyna już istnieje");
            }
        }
    }
}