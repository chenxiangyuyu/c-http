using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PDF_Process
{
    class Charpro
    {
        /// <summary>
        /// 分割字符串
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="cschar">分割的字符，只能是单字符</param>
        /// <returns>返回的是动态数组ArrayList </returns>
        public ArrayList CharacterSegmentation(string str,char cschar)
        {
            ArrayList list = new ArrayList();
            string[] sArray = str.Split(cschar);
            foreach (string i in sArray)
            {
                list.Add(sArray);
            }
            return list;
        }
    }
}
