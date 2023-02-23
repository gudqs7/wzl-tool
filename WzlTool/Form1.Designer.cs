namespace WzlTool
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.resoucePathText = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.outText = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.typeComboBox = new System.Windows.Forms.ComboBox();
            this.goBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "自定义资源Data目录";
            // 
            // resoucePathText
            // 
            this.resoucePathText.Location = new System.Drawing.Point(137, 17);
            this.resoucePathText.Name = "resoucePathText";
            this.resoucePathText.Size = new System.Drawing.Size(388, 21);
            this.resoucePathText.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(531, 17);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "选取";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(78, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "输出目录";
            // 
            // outText
            // 
            this.outText.Location = new System.Drawing.Point(137, 118);
            this.outText.Name = "outText";
            this.outText.Size = new System.Drawing.Size(388, 21);
            this.outText.TabIndex = 4;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(531, 118);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "选取";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(42, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "打包文件夹范围";
            // 
            // typeComboBox
            // 
            this.typeComboBox.FormattingEnabled = true;
            this.typeComboBox.Items.AddRange(new object[] {
            "仅地图相关资源(即ObjectsXxx, TilesXxx, SmTilesXxx)",
            "所有资源"});
            this.typeComboBox.Location = new System.Drawing.Point(137, 67);
            this.typeComboBox.Name = "typeComboBox";
            this.typeComboBox.Size = new System.Drawing.Size(388, 20);
            this.typeComboBox.TabIndex = 3;
            // 
            // goBtn
            // 
            this.goBtn.Location = new System.Drawing.Point(226, 172);
            this.goBtn.Name = "goBtn";
            this.goBtn.Size = new System.Drawing.Size(157, 37);
            this.goBtn.TabIndex = 6;
            this.goBtn.Text = "开始打包";
            this.goBtn.UseVisualStyleBackColor = true;
            this.goBtn.Click += new System.EventHandler(this.goBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 238);
            this.Controls.Add(this.goBtn);
            this.Controls.Add(this.typeComboBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.outText);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.resoucePathText);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "wzl批量打包工具 (QQ Group: 563222379)";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox resoucePathText;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox outText;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox typeComboBox;
        private System.Windows.Forms.Button goBtn;
    }
}

