using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MSWord = Microsoft.Office.Interop.Word;
using System.IO;
using System.Reflection;

namespace Test
{
    class ConstructWord
    {
        private string name;//文档名
        private object path;//路径名
        private string wordstr;//word文档内容
        private MSWord.Application wordApp;//word应用程序变量
        private MSWord.Document worddoc;//word文档变量
        private bool isFinish = false;//创建成功
        public void setName(string name)
        {
            this.name = name;
        }
        public string getPath()
        {
            return (string)path;
        }
        public bool construct()
        {
            try
            {
                object Nothing = Missing.Value;//COM调用时用于占位
                object format = MSWord.WdSaveFormat.wdFormatDocument;//word文档的保存形式
                wordApp = new MSWord.ApplicationClass();              //声明一个wordAPP对象
                worddoc = wordApp.Documents.Add(ref Nothing, ref Nothing,
                    ref Nothing, ref Nothing);
                //向文档中写入内容
                wordstr = "开始编辑";
                worddoc.Paragraphs.Last.Range.Text = wordstr;
                //保存文档
                path = "E:\\2014课件\\数据库\\项目\\测试试题文件夹" + "\\" + name;         //设置文件保存路劲
                worddoc.SaveAs(ref path, ref format, ref Nothing, ref Nothing,
                    ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing,
                    ref Nothing, ref Nothing, ref Nothing, ref Nothing);
                //关闭文档
                worddoc.Close(ref Nothing, ref Nothing, ref Nothing);  //关闭worddoc文档对象
                wordApp.Quit(ref Nothing, ref Nothing, ref Nothing);   //关闭wordApp组对象
                isFinish = true;
                //return isFinish;
            }
            catch (Exception ex)
            {
            }
            return isFinish;
        }
    }
}
