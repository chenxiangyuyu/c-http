using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PDF_Process
{
    public partial class WordProFrom : Form
    {
        public WordProFrom()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 替换点位符
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            Charpro ccp = new Charpro();
            ArrayList list1 = ccp.CharacterSegmentation(textBox2.Text.Trim(),'#');
            ArrayList list2 = ccp.CharacterSegmentation(textBox3.Text.Trim(), '#');

            Wdphelper.Action().m_WordProcess(wordurl.Text.Trim(), list1, list2);
            Wdphelper.Action().WpStatus();


           
            

        }
        /// <summary>
        /// 选文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = true;//该值确定是否可以选择多个文件
            dialog.Title = "请选择文件夹";
            dialog.Filter = "文档(*.doc)|*.doc";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                wordurl.Text = dialog.FileName;
            }
        }
    }

}
