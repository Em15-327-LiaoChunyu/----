namespace Test.学生操作
{
    partial class GetSimilarTimu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GetSimilarTimu));
            this.selectGroup = new System.Windows.Forms.GroupBox();
            this.inputScore = new System.Windows.Forms.TextBox();
            this.inputAllScore = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tishi = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.jtihao = new System.Windows.Forms.ComboBox();
            this.xtihao = new System.Windows.Forms.ComboBox();
            this.ttihao = new System.Windows.Forms.ComboBox();
            this.similarGroup = new System.Windows.Forms.GroupBox();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.selectGroup.SuspendLayout();
            this.similarGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // selectGroup
            // 
            this.selectGroup.BackColor = System.Drawing.Color.White;
            this.selectGroup.Controls.Add(this.inputScore);
            this.selectGroup.Controls.Add(this.inputAllScore);
            this.selectGroup.Controls.Add(this.label5);
            this.selectGroup.Controls.Add(this.label4);
            this.selectGroup.Controls.Add(this.tishi);
            this.selectGroup.Controls.Add(this.button1);
            this.selectGroup.Controls.Add(this.radioButton3);
            this.selectGroup.Controls.Add(this.radioButton2);
            this.selectGroup.Controls.Add(this.radioButton1);
            this.selectGroup.Controls.Add(this.jtihao);
            this.selectGroup.Controls.Add(this.xtihao);
            this.selectGroup.Controls.Add(this.ttihao);
            this.selectGroup.Font = new System.Drawing.Font("苏新诗古印宋简", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.selectGroup.Location = new System.Drawing.Point(12, 12);
            this.selectGroup.Name = "selectGroup";
            this.selectGroup.Size = new System.Drawing.Size(335, 620);
            this.selectGroup.TabIndex = 0;
            this.selectGroup.TabStop = false;
            this.selectGroup.Text = "选择需要反馈的题目";
            // 
            // inputScore
            // 
            this.inputScore.Location = new System.Drawing.Point(146, 437);
            this.inputScore.Name = "inputScore";
            this.inputScore.Size = new System.Drawing.Size(60, 27);
            this.inputScore.TabIndex = 15;
            // 
            // inputAllScore
            // 
            this.inputAllScore.Location = new System.Drawing.Point(147, 350);
            this.inputAllScore.Name = "inputAllScore";
            this.inputAllScore.Size = new System.Drawing.Size(60, 27);
            this.inputAllScore.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 444);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(129, 20);
            this.label5.TabIndex = 13;
            this.label5.Text = "输入该题得分";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 353);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(129, 20);
            this.label4.TabIndex = 12;
            this.label4.Text = "输入该题总分";
            // 
            // tishi
            // 
            this.tishi.AutoSize = true;
            this.tishi.Location = new System.Drawing.Point(12, 282);
            this.tishi.Name = "tishi";
            this.tishi.Size = new System.Drawing.Size(49, 20);
            this.tishi.TabIndex = 11;
            this.tishi.Text = "提示";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(101, 525);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(106, 55);
            this.button1.TabIndex = 10;
            this.button1.Text = "确定";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(15, 220);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(87, 24);
            this.radioButton3.TabIndex = 9;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "简答题";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(15, 147);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(87, 24);
            this.radioButton2.TabIndex = 8;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "选择题";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(15, 67);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(87, 24);
            this.radioButton1.TabIndex = 7;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "填空题";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // jtihao
            // 
            this.jtihao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.jtihao.FormattingEnabled = true;
            this.jtihao.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.jtihao.Location = new System.Drawing.Point(125, 216);
            this.jtihao.Name = "jtihao";
            this.jtihao.Size = new System.Drawing.Size(64, 28);
            this.jtihao.TabIndex = 6;
            this.jtihao.Visible = false;
            this.jtihao.SelectedIndexChanged += new System.EventHandler(this.jtihao_SelectedIndexChanged);
            // 
            // xtihao
            // 
            this.xtihao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.xtihao.FormattingEnabled = true;
            this.xtihao.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.xtihao.Location = new System.Drawing.Point(125, 143);
            this.xtihao.Name = "xtihao";
            this.xtihao.Size = new System.Drawing.Size(64, 28);
            this.xtihao.TabIndex = 5;
            this.xtihao.Visible = false;
            this.xtihao.SelectedIndexChanged += new System.EventHandler(this.xtihao_SelectedIndexChanged);
            // 
            // ttihao
            // 
            this.ttihao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ttihao.FormattingEnabled = true;
            this.ttihao.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14"});
            this.ttihao.Location = new System.Drawing.Point(125, 63);
            this.ttihao.Name = "ttihao";
            this.ttihao.Size = new System.Drawing.Size(64, 28);
            this.ttihao.TabIndex = 4;
            this.ttihao.Visible = false;
            this.ttihao.SelectedIndexChanged += new System.EventHandler(this.ttihao_SelectedIndexChanged);
            // 
            // similarGroup
            // 
            this.similarGroup.BackColor = System.Drawing.Color.White;
            this.similarGroup.Controls.Add(this.checkedListBox1);
            this.similarGroup.Font = new System.Drawing.Font("苏新诗古印宋简", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.similarGroup.Location = new System.Drawing.Point(386, 171);
            this.similarGroup.Name = "similarGroup";
            this.similarGroup.Size = new System.Drawing.Size(916, 461);
            this.similarGroup.TabIndex = 1;
            this.similarGroup.TabStop = false;
            this.similarGroup.Text = "相似题目";
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(46, 49);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(583, 290);
            this.checkedListBox1.TabIndex = 2;
            this.checkedListBox1.SelectedIndexChanged += new System.EventHandler(this.checkedListBox1_SelectedIndexChanged);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("苏新诗古印宋简", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button3.Location = new System.Drawing.Point(1136, 632);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(121, 65);
            this.button3.TabIndex = 2;
            this.button3.Text = "返回";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("苏新诗古印宋简", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button4.Location = new System.Drawing.Point(386, 12);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(184, 58);
            this.button4.TabIndex = 3;
            this.button4.Text = "查看相似题目";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // GetSimilarTimu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1350, 730);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.similarGroup);
            this.Controls.Add(this.selectGroup);
            this.Name = "GetSimilarTimu";
            this.Text = "反馈题目";
            this.selectGroup.ResumeLayout(false);
            this.selectGroup.PerformLayout();
            this.similarGroup.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox selectGroup;
        private System.Windows.Forms.ComboBox xtihao;
        private System.Windows.Forms.ComboBox ttihao;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox similarGroup;
        private System.Windows.Forms.ComboBox jtihao;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label tishi;
        private System.Windows.Forms.TextBox inputScore;
        private System.Windows.Forms.TextBox inputAllScore;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
    }
}