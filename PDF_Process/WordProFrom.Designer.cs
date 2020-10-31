namespace PDF_Process
{
    partial class WordProFrom
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
            this.wordurl = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.GenerateBut = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // wordurl
            // 
            this.wordurl.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::PDF_Process.Properties.Settings.Default, "wordUrl", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.wordurl.Location = new System.Drawing.Point(40, 23);
            this.wordurl.Name = "wordurl";
            this.wordurl.Size = new System.Drawing.Size(336, 21);
            this.wordurl.TabIndex = 0;
            this.wordurl.Text = global::PDF_Process.Properties.Settings.Default.wordUrl;
            // 
            // textBox2
            // 
            this.textBox2.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::PDF_Process.Properties.Settings.Default, "oldValue", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBox2.Location = new System.Drawing.Point(40, 65);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(419, 73);
            this.textBox2.TabIndex = 1;
            this.textBox2.Text = global::PDF_Process.Properties.Settings.Default.oldValue;
            // 
            // textBox3
            // 
            this.textBox3.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::PDF_Process.Properties.Settings.Default, "newValue", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBox3.Location = new System.Drawing.Point(40, 155);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(419, 74);
            this.textBox3.TabIndex = 2;
            this.textBox3.Text = global::PDF_Process.Properties.Settings.Default.newValue;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(381, 23);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = ".....";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // GenerateBut
            // 
            this.GenerateBut.Location = new System.Drawing.Point(40, 255);
            this.GenerateBut.Name = "GenerateBut";
            this.GenerateBut.Size = new System.Drawing.Size(419, 34);
            this.GenerateBut.TabIndex = 4;
            this.GenerateBut.Text = "生成";
            this.GenerateBut.UseVisualStyleBackColor = true;
            this.GenerateBut.Click += new System.EventHandler(this.button2_Click);
            // 
            // WordProFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 301);
            this.Controls.Add(this.GenerateBut);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.wordurl);
            this.Name = "WordProFrom";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox wordurl;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button GenerateBut;
    }
}

