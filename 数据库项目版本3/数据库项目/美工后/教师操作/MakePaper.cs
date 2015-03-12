using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
//word操作
using MSWord = Microsoft.Office.Interop.Word;
//文件
using System.IO;
using System.Reflection;

namespace Test
{
    public partial class MakePaper : Form
    {
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

        public MakePaper()
        {
            InitializeComponent();
            dbHelper = new DBHelper();
            paper = new Paper();
            label7.Text = "选择题目:" + label_type + "第" + Convert.ToString(label_tiankong_number) + "道";
        }

        private void getSearchValue()
        {
            sChapter = chapter.Text;
            sPoint = point.Text;
            sMethod = method.Text;
            sDegree = degree.Text;
            sTopic = topic.Text;

            if (sChapter != "")
                sCondition[0] = 1;
            if (sPoint != "")
                sCondition[1] = 1;
            if (sMethod != "")
                sCondition[2] = 1;
            if (sDegree != "")
                sCondition[3] = 1;
            if (sTopic != "")
                sCondition[4] = 1;
        }

        //得到搜索条件个数
        private int getCount()
        {
            int count = 0;
            for (int i = 0; i < sCondition.Length; i++)
            {
                if (sCondition[i] == 1)
                    count++;
            }
            return count;
        }

        //路径选择按钮
        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult result = saveFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
                textBox2.Text = saveFileDialog1.FileName;/*+ ".doc";*/
            else
                textBox2.Text = "";

        }

        //搜索点击事件
        private void button1_Click(object sender, EventArgs e)
        {
            getSearchValue();//给私有变量先赋值
            //搜索条件1个
            if (getCount() == 1)
            {
                if (sCondition[0] == 1)//按chapter搜索
                {
                    DataTable dt = new DataTable() ;
                    dbHelper.connect();
                    if (tabControl1.SelectedTab.Name == "填空题")
                        dt = dbHelper.queryByChapter("填空题",sChapter);
                    else if (tabControl1.SelectedTab.Name == "选择题")
                        dt = dbHelper.queryByChapter("选择题",sChapter);
                    else if (tabControl1.SelectedTab.Name == "简答题")
                        dt = dbHelper.queryByChapter("简答题",sChapter);
                    dbHelper.disconnectInsert();
                    dataGridView1.DataSource = dt;
                }
                else if (sCondition[1] == 1)
                {
                    DataTable dt = new DataTable();
                    dbHelper.connect();

                    if (tabControl1.SelectedTab.Name == "填空题")
                    {
                        dt = dbHelper.queryByPoint("填空题", sPoint);
                        dbHelper.disconnectInsert();
                        dataGridView1.DataSource = dt;
                    }
                    else if (tabControl1.SelectedTab.Name == "选择题")
                    {
                        dt = dbHelper.queryByPoint("选择题", sPoint);
                        dbHelper.disconnectInsert();
                        dataGridView2.DataSource = dt;
                    }
                    else if (tabControl1.SelectedTab.Name == "简答题")
                    {
                        dt = dbHelper.queryByPoint("简答题", sPoint);
                        dbHelper.disconnectInsert();
                        dataGridView3.DataSource = dt;
                    }
                }
                else if (sCondition[2] == 1)
                {
                    DataTable dt = new DataTable();
                    dbHelper.connect();
                    if(tabControl1.SelectedTab.Name == "填空题")
                        dt = dbHelper.queryByMethod("填空题", sPoint);
                    else if (tabControl1.SelectedTab.Name == "选择题")
                        dt = dbHelper.queryByMethod("选择题", sPoint);
                    else if (tabControl1.SelectedTab.Name == "简答题")
                        dt = dbHelper.queryByMethod("简答题", sPoint);
                    dbHelper.disconnectInsert();
                    dataGridView1.DataSource = dt;
                }
                else if (sCondition[3] == 1)
                {
                    DataTable dt = new DataTable();
                    dbHelper.connect();
                    if (tabControl1.SelectedTab.Name == "填空题")
                        dt = dbHelper.queryByDegree("填空题", sDegree);
                    else if (tabControl1.SelectedTab.Name == "选择题")
                        dt = dbHelper.queryByDegree("选择题", sDegree);
                    else if (tabControl1.SelectedTab.Name == "简答题")
                        dt = dbHelper.queryByDegree("简答题", sDegree);
                    dbHelper.disconnectInsert();
                    dataGridView1.DataSource = dt;
                }
                else if (sCondition[4] == 1)
                {
                    DataTable dt = new DataTable();
                    dbHelper.connect();
                    if (tabControl1.SelectedTab.Name == "填空题")
                        dt = dbHelper.queryByTopic("填空题", sTopic);
                    else if (tabControl1.SelectedTab.Name == "选择题")
                        dt = dbHelper.queryByTopic("选择题", sTopic);
                    else if (tabControl1.SelectedTab.Name == "简答题")
                        dt = dbHelper.queryByTopic("简答题", sTopic);
                    dbHelper.disconnectInsert();
                    dataGridView1.DataSource = dt;
                }
            }
            //多个条件的搜索!!!!!!!!
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

        //选中了某一行代表选中了该题目，则将该题目存到试卷类中并生成到卷子中
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            DialogResult dr;
            //界面对话框设置+界面label设置
            if (label_type == "填空题")
            {
                dr = MessageBox.Show("该题作为填空题第" + label_tiankong_number + "题", "组卷", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    //填空题确认某一道后调用saveNumberOfRecord()设置试题类
                    int number = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString()) ;//数据库中题号
                    saveNumberOfRecord("填空题",number);
                    //测试MessageBox.Show(paper.getTiankongNumbers(label_tiankong_number).ToString());
                    label_tiankong_number += 1;
                    label7.Text = "选择题目:" + label_type + "第" + Convert.ToString(label_tiankong_number) + "道";
                    initializeSearchContents();
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
                    int number = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells[0].Value.ToString());//数据库中题号
                    saveNumberOfRecord("选择题", number);
                    label_xuanze_number += 1;
                    label7.Text = "选择题目:" + label_type + "第" + Convert.ToString(label_xuanze_number) + "道";
                    initializeSearchContents();
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
                    int number = Convert.ToInt32(dataGridView3.SelectedRows[0].Cells[0].Value.ToString());//数据库中题号
                    saveNumberOfRecord("简答题", number);
                    label_jianda_number += 1;
                    label7.Text = "选择题目:" + label_type + "第" + Convert.ToString(label_jianda_number) + "道";
                    initializeSearchContents();
                }
                else if (dr == DialogResult.Cancel)
                {
                    MessageBox.Show("请重新选择题目");
                }
            } 
            
            //!!!将该题目存到试卷类中并生成到卷子中!!!
            


        }

       

        //5/22开发思想：
        //点击所选datagridview中某一行后，取出该记录的题号保存到试题类中，方便学生类从试题类中根据题号再进行查询
        //参数1代表题目类型，参数2代表数据库中的题号
        //在dataGridView中的CellClick事件中调用
        private void saveNumberOfRecord(string type,int _number)
        {
            //dataGridView1.SelectedRows[0].Cells[0].Value;正确,即为参数number
            if(type.Equals("填空题"))
            {
                int _i = label_tiankong_number;
                paper.setTiankongNumbers(_i, _number);
            }
            else if (type.Equals("选择题"))
            {
                int _i = label_xuanze_number;
                paper.setXuanzeNumbers(_i, _number);
            }
            else if (type.Equals("简答题"))
            {
                int _i = label_jianda_number;
                paper.setJiandaNumbers(_i, _number);
            }
        }


        //选择不同tab内容，触发label内容的改变（界面）
        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            label_type = tabControl1.SelectedTab.Text.ToString();
            if (label_type == "填空题")
                label7.Text = "选择题目:" + label_type + "第" + Convert.ToString(label_tiankong_number) + "道";
            else if (label_type == "选择题")
                label7.Text = "选择题目:" + label_type + "第" + Convert.ToString(label_xuanze_number) + "道";
            else if(label_type == "简答题")
                label7.Text = "选择题目:" + label_type + "第" + Convert.ToString(label_jianda_number) + "道";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            new TMain().Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //word生成测试
        private void button5_Click(object sender, EventArgs e)
        {
            object path;
            string strContent;
            string subjectname;
            string punctuation = "、";

            MSWord.Application WordApp;
            MSWord.Document WordDoc;

            path = @textBox2.Text.Trim();
            WordApp = new MSWord.ApplicationClass();

            if (File.Exists((string)path))
                File.Delete((string)path);
            WordApp.Visible = false;//设置word应用程序为不可见

            object nothing = Missing.Value;
            WordDoc = WordApp.Documents.Add(ref nothing, ref nothing, ref nothing, ref nothing);

            WordDoc.PageSetup.PaperSize = MSWord.WdPaperSize.wdPaperA3;//页面设置
            WordDoc.PageSetup.Orientation = MSWord.WdOrientation.wdOrientLandscape;//横板还是竖板
            WordDoc.PageSetup.TextColumns.SetCount(2);//分栏
            subjectname = "高考数学模拟卷\n";
            WordDoc.Paragraphs.Last.Range.Font.Size = 16;
            WordDoc.Paragraphs.Last.Range.Font.Bold = 1;
            WordApp.Selection.ParagraphFormat.Alignment = MSWord.WdParagraphAlignment.wdAlignParagraphLeft;//设置左对齐 
            WordDoc.Paragraphs.Last.Range.Text = subjectname;

            strContent = "学号___________  姓名_________  成绩_______\n";
            WordDoc.Paragraphs.Last.Range.Font.Size = 12;
            WordDoc.Paragraphs.Last.Range.Text = strContent;

            MessageBox.Show("生成了");
        }
        
    }
}
