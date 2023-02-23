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
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            typeComboBox.SelectedIndex = 0;
            //resoucePathText.Text = "D:\\nuoran\\资源\\wzl测试";
            //outText.Text = "D:\\nuoran\\资源\\wzl测试";

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
                typeComboBox.Enabled = false;
                resoucePathText.Enabled = false;
                outText.Enabled = false;
                button1.Enabled = false;
                button2.Enabled = false;
                initProgress0(max);
            }
            else
            {
                MessageBox.Show("打包成功!");
                goBtn.Enabled = true;
                typeComboBox.Enabled = true;
                resoucePathText.Enabled = true;
                outText.Enabled = true;
                button1.Enabled = true;
                button2.Enabled = true;
                progressLabel.Text = "";
            }

        }


        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialogHelper folder = new FolderBrowserDialogHelper();
            folder.DirectoryPath = resoucePathText.Text;
            if (folder.ShowDialog(this) == DialogResult.OK)
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
            if (resoucePathText.Text.Trim().Equals("") || outText.Text.Trim().Equals(""))
            {
                MessageBox.Show("请先选择目录!");
                return;
            }

            if (!Directory.Exists(resoucePathText.Text))
            {
                MessageBox.Show("您选择的资源目录不存在!");
                return;
            }

            bool packageAll = typeComboBox.SelectedIndex == 1;
            Thread objThread = new Thread(new ThreadStart(delegate
            {
                doInThread(packageAll);
            }));
            objThread.Start();
        }


        private void doInThread(bool packageAll)
        {
            string resourcePath = resoucePathText.Text;
            string outDir = outText.Text;
            DirectoryInfo resourceDir = new DirectoryInfo(resourcePath);
            DirectoryInfo[] resourceDirs = resourceDir.GetDirectories();

            this.BeginInvoke(initProgress, true, resourceDirs.Length);

            foreach (DirectoryInfo resDirItem in resourceDirs)
            {
                String dirName = resDirItem.Name.ToLower();
                if (packageAll || dirName.StartsWith("objects") || dirName.StartsWith("smtiles") || dirName.StartsWith("tiles"))
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

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult.Yes != MessageBox.Show("确定退出吗?", "温馨提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
            {
                e.Cancel = true;
            }
        }
    }

}
