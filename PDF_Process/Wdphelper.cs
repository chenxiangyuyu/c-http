using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PDF_Process
{
    /// <summary>
    /// 实例化
    /// </summary>
    public class Wdphelper
    {
        private WordPro m_Wp = new WordPro();
        private static readonly Wdphelper m_Wdphelper = new Wdphelper();
        public static Wdphelper Action()
        {
            return m_Wdphelper;
        }
        public void m_WordProcess(string filePath, ArrayList arr_Old, ArrayList arr_New)
        {
            m_Wp.WordProcess(filePath,arr_Old,arr_New);
        }
        public void WpStatus()
        {
            if (m_Wp.Status)
            {
               // MessageBox.Show("成功");
            }
        }
    }
}
