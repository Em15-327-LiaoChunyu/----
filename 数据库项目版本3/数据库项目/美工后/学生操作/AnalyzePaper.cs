using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Test
{
    public partial class AnalyzePaper : Form
    {
        private DBHelper dbHelper;
        private Paper paper;

        public AnalyzePaper()
        {
            InitializeComponent();
            showAnalyze.Visible = false;
            dbHelper = new DBHelper();
            paper = new Paper();
            tchapter1.Text = "";
            tchapter2.Text = "";
            tchapter3.Text = "";
            tchapter4.Text = "";
            tchapter5.Text = "";
            tchapter6.Text = "";
            tchapter7.Text = "";
            tchapter8.Text = "";
            tchapter9.Text = "";
            tchapter10.Text = "";
            tchapter11.Text = "";
            tchapter12.Text = "";
            tchapter13.Text = "";
            tchapter14.Text = "";
            tpoint1.Text = "";
            tpoint2.Text = "";
            tpoint3.Text = "";
            tpoint4.Text = "";
            tpoint5.Text = "";
            tpoint6.Text = "";
            tpoint7.Text = "";
            tpoint8.Text = "";
            tpoint9.Text = "";
            tpoint10.Text = "";
            tpoint11.Text = "";
            tpoint12.Text = "";
            tpoint13.Text = "";
            tpoint14.Text = "";
            tmethod1.Text = "";
            tmethod2.Text = "";
            tmethod3.Text = "";
            tmethod4.Text = "";
            tmethod5.Text = "";
            tmethod6.Text = "";
            tmethod7.Text = "";
            tmethod8.Text = "";
            tmethod9.Text = "";
            tmethod10.Text = "";
            tmethod11.Text = "";
            tmethod12.Text = "";
            tmethod13.Text = "";
            tmethod14.Text = "";
            tdegree1.Text = "";
            tdegree2.Text = "";
            tdegree3.Text = "";
            tdegree4.Text = "";
            tdegree5.Text = "";
            tdegree6.Text = "";
            tdegree7.Text = "";
            tdegree8.Text = "";
            tdegree9.Text = "";
            tdegree10.Text = "";
            tdegree11.Text = "";
            tdegree12.Text = "";
            tdegree13.Text = "";
            tdegree14.Text = "";
            tjieda1.Text = "";
            tjieda2.Text = "";
            tjieda3.Text = "";
            tjieda4.Text = "";
            tjieda5.Text = "";
            tjieda6.Text = "";
            tjieda7.Text = "";
            tjieda8.Text = "";
            tjieda9.Text = "";
            tjieda10.Text = "";
            tjieda11.Text = "";
            tjieda12.Text = "";
            tjieda13.Text = "";
            tjieda14.Text = "";
            tdianping1.Text = "";
            tdianping2.Text = "";
            tdianping3.Text = "";
            tdianping4.Text = "";
            tdianping5.Text = "";
            tdianping6.Text = "";
            tdianping7.Text = "";
            tdianping8.Text = "";
            tdianping9.Text = "";
            tdianping10.Text = "";
            tdianping11.Text = "";
            tdianping12.Text = "";
            tdianping13.Text = "";
            tdianping14.Text = "";
            tanswer1.Text = "";
            tanswer2.Text = "";
            tanswer3.Text = "";
            tanswer4.Text = "";
            tanswer5.Text = "";
            tanswer6.Text = "";
            tanswer7.Text = "";
            tanswer8.Text = "";
            tanswer9.Text = "";
            tanswer10.Text = "";
            tanswer11.Text = "";
            tanswer12.Text = "";
            tanswer13.Text = "";
            tanswer14.Text = "";

            xchapter1.Text = "";
            xchapter2.Text = "";
            xchapter3.Text = "";
            xchapter4.Text = "";
            xpoint1.Text = "";
            xpoint2.Text = "";
            xpoint3.Text = "";
            xpoint4.Text = "";
            xmethod1.Text = "";
            xmethod2.Text = "";
            xmethod3.Text = "";
            xmethod4.Text = "";
            xdegree1.Text = "";
            xdegree2.Text = "";
            xdegree3.Text = "";
            xdegree4.Text = "";
            xjieda1.Text = "";
            xjieda2.Text = "";
            xjieda3.Text = "";
            xjieda4.Text = "";
            xdianping1.Text = "";
            xdianping2.Text = "";
            xdianping3.Text = "";
            xdianping4.Text = "";
            xanswer1.Text = "";
            xanswer2.Text = "";
            xanswer3.Text = "";
            xanswer4.Text = "";

            jchapter1.Text = "";
            jchapter2.Text = "";
            jchapter3.Text = "";
            jchapter4.Text = "";
            jchapter5.Text = "";
            jpoint1.Text = "";
            jpoint2.Text = "";
            jpoint3.Text = "";
            jpoint4.Text = "";
            jpoint5.Text = "";
            jmethod1.Text = "";
            jmethod2.Text = "";
            jmethod3.Text = "";
            jmethod4.Text = "";
            jmethod5.Text = "";
            jdegree1.Text = "";
            jdegree2.Text = "";
            jdegree3.Text = "";
            jdegree4.Text = "";
            jdegree5.Text = "";
            jjieda1.Text = "";
            jjieda2.Text = "";
            jjieda3.Text = "";
            jjieda4.Text = "";
            jjieda5.Text = "";
            jdianping1.Text = "";
            jdianping2.Text = "";
            jdianping3.Text = "";
            jdianping4.Text = "";
            jdianping5.Text = "";
            janswer1.Text = "";
            janswer2.Text = "";
            janswer3.Text = "";
            janswer4.Text = "";
            janswer5.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            new Test.学生操作.SMain().Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //填空题查看分析
        private void button3_Click(object sender, EventArgs e)
        {
            //分析题目过程：1.从数据库中找到该题所在的题号 2.根据题号得到相应属性并将属性显示到界面上 3.再将属性保存到Paper类中，在GetSimilarTimu中调用相关函数得到这些属性
            //1.
            dbHelper.connect();
            int result1 = dbHelper.queryPaperTableByNumbers("填空题",1);
            dbHelper.disconnect(); 
            //2.
            dbHelper.connect();
            string[] result2 = dbHelper.queryFankui("填空题", result1);
            dbHelper.disconnect();
            tchapter1.Text = result2[0];
            tpoint1.Text = result2[1];
            tmethod1.Text = result2[2];
            tdegree1.Text = result2[3];
            tanswer1.Text = result2[4];
            tjieda1.Text = result2[5];
            tdianping1.Text = result2[6];
            //3.
            string[] attributes = new string[3];
            attributes[0] = tpoint1.Text;
            attributes[1] = tmethod1.Text;
            attributes[2] = tdegree1.Text;
            paper.setAttributesOfTimu("填空题", 1, attributes);
            
            //测试用
            /*
            string[] test1 = paper.getAttributesOfTimu("填空题", 1);
            string test2 = "";
            for (int i = 0; i < 3; i++)
                test2 += test1[i] + " ";
            MessageBox.Show(test2);
             * */
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //1.
            dbHelper.connect();
            int result1 = dbHelper.queryPaperTableByNumbers("填空题", 2);
            dbHelper.disconnect();
            //2.
            dbHelper.connect();
            string[] result2 = dbHelper.queryFankui("填空题", result1);
            dbHelper.disconnect();
            tchapter2.Text = result2[0];
            tpoint2.Text = result2[1];
            tmethod2.Text = result2[2];
            tdegree2.Text = result2[3];
            tanswer2.Text = result2[4];
            tjieda2.Text = result2[5];
            tdianping2.Text = result2[6];
            //3.
            string[] attributes = new string[3];
            attributes[0] = tpoint2.Text;
            attributes[1] = tmethod2.Text;
            attributes[2] = tdegree2.Text;
            paper.setAttributesOfTimu("填空题", 2, attributes);

            /*
            //测试用
            string[] test1 = paper.getAttributesOfTimu("填空题", 2);
            string test2 = "";
            for (int i = 0; i < 3; i++)
                test2 += test1[i] + " ";
            MessageBox.Show(test2);
             * */
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //1.
            dbHelper.connect();
            int result1 = dbHelper.queryPaperTableByNumbers("填空题", 3);
            dbHelper.disconnect();
            //2.
            dbHelper.connect();
            string[] result2 = dbHelper.queryFankui("填空题", result1);
            dbHelper.disconnect();
            tchapter3.Text = result2[0];
            tpoint3.Text = result2[1];
            tmethod3.Text = result2[2];
            tdegree3.Text = result2[3];
            tanswer3.Text = result2[4];
            tjieda3.Text = result2[5];
            tdianping3.Text = result2[6];
            //3.
            string[] attributes = new string[3];
            attributes[0] = tpoint3.Text;
            attributes[1] = tmethod3.Text;
            attributes[2] = tdegree3.Text;
            paper.setAttributesOfTimu("填空题", 3, attributes);

            //测试用
            /*
            string[] test1 = paper.getAttributesOfTimu("填空题", 3);
            string test2 = "";
            for (int i = 0; i < 3; i++)
                test2 += test1[i] + " ";
            MessageBox.Show(test2);*/

        }

        private void button6_Click(object sender, EventArgs e)
        {
            dbHelper.connect();
            int result1 = dbHelper.queryPaperTableByNumbers("填空题", 4);
            dbHelper.disconnect();
            dbHelper.connect();
            string[] result2 = dbHelper.queryFankui("填空题", result1);
            dbHelper.disconnect();
            tchapter4.Text = result2[0];
            tpoint4.Text = result2[1];
            tmethod4.Text = result2[2];
            tdegree4.Text = result2[3];
            tanswer4.Text = result2[4];
            tjieda4.Text = result2[5];
            tdianping4.Text = result2[6];
            string[] attributes = new string[3];
            attributes[0] = tpoint4.Text;
            attributes[1] = tmethod4.Text;
            attributes[2] = tdegree4.Text;
            paper.setAttributesOfTimu("填空题", 4, attributes);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            dbHelper.connect();
            int result1 = dbHelper.queryPaperTableByNumbers("填空题", 5);
            dbHelper.disconnect();
            dbHelper.connect();
            string[] result2 = dbHelper.queryFankui("填空题", result1);
            dbHelper.disconnect();
            tchapter5.Text = result2[0];
            tpoint5.Text = result2[1];
            tmethod5.Text = result2[2];
            tdegree5.Text = result2[3];
            tanswer5.Text = result2[4];
            tjieda5.Text = result2[5];
            tdianping5.Text = result2[6];
            string[] attributes = new string[3];
            attributes[0] = tpoint5.Text;
            attributes[1] = tmethod5.Text;
            attributes[2] = tdegree5.Text;
            paper.setAttributesOfTimu("填空题", 5, attributes);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            dbHelper.connect();
            int result1 = dbHelper.queryPaperTableByNumbers("填空题", 6);
            dbHelper.disconnect();
            dbHelper.connect();
            string[] result2 = dbHelper.queryFankui("填空题", result1);
            dbHelper.disconnect();
            tchapter6.Text = result2[0];
            tpoint6.Text = result2[1];
            tmethod6.Text = result2[2];
            tdegree6.Text = result2[3];
            tanswer6.Text = result2[4];
            tjieda6.Text = result2[5];
            tdianping6.Text = result2[6];
            string[] attributes = new string[3];
            attributes[0] = tpoint6.Text;
            attributes[1] = tmethod6.Text;
            attributes[2] = tdegree6.Text;
            paper.setAttributesOfTimu("填空题", 6, attributes);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            dbHelper.connect();
            int result1 = dbHelper.queryPaperTableByNumbers("填空题", 7);
            dbHelper.disconnect();
            dbHelper.connect();
            string[] result2 = dbHelper.queryFankui("填空题", result1);
            dbHelper.disconnect();
            tchapter7.Text = result2[0];
            tpoint7.Text = result2[1];
            tmethod7.Text = result2[2];
            tdegree7.Text = result2[3];
            tanswer7.Text = result2[4];
            tjieda7.Text = result2[5];
            tdianping7.Text = result2[6];

            string[] attributes = new string[3];
            attributes[0] = tpoint7.Text;
            attributes[1] = tmethod7.Text;
            attributes[2] = tdegree7.Text;
            paper.setAttributesOfTimu("填空题", 7, attributes);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            dbHelper.connect();
            int result1 = dbHelper.queryPaperTableByNumbers("填空题", 8);
            dbHelper.disconnect();
            dbHelper.connect();
            string[] result2 = dbHelper.queryFankui("填空题", result1);
            dbHelper.disconnect();
            tchapter8.Text = result2[0];
            tpoint8.Text = result2[1];
            tmethod8.Text = result2[2];
            tdegree8.Text = result2[3];
            tanswer8.Text = result2[4];
            tjieda8.Text = result2[5];
            tdianping8.Text = result2[6];

            string[] attributes = new string[3];
            attributes[0] = tpoint8.Text;
            attributes[1] = tmethod8.Text;
            attributes[2] = tdegree8.Text;
            paper.setAttributesOfTimu("填空题", 8, attributes);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            dbHelper.connect();
            int result1 = dbHelper.queryPaperTableByNumbers("填空题", 9);
            dbHelper.disconnect();
            dbHelper.connect();
            string[] result2 = dbHelper.queryFankui("填空题", result1);
            dbHelper.disconnect();
            tchapter9.Text = result2[0];
            tpoint9.Text = result2[1];
            tmethod9.Text = result2[2];
            tdegree9.Text = result2[3];
            tanswer9.Text = result2[4];
            tjieda9.Text = result2[5];
            tdianping9.Text = result2[6];

            string[] attributes = new string[3];
            attributes[0] = tpoint9.Text;
            attributes[1] = tmethod9.Text;
            attributes[2] = tdegree9.Text;
            paper.setAttributesOfTimu("填空题", 9, attributes);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            dbHelper.connect();
            int result1 = dbHelper.queryPaperTableByNumbers("填空题", 10);
            dbHelper.disconnect();
            dbHelper.connect();
            string[] result2 = dbHelper.queryFankui("填空题", result1);
            dbHelper.disconnect();
            tchapter10.Text = result2[0];
            tpoint10.Text = result2[1];
            tmethod10.Text = result2[2];
            tdegree10.Text = result2[3];
            tanswer10.Text = result2[4];
            tjieda10.Text = result2[5];
            tdianping10.Text = result2[6];

            string[] attributes = new string[3];
            attributes[0] = tpoint10.Text;
            attributes[1] = tmethod10.Text;
            attributes[2] = tdegree10.Text;
            paper.setAttributesOfTimu("填空题", 10, attributes);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            dbHelper.connect();
            int result1 = dbHelper.queryPaperTableByNumbers("填空题", 11);
            dbHelper.disconnect();
            dbHelper.connect();
            string[] result2 = dbHelper.queryFankui("填空题", result1);
            dbHelper.disconnect();
            tchapter11.Text = result2[0];
            tpoint11.Text = result2[1];
            tmethod11.Text = result2[2];
            tdegree11.Text = result2[3];
            tanswer11.Text = result2[4];
            tjieda11.Text = result2[5];
            tdianping11.Text = result2[6];

            string[] attributes = new string[3];
            attributes[0] = tpoint11.Text;
            attributes[1] = tmethod11.Text;
            attributes[2] = tdegree11.Text;
            paper.setAttributesOfTimu("填空题", 11, attributes);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            dbHelper.connect();
            int result1 = dbHelper.queryPaperTableByNumbers("填空题", 12);
            dbHelper.disconnect();
            dbHelper.connect();
            string[] result2 = dbHelper.queryFankui("填空题", result1);
            dbHelper.disconnect();
            tchapter12.Text = result2[0];
            tpoint12.Text = result2[1];
            tmethod12.Text = result2[2];
            tdegree12.Text = result2[3];
            tanswer12.Text = result2[4];
            tjieda12.Text = result2[5];
            tdianping12.Text = result2[6];

            string[] attributes = new string[3];
            attributes[0] = tpoint12.Text;
            attributes[1] = tmethod12.Text;
            attributes[2] = tdegree12.Text;
            paper.setAttributesOfTimu("填空题", 12, attributes);
        }

        private void button24_Click(object sender, EventArgs e)
        {
            dbHelper.connect();
            int result1 = dbHelper.queryPaperTableByNumbers("填空题", 13);
            dbHelper.disconnect();
            dbHelper.connect();
            string[] result2 = dbHelper.queryFankui("填空题", result1);
            dbHelper.disconnect();
            tchapter13.Text = result2[0];
            tpoint13.Text = result2[1];
            tmethod13.Text = result2[2];
            tdegree13.Text = result2[3];
            tanswer13.Text = result2[4];
            tjieda13.Text = result2[5];
            tdianping13.Text = result2[6];

            string[] attributes = new string[3];
            attributes[0] = tpoint13.Text;
            attributes[1] = tmethod13.Text;
            attributes[2] = tdegree13.Text;
            paper.setAttributesOfTimu("填空题", 13, attributes);
        }

        private void button25_Click(object sender, EventArgs e)
        {
            dbHelper.connect();
            int result1 = dbHelper.queryPaperTableByNumbers("填空题", 14);
            dbHelper.disconnect();
            dbHelper.connect();
            string[] result2 = dbHelper.queryFankui("填空题", result1);
            dbHelper.disconnect();
            tchapter14.Text = result2[0];
            tpoint14.Text = result2[1];
            tmethod14.Text = result2[2];
            tdegree14.Text = result2[3];
            tanswer14.Text = result2[4];
            tjieda14.Text = result2[5];
            tdianping14.Text = result2[6];

            string[] attributes = new string[3];
            attributes[0] = tpoint14.Text;
            attributes[1] = tmethod14.Text;
            attributes[2] = tdegree14.Text;
            paper.setAttributesOfTimu("填空题", 14, attributes);
        }

        //选择题查看分析
        private void button15_Click(object sender, EventArgs e)
        {
            dbHelper.connect();
            int result1 = dbHelper.queryPaperTableByNumbers("选择题", 1);
            dbHelper.disconnect();
            dbHelper.connect();
            string[] result2 = dbHelper.queryFankui("选择题", result1);
            dbHelper.disconnect();
            xchapter1.Text = result2[0];
            xpoint1.Text = result2[1];
            xmethod1.Text = result2[2];
            xdegree1.Text = result2[3];
            xanswer1.Text = result2[4];
            xjieda1.Text = result2[5];
            xdianping1.Text = result2[6];

            string[] attributes = new string[3];
            attributes[0] = xpoint1.Text;
            attributes[1] = xmethod1.Text;
            attributes[2] = xdegree1.Text;
            paper.setAttributesOfTimu("选择题", 1, attributes);

            /*
            //测试用
            string[] test1 = paper.getAttributesOfTimu("选择题", 1);
            string test2 = "";
            for (int i = 0; i < 3; i++)
                test2 += test1[i] + " ";
            MessageBox.Show(test2);
             * */
        }

        private void button16_Click(object sender, EventArgs e)
        {
            dbHelper.connect();
            int result1 = dbHelper.queryPaperTableByNumbers("选择题", 2);
            dbHelper.disconnect();
            dbHelper.connect();
            string[] result2 = dbHelper.queryFankui("选择题", result1);
            dbHelper.disconnect();
            xchapter2.Text = result2[0];
            xpoint2.Text = result2[1];
            xmethod2.Text = result2[2];
            xdegree2.Text = result2[3];
            xanswer2.Text = result2[4];
            xjieda2.Text = result2[5];
            xdianping2.Text = result2[6];

            string[] attributes = new string[3];
            attributes[0] = xpoint2.Text;
            attributes[1] = xmethod2.Text;
            attributes[2] = xdegree2.Text;
            paper.setAttributesOfTimu("选择题", 2, attributes);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            dbHelper.connect();
            int result1 = dbHelper.queryPaperTableByNumbers("选择题", 3);
            dbHelper.disconnect();
            dbHelper.connect();
            string[] result2 = dbHelper.queryFankui("选择题", result1);
            dbHelper.disconnect();
            xchapter3.Text = result2[0];
            xpoint3.Text = result2[1];
            xmethod3.Text = result2[2];
            xdegree3.Text = result2[3];
            xanswer3.Text = result2[4];
            xjieda3.Text = result2[5];
            xdianping3.Text = result2[6];

            string[] attributes = new string[3];
            attributes[0] = xpoint3.Text;
            attributes[1] = xmethod3.Text;
            attributes[2] = xdegree3.Text;
            paper.setAttributesOfTimu("选择题", 3, attributes);
        }

        private void button18_Click(object sender, EventArgs e)
        {
            dbHelper.connect();
            int result1 = dbHelper.queryPaperTableByNumbers("选择题", 4);
            dbHelper.disconnect();
            dbHelper.connect();
            string[] result2 = dbHelper.queryFankui("选择题", result1);
            dbHelper.disconnect();
            xchapter4.Text = result2[0];
            xpoint4.Text = result2[1];
            xmethod4.Text = result2[2];
            xdegree4.Text = result2[3];
            xanswer4.Text = result2[4];
            xjieda4.Text = result2[5];
            xdianping4.Text = result2[6];

            string[] attributes = new string[3];
            attributes[0] = xpoint4.Text;
            attributes[1] = xmethod4.Text;
            attributes[2] = xdegree4.Text;
            paper.setAttributesOfTimu("选择题", 4, attributes);
        }

        //简答题查看分析
        private void button19_Click(object sender, EventArgs e)
        {
            dbHelper.connect();
            int result1 = dbHelper.queryPaperTableByNumbers("简答题", 1);
            dbHelper.disconnect();
            dbHelper.connect();
            string[] result2 = dbHelper.queryFankui("简答题", result1);
            dbHelper.disconnect();
            jchapter1.Text = result2[0];
            jpoint1.Text = result2[1];
            jmethod1.Text = result2[2];
            jdegree1.Text = result2[3];
            janswer1.Text = result2[4];
            jjieda1.Text = result2[5];
            jdianping1.Text = result2[6];

            string[] attributes = new string[3];
            attributes[0] = jpoint1.Text;
            attributes[1] = jmethod1.Text;
            attributes[2] = jdegree1.Text;
            paper.setAttributesOfTimu("简答题", 1, attributes);

            /*
            //测试用
            string[] test1 = paper.getAttributesOfTimu("简答题", 1);
            string test2 = "";
            for (int i = 0; i < 3; i++)
                test2 += test1[i] + " ";
            MessageBox.Show(test2);*/
        }

        private void button20_Click(object sender, EventArgs e)
        {
            dbHelper.connect();
            int result1 = dbHelper.queryPaperTableByNumbers("简答题", 2);
            dbHelper.disconnect();
            dbHelper.connect();
            string[] result2 = dbHelper.queryFankui("简答题", result1);
            dbHelper.disconnect();
            jchapter2.Text = result2[0];
            jpoint2.Text = result2[1];
            jmethod2.Text = result2[2];
            jdegree2.Text = result2[3];
            janswer2.Text = result2[4];
            jjieda2.Text = result2[5];
            jdianping2.Text = result2[6];

            string[] attributes = new string[3];
            attributes[0] = jpoint2.Text;
            attributes[1] = jmethod2.Text;
            attributes[2] = jdegree2.Text;
            paper.setAttributesOfTimu("简答题", 2, attributes);
        }

        private void button21_Click(object sender, EventArgs e)
        {
            dbHelper.connect();
            int result1 = dbHelper.queryPaperTableByNumbers("简答题", 3);
            dbHelper.disconnect();
            dbHelper.connect();
            string[] result2 = dbHelper.queryFankui("简答题", result1);
            dbHelper.disconnect();
            jchapter3.Text = result2[0];
            jpoint3.Text = result2[1];
            jmethod3.Text = result2[2];
            jdegree3.Text = result2[3];
            janswer3.Text = result2[4];
            jjieda3.Text = result2[5];
            jdianping3.Text = result2[6];

            string[] attributes = new string[3];
            attributes[0] = jpoint3.Text;
            attributes[1] = jmethod3.Text;
            attributes[2] = jdegree3.Text;
            paper.setAttributesOfTimu("简答题", 3, attributes);
        }

        private void button22_Click(object sender, EventArgs e)
        {
            dbHelper.connect();
            int result1 = dbHelper.queryPaperTableByNumbers("简答题", 4);
            dbHelper.disconnect();
            dbHelper.connect();
            string[] result2 = dbHelper.queryFankui("简答题", result1);
            dbHelper.disconnect();
            jchapter4.Text = result2[0];
            jpoint4.Text = result2[1];
            jmethod4.Text = result2[2];
            jdegree4.Text = result2[3];
            janswer4.Text = result2[4];
            jjieda4.Text = result2[5];
            jdianping4.Text = result2[6];

            string[] attributes = new string[3];
            attributes[0] = jpoint4.Text;
            attributes[1] = jmethod4.Text;
            attributes[2] = jdegree4.Text;
            paper.setAttributesOfTimu("简答题", 4, attributes);
        }

        private void button23_Click(object sender, EventArgs e)
        {
            dbHelper.connect();
            int result1 = dbHelper.queryPaperTableByNumbers("简答题", 5);
            dbHelper.disconnect();
            dbHelper.connect();
            string[] result2 = dbHelper.queryFankui("简答题", result1);
            dbHelper.disconnect();
            jchapter5.Text = result2[0];
            jpoint5.Text = result2[1];
            jmethod5.Text = result2[2];
            jdegree5.Text = result2[3];
            janswer5.Text = result2[4];
            jjieda5.Text = result2[5];
            jdianping5.Text = result2[6];

            string[] attributes = new string[3];
            attributes[0] = jpoint5.Text;
            attributes[1] = jmethod5.Text;
            attributes[2] = jdegree5.Text;
            paper.setAttributesOfTimu("简答题", 5, attributes);
        }

        //显示分析
        private void button26_Click(object sender, EventArgs e)
        {
            /*
            if (Test.教师操作.MakePaperTest.isFinished == true)
                showAnalyze.Visible = true;
            else
                MessageBox.Show("请先完成试卷再来看分析");
            */
            string sql = "select * from paper where id = 8";
            dbHelper.connect();
            int id = dbHelper.queryIsPaperCreated(sql);
            dbHelper.disconnect();
            if (id == 0)
            {
                MessageBox.Show("目前没有试卷");
            }
            else
            {
                showAnalyze.Visible = true;
            }
        }
    
    }
}
