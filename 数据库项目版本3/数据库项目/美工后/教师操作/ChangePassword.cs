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
    public partial class ChangePassword : Form
    {
        private DBHelper dbHelper;

        public ChangePassword()
        {
            InitializeComponent();
            dbHelper = new DBHelper();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string getName = name.Text;
            string getPassword = password.Text;
            string getNewPassword = newpassword.Text;
            string getRepeatPassword = repeatPassword.Text;
            dbHelper.connect();
            int state = dbHelper.changePassword(getName, getPassword, getNewPassword, getRepeatPassword);
            switch (state)
            {
                case 0:
                    MessageBox.Show("您输入的用户名不存在");
                    name.Text = "";
                    password.Text = "";
                    newpassword.Text = "";
                    repeatPassword.Text = "";
                    break;
                case 1:
                    MessageBox.Show("您输入的密码错误");
                    password.Text = "";
                    newpassword.Text = "";
                    repeatPassword.Text = "";
                    break;
                case 2:
                    MessageBox.Show("两次密码输入不一致，请重新输入");
                    newpassword.Text = "";
                    repeatPassword.Text = "";
                    break;
                case 3:
                    MessageBox.Show("密码修改成功");
                    break;
            }
            dbHelper.disconnectInsert();
        }

        //返回按钮
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            new TMain().Show();
        }
    }
}
