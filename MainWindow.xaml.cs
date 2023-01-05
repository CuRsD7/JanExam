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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace JanExam
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /* GITHUB LINK
         * https://github.com/CuRsD7/JanExam
         */

        List<Team> teams = new List<Team>();
        List<Player> frenchPlayers = new List<Player>();
        List<Player> spanishPlayers = new List<Player>();
        List<Player> italianPlayers = new List<Player>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            GetData();
        }

        private void GetData()
        {

            // Create Players

            //French players
            Player p1 = new Player() { Name = "Marie", ResultRecord = "WWDDL" };
            Player p2 = new Player() { Name = "Claude", ResultRecord = "DDDLW" };
            Player p3 = new Player() { Name = "Antoine", ResultRecord = "LWDLW" };

            //Italian players
            Player p4 = new Player() { Name = "Marco", ResultRecord = "WWDLL" };
            Player p5 = new Player() { Name = "Giovanni", ResultRecord = "LLLLD" };
            Player p6 = new Player() { Name = "Valentina", ResultRecord = "DLWWW" };

            //Spanish players
            Player p7 = new Player() { Name = "Maria", ResultRecord = "WWWWW" };
            Player p8 = new Player() { Name = "Jose", ResultRecord = "LLLLL" };
            Player p9 = new Player() { Name = "Pablo", ResultRecord = "DDDDD" };

            // Add Players to lists
            frenchPlayers.Add(p1);
            frenchPlayers.Add(p2);
            frenchPlayers.Add(p3);
            italianPlayers.Add(p4);
            italianPlayers.Add(p5);
            italianPlayers.Add(p6);
            spanishPlayers.Add(p7);
            spanishPlayers.Add(p8);
            spanishPlayers.Add(p9);

            foreach(Player player in frenchPlayers)
            {
                player.CalculateScore();
            }
            foreach (Player player in italianPlayers)
            {
                player.CalculateScore();
            }
            foreach (Player player in spanishPlayers)
            {
                player.CalculateScore();
            }

            // Create Teams
            Team t1 = new Team() { Name = "France", Players = frenchPlayers };
            Team t2 = new Team() { Name = "Italy", Players = italianPlayers};
            Team t3 = new Team() { Name = "Spain", Players = spanishPlayers};

            // Add to list
            teams.Add(t1);
            teams.Add(t2);
            teams.Add(t3);

            // Calculate Team points
            foreach(Team team in teams)
            {
                team.CalculateTeamScore();
            }

            // Display Teams in Listbox
            lbxTeams.ItemsSource = teams;
        }

        private void lbxTeams_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Determine what team is selected
            Team selected = lbxTeams.SelectedItem as Team;

            // Check if null
            if(selected != null)
            {
                // Update Display
                lbxPlayers.ItemsSource = selected.Players;
            }
        }

        private void btnWin_Click(object sender, RoutedEventArgs e)
        {
            // Determine what player & team is selected
            Player selected = lbxPlayers.SelectedItem as Player;
            Team selectedTeam = lbxTeams.SelectedItem as Team;

            // Check if null
            if(selected != null)
            {
                // Update Record
                selected.ResultRecord += "W";
                selected.CalculateScore();
                selectedTeam.CalculateTeamScore();
            }
        }

        private void btnLoss_Click(object sender, RoutedEventArgs e)
        {
            // Determine what player & team is selected
            Player selected = lbxPlayers.SelectedItem as Player;
            Team selectedTeam = lbxTeams.SelectedItem as Team;

            // Check if null
            if (selected != null)
            {
                // Update Record
                selected.ResultRecord += "L";
                selected.CalculateScore();
                selectedTeam.CalculateTeamScore();
            }
        }

        private void btnDraw_Click(object sender, RoutedEventArgs e)
        {
            // Determine what player & team is selected
            Team selectedTeam = lbxTeams.SelectedItem as Team;
            Player selected = lbxPlayers.SelectedItem as Player;

            // Check if null
            if (selected != null)
            {
                // Update Record
                selected.ResultRecord += "D";
                selected.CalculateScore();
                selectedTeam.CalculateTeamScore();
            }
        }
    }
}
