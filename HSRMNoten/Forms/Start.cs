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
        Dictionary<string, string> map;
        string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.txt");
        int rowCount;
        bool minimized = false;

        public Start()
        {
            InitializeComponent();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            if(cbSaveUserData.Checked) 
            {
                string studiengang;
                studiengang = rbDual.Checked ? "AIDual" : "AI";
                string browser;
                browser = rbChrome.Checked ? "Chrome" : "Firefox";
                if (File.Exists(path) && map.ContainsKey("User"))
                {
                    UserDataIO.updateUserData(new string[] { "User:" + tbUser.Text, "PW:" + tbPassword.Text,
                "Studiengang:" + studiengang, "Browser:" + browser, "SaveChecked:True"});
                }
                else if (File.Exists(path))
                {
                    UserDataIO.writeNewUserData(new string[] { "User:" + tbUser.Text, "PW:" + tbPassword.Text,
                "Studiengang:" + studiengang, "Browser:" + browser, "SaveChecked:True", "RefreshTime:" + map["RefreshTime"],
                    "TrayChecked:" + map["TrayChecked"], "AutoLogin:" + map["AutoLogin"], "Startup:" + map["StartUp"]});
                }
                else
                {
                    UserDataIO.writeNewUserData(new string[] { "User:" + tbUser.Text, "PW:" + tbPassword.Text,
                "Studiengang:" + studiengang, "Browser:" + browser, "SaveChecked:True"});
                }

            }
            else
            {
                string studiengang;
                studiengang = rbDual.Checked ? "AIDual" : "AI";
                string browser;
                browser = rbChrome.Checked ? "Chrome" : "Firefox";
                if (map != null && map.ContainsKey("TrayChecked"))
                {
                    UserDataIO.updateUserData(new string[] { "SaveChecked:False",
                    "Studiengang:" + studiengang, "Browser:" + browser});
                }
                else
                {
                    UserDataIO.writeNewUserData(new string[] { "SaveChecked:False", "RowCount:" + rowCount ,
                    "Studiengang:" + studiengang, "Browser:" + browser});
                }


            }

            lblgetData.Visible = true;
            var list = rbFirefox.Checked ? ReadHTML.parseTable(ReadHTML.navigateToGradesFirefox(tbUser.Text, tbPassword.Text, rbDual.Checked)) :
                ReadHTML.parseTable(ReadHTML.navigateToGradesChrome(tbUser.Text, tbPassword.Text, rbDual.Checked));
            if (list == null)
            {
                lblgetData.Visible = false;
                MessageBox.Show("Incorrect User Data");
                return;
            }
            var main = new MainWindow(list, tbUser.Text, tbPassword.Text, rbDual.Checked, rbFirefox.Checked, rowCount, minimized);
            main.Show();
            this.Hide();           
        }

        private void Start_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Start_Load(object sender, EventArgs e)
        {
            if (File.Exists(path))
            {
                map = UserDataIO.readUserData();

                if(map != null && map["StartMinimized"].Equals("True"))
                {
                    minimized = true;
                    this.WindowState = FormWindowState.Minimized;
                    this.Hide();
                }

                if (map["SaveChecked"].Equals("True"))
                {
                    cbSaveUserData.Checked = true;
                    if (map.ContainsKey("User")) tbUser.Text = map["User"];
                    if (map.ContainsKey("PW")) tbPassword.Text = map["PW"];
                }


                if (map.ContainsKey("Studiengang") && map["Studiengang"].Equals("AI"))
                {
                    rbNonDual.Checked = true;
                    rbDual.Checked = false;
                }
                else
                {
                    rbNonDual.Checked = false;
                    rbDual.Checked = true;
                }
                if (map.ContainsKey("Browser") && map["Browser"].Equals("Chrome"))
                {
                    rbChrome.Checked = true;
                    rbFirefox.Checked = false;
                }
                else
                {
                    rbFirefox.Checked = true;
                    rbChrome.Checked = false;
                }
                rowCount = Int32.Parse(map["RowCount"]);


            }           
        }

        private void tbPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnGo_Click(this, new EventArgs());
            }
        }

        private void Start_Shown(object sender, EventArgs e)
        {
  
            if (map != null && map["AutoLogin"].Equals("True"))
                {
                this.Refresh();
                btnGo.PerformClick();
                }
        }

        private void Start_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
            }
        }
    }
}
