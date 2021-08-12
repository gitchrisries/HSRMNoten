using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HSRMNoten.Classes;

namespace HSRMNoten
{
    public partial class Start : Form
    {

        string path = Environment.CurrentDirectory + "\\data.txt";

        public Start()
        {
            InitializeComponent();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            writeUserData();
            var list = ReadHTML.parseTable(ReadHTML.navigateToGrades(tbUser.Text,tbPassword.Text));
            if(list == null)
            {
                MessageBox.Show("Incorrect User Data");
                return;
            }
            var main = new MainWindow(list, tbUser.Text, tbPassword.Text);
            main.Show();
            this.Hide();           
        }

        private void Start_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void writeUserData()
        {
            string userData = tbUser.Text + "\n" + tbPassword.Text;
            File.WriteAllText(path, userData);
        }

        private void readUserData()
        {
            var list = new List<string>();
            
            using (StreamReader sr = new StreamReader(path))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    list.Add(line);
                }
            }

            tbUser.Text = list[0];
            tbPassword.Text = list[1];
        }

        private void Start_Load(object sender, EventArgs e)
        {
            if (File.Exists(path)) readUserData();
        }
    }
}
