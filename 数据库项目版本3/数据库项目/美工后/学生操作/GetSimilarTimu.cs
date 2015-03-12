using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Test.学生操作
{
    public partial class GetSimilarTimu : Form
    {        
        private Paper paper;
        private DBHelper dbHelper;
        private static string topic;//用于传值
        //相关题目有关的属性
        private string chapter;
        private string point;
        private string method;
        private string degree;
        private int score;
        private int totalPoints;

        public GetSimilarTimu()
        {
            InitializeComponent();
            dbHelper = new DBHelper();
            paper = new Paper();

            selectGroup.Visible = false;
            similarGroup.Visible = false;
        }

        private void initializeSelectGroup()
        {
            radioButton1.Checked = true;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            ttihao.Visible = true;
            xtihao.Visible = false;
            jtihao.Visible = false;
            tishi.Text = "提示";
            inputScore.Text = "";
            inputAllScore.Text = "";
        }

        private int tihao = 0;
        private string type = "";
        //确定按钮点击事件
        //先判断输入是否合法->对tkRatio及xzRatio表进行insert或update操作->查询并显示相似题型
        private int checkInput()
        {
            int state;
            if (tihao == 0)
                state = 1;
            else if (inputScore.Text == "" || inputAllScore.Text == "")
                state = 2;
            else if (type == "tiankong" && Convert.ToInt32(inputAllScore.Text) != 4)
                state = 3;
            else if (type == "tiankong" && Convert.ToInt32(inputScore.Text) != 0 && Convert.ToInt32(inputScore.Text) != 4)
                state = 4;
            else if (type == "tiankong" && Convert.ToInt32(inputScore.Text) > Convert.ToInt32(inputAllScore.Text))
                state = 5;
            else if (type == "xuanze" && Convert.ToInt32(inputAllScore.Text) != 5)
                state = 6;
            else if (type == "xuanze" && Convert.ToInt32(inputScore.Text) != 0 && Convert.ToInt32(inputScore.Text) != 5)
                state = 7;
            else if (type == "xuanze" && Convert.ToInt32(inputScore.Text) > Convert.ToInt32(inputAllScore.Text))
                state = 8;
            else
                state = 0;
            return state;
        }

        private void changeRatioTable()
        {
            similarGroup.Visible = true;
            setSomeAttributes();
            //题型为tiankong 对tkRatio表进行操作
            if (type == "tiankong")
            {
                dbHelper.connect();
                string sql1 = "select * from tkRatio where chapter = '" + chapter + "' and point = '" + point + "' and degree = '" + degree + "'";
                //先根据chapter,point,degree到tkRatio表中查询
                int rows = dbHelper.queryIntkRatioInGetSimilarTimu(sql1);
                dbHelper.disconnectInsert();
                //若存在则对tkRatio表执行update操作
                if (rows > 0)
                {
                    string sql2 = "";
                    //再查一次存在的记录得到其true,false,ratio值
                    dbHelper.connect();
                    string[] results = dbHelper.queryIntkRatioInGetSimilarTimu2(sql1);
                    dbHelper.disconnectInsert();
                    //解析所得的true,false,ratio字段用来构造sql语句
                    int correct = Convert.ToInt32(results[0]);
                    int incorrect = Convert.ToInt32(results[1]);
                    decimal ratio = Convert.ToDecimal(results[2]);
                    MessageBox.Show(Convert.ToString(correct) + Convert.ToString(incorrect) + Convert.ToString(ratio));
                    if (score == 4)
                    {
                        int ziduanCorrect = correct + 1;
                        int ziduanIncorrect = incorrect;
                        //注意类型转换，否则一直为0.000!!!!!
                        ratio = Convert.ToDecimal(ziduanCorrect) / Convert.ToDecimal(ziduanCorrect+ziduanIncorrect);
                        MessageBox.Show(Convert.ToString(ratio));
                        sql2 = "update tkRatio set true = " + ziduanCorrect + ",ratio = " + ratio + " where chapter = '" + chapter + "' and point = '" + point + "' and degree ='" + degree + "'";
                    }
                    else if (score == 0)
                    {
                        int ziduanCorrect = correct;
                        int ziduanIncorrect = incorrect + 1;
                        ratio = Convert.ToDecimal(ziduanCorrect) / Convert.ToDecimal(ziduanCorrect + ziduanIncorrect);
                        sql2 = "update tkRatio set false = " + (incorrect + 1) + ",ratio = " + (correct / (incorrect + correct + 1)) + " where chapter = '" + chapter + "' and point = '" + point + "' and degree ='" + degree + "'";
                    }
                    updatetkRatio(sql2);
                    MessageBox.Show("操作完成");
                }
                //不存在则tkRatio表执行insert操作
                else
                {
                    string sql2 = "";
                    string sql21 = "";
                    string sql22 = "";
                    if (score == 4)//得分为4分correct为1,false为0新增一条记录
                    {
                        sql21 = "insert into tkRatio(chapter,point,degree,true,false,ratio) ";
                        sql22 = " values('" + chapter + "','" + point + "','" + degree + "'," + "1,0,1/1)";
                        sql2 = sql21 + sql22;
                    }
                    else//得分为0分correct为0，false为1新增一条记录
                        sql2 = "insert into tkRatio(chapter,point,degree,true,false,ratio) values('" + chapter + "','" + point + "','" + degree + "',0,1,0/1)";
                    insertIntotkRatio(sql2);
                }
            }
            //题型为xuanze 对xzRatio表进行操作
            else if (type == "xuanze")
            {
                dbHelper.connect();
                string sql1 = "select * from xzRatio where chapter = '" + chapter + "' and point = '" + point + "' and degree = '" + degree + "'";
                //先根据chapter,point,degree到tkRatio表中查询
                int rows = dbHelper.queryInxzRatioInGetSimilarTimu(sql1);
                dbHelper.disconnectInsert();
                //若存在则对tkRatio表执行update操作
                if (rows > 0)
                {
                    string sql2 = "";
                    //再查一次存在的记录得到其true,false,ratio值
                    dbHelper.connect();
                    string[] results = dbHelper.queryInxzRatioInGetSimilarTimu2(sql1);
                    dbHelper.disconnectInsert();
                    //解析所得的true,false,ratio字段用来构造sql语句
                    int correct = Convert.ToInt32(results[0]);
                    int incorrect = Convert.ToInt32(results[1]);
                    decimal ratio = Convert.ToDecimal(results[2]);
                    MessageBox.Show(Convert.ToString(correct) + Convert.ToString(incorrect) + Convert.ToString(ratio));
                    if (score == 5)
                    {
                        int ziduanCorrect = correct + 1;
                        int ziduanIncorrect = incorrect;
                        //注意类型转换，否则一直为0.000!!!!!
                        ratio = Convert.ToDecimal(ziduanCorrect) / Convert.ToDecimal(ziduanCorrect + ziduanIncorrect);
                        MessageBox.Show(Convert.ToString(ratio));
                        sql2 = "update xzRatio set true = " + ziduanCorrect + ",ratio = " + ratio + " where chapter = '" + chapter + "' and point = '" + point + "' and degree ='" + degree + "'";
                    }
                    else if (score == 0)
                    {
                        int ziduanCorrect = correct;
                        int ziduanIncorrect = incorrect + 1;
                        ratio = Convert.ToDecimal(ziduanCorrect) / Convert.ToDecimal(ziduanCorrect + ziduanIncorrect);
                        sql2 = "update xzRatio set false = " + (incorrect + 1) + ",ratio = " + (correct / (incorrect + correct + 1)) + " where chapter = '" + chapter + "' and point = '" + point + "' and degree ='" + degree + "'";
                    }
                    updatexzRatio(sql2);
                    MessageBox.Show("操作完成");
                }
                //不存在则tkRatio表执行insert操作
                else
                {
                    string sql2 = "";
                    string sql21 = "";
                    string sql22 = "";
                    if (score == 5)//得分为4分correct为1,false为0新增一条记录
                    {
                        sql21 = "insert into xzRatio(chapter,point,degree,true,false,ratio) ";
                        sql22 = " values('" + chapter + "','" + point + "','" + degree + "'," + "1,0,1/1)";
                        sql2 = sql21 + sql22;
                    }
                    else//得分为0分correct为0，false为1新增一条记录
                        sql2 = "insert into xzRatio(chapter,point,degree,true,false,ratio) values('" + chapter + "','" + point + "','" + degree + "',0,1,0/1)";
                    insertIntoxzRatio(sql2);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //1.先判断输入是否合法
            int state = checkInput();
            if (state == 1)
                MessageBox.Show("请先选择题号");
            else if (state == 2)
                MessageBox.Show("请将该题总分和得分输入完整");
            else if (state == 3)
                MessageBox.Show("填空题总分必须是4分");
            else if (state == 4)
                MessageBox.Show("得分只能为4或0");
            else if (state == 5)
                MessageBox.Show("得分不能超过总分,请重新输入得分");
            else if (state == 6)
                MessageBox.Show("选择题总分必须是5分");
            else if(state == 7)
                MessageBox.Show("得分只能为5或0");
            else if(state == 8)
                MessageBox.Show("得分不能超过总分,请重新输入得分");
            //2.对tkRatio及xzRatio表进行insert或update操作
            else
            {
                changeRatioTable();
                #region 备份
                /*
                if (type == "tiankong")
                {
                    dbHelper.connect();
                    string sql1 = "select * from tkRatio where chapter = '" + chapter + "' and point = '" + point + "' and degree = '" + degree + "'";
                    //先根据chapter,point,degree到tkRatio表中查询
                    int rows = dbHelper.queryIntkRatioInGetSimilarTimu(sql1);
                    dbHelper.disconnectInsert();
                    //若存在则对tkRatio表执行update操作
                    if (rows > 0)
                    {
                        string sql2 = "";
                        //再查一次存在的记录得到其true,false,ratio值
                        dbHelper.connect();
                        string[] results = dbHelper.queryIntkRatioInGetSimilarTimu2(sql1);
                        dbHelper.disconnectInsert();
                        //解析所得的true,false,ratio字段用来构造sql语句
                        int correct = Convert.ToInt32(results[0]);
                        int incorrect = Convert.ToInt32(results[1]);
                        double ratio = Convert.ToDouble(results[2]);
                        MessageBox.Show(Convert.ToString(correct) + Convert.ToString(incorrect) + Convert.ToString(ratio));
                        if (score == 4)
                        {
                            sql2 = "update tkRatio set true = " + (correct + 1) + ",ratio = " + ((correct + 1) / (incorrect + correct+1)) + " where chapter = '" + chapter + "' and point = '" + point + "' and degree ='" + degree + "'";
                            MessageBox.Show(sql2);
                        }
                        else if (score == 0)
                            sql2 = "update tkRatio set false = " + (incorrect + 1) + ",ratio = " + (correct / (incorrect + correct + 1)) + " where chapter = '" + chapter + "' and point = '" + point + "' and degree ='" + degree + "'";
                        updatetkRatio(sql2);
                        MessageBox.Show("操作完成");
                    }
                    //else则tkRatio表执行insert操作
                    else
                    {
                        string sql2 = "";
                        string sql21 = "";
                        string sql22 = "";
                        if (score == 4)//得分为4分correct为1,false为0新增一条记录
                        {
                            sql21 = "insert into tkRatio(chapter,point,degree,true,false,ratio) ";
                            sql22 = " values('" + chapter + "','" + point + "','" + degree + "'," + "1,0,1/1)";
                            sql2 = sql21 + sql22;
                            MessageBox.Show(sql2);
                        }
                        else//得分为0分correct为0，false为1新增一条记录
                            sql2 = "insert into tkRatio(chapter,point,degree,true,false,ratio) values(" + chapter + "," + point + "," + degree + ",0,1,0/1)";
                        insertIntotkRatio(sql2);
                    }
                }
                //!!!!!!
                else if (type == "xuanze")
                {
                    dbHelper.connect();

                    dbHelper.disconnectInsert();
                }

                */
                #endregion
                //3.查询并显示相似题型
                checkedListBox1.Items.Clear();//先将checkedlistbox清空
                //总体思路：//1.根据tihao和type，到某张题型的表中查询题号为tihao的题目，返回该题的一些属性//2.根据属性构造方法再次查询得到相似题目
                setSomeAttributes();

                if (type == "tiankong" || type == "xuanze")
                    getSimilarTimu();//调用关键函数
                else
                    getJiandaSimilarTimu();
                initializeSelectGroup();//左半边的条件清空
                #region
                /*
            //填空题
            if (radioButton1.Checked)
            {
                if (Convert.ToString(ttihao.Text) == "")
                    MessageBox.Show("请输入填空题题号");
                else
                {
                    tihao = Convert.ToInt32(ttihao.Text);
                    //先根据tihao到Paper类中得到该题的一些属性，再根据属性到tiankong表格中查询相似题目
                    string[] attributes = paper.getAttributesOfTimu("填空题", tihao);
                    string point = attributes[0];
                    string method = attributes[1];
                    string degree = attributes[2];
                    //得到分数
                    int score = paper.getTiankongScore(tihao - 1);
                    //然后到数据中查询
                    dbHelper.connect();
                    dbHelper.querySimilarTimus("填空题", point, method, degree, score);
                    dbHelper.disconnectInsert();
                }
            }
            else if (radioButton2.Checked)
            {
                if (Convert.ToString(xtihao.Text) == "")
                    MessageBox.Show("请输入选择题题号");
                else
                {
                    tihao = Convert.ToInt32(xtihao.Text);
                    //先根据tihao到Paper类中得到该题的一些属性，再根据属性到xuanze表格中查询相似题目
                    string[] attributes = paper.getAttributesOfTimu("选择题", tihao);
                    string point = attributes[0];
                    string method = attributes[1];
                    string degree = attributes[2];
                    //得到分数
                    int score = paper.getXuanzeScore(tihao - 1);
                    //然后到数据中查询
                    dbHelper.connect();
                    dbHelper.querySimilarTimus("选择题", point, method, degree, score);
                    dbHelper.disconnectInsert();
                }
            }
            else if (radioButton3.Checked)
            {
                if (Convert.ToString(jtihao.Text) == "")
                    MessageBox.Show("请输入简答题题号");
                else
                {
                    tihao = Convert.ToInt32(jtihao.Text);
                    //先根据tihao到Paper类中得到该题的一些属性，再根据属性到xuanze表格中查询相似题目
                    string[] attributes = paper.getAttributesOfTimu("简答题", tihao);
                    string point = attributes[0];
                    string method = attributes[1];
                    string degree = attributes[2];
                    //得到分数
                    int score = paper.getJiandaScore(tihao - 1);
                    //然后到数据中查询
                    dbHelper.connect();
                    dbHelper.querySimilarTimus("简答题", point, method, degree, score);
                    dbHelper.disconnectInsert();
                }
            }*/
                #endregion
            }
        }

        private void updatetkRatio(string sql)
        {
            dbHelper.connect();
            dbHelper.updatetkRatioInGetSimilarTimu(sql);
            dbHelper.disconnectInsert();
        }

        private void updatexzRatio(string sql)
        {
            dbHelper.connect();
            dbHelper.updatexzRatioInGetSimilarTimu(sql);
            dbHelper.disconnectInsert();
        }

        private void insertIntotkRatio(string sql)
        {
            dbHelper.connect();
            dbHelper.insertIntotkRatioInGetSimilarTimu(sql);
            dbHelper.disconnectInsert();
        }

        private void insertIntoxzRatio(string sql)
        {
            dbHelper.connect();
            dbHelper.insertIntoxzRatioInGetSimilarTimu(sql);
            dbHelper.disconnectInsert();
        }

        //1.得到属性
        private void setSomeAttributes()
        {
            string sql1 = "select * from " + type + " where number = '" + tihao + "'";
            dbHelper.connect();
            string[] attributes = dbHelper.queryByNumberInGetSimilarTimu(sql1);
            chapter = attributes[0];
            point = attributes[1]; 
            method = attributes[2];
            degree = attributes[3];

            score = Convert.ToInt32(inputScore.Text);
            totalPoints = Convert.ToInt32(inputAllScore.Text);
            dbHelper.disconnect();
        }

        //2.得到填空题选择题的相似题目(查看历史记录)
        private void getSimilarTimu()
        {
            StringBuilder results = new StringBuilder("");
            string sql;

            //选择题，填空题
            #region 之前思路
            //思路：构造sql
            //根据难度及其他属性分类sql语句(历史记录!!!）
            //1.degree为简单->chapter,point一致,degree也是简单->没找到就不存在相似题目
            //2.degree为中等->chapter,point一致,degree为中等->随机产生5道中等相似题目，反馈结果，正确率在70%以上通过，否则再提供5道简单题目
            //3.degree为偏难->chapter,point一致,degree为偏难->随机产生5道偏难相似题目，反馈结果，正确率在70%以上通过，否则再提供5道中等题目;反馈结果，正确率在70%以上通过，否则再提供5道简单题目
            #endregion
            //思路修改
            //1.degree为简单->根据chapter,point,"简单"到tkRatio表中找到5道题目
            //2.degree为中等->根据chapter,point,"简单"到tkRatio表中查看ratio字段，若ratio>80%则degree升级为"中等"查询出5道题,否则先查询出5道简单题目
            //3.degree为偏难->根据chapter,point,"简单"到tkRatio表中查看ratio字段，若ratio>80%则degree升级为"中等"查询出5道题，若ratio>80%则degree再升级为"偏难"
            if (degree == "简单")
            {
                sql = "select * from " + type + " where chapter = '" + chapter + "' and" + " number != " + tihao + " and" + " point ='" + point + "' and"+" degree ='简单'";
                dbHelper.connect();
                results = dbHelper.queryByDifferentSqlsInGetSimilarTimu(sql);
                dbHelper.disconnect();
                if (results.ToString() == "")
                    MessageBox.Show("同题目类型同知识点的简单题目不存在");
                else
                    showSimilarTimu(results);
            }
            else if (degree == "中等")
            {
                if(type == "xuanze")
                    sql = "select * from tkRatio where chapter = '" + chapter + "' and" + " point ='" + point + "' and" + " degree ='简单'";
                else
                    sql = "select * from xzRatio where chapter = '" + chapter + "' and" + " point ='" + point + "' and" + " degree ='简单'";
                dbHelper.connect();
                decimal ratios = dbHelper.getRatioInGetSimilarTomu2(sql);
                dbHelper.disconnect();
                if (ratios == 1.111M)
                    MessageBox.Show("以前没有做过同类型同知识点的简单题目");
                else if (ratios > 0.800M && ratios!=1.111M)
                {
                    sql = "select * from " + type + " where chapter = '" + chapter + "' and" + " number != " + tihao + " and" + " point ='" + point + "' and" + " degree ='中等'";
                    dbHelper.connect();
                    results = dbHelper.queryByDifferentSqlsInGetSimilarTimu(sql);
                    dbHelper.disconnect();
                    if(results.ToString() == "")
                        MessageBox.Show("无相似题目");
                    else 
                        showSimilarTimu(results);//显示中等题目
                }
                else
                {
                    sql = "select * from " + type + " where chapter = '" + chapter + "' and" + " number != " + tihao + " and" + " point ='" + point + "' and" + " degree ='简单'";
                    dbHelper.connect();
                    results = dbHelper.queryByDifferentSqlsInGetSimilarTimu(sql);
                    dbHelper.disconnect();
                    if (results.ToString() == "")
                        MessageBox.Show("无相似题目");
                    else
                        showSimilarTimu(results);//显示简单题目
                }
            }
            else if (degree == "偏难")
            {
                if (type == "xuanze")
                    sql = "select * from tkRatio where chapter = '" + chapter + "' and" + " point ='" + point + "' and" + " degree ='简单'";
                else
                    sql = "select * from xzRatio where chapter = '" + chapter + "' and" + " point ='" + point + "' and" + " degree ='简单'";
                dbHelper.connect();
                decimal ratios = dbHelper.getRatioInGetSimilarTomu2(sql);
                dbHelper.disconnect();
                if (ratios > 0.800M)
                {
                    sql = "select * from " + type + " where chapter = '" + chapter + "' and" + " number != " + tihao + " and" + " point ='" + point + "' and" + " degree ='中等'";
                    dbHelper.connect();
                    ratios = dbHelper.getRatioInGetSimilarTomu2(sql);
                    dbHelper.disconnect();
                    if (ratios > 0.800M)
                    {
                        sql = "select * from " + type + " where chapter = '" + chapter + "' and" + " number != " + tihao + " and" + " point ='" + point + "' and" + " degree ='偏难'";
                        dbHelper.connect();
                        results = dbHelper.queryByDifferentSqlsInGetSimilarTimu(sql);
                        dbHelper.disconnect();
                        if (results.ToString() == "")
                            MessageBox.Show("无相似题目");
                        else
                            showSimilarTimu(results);//显示偏难题目
                    }
                    else
                    {
                        sql = "select * from " + type + " where chapter = '" + chapter + "' and" + " number != " + tihao + " and" + " point ='" + point + "' and" + " degree ='中等'";
                        dbHelper.connect();
                        results = dbHelper.queryByDifferentSqlsInGetSimilarTimu(sql);
                        dbHelper.disconnect();
                        if (results.ToString() == "")
                            MessageBox.Show("无相似题目");
                        else
                            showSimilarTimu(results);//显示中等题目
                    }
                }
                else
                {
                    sql = "select * from " + type + " where chapter = '" + chapter + "' and" + " number != " + tihao + " and" + " point ='" + point + "' and" + " degree ='简单'";
                    dbHelper.connect();
                    results = dbHelper.queryByDifferentSqlsInGetSimilarTimu(sql);
                    dbHelper.disconnect();
                    if (results.ToString() == "")
                        MessageBox.Show("无相似题目");
                    else
                        showSimilarTimu(results);//显示简单题目
                }
            }
        }

        //3.得到简答题的相似题目(根据该题正确率)
        private void getJiandaSimilarTimu()
        {
            string sql = "";
            double accuracy = Convert.ToInt32(score) / Convert.ToInt32(totalPoints);
            if (accuracy > 0.8)//正确率大于80%，返回难题
            {
                sql = "select topic from jianda where number! = "+tihao+" and chapter = '" + chapter + "' and point = '" + point + "' and degree = '偏难'";
                dbHelper.connect();
                StringBuilder results = dbHelper.queryByDifferentSqlsInGetSimilarTimu(sql);
                dbHelper.disconnect();
                if (results.ToString() == "")
                    MessageBox.Show("不存在偏难的相似题目");
                else
                    showSimilarTimu(results);
            }
            else if (accuracy > 0.4)//正确率大于40%小于80%，返回中等题
            {
                sql = "select topic from jianda where number! = " + tihao + " and chapter = '" + chapter + "' and point = '" + point + "' and degree = '中等'";
                dbHelper.connect();
                StringBuilder results = dbHelper.queryByDifferentSqlsInGetSimilarTimu(sql);
                dbHelper.disconnect();
                if (results.ToString() == "")
                    MessageBox.Show("不存在中等的相似题目");
                else
                    showSimilarTimu(results);
            }
            else//返回简单题
            {
                sql = "select topic from jianda where number! = " + tihao + " and chapter = '" + chapter + "' and point = '" + point + "' and degree = '简单'";
                dbHelper.connect();
                StringBuilder results = dbHelper.queryByDifferentSqlsInGetSimilarTimu(sql);
                dbHelper.disconnect();
                if (results.ToString() == "")
                    MessageBox.Show("不存在简单的相似题目");
                else
                    showSimilarTimu(results);
            }
        }

        private void showSimilarTimu(StringBuilder results)
        {
            for (int i = 0; i < results.Length; i++)
            {
                checkedListBox1.Items.Add(results[i]);
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                type = "tiankong";
                ttihao.Visible = true;
                xtihao.Visible = false;
                jtihao.Visible = false;
                tishi.Text = "提示";
                inputScore.Text = "";
                inputAllScore.Text = "";
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                type = "xuanze";
                xtihao.Visible = true;
                ttihao.Visible = false;
                jtihao.Visible = false;
                tishi.Text = "提示";
                inputScore.Text = "";
                inputAllScore.Text = "";
            }

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                type = "jianda";
                jtihao.Visible = true;
                ttihao.Visible = false;
                xtihao.Visible = false;
                tishi.Text = "提示";
                inputScore.Text = "";
                inputAllScore.Text = "";
            }               
        }

        private void ttihao_SelectedIndexChanged(object sender, EventArgs e)
        {
            tihao = Convert.ToInt32(ttihao.Text);
            tishi.Text = "请输入填空题第" + tihao + "题的总分和所得分";
        }

        private void xtihao_SelectedIndexChanged(object sender, EventArgs e)
        {
            tihao = Convert.ToInt32(xtihao.Text);
            tishi.Text = "请输入选择题第" + tihao + "题的总分和所得分";
        }

        private void jtihao_SelectedIndexChanged(object sender, EventArgs e)
        {
            tihao = Convert.ToInt32(jtihao.Text);
            tishi.Text = "请输入简答题第" + tihao + "题的总分和所得分";
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string topic = checkedListBox1.SelectedItem.ToString();//获得topic值
            MessageBox.Show(topic);
        }

        //返回
        private void button3_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            new SMain().Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            /*
            if (Test.教师操作.MakePaperTest.isFinished == true)
                selectGroup.Visible = true;
            else
                MessageBox.Show("请先完成试卷再来查看相似题目");
             * */
            string sql = "select * from paper";
            dbHelper.connect();
            int id = dbHelper.queryIsPaperCreated(sql);
            dbHelper.disconnect();
            if (id == 0)
            {
                MessageBox.Show("目前没有试卷");
            }
            else
            {
                selectGroup.Visible = true;
            }
        }
    }
}
