using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace Test
{
    public partial class Register : Form
    {
        private DBHelper dbHelper;

        public Register()
        {
            InitializeComponent();
            dbHelper = new DBHelper();
        }

        //确定按钮
        private void button1_Click(object sender, EventArgs e)
        {
            int state;
            //先获取用户的输入
            string name = textBox1.Text.ToString();
            string password = textBox2.Text.ToString();
            string passwordAgain = textBox3.Text.ToString();
            string role = "";
            if (radioButton1.Checked)//如果用户是教师
            {
                role = "teacher";
            }
            else if (radioButton2.Checked)//如果用户是学生
            {
                role = "student";
            }
            //开始逻辑判断
            if (name == "" || password == "" || passwordAgain == "" || role == "")
            {
                MessageBox.Show("请将信息输入完整");
            }
            else//信息输入完整
            {
                if (password.Equals(passwordAgain))
                {
                    //连接数据库
                    //dbHelper.connect();
                    //插入前参数准备(界面上得到的信息作为参数)
                    string[] information = {name,password,role};
                    //先打开数据库
                    dbHelper.connect();
                    //开始插入
                    state = dbHelper.insertUser(information);
                    if (state > 0)
                    {
                        MessageBox.Show("添加用户成功!");
                        this.Visible = false;
                        //注册成功后，返回到Login界面
                        new Login().Show();
                    }
                    else
                    {
                        MessageBox.Show("添加失败，请稍后再试");
                    }
                }
                else
                {
                    MessageBox.Show("两次密码不一致");
                }
            }
            //关闭数据库
            dbHelper.disconnectInsert();
        }

        //取消按钮，返回Login界面
        private void button2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            new Login().Show();
        }

    }
}
