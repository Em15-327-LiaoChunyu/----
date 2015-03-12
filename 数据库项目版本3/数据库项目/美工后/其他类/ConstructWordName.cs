using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test
{
    class ConstructWordName
    {
        private string chapter;//章节
        private string point;//知识点
        private string method;//思想方法
        private string degree;//难易程度
        private string name;//word名

        public ConstructWordName()
        {
            chapter = "";
            point = "";
            method = "";
            degree = "";
            name = "";
        }

        public void setChapter(string chapter)
        {
            this.chapter = chapter;
        }

        public void setPoint(string point)
        {
            this.point = point;
        }

        public void setMethod(string method)
        {
            this.method = method;
        }

        public void setDegree(string degree)
        {
            this.degree = degree;
        }

        //构建word名称
        public string constructName()
        {
            if (method == "")
                method = "null";
            name = chapter + "_" + point + "_" + method + "_" + degree;//注意间隔不能为'/'否则路径名不对
            return name;
        }
    }
}
