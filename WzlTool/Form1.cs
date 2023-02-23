using System;
using System.IO;
using System.Threading;
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
            resoucePathText.Text = "D:\\nuoran\\资源\\pak补丁\\Data";
            outText.Text = "D:\\nuoran\\资源\\wzl测试";

            //实例化委托
            updateTxt = new UpdateTxt(UpdateTxtMethod);
            initProgress = new InitProgress(initProgressMethod);
        }

        //创建一个委托，是为访问TextBox控件服务的。
        public delegate void UpdateTxt(string msg);

        //定义一个委托变量
        public UpdateTxt updateTxt;

        //创建一个委托，是为访问TextBox控件服务的。
        public delegate void InitProgress(bool start, int max);

        //定义一个委托变量
        public InitProgress initProgress;

        public void UpdateTxtMethod(string msg)
        {
            wzlProgressBar.PerformStep();
            progressLabel.Text = msg;
        }

        public void initProgressMethod(bool start, int max)
        {
            if (start)
            {
                goBtn.Enabled = false;
                initProgress0(max);
            } else
            {
                MessageBox.Show("打包成功!");
                goBtn.Enabled = true;
                progressLabel.Text = "";
            }

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
            Thread objThread = new Thread(new ThreadStart(delegate
            {
                doInThread();
            }));
            objThread.Start();
        }


        private void doInThread()
        {
            string resourcePath = resoucePathText.Text;
            string outDir = outText.Text;
            DirectoryInfo resourceDir = new DirectoryInfo(resourcePath);
            DirectoryInfo[] resourceDirs = resourceDir.GetDirectories();

            this.BeginInvoke(initProgress, true, resourceDirs.Length);

            foreach (DirectoryInfo resDirItem in resourceDirs)
            {
                String dirName = resDirItem.Name.ToLower();
                if (dirName.StartsWith("objects") || dirName.StartsWith("smtiles") || dirName.StartsWith("tiles"))
                {
                    // 执行PerformStep()函数
                    this.BeginInvoke(updateTxt, "正在处理: " + dirName);
                    WzlUtil.WriteWzlBy16(resDirItem.FullName, outDir, dirName);
                }
            }

            this.BeginInvoke(initProgress, false, resourceDirs.Length);
        }

        private void initProgress0(int max)
        {
            // 显示进度条控件.
            wzlProgressBar.Visible = true;
            // 设置进度条最小值.
            wzlProgressBar.Minimum = 0;
            // 设置进度条最大值.
            wzlProgressBar.Maximum = max;
            // 设置进度条初始值
            wzlProgressBar.Value = 0;
            // 设置每次增加的步长
            wzlProgressBar.Step = 1;
        }
    }

}
