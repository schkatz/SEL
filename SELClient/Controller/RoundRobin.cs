using SELClient.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SELClient.Controller
{
    class RoundRobin : IRoundRobin
    {
  

        public void RoundRobinRotateTeam(string[] lista)
        {
            string tmp = lista[lista.Length - 1];
            Array.Copy(lista, 0, lista, 1, lista.Length - 1);
            lista[0] = tmp;
        }

       public void RoundRobinGenerate(int num_teams, string[] lista, ListBox listBoxRounds)
        {
            for (int k = 0; k < num_teams / 2; k++)
            {
                if (num_teams % 2 == 0)
                {
                    listBoxRounds.Items.Add("Runda " + (k + 1));
                    listBoxRounds.Items.Add("---");
                    for (int j = 0; j < num_teams / 2; j++)
                    {
                        string wynik = lista[j] + " VS " + lista[(num_teams-1) - j];
                        listBoxRounds.Items.Add(wynik);
                        listBoxRounds.Items.Add("---");
                    }
                    RoundRobinRotateTeam(lista);
                }
                else
                {
                    listBoxRounds.Items.Add("Runda " + (k + 1));
                    listBoxRounds.Items.Add("---");
                    for (int j = 0; j < num_teams / 2; j++)
                    {
                        string wynik = lista[j + 1] + " VS " + lista[(num_teams-1) - j];

                        listBoxRounds.Items.Add(wynik);
                        listBoxRounds.Items.Add("---");

                    }
                    listBoxRounds.Items.Add(lista[0] + " BYE");
                    listBoxRounds.Items.Add("---");
                    RoundRobinRotateTeam(lista);
                }
            }
        }
    }
}
