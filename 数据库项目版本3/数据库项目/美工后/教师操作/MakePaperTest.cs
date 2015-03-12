using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Test.教师操作
{
    public partial class MakePaperTest : Form
    {
        public static bool isFinished = false;
        //-----成员变量-----
        //搜索条件,用户输入得到
        private string sChapter;
        private string sPoint;
        private string sMethod;
        private string sDegree;
        private string sTopic;
        private int[] sCondition = new int[5];//搜索条件,用int数组标识，元素值为1代表有值
        
        //其他类
        private DBHelper dbHelper;
        private Paper paper;

        //关于label中内容的一些设置
        private string label_type = "填空题";
        private int label_tiankong_number = 1;
        private int label_xuanze_number = 1;
        private int label_jianda_number = 1;

        //-----成员函数-----
        //-----1.点击事件及构造函数------
        public MakePaperTest()
        {
            InitializeComponent();
            dbHelper = new DBHelper();
            paper = new Paper();
            label7.Text = "选择题目:" + label_type + "第" + Convert.ToString(label_tiankong_number) + "道";

            dbHelper.connect();
            DataSet ds = dbHelper.showTiankongInMakePaperTest();
            dbHelper.disconnectInsert();
            this.dataGridView1.DataSource = ds.Tables["tiankong"];
        }
        
        //路径选择按钮点击事件
        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult result = saveFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
                textBox2.Text = saveFileDialog1.FileName;/*+ ".doc";*/
            else
                textBox2.Text = "";
        }
        
        //radioButton按钮点击事件
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            //选择不同的radioButton，触发label内容的改变（界面）
            if (radioButton1.Checked)
            {
                //提示用户的label
                label_type = radioButton1.Text;
                label7.Text = "选择题目:" + label_type + "第" + Convert.ToString(label_tiankong_number) + "道";
                //显示所有的填空题
                dbHelper.connect();
                DataSet ds = dbHelper.showTiankongInMakePaperTest();
                dataGridView1.DataSource = ds.Tables["tiankong"];
                dbHelper.disconnectInsert();
                initializeSearchContents();
            }
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                //提示用户的label
                label_type = radioButton2.Text;
                label7.Text = "选择题目:" + label_type + "第" + Convert.ToString(label_xuanze_number) + "道";
                //显示所有的选择题
                dbHelper.connect();
                DataSet ds = dbHelper.showXuanzeInMakePaperTest();
                dataGridView1.DataSource = ds.Tables["xuanze"];
                dbHelper.disconnectInsert();
                initializeSearchContents();
            }
        }
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                //提示用户的label
                label_type = radioButton3.Text;
                label7.Text = "选择题目:" + label_type + "第" + Convert.ToString(label_jianda_number) + "道";
                //显示所有的简答题
                dbHelper.connect();
                DataSet ds = dbHelper.showJiandaInMakePaperTest();
                dataGridView1.DataSource = ds.Tables["jianda"];
                dbHelper.disconnectInsert();
                initializeSearchContents();
            }

        }

        //搜索按钮点击事件
        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "";
            if (radioButton1.Checked)
                sql = constructSelectSql("tiankong");
            else if (radioButton2.Checked)
                sql = constructSelectSql("xuanze");
            else if (radioButton3.Checked)
                sql = constructSelectSql("jianda");

            dbHelper.connect();
            DataTable dt = dbHelper.queryInMakePaperTest(sql);
            dbHelper.disconnect();
            dataGridView1.DataSource = dt;
        }

        //返回按钮点击事件
        private void button2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            new TMain().Show();
        }

        //生成卷子
        private void button5_Click(object sender, EventArgs e)
        {
            //先得判断题目是否都确定了，才能生成卷子
            if (label_tiankong_number == 12 && label_xuanze_number == 4 && label_jianda_number == 6)
            {
            }
            else
                MessageBox.Show("题目未输入完整");
        }

        //窗口关闭事件
        private void MakePaperTest_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }


        //-----2.自定义函数-----
        //构造查询语句函数
        private string constructSelectSql(string type)
        {
            //特别注意细节之处
            string sql = "select * from " + type;
            if (chapter.Text != "")
            {
                sql += " where chapter= '" + chapter.Text+"'";
                if(point.Text != "")
                    sql += " and point= '" + point.Text + "'";
                if (method.Text != "")
                    sql += " and method= '" + method.Text + "'";
                if (degree.Text != "")
                    sql += " and degree= '" + degree.Text + "'";
            }
            else if (point.Text != "")
            {
                sql += " where point= '" + point.Text + "'";
                if(method.Text!="")
                    sql += " and method= '" + method.Text + "'";
                if (degree.Text != "")
                    sql += " and degree= '" + degree.Text + "'";
            }
            else if (method.Text != "")
            {
                sql += " where method= '" + method.Text + "'";
                if(degree.Text !="")
                    sql += " and degree= '" + degree.Text + "'";
            }
            else if(degree.Text!="")
                sql += " where degree= '" + degree.Text + "'";
           
            return sql;
        }
   
        //初始化条件值
        private void initializeSearchContents()
        {
            chapter.Text = "";
            point.Text = "";
            method.Text = "";
            degree.Text = "";
            topic.Text = "";
        }


        //-----模块-----
        //从datagridview中点击选择题目
        //题目个数
        private int count = 0;//全部选完了再一起insert到paper表中
        private int tCount = 0;//填空题题目总数
        private int xCount = 0;//选择题题目总数
        private int jCount = 0;//简答题题目总数
        private int insertCount = 0;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DialogResult dr;
            //界面对话框设置+界面label设置
            if (label_type == "填空题")
            {
                dr = MessageBox.Show("该题作为填空题第" + label_tiankong_number + "题", "组卷", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    if (tCount < 14)
                    {
                        int number = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());//数据库中题号
                        //填空题确认某一道后调用saveNumberOfRecord()设置试题类
                        saveNumberOfRecord("填空题", number);
                        count++;//题目总数
                        tCount++;//填空题总数
                        label_tiankong_number += 1;
                        label7.Text = "选择题目:" + label_type + "第" + Convert.ToString(label_tiankong_number) + "道";
                        initializeSearchContents();
                    }
                    else if (tCount >= 14)
                        MessageBox.Show("不能再插入了");
                }
                else if (dr == DialogResult.Cancel)
                {
                    MessageBox.Show("请重新选择题目");
                }
            }
            else if (label_type == "选择题")
            {
                dr = MessageBox.Show("该题作为选择题第" + label_xuanze_number + "题", "组卷", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    if (xCount < 4)
                    {
                        int number = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());//数据库中题号
                        saveNumberOfRecord("选择题", number);
                        count++;
                        xCount++;
                        label_xuanze_number += 1;
                        label7.Text = "选择题目:" + label_type + "第" + Convert.ToString(label_xuanze_number) + "道";
                        initializeSearchContents();
                    }
                    else if(xCount >= 4)
                        MessageBox.Show("不能再插入了");
                }
                else if (dr == DialogResult.Cancel)
                {
                    MessageBox.Show("请重新选择题目");
                }
            }
            else if (label_type == "简答题")
            {
                dr = MessageBox.Show("该题作为简答题第" + label_jianda_number + "题", "组卷", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    if (jCount < 5)
                    {
                        int number = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());//数据库中题号
                        saveNumberOfRecord("简答题", number);
                        count++;
                        jCount++;
                        label_jianda_number += 1;
                        label7.Text = "选择题目:" + label_type + "第" + Convert.ToString(label_jianda_number) + "道";
                        initializeSearchContents();
                    }
                    else if(jCount >= 5)
                        MessageBox.Show("不能再插入了");
                }
                else if (dr == DialogResult.Cancel)
                {
                    MessageBox.Show("请重新选择题目");
                }
            }

            //如果题目全部确定了，就insert到paper表中
            if (count == 23)
            {
                if (insertCount == 0)
                {
                    int[] all = paper.getAllNumbers();
                    dbHelper.connect();
                    int state = dbHelper.insertNumbersToPaperTable(all);
                    if (state > 0)
                        MessageBox.Show("题目题号已经插入paper表中了");
                    dbHelper.disconnectInsert();
                    insertCount++;
                }
                else
                    MessageBox.Show("已经插入1张试卷的题号了");

                isFinished = true;
            }
        }

        //开发思想：
        //点击所选datagridview中某一行后，取出该记录的题号保存到试题类中，方便学生类从试题类中根据题号再进行查询
        //参数1代表题目类型，参数2代表数据库中的题号
        //在dataGridView中的CellClick事件中调用
        private int tAccount = 1;
        private int xAccount = 1;
        private int jAccount = 1;
        private void saveNumberOfRecord(string type, int _number)
        {
            //dataGridView1.SelectedRows[0].Cells[0].Value;正确,即为参数number
            if (type.Equals("填空题"))
            {
                int _i = tAccount ;
                paper.setTiankongNumbers(_i, _number);
                tAccount++;
            }
            else if (type.Equals("选择题"))
            {
                int _i = xAccount;
                paper.setXuanzeNumbers(_i, _number);
                xAccount++;
            }
            else if (type.Equals("简答题"))
            {
                int _i = jAccount;
                paper.setJiandaNumbers(_i, _number);
                jAccount++;
            }
        }

        private void chapter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (chapter.Text == "集合命题")
            {
                point.Items.Clear();
                point.Items.Add("");
                point.Items.Add("集合概念及其运算");
                point.Items.Add("四种命题形式");
                point.Items.Add("充分必要条件");
                point.Items.Add("集合推出关系");
            }
            else if (chapter.Text == "不等式章")
            {
                point.Items.Clear();
                point.Items.Add("");
                point.Items.Add("不等式的性质");
                point.Items.Add("解不等式");
                point.Items.Add("证不等式");
                point.Items.Add("含绝对值的问题");
                point.Items.Add("线性规划");
                point.Items.Add("恒成立问题");
            }
            else if (chapter.Text == "函数基本性质")
            {
                point.Items.Clear();
                point.Items.Add("");
                point.Items.Add("函数概念");
                point.Items.Add("建函数关系");
                point.Items.Add("函数运算");
                point.Items.Add("函数性质");
                point.Items.Add("函数图像");
                point.Items.Add("映射函数");
                point.Items.Add("二次函数方程不等式");
                point.Items.Add("函数方程");
            }
            else if (chapter.Text == "幂指对函数")
            {
                point.Items.Clear();
                point.Items.Add("");
                point.Items.Add("幂函数的图像与性质");
                point.Items.Add("指数函数的图像与性质");
                point.Items.Add("反函数");
                point.Items.Add("对数函数");
                point.Items.Add("指对方程不等式");
            }
            //下面继续添加
            else if (chapter.Text == "三角比章")
            {
                point.Items.Clear();
                point.Items.Add("");
                point.Items.Add("任意角与三角比");
                point.Items.Add("三角恒等式");
                point.Items.Add("解三角形");
                point.Items.Add("三角函数");
                point.Items.Add("反三角函数");
                point.Items.Add("三角方程");
            }
            //下面继续添加
            else if (chapter.Text == "数列与数学归纳法")
            {
                point.Items.Clear();
                point.Items.Add("");
                point.Items.Add("数列概念");
                point.Items.Add("等差数列的通项与求和");
                point.Items.Add("等比数列的通项与求和");
                point.Items.Add("递推数列求通项与求和");
                point.Items.Add("其他数列的通项与求和");
                point.Items.Add("数学归纳法");
                point.Items.Add("归纳猜想证明");
            }
            //下面继续添加
            else if (chapter.Text == "排列组合与二项式定理")
            {
                point.Items.Clear();
                point.Items.Add("");
                point.Items.Add("排列与乘法原理");
                point.Items.Add("组合与加法原理");
                point.Items.Add("二项式定理");
            }
            //下面继续添加
            else if (chapter.Text == "概率初步")
            {
                point.Items.Clear();
                point.Items.Add("");
                point.Items.Add("任意角与三角比");
                point.Items.Add("概率概念");
                point.Items.Add("等可能事件的概率");
                point.Items.Add("互斥事件");
                point.Items.Add("独立事件");
                point.Items.Add("重复试验及其概率计算");
                point.Items.Add("数学期望");
            }
            //下面继续添加
            else if (chapter.Text == "三角比章")
            {
                point.Items.Clear();
                point.Items.Add("");
                point.Items.Add("任意角与三角比");
                point.Items.Add("三角恒等式");
                point.Items.Add("三角恒等式");
                point.Items.Add("三角恒等式");
                point.Items.Add("三角恒等式");
            }
            //下面继续添加
            else if (chapter.Text == "数理统计等")
            {
                point.Items.Clear();
                point.Items.Add("");
                point.Items.Add("统计量口");
                point.Items.Add("频率分布图");
                point.Items.Add("抽样方法");
                point.Items.Add("统计分布");
            }
            //下面继续添加
            else if (chapter.Text == "复数初步")
            {
                point.Items.Clear();
                point.Items.Add("");
                point.Items.Add("复数概念和表示");
                point.Items.Add("复数运算");
                point.Items.Add("方程复根");
            }
            //下面继续添加
            else if (chapter.Text == "向量初步")
            {
                point.Items.Clear();
                point.Items.Add("");
                point.Items.Add("向量概念及运算");
                point.Items.Add("平面向量坐标表示及其运算");
                point.Items.Add("数量积与性质");
                point.Items.Add("空间向量坐标表示及其运算");
                point.Items.Add("空间向量坐标表示及其运算");
                point.Items.Add("向量积与性质");
            }
            //下面继续添加
            else if (chapter.Text == "坐标平面上的直线")
            {
                point.Items.Clear();
                point.Items.Add("");
                point.Items.Add("坐标方程基本概念");
                point.Items.Add("直线方程");
                point.Items.Add("夹角距离公式");
                point.Items.Add("点线对称");
                point.Items.Add("曲线与方程");
            }
            //下面继续添加
            else if (chapter.Text == "圆锥曲线")
            {
                point.Items.Clear();
                point.Items.Add("");
                point.Items.Add("圆方程与性质");
                point.Items.Add("椭圆方程与性质");
                point.Items.Add("双曲线方程与性质");
                point.Items.Add("抛物线方程与性质");
                point.Items.Add("平移坐标轴");
                point.Items.Add("参数方程");
                point.Items.Add("极坐标与极坐标方程");
            }
            //下面继续添加
            else if (chapter.Text == "三角比章")
            {
                point.Items.Clear();
                point.Items.Add("");
                point.Items.Add("任意角与三角比");
                point.Items.Add("三角恒等式");
                point.Items.Add("三角恒等式");
                point.Items.Add("三角恒等式");
                point.Items.Add("三角恒等式");
            }
            //下面继续添加
            else if (chapter.Text == "空间图形")
            {
                point.Items.Clear();
                point.Items.Add("");
                point.Items.Add("空间图形的位置关系");
                point.Items.Add("多面体的概念与计算");
                point.Items.Add("旋转体的概念与计算");
                point.Items.Add("空间坐标系");
                point.Items.Add("三视图口");
            }
          

        }

        

       

        
    }
}
