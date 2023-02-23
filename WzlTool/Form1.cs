using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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

        private void goBtn_Click(object sender, EventArgs e)
        {
            String resourcePath = resoucePathText.Text;
            String outDir = outText.Text;

            DirectoryInfo resourceDir = new DirectoryInfo(resourcePath);
            DirectoryInfo[] resourceDirs = resourceDir.GetDirectories();
            foreach (DirectoryInfo resDirItem in resourceDirs)
            {
                String dirName = resDirItem.Name.ToLower();
                if (dirName.StartsWith("objects") || dirName.StartsWith("smtiles") || dirName.StartsWith("tiles"))
                {
                    Console.WriteLine("处理中: " + dirName);
                    WzlUtil.WriteWzlBy16(resDirItem.FullName, outDir, dirName);
                }
            }
        }
    }
}
