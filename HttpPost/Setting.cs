using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Windows.Forms;

namespace HttpPost
{
    public partial class Setting : Form
    {
        public Setting()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 保存,单位个是判断多个要用另外方法：按键状态，或者直接保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            string url = Properties.Settings.Default.Url.ToString();
            if (url == textBox1.Text.ToString())
            {
                this.Close();
            }
            else
            {
                Properties.Settings.Default.Url = textBox1.Text.ToString();
                MessageBox.Show("保存成功");
                this.Close();
            }
        }
        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Setting_Load(object sender, EventArgs e)
        {
            textBox1.Text = Properties.Settings.Default.Url.ToString();
        }
    }
}
