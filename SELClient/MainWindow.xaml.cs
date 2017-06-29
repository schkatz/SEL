using Registration;
using RestSharp;
using SELClient.Controller;
using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;

namespace SELClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public RestClient client;
        private DirectoryInfo di;
        private Login login;

        public MainWindow()
        {
            InitializeComponent();
            di = new DirectoryInfo(".");
            login = new Login();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (login.LogIn(textBox.Text, passwordBox.Password))
            {
                this.Hide();
                MainMenu mm = new MainMenu();
                mm.Show();
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            foreach (FileInfo fi in di.GetFiles("Registration.dll"))
            {
                Assembly pluginAssembly = Assembly.LoadFrom(fi.FullName);
                foreach (Type pluginType in pluginAssembly.GetTypes())
                {
                    if (pluginType.GetInterface(typeof(IExecute).Name) != null)
                    {
                        IExecute ipe
                            = (IExecute)Activator.CreateInstance(pluginType);
                        string nick = textBoxNick.Text, email = textBoxEmail.Text, pw = passwordBoxReg.Password, pwcheck = passwordBoxRegCheck.Password;
                        Task.Factory.StartNew(() => ipe.Execute(nick, email, pw, pwcheck));
                    }
                }
            }
        }
    }
}