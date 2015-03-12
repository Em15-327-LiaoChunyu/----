using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace Test
{
    public partial class Choose : Form
    {
        public static string chapter = "";//章节
        public static string point = "";//知识点
        public static string method = "";//思想方法属性
        public static string degree = "";//难度属性
        private DBHelper dbHelper;

        public Choose()
        {
            InitializeComponent();
            dbHelper = new DBHelper();
        }

        //???想先选好属性，再选择操作,在哪里调用的问题
        int state;
        public void button_show()
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                if (checkedListBox1.GetItemChecked(i))
                {
                    state = 1;
                    break;
                }
            }
            if (state == 1)
            {
                button1.Visible = true;
                button2.Visible = true;
                button3.Visible = true;
            }
        }
      
        //判断是否选择了题目的属性并且得到一些属性值
        private int canChooseOperation()
        {
            int state = 0;
            //必选项
            bool isChapter = false;
            bool isPoint = false;
            bool isDegree = false;
            //章节选了吗
            for (int i = 0; i < chapterWord.Items.Count; i++)
            {
                if (chapterWord.GetItemChecked(i))
                {
                    isChapter = true;
                    break;
                }
            }
            //得到chapter的值
            foreach (object itemChecked in chapterWord.CheckedItems)
            {
                chapter = chapter + itemChecked.ToString() + " ";
            }
            //知识点选了吗
            for (int i = 0; i < pointWord.Items.Count; i++)
            {
                if (pointWord.GetItemChecked(i))
                {
                    isPoint = true;
                    break;
                }
            }
            //得到point的值
            foreach (object itemChecked in pointWord.CheckedItems)
            {
                point = point + itemChecked.ToString() + " ";
            }
            /*
            //思想方法选了吗
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                if (checkedListBox1.GetItemChecked(i))
                {
                    can = true;
                    break;
                }
            }*/
            //为method字段赋值
            foreach (object itemChecked in checkedListBox1.CheckedItems)
            {
                method = method + itemChecked.ToString() + " ";
            }


            //题目难度选了吗
            if (radioButton1.Checked)
            {
                isDegree = true;
                degree = radioButton1.Text;
            }
            else if (radioButton2.Checked)
            {
                isDegree = true;
                degree = radioButton2.Text;
            }
            else if (radioButton3.Checked)
            {
                isDegree = true;
                degree = radioButton3.Text;
            }

            //判断
            if (!isChapter)
                state = 1;//章节没选
            else if (isChapter && !isPoint)
                state = 2;
            else if (isChapter && isPoint && !isDegree)
                state = 3;
            else
                state = 4;
            return state;
        }

        //insert 新建word+插入数据库表中
        private void button1_Click(object sender, EventArgs e)
        {
            if (canChooseOperation() == 4)
            {
                //从控件得到用户的选择->通过ConstructWordName对象的方法来构造word名称
                ConstructWordName wordname = new ConstructWordName();
                wordname.setChapter(chapter);
                wordname.setPoint(point);
                wordname.setMethod(method);
                wordname.setDegree(degree);
                string name = wordname.constructName();

                //然后就生成word
                //问题：如果word已经存在怎么办？
                //解决方法：先检查是否存在，若存在，则将一个_标识
                ConstructWord word = new ConstructWord();
                word.setName(name);
                bool isFinish = word.construct();
                if (isFinish)
                    MessageBox.Show("创建word成功!");
                else
                    MessageBox.Show("创建word失败!");

                //路径存到数据库中
                /*
                String path = word.getPath();
                int state = dbHelper.insertShiti(path);
                if (state > 1)
                    MessageBox.Show("路径已存入数据库");
                else
                    MessageBox.Show("路径未存入数据库");
                 * */
            }
            else
            {
                MessageBox.Show("请先选择题目属性");
            }
            
            
        }

       

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            //字符串可以构造
            openFileDialog.InitialDirectory = "E:\\2014课件\\数据库\\项目\\测试试题文件夹\\函数基本性质 _函数图像 _定义公式 _中等.doc";
            openFileDialog.Filter = "所有文件(*.*)|*.*";
            openFileDialog.RestoreDirectory = true;
            openFileDialog.FilterIndex = 1;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (openFileDialog.FileName != "")
                    Process.Start(openFileDialog.FileName);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            //字符串可以构造
            openFileDialog.InitialDirectory = "E:\\2014课件\\数据库\\项目\\测试试题文件夹\\函数基本性质 _函数图像 _定义公式 _中等.doc";
            openFileDialog.Filter = "所有文件(*.*)|*.*";
            openFileDialog.RestoreDirectory = true;
            openFileDialog.FilterIndex = 1;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (openFileDialog.FileName != "")
                    Process.Start(openFileDialog.FileName);
            }
        }

   
        //选择章节内容改变触发事件
        private void chapterWord_SelectedValueChanged(object sender, EventArgs e)
        {
            //清空pointWord中内容
            for (int i = 0; i < pointWord.Items.Count; i++)
            {
                pointWord.Items.RemoveAt(i);
            }
            if (chapterWord.SelectedItem.ToString() == "集合命题")
            {
                pointWord.Items.Add("集合概念及其运算");
                pointWord.Items.Add("四种命题形式");
                pointWord.Items.Add("充分必要条件");
            }
            else if (chapterWord.SelectedItem.ToString() == "不等式章")
            {
                pointWord.Items.Add("不等式的性质");
                pointWord.Items.Add("解不等式");
                pointWord.Items.Add("证不等式");
                pointWord.Items.Add("含绝对值的问题");
                pointWord.Items.Add("线性规划");
                pointWord.Items.Add("恒成立问题");
            }
            else if (chapterWord.SelectedItem.ToString() == "函数基本性质")
            {
                pointWord.Items.Add("函数概念");
                pointWord.Items.Add("建函数关系");
                pointWord.Items.Add("函数运算");
                pointWord.Items.Add("函数图像");
                pointWord.Items.Add("映射函数");
                pointWord.Items.Add("二次函数方程不等式");
                pointWord.Items.Add("函数方程");
            }
            //......
        }

        //使checkedListBox只能单选
        private void chapterWord_ItemCheck_1(object sender, ItemCheckEventArgs e)
        {
            //清空pointWord中内容
            for (int i = 0; i < pointWord.Items.Count; i++)
            {
                pointWord.Items.RemoveAt(i);
            }
            for (int i = 0; i < chapterWord.Items.Count; i++)
            {
                if (i != e.Index)
                {
                    chapterWord.SetItemCheckState(i, System.Windows.Forms.CheckState.Unchecked);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            new TMain().Show();
        }
    }
}
