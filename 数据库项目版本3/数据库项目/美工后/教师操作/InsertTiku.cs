using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace Test
{
    public partial class InsertTiku : Form
    {
        private DBHelper dbHelper;

        public InsertTiku()
        {
            InitializeComponent();
            dbHelper = new DBHelper();
            //遍历
            dbHelper.connect();
            int row1 = dbHelper.traverseTable("选择题");
            showXuanzeTihao.Text = row1.ToString();
            int row2 = dbHelper.traverseTable("填空题");
            showTiankongTihao.Text = row2.ToString();
            int row3 = dbHelper.traverseTable("判断题");
            showPanduanTihao.Text = row3.ToString();
            int row4 = dbHelper.traverseTable("简答题");
            showJiandaTihao.Text = row4.ToString();
            //dbHelper.connect();
            //int row = dbHelper.traverseTable();
            dbHelper.disconnect();
            //label.Text = row.ToString();
        }

        //选择题：是否输入了内容
        private bool isInputXuanzeContents()//内容一定要输入
        {
            //number，degree,topic,A,B,C,D,answer,value属性不能为空
            if(number.Text == "" || topic.Text == "" || A.Text == "" || B.Text == "" || C.Text == "" || D.Text == "" || answer.Text == "" || value.Text == "")
                return false;
            else
                return true;
        }

        //填空题：5个空判断
        private bool isFiveBlankInput()
        {
            //全部没输入为真
            if (kong1.Text == "" && kong2.Text == "" && kong3.Text == "" && kong4.Text == "" && kong5.Text == "")
                return true;
            else
                return false;
        }

        //填空题：是否输入了内容
        private bool isInputTiankongContents()
        {
            if (number1.Text == "" || topic1.Text == "" || answer1.Text == "" || isFiveBlankInput())
                return false;
            else 
                return true;
        }

        //判断题：是否输入了内容
        private bool isInputPanduanContents()
        {
            if (number2.Text == "" || topic2.Text == "")
                return false;
            else 
                return true;
        }

        //简答题：是否输入了内容
        private bool isInputJiandaContents()
        {
            if (number3.Text == "" || topic3.Text == "" || answer3.Text == "")
                return false;
            else 
                return true;
        }

        //是否输入了属性
        private bool isInputAttributes()
        {
            if (chapter.Text == "" || point.Text == "" || degree.Text == "")
                return false;
            else
                return true;
        }

        private bool isNumberic(string str)
        {
            //法一：try-catch
            /*
            try
            {
                int v = Convert.ToInt32(str);
                return true;
            }
            catch
            {
                return false;
            }
            */
            //法二：正则表达式
            return Regex.IsMatch(str, @"^[+-]?/d*[.]?/d*$");
        }

        //输入题号是否正确
        private bool isTihaoCorrect(string type)
        {
            //注意要类型转化！！坑了好长时间啊！
            if (type == "选择题")
            {
                if (Convert.ToInt32(number.Text) == (Convert.ToInt32(showXuanzeTihao.Text) + 1))
                    return true;
                else 
                    return false;//题号输入错误
            }
            else if (type == "填空题")
            {
                if (Convert.ToInt32(number1.Text) == (Convert.ToInt32(showTiankongTihao.Text) + 1))
                    return true;
                else
                    return false;
            }
            else if (type == "判断题")
            {
                if (Convert.ToInt32(number2.Text) == (Convert.ToInt32(showPanduanTihao.Text) + 1))
                    return true;
                else
                    return false;
            }
            else if (type == "简答题")
            {
                if (Convert.ToInt32(number3.Text) == (Convert.ToInt32(showJiandaTihao.Text) + 1))
                    return true;
                else
                    return false;
            }
            return false;
        }

        //和选择题的模式对应
        private string[] getXuanzeContents()
        {
            string[] contents = new string[15];
            contents[0] = number.Text;//题号
            contents[1] = Convert.ToString(1);//题型
            contents[2] = chapter.Text;//章节
            contents[3] = point.Text;//知识点
            contents[4] = method.Text;//思想方法
            contents[5] = degree.Text;//难易程度
            contents[6] = topic.Text;//题目
            contents[7] = A.Text;//4个选项
            contents[8] = B.Text;
            contents[9] = C.Text;
            contents[10] = D.Text;
            contents[11] = answer.Text;//答案
            contents[12] = value.Text;//分值
            contents[13] = jieda.Text;//解答过程
            contents[14] = dianping.Text;//点评
            return contents;

        }
        
        //和填空题的模式对应
        private string[] getTiankongContents()
        {
            string[] contents = new string[16];
            contents[0] = number1.Text;//number
            contents[1] = Convert.ToString(2);//typeID
            contents[2] = chapter.Text;
            contents[3] = point.Text;
            contents[4] = method.Text;
            contents[5] = degree.Text;
            contents[6] = topic1.Text;
            contents[7] = kong1.Text;
            contents[8] = kong2.Text;
            contents[9] = kong3.Text;
            contents[10] = kong4.Text;
            contents[11] = kong5.Text;
            contents[12] = answer1.Text;
            contents[13] = value1.Text;
            contents[14] = jieda1.Text;
            contents[15] = dianping1.Text;
            return contents;
        }

        //和判断题的模式对应
        private string[] getPanduanContents()
        {
            string[] contents = new string[8];
            contents[0] = number2.Text;
            contents[1] = Convert.ToString(3);
            contents[2] = chapter.Text;
            contents[3] = point.Text;
            contents[4] = method.Text;
            contents[5] = degree.Text;
            contents[6] = topic2.Text;
            contents[7] = answer2.Text;
            return contents;
        }

        //和简答题的模式对应
        private string[] getJiandaContents()
        {
            string[] contents = new string[11];
            contents[0] = number3.Text;
            contents[1] = Convert.ToString(4);
            contents[2] = chapter.Text;
            contents[3] = point.Text;
            contents[4] = method.Text;
            contents[5] = degree.Text;
            contents[6] = topic3.Text;
            contents[7] = answer3.Text;
            contents[8] = value3.Text;
            contents[9] = jieda3.Text;
            contents[10] = dianping3.Text;
            return contents;
        }

        //返回按钮点击事件
        private void button3_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            new TMain().Show();
        }

        //关闭按钮点击事件
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //选择题录入
        private void button1_Click(object sender, EventArgs e)
        {
            if (isInputXuanzeContents() == false)
                MessageBox.Show("请将内容输入完整");
            else if (isInputAttributes() == false)
                MessageBox.Show("请输入必填属性");
            else if (isTihaoCorrect("选择题") == false)
                MessageBox.Show("请输入正确题号");
            else
            {
                dbHelper.connect();
                string[] information = getXuanzeContents();
                int rows = dbHelper.insertXuanze(information);
                if (rows > 0)
                {
                    MessageBox.Show("插入成功");
                    showXuanzeTihao.Text = Convert.ToString(Convert.ToInt16(showXuanzeTihao.Text) + 1);
                    number.Text = "";
                    topic.Text = "";
                    answer.Text = "";
                    A.Text = "";
                    B.Text = "";
                    C.Text = "";
                    D.Text = "";
                    jieda.Text = "";
                    dianping.Text = "";
                    chapter.Text = Convert.ToString(chapter.Items[0]);
                    point.Text = Convert.ToString(point.Items[0]);
                    method.Text = Convert.ToString(method.Items[0]);
                    degree.Text = Convert.ToString(degree.Items[0]);
                }
                else
                    MessageBox.Show("插入失败");
                dbHelper.disconnectInsert();
            }
        }

        //填空题录入
        private void button4_Click(object sender, EventArgs e)
        {
            if (isInputTiankongContents() == false)
                MessageBox.Show("请输入完整");
            else if (isInputAttributes() == false)
                MessageBox.Show("请输入必填属性");
            else if (isTihaoCorrect("填空题") == false)
                MessageBox.Show("请输入正确题号");
            else
            {
                dbHelper.connect();
                string[] information = getTiankongContents();
                int rows = dbHelper.insertTiankong(information);
                if (rows > 0)
                {
                    MessageBox.Show("插入成功");
                    showTiankongTihao.Text = Convert.ToString(Convert.ToInt32(showTiankongTihao.Text) + 1);
                    number1.Text = "";
                    topic1.Text = "";
                    answer1.Text = "";
                    kong1.Text = "";
                    kong2.Text = "";
                    kong3.Text = "";
                    kong4.Text = "";
                    kong5.Text = "";
                    jieda1.Text = "";
                    dianping1.Text = "";
                    chapter.Text = Convert.ToString(chapter.Items[0]);
                    point.Text = Convert.ToString(point.Items[0]);
                    method.Text = Convert.ToString(method.Items[0]);
                    degree.Text = Convert.ToString(degree.Items[0]);
                }
                else
                    MessageBox.Show("插入失败");
                dbHelper.disconnectInsert();
            }

        }

        //判断题录入
        private void button5_Click(object sender, EventArgs e)
        {
            if (isInputPanduanContents() == false)
                MessageBox.Show("请输入完整");
            else if (isInputAttributes() == false)
                MessageBox.Show("请输入必填属性");
            else if (isTihaoCorrect("判断题") == false)
                MessageBox.Show("请输入正确题号");
            else
            {
                dbHelper.connect();
                string[] information = getPanduanContents();
                int rows = dbHelper.insertPanduan(information);
                if (rows > 0)
                {
                    MessageBox.Show("插入成功");
                    showPanduanTihao.Text = Convert.ToString(Convert.ToInt32(showPanduanTihao.Text)+1);
                    number2.Text = "";
                    topic2.Text = "";
                    answer2.Text = "√";
                }
                else
                    MessageBox.Show("插入失败");
                dbHelper.disconnectInsert();
            }
        }

        //简答题录入
        private void button6_Click(object sender, EventArgs e)
        {
            if (isInputJiandaContents() == false)
                MessageBox.Show("请输入完整");
            else if (isInputAttributes() == false)
                MessageBox.Show("请输入必填属性");
            else if (isTihaoCorrect("简答题") == false)
                MessageBox.Show("请输入正确题号");
            else
            {
                dbHelper.connect();
                string[] information = getJiandaContents();
                int rows = dbHelper.insertJianda(information);
                if (rows > 0)
                {
                    MessageBox.Show("插入成功");
                    //题号加1   所有空格内容初始化
                    showJiandaTihao.Text = Convert.ToString(Convert.ToInt16(showJiandaTihao.Text) + 1);
                    number3.Text = "";
                    topic3.Text = "";
                    answer3.Text = "";
                    value3.Text = "";
                    jieda3.Text = "";
                    dianping3.Text = "";
                }
                else
                    MessageBox.Show("插入失败");
                dbHelper.disconnectInsert();
            }

        }

        private void InsertTiku_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("确认退出吗？", "注意", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (result == DialogResult.Cancel)
                e.Cancel = true;
        }

        //point里的值根据chapter的值动态修改
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
