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

        string path = Environment.CurrentDirectory + "\\userdata.txt";

        public Start()
        {
            InitializeComponent();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            if(cbSaveUserData.Checked) writeUserData();
            lblgetData.Visible = true;
            var list = rbFirefox.Checked ? ReadHTML.parseTable(ReadHTML.navigateToGradesFirefox(tbUser.Text, tbPassword.Text, rbDual.Checked)) :
                ReadHTML.parseTable(ReadHTML.navigateToGradesChrome(tbUser.Text, tbPassword.Text, rbDual.Checked));
            if (list == null)
            {
                lblgetData.Visible = false;
                MessageBox.Show("Incorrect User Data");
                return;
            }
            var main = new MainWindow(list, tbUser.Text, tbPassword.Text, rbDual.Checked, rbFirefox.Checked);
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

        private void rbNonDual_CheckedChanged(object sender, EventArgs e)
        {
            if(rbNonDual.Checked != true)
            {
                rbDual.Checked = true;
                rbNonDual.Checked = false;
            }
            

        }

        private void rbDual_CheckedChanged(object sender, EventArgs e)
        {
            if (rbDual.Checked != true)
            {
                rbDual.Checked = false;
                rbNonDual.Checked = true;
            }
        }

        private void rbFirefox_CheckedChanged(object sender, EventArgs e)
        {

            if (rbFirefox.Checked != true)
            {
                rbChrome.Checked = true;
                rbFirefox.Checked = false;
            }

        }

        private void rbChrome_CheckedChanged(object sender, EventArgs e)
        {

            if (rbChrome.Checked != true)
            {
                rbChrome.Checked = false;
                rbFirefox.Checked = true;
            }

        }
    }
}
