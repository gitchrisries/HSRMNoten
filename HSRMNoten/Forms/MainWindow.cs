using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HSRMNoten.Classes;
using Microsoft.Win32;
using HSRMNoten.Forms;

namespace HSRMNoten
{
    public partial class MainWindow : Form
    {
        List<List<string>> list;
        string user;
        string pw;
        int i;
        int rowCount;
        bool dual;
        bool firefox;
        Dictionary<string,string> map;
        public bool trayChecked;
        public bool startUp;
        public bool autoLogin;
        public bool savedUserData;
        public bool minimized;

        public MainWindow(List<List<string>> list, string user, string pw, bool dual, bool firefox, int rowCount, bool minimized)
        {
            this.list = list;
            this.user = user;
            this.pw = pw;
            this.dual = dual;
            this.firefox = firefox;
            this.rowCount = rowCount;
            this.minimized = minimized;
            SystemEvents.PowerModeChanged += SystemEvents_PowerModeChanged;

            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            readUserData();

            dataGridView.ColumnCount = 3;
            dataGridView.Columns[0].Name = "Modul";
            dataGridView.Columns[1].Name = "Note";
            dataGridView.Columns[2].Name = "Credit Points";
            tbSetTimer.Text = (timer1.Interval / 60000).ToString();
            btnSetTimer.Enabled = false;
            if (rowCount < list.Count && rowCount > 0)
            {
                MessageBox.Show(new Form { TopMost = true }, "Eine neue Note wurde eingetragen.",
                  "Neue Note", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            fillList();

            if (map.ContainsKey("RowCount"))
            {
                UserDataIO.updateUserData(new string[] { "RowCount:" + rowCount });
            }
            else
            {
                UserDataIO.appendUserData(new string[] { "RowCount:" + rowCount });
            }

        }

        private void readUserData()
        {
            map = UserDataIO.readUserData();
            if (map.ContainsKey("TrayChecked") && map["TrayChecked"].Equals("True"))
            {
                trayChecked = true;
            }
            if (map.ContainsKey("RefreshTime"))
            {              
                tbSetTimer.Text = map["RefreshTime"];
                timer1.Interval = Int32.Parse(tbSetTimer.Text) * 60000;
                startUp = map["StartUp"].Equals("True") ? true : false;
                autoLogin = map["AutoLogin"].Equals("True") ? true : false;
                trayChecked = map["TrayChecked"].Equals("True") ? true : false;
                minimized = map["StartMinimized"].Equals("True") ? true : false;
            }
            savedUserData = map["SaveChecked"].Equals("True") ? true : false;

        }

        private void fillList()
        {
            lblLoading.Visible = true;
            foreach (var l in list)
            {
                string[] row = new string[3];
                
                if (l[1].Equals("Durchschnittsnote Deutschlandstipendium"))
                {                   
                    row[0] = l[1];
                    row[1] = l[3];
                    row[2] = l[5];
                }
                else
                {
                    row[0] = l[1];
                    row[1] = l[4];
                    row[2] = l[6];
                }
                dataGridView.Rows.Add(row); 
            }
            dataGridView.Rows[0].Cells[0].Selected = false;

            rowCount = dataGridView.Rows.Count;

            foreach (DataGridViewRow item in dataGridView.Rows)
            {
                if (item.Cells[1].Value != null && !item.Cells[1].Value.ToString().Any(char.IsDigit) 
                    && !item.Cells[1].Value.ToString().Equals(""))
                {
                    item.DefaultCellStyle.BackColor = Color.LightBlue;
                }

            }

            dataGridView.Rows[dataGridView.Rows.Count - 1].DefaultCellStyle.BackColor = Color.Beige;
            lblTimer.Text = "Refresh Counter: " + i;
            lblLoading.Visible = false;
        }


        private void btnRefresh_Click(object sender, EventArgs e)
        {          
            lblLoading.Visible = true;
            i++;
            refresh();
        }

        private void refresh()
        {
            dataGridView.Rows.Clear();
            this.Refresh();
            var newlist = firefox ? ReadHTML.parseTable(ReadHTML.navigateToGradesFirefox(user, pw, dual))
                : ReadHTML.parseTable(ReadHTML.navigateToGradesChrome(user, pw, dual));

            if (rowCount == 0)
            {
                rowCount = newlist.Count;
            }

            if (rowCount < newlist.Count)
            {

                string modul = "";
                foreach (var x in newlist)
                {
                    bool inList = false;
                    foreach (var y in list)
                    {
                        inList = inList || x[0].Equals(y[0]);
                    }
                    if (!inList)
                    {
                        modul = x[1];
                        break;
                    }
                }

                MessageBox.Show(new Form { TopMost = true }, "Neue Note für das Modul " + modul + ".",
                    "Neue Note", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                UserDataIO.updateUserData(new string[] { "RowCount:" + rowCount });
                rowCount = newlist.Count;
            }

            list = newlist;
            fillList();

        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            string refreshTime = timer1.Interval / 60000 + "";
            if (map.ContainsKey("RefreshTime"))
            {
                UserDataIO.updateUserData(new string[] { "TrayChecked:" + trayChecked, "RefreshTime:" + refreshTime,
                "AutoLogin:" + autoLogin, "StartUp:" + startUp, "StartMinimized:" + minimized});
            }
            else
            {
                UserDataIO.appendUserData(new string[] { "TrayChecked:" + trayChecked, "RefreshTime:" + refreshTime,
                    "AutoLogin:" + autoLogin, "StartUp:" + startUp, "StartMinimized:" + minimized});
                map = UserDataIO.readUserData();
            }

            Application.Exit();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            btnRefresh_Click(sender, e);
        }


        private void btnSetTimer_Click(object sender, EventArgs e)
        {
            if (tbSetTimer.Text.Equals("") || Int32.Parse(tbSetTimer.Text) < 5)
            {
                tbSetTimer.Text = "5";
                timer1.Interval = Int32.Parse(tbSetTimer.Text) * 60000;
                MessageBox.Show("Minimale Refresh Time ist 5 Minuten.", "Achtung");
                return;
            }

            btnSetTimer.Enabled = false;
            
            timer1.Interval = Int32.Parse(tbSetTimer.Text) * 60000;
        }



        private void MainWindow_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized && trayChecked)
            {
                Hide();
                notifyIcon.Visible = true;
            }
        }

        private void tbSetTimer_TextChanged(object sender, EventArgs e)
        {
            btnSetTimer.Enabled = true;
        }

        private void notifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon.Visible = false;
        }

        void SystemEvents_PowerModeChanged(object sender, PowerModeChangedEventArgs e)
        {
            if (e.Mode == PowerModes.Suspend)
            {
                timer1.Stop();
            }
            else if (e.Mode == PowerModes.Resume)
            {
                timer1.Start();
            }
        }

        private void btnOptions_Click(object sender, EventArgs e)
        {
            var options = new Options(trayChecked, startUp, autoLogin, savedUserData,minimized);
            options.Show();
        }

        public void writeOptions(bool tray, bool startup, bool autoLogin, bool minimized)
        {
            trayChecked = tray;
            startUp = startup;
            this.autoLogin = autoLogin;
            this.minimized = minimized;
        }

        private void MainWindow_Shown(object sender, EventArgs e)
        {
            if (minimized)
            {
                this.WindowState = FormWindowState.Minimized;
                notifyIcon.Visible = true;
                this.Hide();
            }
        }
    }
}
