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
    public partial class Login : Form
    {
        private DBHelper dbHelper;
        
        //用于界面间传值!!!
        public static string name;
    
        public Login()
        {
            InitializeComponent();
            dbHelper = new DBHelper();
            //方便调试
            textBox1.Text = "zack";
            textBox2.Text = "123456";
            //设置窗口大小
            //MessageBox.Show(Convert.ToString(Screen.PrimaryScreen.Bounds.Width));1366
            //MessageBox.Show(Convert.ToString(Screen.PrimaryScreen.Bounds.Height));768
        }

        //确定按钮点击事件：先连接数据库+再逻辑判断
        private void button1_Click(object sender, EventArgs e)
        {
            int state;
            //从界面得到信息
            name = this.textBox1.Text.ToString();
            string password = this.textBox2.Text.ToString();
            //连接数据库
            dbHelper.connect();
            //查询用户之前先判断是否输入了name和password
            if (name == "" && password == "")
            {
                MessageBox.Show("请输入您的登录名和密码", "注意", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (name == "")
            {
                MessageBox.Show("请输入您的登录名", "注意", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (password == "")
            {
                MessageBox.Show("请输入您的密码", "注意", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //name和password都输入了，然后到数据库中查询用户
            if (name != "" && password != "")
            {
                if (name == "admin" && password == "123")
                {
                    this.Visible = false;
                    new Test.管理员.AMain().Show();
                }
                else
                {
                    state = dbHelper.queryUser(name, password);
                    if (state == 4)//教师
                    {
                        MessageBox.Show("恭喜您登录成功!", "登录成功!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.Visible = false;
                        new TMain().Show();

                    }
                    else if (state == 5)//学生
                    {
                        MessageBox.Show("恭喜您登录成功!", "登录成功!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Visible = false;
                        new Test.学生操作.SMain().Show();
                    }
                    else if (state == 2)
                    {
                        this.textBox2.Text = "";
                        MessageBox.Show("密码错误，请重新输入!", "错误!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (state == 3)
                    {
                        this.textBox1.Text = "";
                        this.textBox2.Text = "";
                        MessageBox.Show("此用户不存在，请您注册!", "注册", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    //关闭数据库
                    dbHelper.disconnect();
                }
            }
        }

        //退出按钮点击事件
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //注册按钮点击事件
        private void button3_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            new Register().Show();
        }


        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("确认退出吗？", "注意", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (result == DialogResult.Cancel)
                e.Cancel = true;
        }

    }
}
