using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Test
{
    public partial class UDTiku : Form
    {
        //-----成员变量-----
        //数据库操作类
        private DBHelper dbHelper;
        
        //选择题
        //更新操作的原始值(dataGridView中某条记录各个字段的初始值)
        private string xchapter1;
        private string xpoint1;
        private string xmethod1;
        private string xdegree1;
        private string xtopic1;
        private string xa1;
        private string xb1;
        private string xc1;
        private string xd1;
        private string xanswer1;
        //更新操作后的值(修改后各个字段的值)
        private string xchapter2;
        private string xpoint2;
        private string xmethod2;
        private string xdegree2;
        private string xtopic2;
        private string xa2;
        private string xb2;
        private string xc2;
        private string xd2;
        private string xanswer2;

        //填空题
        private string tchapter1;
        private string tpoint1;
        private string tmethod1;
        private string tdegree1;
        private string ttopic1;
        private string tk11;
        private string tk21;
        private string tk31;
        private string tk41;
        private string tk51;
        private string tanswer1;

        private string tchapter2;
        private string tpoint2;
        private string tmethod2;
        private string tdegree2;
        private string ttopic2;
        private string tk12;
        private string tk22;
        private string tk32;
        private string tk42;
        private string tk52;
        private string tanswer2;

        //简答
        private string jchapter1;
        private string jpoint1;
        private string jmethod1;
        private string jdegree1;
        private string jtopic1;
        private string janswer1;

        private string jchapter2;
        private string jpoint2;
        private string jmethod2;
        private string jdegree2;
        private string jtopic2;
        private string janswer2;

        //-----成员函数-----
        //-----1.点击事件及构造函数-----
        public UDTiku()
        {
            InitializeComponent();
            cannotEdit();
            dbHelper = new DBHelper();
            dbHelper.connect();
            DataSet dataset = dbHelper.showXuanzeInUDTku();
            dbHelper.disconnectInsert();
            this.dataGridView1.DataSource = dataset.Tables["xuanze"];
        }

        //删除按钮!!!!!
        private void button7_Click(object sender, EventArgs e)
        {
            string type = "";
            if (radioButton1.Checked)
                type = "xuanze";
            else if (radioButton2.Checked)
                type = "tiankong";
            else if (radioButton3.Checked)
                type = "jianda";
            string tihao = number.Text;
            string sql = "delete from " + type + " where number = " + tihao;
            dbHelper.connect();
            int rows = dbHelper.deleteShitiInUDTiku(sql);
            if (rows > 0)
                MessageBox.Show("删除成功");
            else
                MessageBox.Show("未删除成功");
            dbHelper.disconnectInsert();
            
            dbHelper.connect();
            if (type == "xuanze")
            {
                dbHelper.showXuanzeInUDTku();
                DataSet dataset = dbHelper.showXuanzeInUDTku();
                this.dataGridView1.DataSource = dataset.Tables["xuanze"];
            }
            else if (type == "tiankong")
            {
                dbHelper.showTiankongInUDTku();
                DataSet ds = dbHelper.showTiankongInUDTku();
                this.dataGridView1.DataSource = ds.Tables["tiankong"];
            }
            else
            {
                dbHelper.showJiandaInUDTku();
                DataSet ds = dbHelper.showJiandaInUDTku();
                this.dataGridView1.DataSource = ds.Tables["jianda"];
            }
            dbHelper.disconnectInsert();
        }

        //窗口关闭事件
        private void UDTiku_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        //radioButton点击事件
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            //先清空查询条件
            if (radioButton1.Checked)
            {
                initializeConditions();
                initializeValues();
                //不能编辑
                cannotEdit();
            }
            //再显示所有选择题
            dbHelper.connect();
            DataSet ds = dbHelper.showXuanzeInUDTku();
            dataGridView1.DataSource = ds.Tables["xuanze"];
            dbHelper.disconnectInsert();
            //修改textbox改变名字
            label28.Text = "答案A";
            label27.Text = "答案B";
            label26.Text = "答案C";
            label25.Text = "答案D";
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                initializeConditions();
                initializeValues();
                //不能编辑
                cannotEdit();
            }
            dbHelper.connect();
            DataSet ds = dbHelper.showTiankongInUDTku();
            dataGridView1.DataSource = ds.Tables["tiankong"];
            dbHelper.disconnectInsert();
            //修改textbox改变名字
            label28.Text = "空格1";
            label27.Text = "空格2";
            label26.Text = "空格3";
            label25.Text = "空格4";
        }
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                initializeConditions();
                initializeValues();
                //不能编辑
                cannotEdit();
            }
            dbHelper.connect();
            DataSet ds = dbHelper.showJiandaInUDTku();
            dataGridView1.DataSource = ds.Tables["jianda"];
            dbHelper.disconnectInsert();
            label28.Text = "";
            label27.Text = "";
            label26.Text = "";
            label25.Text = "";
        }

        //查询时辅助构造sql的函数
        private string constructSelectSql(string type)
        {
            //特别注意细节之处
            string sql = "select * from " + type;
            if (queryChapter.Text != "")
            {
                sql += " where chapter= '" + queryChapter.Text + "'";
                if (queryPoint.Text != "")
                    sql += " and point= '" + queryPoint.Text + "'";
                if (queryMethod.Text != "")
                    sql += " and method= '" + queryMethod.Text + "'";
                if (queryDegree.Text != "")
                    sql += " and degree= '" + queryDegree.Text + "'";
            }
            else if (queryPoint.Text != "")
            {
                sql += " where point= '" + queryPoint.Text + "'";
                if (queryMethod.Text != "")
                    sql += " and method= '" + queryMethod.Text + "'";
                if (queryDegree.Text != "")
                    sql += " and degree= '" + queryDegree.Text + "'";
            }
            else if (queryMethod.Text != "")
            {
                sql += " where method= '" + queryMethod.Text + "'";
                if (queryDegree.Text != "")
                    sql += " and degree= '" + queryDegree.Text + "'";
            }
            else if (queryDegree.Text != "")
                sql += " where degree= '" + queryDegree.Text + "'";

            return sql;
        }

        //查询按钮点击事件
        private void button6_Click_1(object sender, EventArgs e)
        {
            #region 备份：之前只能1个条件的查询->改为多个条件查询（参考MakePaperTest）6/11
            /*
            //查询条件只能为1个
            bool[] condition = new bool[4];
            int count = 0;//计数器：等于0显示全部，若条件查询只能为1
            for (int i = 0; i < 4; i++)//初始化数组
                condition[i] = false;

            if (queryChapter.Text != "")
                condition[0] = true;
            if (queryPoint.Text != "")
                condition[1] = true;
            if (queryMethod.Text != "")
                condition[2] = true;
            if (queryDegree.Text != "")
                condition[3] = true;
            for (int i = 0; i < 4; i++)
            {
                if (condition[i] == true)
                    count++;
            }

            //计数器为0，显示全部
            if (count == 0)
            {
                //再判断是哪种题型
                if (radioButton1.Checked)//显示所有选择题
                {
                    dbHelper.connect();
                    DataSet ds = dbHelper.showXuanzeInUDTku();
                    dbHelper.disconnectInsert();
                    dataGridView1.DataSource = ds.Tables["xuanze"];
                }
                else if (radioButton2.Checked)
                {
                    dbHelper.connect();
                    DataSet ds = dbHelper.showTiankongInUDTku();
                    dbHelper.disconnectInsert();
                    dataGridView1.DataSource = ds.Tables["tiankong"];
                }
                else if (radioButton3.Checked)
                {
                    dbHelper.connect();
                    DataSet ds = dbHelper.showJiandaInUDTku();
                    dbHelper.disconnectInsert();
                    dataGridView1.DataSource = ds.Tables["jianda"];
                }
            }
            //计数器为1，1个条件成功查询
            else if (count == 1)
            {
                //再依次判断是哪个条件
                if (condition[0] == true)//按chapter查询
                {
                    //然后再判断是哪种题型
                    if (radioButton1.Checked)//题目类型为选择题
                    {
                        dbHelper.connect();
                        DataTable dt = dbHelper.queryByChapterInUDTiku("选择题", queryChapter.Text);
                        dbHelper.disconnect();
                        dataGridView1.DataSource = dt;
                    }
                    else if (radioButton2.Checked)
                    {
                        dbHelper.connect();
                        DataTable dt = dbHelper.queryByChapterInUDTiku("填空题", queryChapter.Text);
                        dbHelper.disconnect();
                        dataGridView1.DataSource = dt;
                    }
                    else if (radioButton3.Checked)
                    {
                        dbHelper.connect();
                        DataTable dt = dbHelper.queryByChapterInUDTiku("简答题", queryChapter.Text);
                        dbHelper.disconnect();
                        dataGridView1.DataSource = dt;
                    }
                }
                else if (condition[1] == true)//按point查询
                {
                    //判断题目类型
                    if (radioButton1.Checked)//选择题
                    {
                        dbHelper.connect();
                        DataTable dt = dbHelper.queryByPointInUDTiku("选择题", queryPoint.Text);
                        dbHelper.disconnect();
                        dataGridView1.DataSource = dt;
                    }
                    else if (radioButton2.Checked)//填空题
                    {
                        dbHelper.connect();
                        DataTable dt = dbHelper.queryByPointInUDTiku("填空题", queryPoint.Text);
                        dbHelper.disconnect();
                        dataGridView1.DataSource = dt;
                    }
                    else if (radioButton3.Checked)//简答题
                    {
                        dbHelper.connect();
                        DataTable dt = dbHelper.queryByPointInUDTiku("简单题", queryPoint.Text);
                        dbHelper.disconnect();
                        dataGridView1.DataSource = dt;
                    }
                }
                else if (condition[2] == true)//method
                {
                    //判断题目类型
                    if (radioButton1.Checked)
                    {
                        dbHelper.connect();
                        DataTable dt = dbHelper.queryByMethodInUDTiku("选择题", queryMethod.Text);
                        dbHelper.disconnect();
                        dataGridView1.DataSource = dt;
                    }
                    else if (radioButton2.Checked)
                    {
                        dbHelper.connect();
                        DataTable dt = dbHelper.queryByMethodInUDTiku("填空题", queryMethod.Text);
                        dbHelper.disconnect();
                        dataGridView1.DataSource = dt;
                    }
                    else if (radioButton3.Checked)
                    {
                        dbHelper.connect();
                        DataTable dt = dbHelper.queryByMethodInUDTiku("简答题", queryMethod.Text);
                        dbHelper.disconnect();
                        dataGridView1.DataSource = dt;
                    }
                }
                else if (condition[3] == true)//degree
                {
                    if (radioButton1.Checked)
                    {
                        dbHelper.connect();
                        DataTable dt = dbHelper.queryByDegreeInUDTiku("选择题", queryDegree.Text);
                        dbHelper.disconnect();
                        dataGridView1.DataSource = dt;
                    }
                    else if (radioButton2.Checked)
                    {
                        dbHelper.connect();
                        DataTable dt = dbHelper.queryByDegreeInUDTiku("填空题", queryDegree.Text);
                        dbHelper.disconnect();
                        dataGridView1.DataSource = dt;
                    }
                    else if (radioButton3.Checked)
                    {
                        dbHelper.connect();
                        DataTable dt = dbHelper.queryByDegreeInUDTiku("简答题", queryDegree.Text);
                        dbHelper.disconnect();
                        dataGridView1.DataSource = dt;
                    }
                }
            }
            //查询不能超过两个条件
            else
            {
                MessageBox.Show("只能选择1个条件");
            }
             * */
            #endregion

            string sql = "";
            if (radioButton1.Checked)
                sql = constructSelectSql("xuanze");
            else if (radioButton2.Checked)
                sql = constructSelectSql("tiankong");
            else if (radioButton3.Checked)
                sql = constructSelectSql("jianda");
            dbHelper.connect();
            DataTable dt = dbHelper.queryInUDTiku(sql);
            dbHelper.disconnect();
            dataGridView1.DataSource = dt;

            //查询完将条件全部清空
            queryChapter.Text = "";
            queryPoint.Text = "";
            queryMethod.Text = "";
            queryDegree.Text = "";

        }

        //更新按钮点击事件
        private void button8_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)//选择题
            {
                //一.插入Log表格
                //1.根据选择题字段定义Log表格的各个字段并且赋值(根据题目类型区分！)
                string name = Login.name;//name为静态变量
                string time = Convert.ToString(DateTime.Now);
                string tableName = "xuanze";
                string record = number.Text;
                string[] ziduan = { "", "", "", "", "", "", "", "", "", "" };
                string[] oldContent = { "", "", "", "", "", "", "", "", "", "" };
                string[] newContent = { "", "", "", "", "", "", "", "", "", "" };
                //2.得到更新操作后的值
                xchapter2 = chapter.Text;
                xpoint2 = point.Text;
                xmethod2 = method.Text;
                xdegree2 = degree.Text;
                xtopic2 = topic.Text;
                xa2 = A.Text;
                xb2 = B.Text;
                xc2 = C.Text;
                xd2 = D.Text;
                xanswer2 = answer.Text;
                //3.调用比较各个字段变化的函数
                compareChange("选择题");
                //4.给ziduan,oldContent,newContent赋值
                //通过compareChange函数将isChange数组中为true的元素作为修改内容存到变量中
                if (isChange[0] == true)//chapter修改过了
                {
                    ziduan[0] = "章节";
                    oldContent[0] = xchapter1;
                    newContent[1] = xchapter2;
                }
                if (isChange[1] == true)//point修改过了
                {
                    ziduan[1] = "知识点";
                    oldContent[1] = xpoint1;
                    newContent[1] = xpoint2;
                }
                if (isChange[2] == true)//method修改过了
                {
                    ziduan[2] = "思想方法";
                    oldContent[2] = xmethod1;
                    newContent[2] = xmethod2;
                }
                if (isChange[3] == true)//degree修改过了
                {
                    ziduan[3] = "难易程度";
                    oldContent[3] = xdegree1;
                    newContent[3] = xdegree2;
                }
                if (isChange[4] == true)//topic修改过了
                {
                    ziduan[4] = "题目";
                    oldContent[4] = xtopic1;
                    newContent[4] = xtopic2;
                }
                if (isChange[5] == true)//A修改过了
                {
                    ziduan[5] = "A选项";
                    oldContent[5] = xa1;
                    newContent[5] = xa2;
                }
                if (isChange[6] == true)//B修改过了
                {
                    ziduan[6] = "B选项";
                    oldContent[6] = xb1;
                    newContent[6] = xb2;
                }
                if (isChange[7] == true)//C修改过了
                {
                    ziduan[7] = "C选项";
                    oldContent[7] = xc1;
                    newContent[7] = xc2;
                }
                if (isChange[8] == true)//D修改过了
                {
                    ziduan[8] = "D选项";
                    oldContent[8] = xd1;
                    newContent[8] = xd2;
                }
                if (isChange[9] == true)
                {
                    ziduan[9] = "答案";
                    oldContent[9] = xanswer1;
                    newContent[9] = xanswer2;
                }
                //5.插入到Log表中
                for (int i = 0; i < 10; i++)
                {
                    if (ziduan[i] != "")
                    {
                        string[] information = new string[7];
                        //information[0] = user.getName();//方法错误！！！因为这边new User，与Login中不是一个实例,name为null
                        information[0] = Login.name;
                        information[1] = time;
                        information[2] = tableName;
                        information[3] = record;
                        information[4] = ziduan[i];
                        information[5] = oldContent[i];
                        information[6] = newContent[i];
                        dbHelper.connect();
                        int rows = dbHelper.insertLog(information);
                        //debug用
                        if (rows > 0)
                            MessageBox.Show("插入到Log表中");
                        else
                            MessageBox.Show("未插入成功");
                        dbHelper.disconnectInsert();
                    }
                }


                //二.update操作
                string sql = "update xuanze set answer='" + answer.Text + "',chapter='" + chapter.Text + "',point='" + point.Text + "',method='" + method.Text + "',degree='" + degree.Text + "',topic='" + topic.Text + "',A='" + A.Text + "',B='" + B.Text + "',C='" + C.Text + "',D='" + D.Text +
                    "' where number=" + Convert.ToInt32(number.Text);
                if (MessageBox.Show("您确实要修改吗？", "小心", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    dbHelper.connect();
                    DataSet ds = dbHelper.updateTimuInUDTiku("选择题", sql);
                    dbHelper.disconnectInsert();
                    dataGridView1.DataSource = ds.Tables["xuanze"];
                    initializeValues();
                    //下面不能修改
                    cannotEdit();
                }
            }
            else if (radioButton2.Checked)//填空题
            {
                //一.插入Log表格
                //1.根据填空题字段定义Log表格的各个字段并且赋值(根据题目类型区分！)
                string name = Login.name;//name为静态变量
                string time = Convert.ToString(DateTime.Now);
                string tableName = "tiankong";
                string record = number.Text;
                string[] ziduan = { "", "", "", "", "", "", "", "", "", "","" };
                string[] oldContent = { "", "", "", "", "", "", "", "", "", "" ,""};
                string[] newContent = { "", "", "", "", "", "", "", "", "", "","" };
                //2.得到更新操作后的值
                tchapter2 = chapter.Text;
                tpoint2 = point.Text;
                tmethod2 = method.Text;
                tdegree2 = degree.Text;
                ttopic2 = topic.Text;
                tk12 = A.Text;
                tk22 = B.Text;
                tk32 = C.Text;
                tk42 = D.Text;
                tanswer2 = answer.Text;
                //3.调用比较各个字段变化的函数
                compareChange("填空题");
                //4.给ziduan,oldContent,newContent赋值
                //通过compareChange函数将isChange数组中为true的元素作为修改内容存到变量中
                if (isChange[0] == true)//chapter修改过了
                {
                    ziduan[0] = "章节";
                    oldContent[0] = tchapter1;
                    newContent[1] = tchapter2;
                }
                if (isChange[1] == true)//point修改过了
                {
                    ziduan[1] = "知识点";
                    oldContent[1] = tpoint1;
                    newContent[1] = tpoint2;
                }
                if (isChange[2] == true)//method修改过了
                {
                    ziduan[2] = "思想方法";
                    oldContent[2] = tmethod1;
                    newContent[2] = tmethod2;
                }
                if (isChange[3] == true)//degree修改过了
                {
                    ziduan[3] = "难易程度";
                    oldContent[3] = tdegree1;
                    newContent[3] = tdegree2;
                }
                if (isChange[4] == true)//topic修改过了
                {
                    ziduan[4] = "题目";
                    oldContent[4] = ttopic1;
                    newContent[4] = ttopic2;
                }
                if (isChange[5] == true)//K1修改过了
                {
                    ziduan[5] = "空格1";
                    oldContent[5] = tk11;
                    newContent[5] = tk12;
                }
                if (isChange[6] == true)//K2修改过了
                {
                    ziduan[6] = "空格2";
                    oldContent[6] = tk21;
                    newContent[6] = tk22;
                }
                if (isChange[7] == true)//K3修改过了
                {
                    ziduan[7] = "空格3";
                    oldContent[7] = tk31;
                    newContent[7] = tk32;
                }
                if (isChange[8] == true)//K4修改过了
                {
                    ziduan[8] = "空格4";
                    oldContent[8] = tk41;
                    newContent[8] = tk42;
                }
                if (isChange[9] == true)
                {
                    ziduan[9] = "答案";
                    oldContent[9] = tanswer1;
                    newContent[9] = tanswer2;
                }
                //5.插入到Log表中
                for (int i = 0; i < 11; i++)
                {
                    if (ziduan[i] != "")
                    {
                        string[] information = new string[7];
                        //information[0] = user.getName();//方法错误！！！因为这边new User，与Login中不是一个实例,name为null
                        information[0] = Login.name;
                        information[1] = time;
                        information[2] = tableName;
                        information[3] = record;
                        information[4] = ziduan[i];
                        information[5] = oldContent[i];
                        information[6] = newContent[i];
                        dbHelper.connect();
                        int rows = dbHelper.insertLog(information);
                        //debug用
                        if (rows > 0)
                            MessageBox.Show("插入到Log表中");
                        else
                            MessageBox.Show("未插入成功");
                        dbHelper.disconnectInsert();
                    }
                }

                //二.update操作
                string sql = "update tiankong set answer='" + answer.Text + "',chapter='" + chapter.Text + "',point='" + point.Text + "',method='" + method.Text + "',degree='" + degree.Text + "',topic='" + topic.Text + "',k1='" + A.Text + "',k2='" + B.Text + "',k3='" + C.Text + "',k4='" + D.Text +
                    "' where number=" + Convert.ToInt32(number.Text);
                if (MessageBox.Show("您确实要修改吗？", "小心", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    dbHelper.connect();
                    DataSet ds = dbHelper.updateTimuInUDTiku("填空题", sql);
                    dbHelper.disconnectInsert();
                    dataGridView1.DataSource = ds.Tables["tiankong"];
                    initializeValues();
                    //下面不能修改
                    cannotEdit();
                }
            }
            else if (radioButton3.Checked)
            {
                //一.插入Log表格
                //1.根据填空题字段定义Log表格的各个字段并且赋值(根据题目类型区分！)
                string name = Login.name;//name为静态变量
                string time = Convert.ToString(DateTime.Now);
                string tableName = "jianda";
                string record = number.Text;
                string[] ziduan = { "", "", "", "", "", "" };
                string[] oldContent = { "", "", "", "", "", "" };
                string[] newContent = { "", "", "", "", "", "" };
                //2.得到更新操作后的值
                jchapter2 = chapter.Text;
                jpoint2 = point.Text;
                jmethod2 = method.Text;
                jdegree2 = degree.Text;
                jtopic2 = topic.Text;
                janswer2 = answer.Text;
                //3.调用比较各个字段变化的函数
                compareChange("简答题");
                //4.给ziduan,oldContent,newContent赋值
                //通过compareChange函数将isChange数组中为true的元素作为修改内容存到变量中
                if (isChange[0] == true)//chapter修改过了
                {
                    ziduan[0] = "章节";
                    oldContent[0] = jchapter1;
                    newContent[1] = jchapter2;
                }
                if (isChange[1] == true)//point修改过了
                {
                    ziduan[1] = "知识点";
                    oldContent[1] = jpoint1;
                    newContent[1] = jpoint2;
                }
                if (isChange[2] == true)//method修改过了
                {
                    ziduan[2] = "思想方法";
                    oldContent[2] = jmethod1;
                    newContent[2] = jmethod2;
                }
                if (isChange[3] == true)//degree修改过了
                {
                    ziduan[3] = "难易程度";
                    oldContent[3] = jdegree1;
                    newContent[3] = jdegree2;
                }
                if (isChange[4] == true)//topic修改过了
                {
                    ziduan[4] = "题目";
                    oldContent[4] = jtopic1;
                    newContent[4] = jtopic2;
                }
                if (isChange[5] == true)
                {
                    ziduan[5] = "答案";
                    oldContent[5] = janswer1;
                    newContent[5] = janswer2;
                }
                //5.插入到Log表中
                for (int i = 0; i < 6; i++)
                {
                    if (ziduan[i] != "")
                    {
                        string[] information = new string[7];
                        //information[0] = user.getName();//方法错误！！！因为这边new User，与Login中不是一个实例,name为null
                        information[0] = Login.name;
                        information[1] = time;
                        information[2] = tableName;
                        information[3] = record;
                        information[4] = ziduan[i];
                        information[5] = oldContent[i];
                        information[6] = newContent[i];
                        dbHelper.connect();
                        int rows = dbHelper.insertLog(information);
                        //debug用
                        if (rows > 0)
                            MessageBox.Show("插入到Log表中");
                        else
                            MessageBox.Show("未插入成功");
                        dbHelper.disconnectInsert();
                    }
                }
                //二.update操作
                string sql = "update jianda set answer='" + answer.Text + "',chapter='" + chapter.Text + "',point='" + point.Text + "',method='" + method.Text + "',degree='" + degree.Text + "',topic='" + topic.Text +
                    "' where number=" + Convert.ToInt32(number.Text);
                if (MessageBox.Show("您确实要修改吗？", "小心", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    dbHelper.connect();
                    DataSet ds = dbHelper.updateTimuInUDTiku("简答题", sql);
                    dbHelper.disconnectInsert();
                    dataGridView1.DataSource = ds.Tables["jianda"];
                    initializeValues();
                    //下面不能修改
                    cannotEdit();
                }
            }
            

        }

        //点击datagridview中某一行，在下面显示数据（已实现）
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (radioButton1.Checked)
            {
                number.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                chapter.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                point.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                method.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                degree.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                topic.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                A.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                B.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
                C.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
                D.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
                answer.Text = dataGridView1.CurrentRow.Cells[11].Value.ToString();
                //得到初始值
                xchapter1 = chapter.Text;
                xpoint1 = point.Text;
                xmethod1 = method.Text;
                xdegree1 = degree.Text;
                xtopic1 = topic.Text;
                xa1 = A.Text;
                xb1 = B.Text;
                xc1 = C.Text;
                xd1 = D.Text;
                xanswer1 = answer.Text;
            }
            else if (radioButton2.Checked)
            {
                number.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                chapter.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                point.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                method.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                degree.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                topic.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                A.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();//k1
                B.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();//k2
                C.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();//k3
                D.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();//k4
                answer.Text = dataGridView1.CurrentRow.Cells[12].Value.ToString();
                //得到初始值
                tchapter1 = chapter.Text;
                tpoint1 = point.Text;
                tmethod1 = method.Text;
                tdegree1 = degree.Text;
                ttopic1 = topic.Text;
                tk11 = A.Text;
                tk21 = B.Text;
                tk31 = C.Text;
                tk41 = D.Text;
                tanswer1 = answer.Text;
            }
            else if (radioButton3.Checked)
            {
                number.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                chapter.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                point.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                method.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                degree.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                topic.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                answer.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                //得到初始值
                jchapter1 = chapter.Text;
                jpoint1 = point.Text;
                jmethod1 = method.Text;
                jdegree1 = degree.Text;
                jtopic1 = topic.Text;
                janswer1 = answer.Text;
                //没有？？？？？？？
                A.ReadOnly = true;
                B.ReadOnly = true;
                C.ReadOnly = true;
                D.ReadOnly = true;
            }

            //可以编辑了
            canEdit();
        }

        //-----2.自定义函数-----
        //各个字段是否改变(bool值)
        //private bool[] isChange = new bool[] { };
        private bool[] isChange = { false, false, false, false, false, false, false, false, false, false };
        private void compareChange(string type)
        {
            if (type == "选择题")
            {
                if (xchapter2 != xchapter1)
                    isChange[0] = true;
                if (xpoint2 != xpoint1)
                    isChange[1] = true;
                if (xmethod2 != xmethod1)
                    isChange[2] = true;
                if (xdegree2 != xdegree1)
                    isChange[3] = true;
                if (xtopic2 != xtopic1)
                    isChange[4] = true;
                if (xa2 != xa1)
                    isChange[5] = true;
                if (xb2 != xb1)
                    isChange[6] = true;
                if (xc2 != xc1)
                    isChange[7] = true;
                if (xd2 != xd1)
                    isChange[8] = true;
                if (xanswer2 != xanswer1)
                    isChange[9] = true;
            }
            else if (type == "填空题")
            {
                if (tchapter2 != tchapter1)
                    isChange[0] = true;
                if (tpoint2 != tpoint1)
                    isChange[1] = true;
                if (tmethod2 != tmethod1)
                    isChange[2] = true;
                if (tdegree2 != tdegree1)
                    isChange[3] = true;
                if (ttopic2 != ttopic1)
                    isChange[4] = true;
                if (tk12 != tk11)
                    isChange[5] = true;
                if (tk22 != tk21)
                    isChange[6] = true;
                if (tk32 != tk31)
                    isChange[7] = true;
                if (tk42 != tk41)
                    isChange[8] = true;
                if (tanswer2 != tanswer1)
                    isChange[9] = true;
            }
            else if (type == "简答题")
            {
                if (jchapter2 != jchapter1)
                    isChange[0] = true;
                if (jpoint2 != jpoint1)
                    isChange[1] = true;
                if (jmethod2 != jmethod1)
                    isChange[2] = true;
                if (jdegree2 != jdegree1)
                    isChange[3] = true;
                if (jtopic2 != jtopic1)
                    isChange[4] = true;
                if (janswer2 != janswer1)
                    isChange[5] = true;
            }
        }

        //初始化搜索条件函数
        private void initializeConditions()
        {
            queryChapter.Text = "";
            queryPoint.Text = "";
            queryMethod.Text = "";
            queryDegree.Text = "";
        }
        //清楚修改值
        private void initializeValues()
        {
            number.Text = "";
            answer.Text = "";
            topic.Text = "";
            A.Text = "";
            B.Text = "";
            C.Text = "";
            D.Text = "";
            chapter.Text = "";
            point.Text = "";
            method.Text = "";
            degree.Text = "";
        }
        //禁止编辑
        private void cannotEdit()
        {
            number.ReadOnly = true;
            answer.ReadOnly = true;
            topic.ReadOnly = true;
            A.ReadOnly = true;
            B.ReadOnly = true;
            C.ReadOnly = true;
            D.ReadOnly = true;
            chapter.ReadOnly = true;
            point.ReadOnly = true;
            method.ReadOnly = true;
            degree.ReadOnly = true;
        }
        //启用编辑
        private void canEdit()
        {
            answer.ReadOnly = false;
            topic.ReadOnly = false;
            A.ReadOnly = false;
            B.ReadOnly = false;
            C.ReadOnly = false;
            D.ReadOnly = false;
            chapter.ReadOnly = false;
            point.ReadOnly = false;
            method.ReadOnly = false;
            degree.ReadOnly = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            new TMain().Show();
        }

        private void queryChapter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (queryChapter.Text == "集合命题")
            {
                queryPoint.Items.Clear();
                queryPoint.Items.Add("");
                queryPoint.Items.Add("集合概念及其运算");
                queryPoint.Items.Add("四种命题形式");
                queryPoint.Items.Add("充分必要条件");
                queryPoint.Items.Add("集合推出关系");
            }
            else if (queryChapter.Text == "不等式章")
            {
                queryPoint.Items.Clear();
                queryPoint.Items.Add("");
                queryPoint.Items.Add("不等式的性质");
                queryPoint.Items.Add("解不等式");
                queryPoint.Items.Add("证不等式");
                queryPoint.Items.Add("含绝对值的问题");
                queryPoint.Items.Add("线性规划");
                queryPoint.Items.Add("恒成立问题");
            }
            else if (queryChapter.Text == "函数基本性质")
            {
                queryPoint.Items.Clear();
                queryPoint.Items.Add("");
                queryPoint.Items.Add("函数概念");
                queryPoint.Items.Add("建函数关系");
                queryPoint.Items.Add("函数运算");
                queryPoint.Items.Add("函数性质");
                queryPoint.Items.Add("函数图像");
                queryPoint.Items.Add("映射函数");
                queryPoint.Items.Add("二次函数方程不等式");
                queryPoint.Items.Add("函数方程");
            }
            else if (queryChapter.Text == "幂指对函数")
            {
                queryPoint.Items.Clear();
                queryPoint.Items.Add("");
                queryPoint.Items.Add("幂函数的图像与性质");
                queryPoint.Items.Add("指数函数的图像与性质");
                queryPoint.Items.Add("反函数");
                queryPoint.Items.Add("对数函数");
                queryPoint.Items.Add("指对方程不等式");
            }
            //下面继续添加
            else if (queryChapter.Text == "三角比章")
            {
                queryPoint.Items.Clear();
                queryPoint.Items.Add("");
                queryPoint.Items.Add("任意角与三角比");
                queryPoint.Items.Add("三角恒等式");
                queryPoint.Items.Add("解三角形");
                queryPoint.Items.Add("三角函数");
                queryPoint.Items.Add("反三角函数");
                queryPoint.Items.Add("三角方程");
            }
            //下面继续添加
            else if (queryChapter.Text == "数列与数学归纳法")
            {
                queryPoint.Items.Clear();
                queryPoint.Items.Add("");
                queryPoint.Items.Add("数列概念");
                queryPoint.Items.Add("等差数列的通项与求和");
                queryPoint.Items.Add("等比数列的通项与求和");
                queryPoint.Items.Add("递推数列求通项与求和");
                queryPoint.Items.Add("其他数列的通项与求和");
                queryPoint.Items.Add("数学归纳法");
                queryPoint.Items.Add("归纳猜想证明");
            }
            //下面继续添加
            else if (queryChapter.Text == "排列组合与二项式定理")
            {
                queryPoint.Items.Clear();
                queryPoint.Items.Add("");
                queryPoint.Items.Add("排列与乘法原理");
                queryPoint.Items.Add("组合与加法原理");
                queryPoint.Items.Add("二项式定理");
            }
            //下面继续添加
            else if (queryChapter.Text == "概率初步")
            {
                queryPoint.Items.Clear();
                queryPoint.Items.Add("");
                queryPoint.Items.Add("任意角与三角比");
                queryPoint.Items.Add("概率概念");
                queryPoint.Items.Add("等可能事件的概率");
                queryPoint.Items.Add("互斥事件");
                queryPoint.Items.Add("独立事件");
                queryPoint.Items.Add("重复试验及其概率计算");
                queryPoint.Items.Add("数学期望");
            }
            //下面继续添加
            else if (queryChapter.Text == "三角比章")
            {
                queryPoint.Items.Clear();
                queryPoint.Items.Add("");
                queryPoint.Items.Add("任意角与三角比");
                queryPoint.Items.Add("三角恒等式");
                queryPoint.Items.Add("三角恒等式");
                queryPoint.Items.Add("三角恒等式");
                queryPoint.Items.Add("三角恒等式");
            }
            //下面继续添加
            else if (queryChapter.Text == "数理统计等")
            {
                queryPoint.Items.Clear();
                queryPoint.Items.Add("");
                queryPoint.Items.Add("统计量口");
                queryPoint.Items.Add("频率分布图");
                queryPoint.Items.Add("抽样方法");
                queryPoint.Items.Add("统计分布");
            }
            //下面继续添加
            else if (queryChapter.Text == "复数初步")
            {
                queryPoint.Items.Clear();
                queryPoint.Items.Add("");
                queryPoint.Items.Add("复数概念和表示");
                queryPoint.Items.Add("复数运算");
                queryPoint.Items.Add("方程复根");
            }
            //下面继续添加
            else if (queryChapter.Text == "向量初步")
            {
                queryPoint.Items.Clear();
                queryPoint.Items.Add("");
                queryPoint.Items.Add("向量概念及运算");
                queryPoint.Items.Add("平面向量坐标表示及其运算");
                queryPoint.Items.Add("数量积与性质");
                queryPoint.Items.Add("空间向量坐标表示及其运算");
                queryPoint.Items.Add("空间向量坐标表示及其运算");
                queryPoint.Items.Add("向量积与性质");
            }
            //下面继续添加
            else if (queryChapter.Text == "坐标平面上的直线")
            {
                queryPoint.Items.Clear();
                queryPoint.Items.Add("");
                queryPoint.Items.Add("坐标方程基本概念");
                queryPoint.Items.Add("直线方程");
                queryPoint.Items.Add("夹角距离公式");
                queryPoint.Items.Add("点线对称");
                queryPoint.Items.Add("曲线与方程");
            }
            //下面继续添加
            else if (queryChapter.Text == "圆锥曲线")
            {
                queryPoint.Items.Clear();
                queryPoint.Items.Add("");
                queryPoint.Items.Add("圆方程与性质");
                queryPoint.Items.Add("椭圆方程与性质");
                queryPoint.Items.Add("双曲线方程与性质");
                queryPoint.Items.Add("抛物线方程与性质");
                queryPoint.Items.Add("平移坐标轴");
                queryPoint.Items.Add("参数方程");
                queryPoint.Items.Add("极坐标与极坐标方程");
            }
            //下面继续添加
            else if (queryChapter.Text == "三角比章")
            {
                queryPoint.Items.Clear();
                queryPoint.Items.Add("");
                queryPoint.Items.Add("任意角与三角比");
                queryPoint.Items.Add("三角恒等式");
                queryPoint.Items.Add("三角恒等式");
                queryPoint.Items.Add("三角恒等式");
                queryPoint.Items.Add("三角恒等式");
            }
            //下面继续添加
            else if (queryChapter.Text == "空间图形")
            {
                queryPoint.Items.Clear();
                queryPoint.Items.Add("");
                queryPoint.Items.Add("空间图形的位置关系");
                queryPoint.Items.Add("多面体的概念与计算");
                queryPoint.Items.Add("旋转体的概念与计算");
                queryPoint.Items.Add("空间坐标系");
                queryPoint.Items.Add("三视图口");
            }
        }
    }
}
