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
        string path = Environment.CurrentDirectory + "\\userdata.txt";
        int rowCount;

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
                else
                {
                    UserDataIO.writeNewUserData(new string[] { "User:" + tbUser.Text, "PW:" + tbPassword.Text,
                "Studiengang:" + studiengang, "Browser:" + browser, "SaveChecked:True", "RefreshTime:" + map["RefreshTime"],
                    "TrayChecked:" + map["TrayChecked"]});
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
                    UserDataIO.writeNewUserData(new string[] { "SaveChecked:False", "RowCount:" + rowCount ,
                    "TrayChecked:" + map["TrayChecked"], "RefreshTime:" + map["RefreshTime"],
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
            var main = new MainWindow(list, tbUser.Text, tbPassword.Text, rbDual.Checked, rbFirefox.Checked, rowCount);
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

                if (map["SaveChecked"].Equals("True"))
                {
                    cbSaveUserData.Checked = true;

                }
                if (map.ContainsKey("User")) tbUser.Text = map["User"];
                if (map.ContainsKey("PW")) tbPassword.Text = map["PW"];

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

    }
}
