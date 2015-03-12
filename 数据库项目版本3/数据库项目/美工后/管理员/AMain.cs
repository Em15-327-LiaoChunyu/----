using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Test.管理员
{
    public partial class AMain : Form
    {
        private DBHelper dbHelper;
        private int mode;//1为查看用户 2为查看Log表

        public AMain()
        {
            InitializeComponent();
            dbHelper = new DBHelper();
        }

        //查看用户
        private void button1_Click(object sender, EventArgs e)
        {
            dbHelper.connect();
            DataTable dt = dbHelper.getUserInformationInAMain();
            dbHelper.disconnectInsert();
            dataGridView1.DataSource = dt;
            mode = 1;
        }

        //查看Log表
        private void button2_Click(object sender, EventArgs e)
        {
            dbHelper.connect();
            DataTable dt = dbHelper.getLogInformationInAMain();
            dbHelper.disconnectInsert();
            dataGridView1.DataSource = dt;
            mode = 2;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            new Login().Show();
        }

        //选择某一行即删除
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (mode == 1)
            {
                DialogResult dr = MessageBox.Show("确定删除该用户吗?", "注意", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                    string sql = "delete from SystemUser where id = " + id;
                    dbHelper.connect();//删除用户
                    dbHelper.deleteUserInAMain(sql);
                    dbHelper.disconnectInsert();

                    dbHelper.connect();//再显示
                    DataTable dt = dbHelper.getUserInformationInAMain();
                    dbHelper.disconnectInsert();
                    dataGridView1.DataSource = dt;
                }
                else
                { }
            }
        }

    }
}
