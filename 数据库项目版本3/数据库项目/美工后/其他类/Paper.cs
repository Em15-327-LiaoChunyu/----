using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test
{
    //试题类
    class Paper
    {
        private int[] tiankongNumbers = new int[14];
        private int[] xuanzeNumbers = new int[4];
        private int[] jiandaNumbers = new int[5];
        //题目分数
        private int[] tiankongScores = new int[14];
        private int[] xuanzeScores = new int[4];
        private int[] jiandaScores = new int[5];
        //二维数组：表示某题型的某道题的3个属性(知识点，思想方法，难易程度)
        private string[,] tiankongAttributes = new string[14, 3];
        private string[,] xuanzeAttributes = new string[4,3];
        private string[,] jiandaAttributes = new string[5,3];

        //set函数：
        //参数:i-小标，标识卷子中的题号 number-真正存在数据库中的题号
        public void setTiankongNumbers(int i,int number)
        {
            tiankongNumbers[i-1] = number;
        }

        public void setXuanzeNumbers(int i, int number)
        {
            xuanzeNumbers[i-1] = number;
        }

        public void setJiandaNumbers(int i, int number)
        {
            jiandaNumbers[i-1] = number;
        }

        //set分数
        public void setTiankongScores(int[] scores)
        {
            tiankongScores = scores;
        }

        public void setXuanzeScores(int[] scores)
        {
            xuanzeScores = scores;
        }

        public void setJiandaScores(int[] scores)
        {
            jiandaScores = scores;
        }

        //get分数
        public int getTiankongScore(int i)
        {
            return tiankongScores[i];
        }

        public int getXuanzeScore(int i)
        {
            return xuanzeScores[i];
        }

        public int getJiandaScore(int i)
        {
            return jiandaScores[i];
        }

        //函数参数：试卷中的题号 函数返回值：数据库中的题号
        public int getTiankongNumbers(int i)
        {
            return tiankongNumbers[i];
        }

        public int getXuanzeNumbers(int i)
        {
            return xuanzeNumbers[i];
        }

        public int getJiandaNumbers(int i)
        {
            return jiandaNumbers[i];
        }

        //一下子全部get
        public int[] getAllNumbers()
        {
            int[] all = new int[23];
            for (int i = 0; i < 14; i++)
            {
                all[i] = tiankongNumbers[i];
            }
            for (int i = 14,j = 0; j < 4; i++,j++)
            {
                all[i] = xuanzeNumbers[j];
            }
            for (int i = 18,j = 0; j < 5; i++,j++)
            {
                all[i] = jiandaNumbers[j];
            }
            return all;
        }
    
        //得到某道题的属性
        //参数：type--题目类型  i--某种题目类型的第几道题 attributes---从AnalyzePaper界面中得到的属性
        public void setAttributesOfTimu(string type,int i,string[] attributes)
        {
            if(type.Equals("填空题"))
            {
                //!!!算法核心
                //得到寻找相似题目所用的属性 point,method,degree
                tiankongAttributes[i-1,0] = attributes[0];//point
                tiankongAttributes[i-1, 1] = attributes[1];//method
                tiankongAttributes[i-1, 2] = attributes[2];//degree
            }
            else if (type.Equals("选择题"))
            {
                xuanzeAttributes[i-1, 0] = attributes[0];
                xuanzeAttributes[i-1, 1] = attributes[1];
                xuanzeAttributes[i-1, 2] = attributes[2];
            }
            else if (type.Equals("简答题"))
            {
                jiandaAttributes[i-1,0] = attributes[0];
                jiandaAttributes[i-1,1] = attributes[1];
                jiandaAttributes[i-1,2] = attributes[2];
            }
        }

        public string[] getAttributesOfTimu(string type,int i)
        {
            string[] attributes = new string[3];
            if (type.Equals("填空题"))
            {
                attributes[0] = tiankongAttributes[i-1, 0];
                attributes[1] = tiankongAttributes[i-1, 1];
                attributes[2] = tiankongAttributes[i-1, 2];
            }
            else if (type.Equals("选择题"))
            {
                attributes[0] = xuanzeAttributes[i-1,0];
                attributes[1] = xuanzeAttributes[i-1, 1];
                attributes[2] = xuanzeAttributes[i-1, 2];
            }
            else if (type.Equals("简答题"))
            {
                attributes[0] = jiandaAttributes[i-1,0];
                attributes[1] = jiandaAttributes[i-1, 1];
                attributes[2] = jiandaAttributes[i-1, 2];
            }
            return attributes;
        }
    }
}
