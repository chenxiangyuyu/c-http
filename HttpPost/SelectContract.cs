using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HttpPost
{
    public partial class SelectContract : Form
    {
        public SelectContract()
        {
            InitializeComponent();
        }
        Setting set = new Setting();
        /// <summary>
        /// 启动设置界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panel1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if ((Control.ModifierKeys & Keys.Control) == Keys.Control)
            {
                Setting set = new Setting();
                set.Show(); 
            }
        }
        //初始化数据
        string beginDt;
        string toOrg;
        string url;
        string projectCode;
        /// <summary>
        /// 加载界面和数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            //获取开始时间
            beginDt = DateTime.Now.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss");
            beDt.Text = beginDt;
            //Apartdata
            int apta = Properties.Settings.Default.Apartdata;
            endDt.Text = DateTime.Now.AddDays(apta).ToString("yyyy-MM-dd HH:mm:ss");
            //选择机构.税号
            toOrg = Properties.Settings.Default.toOrg.ToString();
            //项目编码
            projectCode = Properties.Settings.Default.projectCode.ToString();
            //选择合同模板
            busidTx.Text = Properties.Settings.Default.busId.ToString();
            //加载用户信息
            userName.Text= Properties.Settings.Default.userName.ToString();
            userCarid.Text = Properties.Settings.Default.userCarid.ToString();
            userMobile.Text = Properties.Settings.Default.userMobile.ToString();
            //加载提交目录
            url= Properties.Settings.Default.Url.ToString()+ Properties.Settings.Default.Api.ToString();
        }
        /// <summary>
        /// 推送
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Sentbu_Click(object sender, EventArgs e)
        {
            //随机生成用户ID
            string toUser = RandomChars.NumChar(12, RandomChars.UppLowType.random);
            //随机生成合同ID
            string fileId = RandomChars.NumChar(8, RandomChars.UppLowType.random);
            //保存值
            Properties.Settings.Default.Save();
            //取文件名
            string fileName=System.IO.Path.GetFileName(busidTx.Text.Trim());


           
            //处理数据
            var formDatas = new List<HttpPost.FormItemModel>();
             //添加文件
            formDatas.Add(new HttpPost.FormItemModel()
            {
                Key = "file",
                Value = "",
                FileName = fileName,
                FileContent = File.OpenRead(busFile.Text.Trim())
            });
            //添加合同信息
            formDatas.Add(new HttpPost.FormItemModel()
            {
                Key = "fileId",
                Value = fileId
            });
            formDatas.Add(new HttpPost.FormItemModel()
            {
                Key = "fileName",
                Value = userName+"的劳动合同"+ DateTime.Now.ToLocalTime().ToString("MM-dd-yyyy")
            });
            formDatas.Add(new HttpPost.FormItemModel()
            {
                Key = "busId",
                Value = busidTx.Text.Trim()
            });
            //基本信息
            formDatas.Add(new HttpPost.FormItemModel()
            {
                Key = "toOrg",
                Value = toOrg
            });
            formDatas.Add(new HttpPost.FormItemModel()
            {
                Key = "projectCode",
                Value = projectCode
            });

            //时间
            formDatas.Add(new HttpPost.FormItemModel()
            {
                Key = "beginDt",
                Value = beDt.Text.Trim()
            }) ;
            formDatas.Add(new HttpPost.FormItemModel()
            {
                Key = "endDt",
                Value = endDt.Text.Trim()
            }) ;
            //用户信息
            formDatas.Add(new HttpPost.FormItemModel()
            {
                Key = "toUser",
                Value = toUser
            });
            formDatas.Add(new HttpPost.FormItemModel()
            {
                Key = "authName",
                Value = userName.Text.Trim()
            });
            formDatas.Add(new HttpPost.FormItemModel()
            {
                Key = "authIdCard",
                Value = userCarid.Text.Trim()
            });
            formDatas.Add(new HttpPost.FormItemModel()
            {
                Key = "authMobile",
                Value = userMobile.Text.Trim()
            });

            var result = PostHttp.PostForm(url, formDatas);
            MessageBox.Show(result);

        }
        /// <summary>
        /// 保存合同模板
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.busId = busidTx.Text.Trim();
        }
        /*
        private void saveValue()
        {
            Properties.Settings.Default.busId = busidTx.Text.Trim();
            Properties.Settings.Default.busId = busidTx.Text.Trim();
            Properties.Settings.Default.busId = busidTx.Text.Trim();
            Properties.Settings.Default.busId = busidTx.Text.Trim();
            Properties.Settings.Default.busId = busidTx.Text.Trim();
        }
        */
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = true;//该值确定是否可以选择多个文件
            dialog.Title = "请选择文件夹";
            dialog.Filter = "PDF(*.pdf)|*.pdf";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                busFile.Text = dialog.FileName;
            }
        }


    }
}
