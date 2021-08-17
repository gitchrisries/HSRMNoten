using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HSRMNoten.Forms;
using Microsoft.Win32;

namespace HSRMNoten.Forms
{
    public partial class Options : Form
    {


        public Options(bool trayChecked, bool startUp, bool autoLogin, bool savedUserData, bool minimized)
        {
            InitializeComponent();
            cbAutoLogin.Checked = autoLogin;
            cbMinimizeTray.Checked = trayChecked;
            cbStartUp.Checked = startUp;
            cbStartMinimzed.Checked = minimized;
            if (!savedUserData)
            {
                cbAutoLogin.Checked = false;
                cbAutoLogin.Enabled = false;
            }

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                RegisterInStartup(cbStartUp.Checked);
            }
            catch (Exception)
            {
                MessageBox.Show(new Form { TopMost = true }, "Run at Windows Startup nicht möglich.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbStartUp.Checked = false;
                return;
            }

            if (System.Windows.Forms.Application.OpenForms["MainWindow"] != null)
            {
                (System.Windows.Forms.Application.OpenForms["MainWindow"] as MainWindow).writeOptions(
                    cbMinimizeTray.Checked, cbStartUp.Checked,cbAutoLogin.Checked, cbStartMinimzed.Checked);
            }

            this.Close();
        }

        private void RegisterInStartup(bool isChecked)
        {
            RegistryKey registryKey = Registry.CurrentUser.OpenSubKey
                    ("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            if (isChecked)
            {
                registryKey.SetValue("HSRM Noten Tool", Application.ExecutablePath);
            }
            else if (registryKey.GetValueNames().Contains("HSRM Noten Tool"))
            {
                    registryKey.DeleteValue("HSRM Noten Tool");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbAutoLogin_CheckedChanged(object sender, EventArgs e)
        {
            if (cbAutoLogin.Checked)
            {
                cbStartMinimzed.Enabled = true;
            }
            else
            {
                cbStartMinimzed.Enabled = false;
                cbStartMinimzed.Checked = false;
            }
        }
    }
}
