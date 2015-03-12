using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Test.学生操作
{
    public partial class SMain : Form
    {
        public SMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            new AnalyzePaper().Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            //new InputScore().Show();
            new GetSimilarTimu().Show();
        }

        private void button3_Click(object sender, EventArgs e)
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
