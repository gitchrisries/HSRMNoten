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
        public MainWindow(List<List<string>> list, string user, string pw)
        {
            this.list = list;
            this.user = user;
            this.pw = pw;
            InitializeComponent();           
        }

        private void Form1_Load(object sender, EventArgs e)
        {       
            dataGridView1.ColumnCount = 3;
            dataGridView1.Columns[0].Name = "Modul";
            dataGridView1.Columns[1].Name = "Note";
            dataGridView1.Columns[2].Name = "Credit Points";
            tbSetTimer.Text = (timer1.Interval / 1000).ToString();
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
                dataGridView1.Rows.Add(row); 
            }

            rowCount = dataGridView1.Rows.Count;

            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                if (item.Cells[1].Value != null && !item.Cells[1].Value.ToString().Any(char.IsDigit) 
                    && !item.Cells[1].Value.ToString().Equals(""))
                {
                    item.DefaultCellStyle.BackColor = Color.Yellow;
                }
            }

            dataGridView1.Rows[dataGridView1.Rows.Count - 2].DefaultCellStyle.BackColor = Color.Beige;
            lblTimer.Text = "Loaded " + i + " times";
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            lblLoading.Visible = false;

        }


        private void btnRefresh_Click(object sender, EventArgs e)
        {
            refresh();          
        }

        private void refresh()
        {
            dataGridView1.Rows.Clear();
            list = ReadHTML.parseTable(ReadHTML.navigateToGrades(user, pw));
            
            if (begin)
            {
                rowCount = list.Count;
                begin = false;
            }

            if (rowCount < list.Count)
            {
                MessageBox.Show("Eine neue Note wurde eingetragen.", "Neue Note",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            }

            fillList();
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }


        private void MainWindow_Resize(object sender, EventArgs e)
        {
  
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
            }
        }

        private void notifyIcon_MouseDoubleClick_1(object sender, MouseEventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {            
            i++;          
            refresh();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            this.dataGridView1.BackgroundColor = Color.DarkGray;
            lblLoading.Visible = true;
        }

        private void btnSetTimer_Click(object sender, EventArgs e)
        {
            if (Int32.Parse(tbSetTimer.Text) < 10)
            {
                tbSetTimer.Text = "10";
                return;
            }
            
            timer1.Interval = Int32.Parse(tbSetTimer.Text) * 1000;
            timer2.Interval = Int32.Parse(tbSetTimer.Text) * 1000;
        }
    }
}
