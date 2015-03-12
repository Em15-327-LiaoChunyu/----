using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace Test
{
    public partial class TMain : Form
    {
        public TMain()
        {
            InitializeComponent();
            label1.Text = "欢迎";
            label4.Text = Login.name;
            label2.Text = "老师使用本系统";
            //old:     label1.Text = "欢迎" + Login.name + "老师使用本系统";
            timer1.Start();
        }

        //编辑题库按钮事件
        private void button1_Click(object sender, EventArgs e)
        {
            //this.SetStyle(ControlStyles.SupportsTransparentBackColor,true);//6.13 lsm
            //this.BackColor = Color.Transparent;//lsm
            this.Visible = false;
            new InsertTiku().Show();
            /*
            Process p = new Process();
            ProcessStartInfo psi = new ProcessStartInfo("E:\\tiku\\新建 Microsoft Office Word 文档.docx");
            p.StartInfo = psi;
            try
            {
                p.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("发生错误");
            }
             * */
        }

        //组装卷子按钮事件
        private void button2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            new Test.教师操作.MakePaperTest().Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            new UDTiku().Show();
        }

        //word方式录入题目
        private void button4_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            new Choose().Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            new ChangePassword().Show();
        }


        //返回按钮点击事件
        private void button6_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("确认退出吗？", "注意", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (result == DialogResult.OK)
            {
                this.Visible = false;
                new Login().Show();
            }
        }


       
    }
}
