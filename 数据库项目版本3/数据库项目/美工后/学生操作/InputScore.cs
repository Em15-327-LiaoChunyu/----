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
    public partial class InputScore : Form
    {
        private Paper paper;

        public InputScore()
        {
            InitializeComponent();
            paper = new Paper();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool isInputAllScores()
        {
            if (tScore1.Text != "" && tScore2.Text != "" && tScore3.Text != "" && tScore4.Text != "" && tScore5.Text != "" && tScore6.Text != "" && tScore7.Text != "" && tScore8.Text != "" &&
                tScore9.Text != "" && tScore10.Text != "" && tScore11.Text != "" && tScore12.Text != "" && tScore13.Text != "" && tScore14.Text != ""
                && xScore1.Text != "" && xScore2.Text != "" && xScore3.Text != "" && xScore4.Text != ""
                && jScore1.Text != "" && jScore2.Text != "" && jScore3.Text != "" && jScore4.Text != "" && jScore5.Text != "")
                return true;
            else
                return false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //先保存分数到Paper类中
            //必须全部选择了分数
            bool flag = isInputAllScores();
            if (flag)
            {
                int[] tiankongScores = new int[14];
                tiankongScores[0] = Convert.ToInt32(tScore1.Text);
                tiankongScores[1] = Convert.ToInt32(tScore2.Text);
                tiankongScores[2] = Convert.ToInt32(tScore3.Text);
                tiankongScores[3] = Convert.ToInt32(tScore4.Text);
                tiankongScores[4] = Convert.ToInt32(tScore5.Text);
                tiankongScores[5] = Convert.ToInt32(tScore6.Text);
                tiankongScores[6] = Convert.ToInt32(tScore7.Text);
                tiankongScores[7] = Convert.ToInt32(tScore8.Text);
                tiankongScores[8] = Convert.ToInt32(tScore9.Text);
                tiankongScores[9] = Convert.ToInt32(tScore10.Text);
                tiankongScores[10] = Convert.ToInt32(tScore11.Text);
                tiankongScores[11] = Convert.ToInt32(tScore12.Text);
                tiankongScores[12] = Convert.ToInt32(tScore13.Text);
                tiankongScores[13] = Convert.ToInt32(tScore14.Text);
                paper.setTiankongScores(tiankongScores);

                int[] xuanzeScores = new int[4];
                xuanzeScores[0] = Convert.ToInt32(xScore1.Text);
                xuanzeScores[1] = Convert.ToInt32(xScore2.Text);
                xuanzeScores[2] = Convert.ToInt32(xScore3.Text);
                xuanzeScores[3] = Convert.ToInt32(xScore4.Text);
                paper.setXuanzeScores(xuanzeScores);
                
                int[] jiandaScores = new int[5];
                jiandaScores[0] = Convert.ToInt32(jScore1.Text);
                jiandaScores[1] = Convert.ToInt32(jScore2.Text);
                jiandaScores[2] = Convert.ToInt32(jScore3.Text);
                jiandaScores[3] = Convert.ToInt32(jScore4.Text);
                jiandaScores[4] = Convert.ToInt32(jScore5.Text);
                paper.setJiandaScores(jiandaScores);
                //再打开GetSimilarTimu类
                this.Close();
                new Test.学生操作.GetSimilarTimu().Show();
            }
            else
                MessageBox.Show("请将分数输入完整");
        }

      

    }
}
