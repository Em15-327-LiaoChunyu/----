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
    public partial class Administer : Form
    {
        private DBHelper dbHelper;
        public Administer()
        {
            InitializeComponent();
            dbHelper = new DBHelper();
            dbHelper.connect();
            DataTable dt = dbHelper.getChangeInformation();
            dbHelper.disconnectInsert();
            dataGridView1.DataSource = dt;

            //Log表 (name time basicInformation oldContent newContent)
            //basicInformation:包括了哪张表哪个记录哪几个字段 
            //oldContent:原来信息
            //newContent:修改完的信息
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            new Login().Show();
        }

    }
}
