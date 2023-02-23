using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WindowsFormsApp;

namespace WzlTool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            typeComboBox.SelectedIndex = 0;
        }



        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialogHelper folder = new FolderBrowserDialogHelper();
            folder.DirectoryPath = resoucePathText.Text;
            if(folder.ShowDialog(this) == DialogResult.OK)
            {
                resoucePathText.Text = folder.DirectoryPath;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialogHelper folder = new FolderBrowserDialogHelper();
            folder.DirectoryPath = outText.Text;
            if (folder.ShowDialog(this) == DialogResult.OK)
            {
                outText.Text = folder.DirectoryPath;
            }
        }
    }
}
