using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ADW05_TAKE_HOME.Form1;

namespace ADW05_TAKE_HOME
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public class Team
        {
            public string teamName { get; set; }
            public string teamCountry { get; set; }
            public string teamCity { get; set; }

            private List<Player> player = new List<Player>();

            public void addPlayer(string pNum, string pName, string pPos)
            {
                Player pemain = new Player();
                pemain.playerNum = pNum;
                pemain.playerName = pName;
                pemain.playerPos = pPos;
                player.Add(pemain);
            }
            public List<Player> Players
            {
                get { return player; }
                set { player = value; }
            }
        }
        public class Player
        {
            public string playerName { get; set; }
            public string playerNum { get; set; }
            public string playerPos { get; set; }
        }

        public List<Team> team = new List<Team>();

        private void Form1_Load(object sender, EventArgs e)
        {
            //urutkan listBox
            listBox_all.Sorted = true;
            //tambah pemain ke dalam comboBox masing-masing club
            Team pertamax = new Team();
            pertamax.teamName = "Arsenal";
            pertamax.teamCountry = "England";
            pertamax.teamCity = "Islington";
            Team inputTeamPlayer = pertamax;
            inputTeamPlayer.addPlayer("01", "Bernd Leo", "GK");
            inputTeamPlayer.addPlayer("02", "Hector Bellerin", "DF");
            inputTeamPlayer.addPlayer("03", "Kieran Tierny", "DF");
            inputTeamPlayer.addPlayer("04", "Ben White", "DF");
            inputTeamPlayer.addPlayer("05", "Thomas Partey", "MF");
            inputTeamPlayer.addPlayer("06", "Gabriel Magalhaes", "DF");
            inputTeamPlayer.addPlayer("07", "Bukayo Saka", "MF");
            inputTeamPlayer.addPlayer("34", "Granit Xhaka", "MF");
            inputTeamPlayer.addPlayer("08", "Martin Odegaard", "MF");
            inputTeamPlayer.addPlayer("14", "Pierre-Emerick Aubameyang", "FW");
            inputTeamPlayer.addPlayer("09", "Alexandre Lacazette", "FW");
            team.Add(inputTeamPlayer);
            Team keduax = new Team();
            keduax.teamName = "Chelsea";
            keduax.teamCountry = "England";
            keduax.teamCity = "Fulham";
            inputTeamPlayer = keduax;
            inputTeamPlayer.addPlayer("16", "Edouard Mendy", "GK");
            inputTeamPlayer.addPlayer("05", "Jorginho", "MF");
            inputTeamPlayer.addPlayer("17", "Mateo Kovacic", "MF");
            inputTeamPlayer.addPlayer("07", "N'Golo Kante", "MF");
            inputTeamPlayer.addPlayer("19", "Mason Mount", "MF");
            inputTeamPlayer.addPlayer("11", "Timo Werner", "FW");
            inputTeamPlayer.addPlayer("10", "Christian Pulistic", "FW");
            inputTeamPlayer.addPlayer("22", "Hakim Ziyech", "FW");
            inputTeamPlayer.addPlayer("20", "Callum-Hudson Odoi", "FW");
            inputTeamPlayer.addPlayer("06", "Thiago Silva", "DF");
            inputTeamPlayer.addPlayer("29", "Kai Havertz", "FW");
            team.Add(inputTeamPlayer);
            Team ketigax = new Team();
            ketigax.teamName = "Paris Saint German";
            ketigax.teamCountry = "France";
            ketigax.teamCity = "Paris";
            inputTeamPlayer = ketigax;
            inputTeamPlayer.addPlayer("07", "Kylian Mbappe", "FW");
            inputTeamPlayer.addPlayer("10", "Neymar Jr.", "FW");
            inputTeamPlayer.addPlayer("01", "Keylor Navas", "GK");
            inputTeamPlayer.addPlayer("21", "Ander Herrera", "MF");
            inputTeamPlayer.addPlayer("14", "Danilo Pereira", "MF");
            inputTeamPlayer.addPlayer("09", "Mauro Icardi", "FW");
            inputTeamPlayer.addPlayer("04", "Sergio Ramos", "DF");
            inputTeamPlayer.addPlayer("06", "Marco Verrati", "MF");
            inputTeamPlayer.addPlayer("08", "Leandro Paredes", "MF");
            inputTeamPlayer.addPlayer("30", "Lionel Messi", "FW");
            inputTeamPlayer.addPlayer("44", "Hugo Ekitike", "FW");
            team.Add(inputTeamPlayer);
        }

        private void comboBox_ChooseCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox_ChooseTeam.Items.Clear();
            //simpan hasil select item sebagai string
            string simpanNama = comboBox_ChooseCountry.SelectedItem.ToString();
            foreach (Team x in team)
            {
                if (x.teamCountry == simpanNama)
                {
                    comboBox_ChooseTeam.Items.Add(x.teamName);
                }
            }
        }

        private void comboBox_ChooseTeam_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox_all.Items.Clear();
            string simpanNama = comboBox_ChooseTeam.SelectedItem.ToString();
            Team tim = new Team();
            foreach (Team x in team)
            {
                if (x.teamName == simpanNama)
                {
                    tim = x;
                }
            }
            foreach (Player player in tim.Players)
            {
                //masukan player ke dalam listbox sesuai dengan tim masing-masing
                string inputPlayer = String.Format("({0}) {1}, {2}", player.playerNum, player.playerName, player.playerPos);
                listBox_all.Items.Add(inputPlayer);
            }
        }

        private void button_addTeam_Click(object sender, EventArgs e)
        {
            //cek apakah textbox kosong atau tidak
            if (string.IsNullOrEmpty(textBox_TeamName.Text) || string.IsNullOrEmpty(textBox_TeamCountry.Text) || string.IsNullOrEmpty(textBox_TeamCity.Text))
            {
                string a = "All Fields Need to be Filled!";
                MessageBox.Show(a, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //tampung string yang diinput di textbox
                string name = textBox_TeamName.Text;
                string city = textBox_TeamCity.Text;
                string country = textBox_TeamCountry.Text;
                bool isExists = false;
                //cek apakah sudah ada/tidak team-nya
                foreach (Team x in team)
                {
                    if (x.teamName == name)
                    {
                        isExists = true;
                        break;
                    }
                }
                //jika isExists = true, maka error
                if (isExists)
                {
                    MessageBox.Show("Team already exists!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                //jika !isExists, maka input data
                if (!isExists)
                {
                    Team inputTeamPlayer = new Team();
                    inputTeamPlayer.teamName = name;
                    inputTeamPlayer.teamCity = city;
                    inputTeamPlayer.teamCountry = country;
                    team.Add(inputTeamPlayer);
                }
                comboBox_ChooseCountry.Items.Clear();

                foreach (Team x in team)
                {
                    if (comboBox_ChooseCountry.Items.Contains(x.teamCountry) == false)
                    {
                        comboBox_ChooseCountry.Items.Add(x.teamCountry);
                    }
                }
                textBox_TeamCity.Clear();
                textBox_TeamCountry.Clear();
                textBox_TeamName.Clear();
            }
        }

        private void button_addPlayer_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_PlayerName.Text) || string.IsNullOrEmpty(textBox_PlayerNumber.Text) || string.IsNullOrEmpty(comboBox_PlayerPosition.SelectedItem.ToString()))
            {
                string a = "All Fields Need to be Filled!";
                MessageBox.Show(a, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //simpan selected team pada cmb box sbg string
                string selectedTeam = comboBox_ChooseTeam.SelectedItem.ToString();
                foreach (Team x in team)
                {
                    if (x.teamName == selectedTeam)
                    {
                        bool isNumAvailable = false;
                        bool isNameAvailable = false;
                        foreach (Player player in x.Players)
                        {
                            if (player.playerNum == textBox_PlayerNumber.Text)
                            {
                                isNumAvailable = true;
                                break;
                            }
                            if (player.playerName == textBox_PlayerName.Text)
                            {
                                isNameAvailable = true;
                                break;
                            }
                        }
                        if (!isNumAvailable && !isNameAvailable)
                        {
                            x.addPlayer(textBox_PlayerNumber.Text, textBox_PlayerName.Text, comboBox_PlayerPosition.SelectedItem.ToString());
                        }
                        else if (isNumAvailable == true)
                        {
                            MessageBox.Show("Player Number Already Exists!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else if (isNameAvailable == true)
                        {
                            MessageBox.Show("Player Name Already Exists!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                listBox_all.Items.Clear();
                //simpan selected team sebagai string
                string simpanTeam = comboBox_ChooseTeam.SelectedItem.ToString();
                Team tim = new Team();
                foreach (Team p in team)
                {
                    if (p.teamName == simpanTeam)
                    {
                        tim = p;
                    }
                }
                foreach (Player player in tim.Players)
                {

                    string inputListBox = String.Format("({0}) {1}, {2}", player.playerNum, player.playerName, player.playerPos);
                    listBox_all.Items.Add(inputListBox);
                }
            }
            textBox_PlayerName.Clear();
            textBox_PlayerNumber.Clear();
        }

        private void button_remove_Click(object sender, EventArgs e)
        {
            string simpanTeam = comboBox_ChooseTeam.SelectedItem.ToString();

            foreach (Team x in team)
            {
                if (x.teamName == simpanTeam)
                {
                    if (x.Players.Count <= 11)
                    {
                        MessageBox.Show("Unable to Remove Players if Players Less Than 11", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        continue;
                    }
                }
                string[] splitCommas = listBox_all.SelectedItem.ToString().Split(',');
                string[] splitBracket = splitCommas[0].Split(')');
                string num = splitBracket[0].Substring(0);
                string name = splitBracket[1].Substring(1);
                bool isTrue = true;

                while(isTrue)
                {
                    foreach (Player player in x.Players)
                    {
                        if (player.playerName == name)
                        {
                            x.Players.Remove(player);
                            isTrue = false;
                            break;
                        }
                    }
                    break;
                }
            }
            listBox_all.Items.Clear();
            string simpanNama2 = comboBox_ChooseTeam.SelectedItem.ToString();
            Team tim = new Team();
            foreach (Team p in team)
            {
                if (p.teamName == simpanNama2)
                {
                    tim = p;
                }
            }
            foreach (Player player in tim.Players)
            {
                string inputListBox = String.Format("({0}) {1}, {2}", player.playerNum, player.playerName, player.playerPos);
                listBox_all.Items.Add(inputListBox);

            }
        }
    }
}
