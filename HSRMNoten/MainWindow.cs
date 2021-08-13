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

namespace HSRMNoten
{
    public partial class MainWindow : Form
    {
        List<List<string>> list;
        string user;
        string pw;
        int i = 0;
        int rowCount;
        bool begin;
        bool dual;
        bool firefox;

        public MainWindow(List<List<string>> list, string user, string pw, bool dual, bool firefox)
        {
            this.list = list;
            this.user = user;
            this.pw = pw;
            this.dual = dual;
            this.firefox = firefox;
            SystemEvents.PowerModeChanged += SystemEvents_PowerModeChanged;
            InitializeComponent();           
        }

        private void Form1_Load(object sender, EventArgs e)
        {       
            dataGridView.ColumnCount = 3;
            dataGridView.Columns[0].Name = "Modul";
            dataGridView.Columns[1].Name = "Note";
            dataGridView.Columns[2].Name = "Credit Points";
            tbSetTimer.Text = (timer1.Interval / 60000).ToString();
            btnSetTimer.Enabled = false;
            fillList();
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
            list = firefox ? ReadHTML.parseTable(ReadHTML.navigateToGradesFirefox(user, pw, dual)) : ReadHTML.parseTable(ReadHTML.navigateToGradesChrome(user, pw, dual));
  
            if (begin)
            {
                rowCount = list.Count;
                begin = false;
            }

            if (rowCount < list.Count)
            {
                MessageBox.Show("Eine neue Note wurde eingetragen.", "Neue Note",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                begin = true;
            }

            fillList();
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }


        private void timer1_Tick(object sender, EventArgs e)
        {            
            i++;          
            refresh();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            lblLoading.Visible = true;
        }

        private void btnSetTimer_Click(object sender, EventArgs e)
        {
            if (tbSetTimer.Text.Equals("") || Int32.Parse(tbSetTimer.Text) < 5)
            {
                tbSetTimer.Text = "5";
                timer1.Interval = Int32.Parse(tbSetTimer.Text) * 60000;
                timer2.Interval = Int32.Parse(tbSetTimer.Text) * 60000;
                MessageBox.Show("Minimale Refresh Time ist 5 Minuten.", "Achtung");
                return;
            }

            btnSetTimer.Enabled = false;
            
            timer1.Interval = Int32.Parse(tbSetTimer.Text) * 60000;
            timer2.Interval = Int32.Parse(tbSetTimer.Text) * 60000;
        }


        private void MainWindow_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized && cbTray.Checked)
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
                timer2.Stop();
            }
            else if (e.Mode == PowerModes.Resume)
            {
                timer1.Start();
                timer2.Start();
            }
        }
    }
}
