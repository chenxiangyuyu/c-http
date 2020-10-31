using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PDF_Process
{

    public class WordPro
    {

        public bool Status = true;
        /// <summary>
        /// word文档占位符替换文件
        /// </summary>
        /// <param name="filePath">文件目录</param>
        /// <param name="arr_Old">占位符：｛ "old1", "old2"｝</param>
        /// <param name="arr_New">占位值：{ "new1", "new2" }</param>
        /// <param name="arr_Location">图片位置：在该占位符所在行和列的原点{ "右偏移值/左偏移值/宽的值/高的值", "10/10/100/100" }</param>
        /// <returns></returns>
        public  void WordProcess(string filePath, ArrayList arr_Old, ArrayList arr_New)
        {
            //图片位置，判断文件种类
            if (true)
            {
               // WordStringsReplace(filePath, arr_Old, arr_New);
               WordStringsReplace(filePath, new ArrayList() { "old1", "old2" }, new ArrayList() { "new1", "new2" });
            }
            else
            { 
            }
           
        }
        ///<summary>
        /// 替换word模板文件内容，包括表格中内容
        /// 调用如下:WordStringsReplace("D:/CNSI/CNSI_1.doc", new ArrayList() { "old1", "old2" }, new ArrayList() { "new1", "new2" });
        /// </summary>
        /// <param name="filePath">文件全路径</param>
        /// <param name="arr_Old">占位符数组</param>
        /// <param name="arr_New">替换字符串数组</param>
        private void WordStringsReplace(string filePath, ArrayList arr_Old, ArrayList arr_New)
        {
            if (!File.Exists(filePath))
            {
                MessageBox.Show("模板文件不存在！");
                return;
            }
            if (arr_Old.Count != arr_New.Count)
            {
                MessageBox.Show("占位符和替换内容不一致！");
                return;
            }
            Microsoft.Office.Interop.Word.Application app = new Microsoft.Office.Interop.Word.Application();
            object oMissing = System.Reflection.Missing.Value;
            object file = filePath;
            Microsoft.Office.Interop.Word._Document doc = app.Documents.Open(ref file,
                   ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                   ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                   ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing);
            for (int i = 0; i < arr_Old.Count; i++)
            {
                app.Selection.Find.ClearFormatting();
                app.Selection.Find.Replacement.ClearFormatting();
                app.Selection.Find.Text = "%"+arr_Old[i].ToString()+"%";
                app.Selection.Find.Replacement.Text = arr_New[i].ToString();
                object objReplace = Microsoft.Office.Interop.Word.WdReplace.wdReplaceAll;
                app.Selection.Find.Execute(ref oMissing, ref oMissing, ref oMissing,
                                           ref oMissing, ref oMissing, ref oMissing,
                                           ref oMissing, ref oMissing, ref oMissing,
                                           ref oMissing, ref objReplace, ref oMissing,
                                           ref oMissing, ref oMissing, ref oMissing);
            }

            //保存
            doc.Save();
            doc.Close(ref oMissing, ref oMissing, ref oMissing);
            app.Quit(ref oMissing, ref oMissing, ref oMissing);
        }
        /// <summary>
        /// 替换word模板文件中图片，这个只能替换一个图片，多个测试有点问题
        /// </summary>
        /// <param name="filePath">文件全路径</param>
        /// <param name="str_Old">占位符字符串</param>
        /// <param name="str_Pics">替换图片路径</param>
        /// <param name="x">x点位置，（0，0）在该占位符所在行和列的原点</param>
        /// <param name="y">y点位置</param>
        /// <param name="width">图片宽度</param>
        /// <param name="height">图片高度</param>
        private void WordStringsReplace(string filePath, String str_Old, String str_Pics, int x, int y, int w, int h)
        {
            if (!File.Exists(filePath))
            {
                MessageBox.Show("模板文件不存在！");
                return;
            }
            Microsoft.Office.Interop.Word.Application app = new Microsoft.Office.Interop.Word.Application();
            object oMissing = System.Reflection.Missing.Value;
            object file = filePath;
            Microsoft.Office.Interop.Word._Document doc = app.Documents.Open(ref file,
                   ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                   ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                   ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing);
            object replaceAll = Microsoft.Office.Interop.Word.WdReplace.wdReplaceAll;
            object LinkToFile = false;
            object SaveWithDocument = true;
            app.Selection.Find.ClearFormatting();
            app.Selection.Find.Text = str_Old;
            app.Selection.Find.Execute(ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing);
            object Anchor = app.Selection.Range;
            //oDoc.InlineShapes.AddPicture(picfileName, ref LinkToFile, ref SaveWithDocument, ref Anchor);         
            object left = x;
            object top = y;
            object width = w;
            object height = h;
            Anchor = app.Selection.Range;
            doc.Shapes.AddPicture(str_Pics, ref LinkToFile, ref SaveWithDocument, ref left, ref top, ref width, ref height, ref Anchor);
            //保存
            doc.Save();
            doc.Close(ref oMissing, ref oMissing, ref oMissing);
            app.Quit(ref oMissing, ref oMissing, ref oMissing);
            //清除占位符
            WordStringsReplace(filePath, new ArrayList() { str_Old }, new ArrayList() { " " });
        }
    }
}
