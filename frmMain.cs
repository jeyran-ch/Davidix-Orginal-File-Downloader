using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Davidix_Original_File_Downloader
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }
        Helper clshp = new Helper();
        
        string[] dlfiles,svfiles;



        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = lstFiles.SelectedItem.ToString();
        }


        private void btnGet_Click(object sender, EventArgs e)
        {
            lstFiles.DataSource = clshp.GetDirFiles(txtDir.Text, null, false, true, txtUrl.Text);
             dlfiles = clshp.GetDirFiles(txtDir.Text, null, false, true, txtUrl.Text);
             svfiles = clshp.GetDirFiles(txtDir.Text, null, true, false, null);
            toolStripTotalFiles.Text = svfiles.Length.ToString();

            if (lstFiles.Items.Count > 0)
                C_Dl_state(true);
            else
                C_Dl_state(false);

        
        }

        

        private void btnCopy_Click(object sender, EventArgs e)
        {
            string temp = "";
            for (int i = 0; i < lstFiles.Items.Count; i++)
            {
                temp += lstFiles.Items[i].ToString()+"\n";
            }
            Clipboard.SetText(temp);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            show_About();
        }

        private static void show_About()
        {
            frmAbout frm = new frmAbout();
            frm.ShowDialog();
        }

        private void C_Dl_state(bool Status)
        {
            btnCopy.Enabled = Status;
            btnDL.Enabled = Status;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            show_About();
        }

        private void btnDL_Click(object sender, EventArgs e)
        {
            clshp.ProgressbarDL = toolStripProgressBarDL;
            for (int i = 0; i < dlfiles.Length; i++)
                clshp.Download((dlfiles[i]), svfiles[i]);

        }
    
    }
}
