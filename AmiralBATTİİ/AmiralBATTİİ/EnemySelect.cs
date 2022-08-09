using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;
using System.Threading;

namespace AmiralBATTİİ
{
    public partial class EnemySelect : Form
    {
        public volatile System.Windows.Forms.Timer updateTimer;
        public string enemyNick = "";
        string enemyAddressIPAndPort = "";
        public Button agreeButton;
        public List<string> onlineEnemyList = new List<string>();
        public EnemySelect()
        {
            InitializeComponent();
            this.Text = "BattleShip - " + Program.userLogin;
        }
        private void SetTimer()
        {
            // Create a timer with a 15 seconds interval.
            updateTimer = new System.Windows.Forms.Timer();// (15000);//61000
            // Hook up the Elapsed event for the timer. 
            updateTimer.Interval = 5000;
            updateTimer.Tick += new EventHandler(OnEnemyTimedEvent);
            //pdateTimer.Elapsed += OnEnemyTimedEvent;
            //updateTimer.AutoReset = true;
            updateTimer.Enabled = true;
            GetEnemies();
        }
        private void OnEnemyTimedEvent(Object source, EventArgs e)//ElapsedEventArgs e)
        {
            GetEnemies();
            Thread.Sleep(200);
            updateTimer.Enabled = false;
            GetOffers();
        }
        public void GetEnemies()
        {
            //Send GetEnemies communique
            char comm = (char)13;
            string message = comm + " " + Program.userLogin + " <EOF>"; //enemies except me
            Program.client.Send(message);
            //Receive answer in program's thread           
        }
        public void GetOffers()
        {
            //Send Getoffers communique
            char comm = (char)7;
            string message = comm + " " + Program.userLogin + " <EOF>"; //enemies except me
            Program.client.Send(message);
            //Receive answer in program;s thread          
        }
        private void DGVAvailableEnemies_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int row = e.RowIndex;
                //Get clicked row enemy details
                enemyAddressIPAndPort = DGVAvailableEnemies.Rows[row].Cells[0].Value.ToString();
                enemyNick = DGVAvailableEnemies.Rows[row].Cells[1].Value.ToString();
                BConnect.Text = "Play with " + enemyNick;
            }
        }
        private void BConnect_Click(object sender, EventArgs e)
        {
            if (enemyNick != "")
            {
                updateTimer.Enabled = false;
                //Send Offer communique
                string message = (char)8 + " " + Program.userLogin + " " + enemyNick + " <EOF>"; //enemies except me
                Program.client.Send(message);
                //Receive answer in program's thread       
                agreeButton = (Button)sender;
                agreeButton.Enabled = false;
            }
        }
        private void CloseApp(object sender, FormClosingEventArgs e)
        {
            if (DialogResult != DialogResult.OK/*Program.dialog != 2*/)
            {
                DialogResult = DialogResult.No;
                //Program.dialog = 0;
                //Send CloseApp communique
                char comm = (char)14;
                string message = comm + " " + Program.userLogin + " " + enemyNick + " <EOF>";
                Program.client.Send(message);
            }
            if (updateTimer.Enabled == true)
            {
                updateTimer.Enabled = false;
            }
        }

        private void EnemySelect_Load(object sender, EventArgs e)
        {
            DGVAvailableEnemies.ClearSelection();
            SetTimer();
        }
    }
}
