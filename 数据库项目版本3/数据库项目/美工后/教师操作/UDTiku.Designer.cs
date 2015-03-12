namespace Test
{
    partial class UDTiku
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UDTiku));
            this.button4 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label16 = new System.Windows.Forms.Label();
            this.queryDegree = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.queryMethod = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.queryPoint = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.queryChapter = new System.Windows.Forms.ComboBox();
            this.button6 = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.topic = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.degree = new System.Windows.Forms.TextBox();
            this.point = new System.Windows.Forms.TextBox();
            this.method = new System.Windows.Forms.TextBox();
            this.chapter = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.D = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.C = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.B = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.A = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.answer = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.number = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("苏新诗古印宋简", 15.75F, System.Drawing.FontStyle.Bold);
            this.button4.Location = new System.Drawing.Point(1133, 664);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(103, 54);
            this.button4.TabIndex = 1;
            this.button4.Text = "返回";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.White;
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.queryDegree);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this.queryMethod);
            this.groupBox3.Controls.Add(this.label18);
            this.groupBox3.Controls.Add(this.queryPoint);
            this.groupBox3.Controls.Add(this.label19);
            this.groupBox3.Controls.Add(this.queryChapter);
            this.groupBox3.Controls.Add(this.button6);
            this.groupBox3.Font = new System.Drawing.Font("苏新诗古印宋简", 15.75F, System.Drawing.FontStyle.Bold);
            this.groupBox3.Location = new System.Drawing.Point(833, 47);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(481, 312);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "查询";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(19, 214);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(102, 21);
            this.label16.TabIndex = 13;
            this.label16.Text = "难易程度";
            // 
            // queryDegree
            // 
            this.queryDegree.FormattingEnabled = true;
            this.queryDegree.Items.AddRange(new object[] {
            "",
            "简单",
            "中等",
            "偏难"});
            this.queryDegree.Location = new System.Drawing.Point(151, 206);
            this.queryDegree.Name = "queryDegree";
            this.queryDegree.Size = new System.Drawing.Size(186, 29);
            this.queryDegree.TabIndex = 12;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(19, 155);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(102, 21);
            this.label17.TabIndex = 11;
            this.label17.Text = "思想方法";
            // 
            // queryMethod
            // 
            this.queryMethod.FormattingEnabled = true;
            this.queryMethod.Items.AddRange(new object[] {
            "",
            "代数证明",
            "变量分离",
            "函数与方程",
            "定义公式",
            "计算器辅助",
            "分类讨论",
            "构造法",
            "换元法",
            "几何证明",
            "极端性",
            "最值问题",
            "归纳与类比",
            "枚举法",
            "逆向思维",
            "开放性问题",
            "整体与配对",
            "补集的思想",
            "比较差商法",
            "数形结合",
            "特殊化",
            "联立方程",
            "待定系数",
            "学习能力",
            "应用题",
            "等价转化",
            "没啥思想"});
            this.queryMethod.Location = new System.Drawing.Point(151, 147);
            this.queryMethod.Name = "queryMethod";
            this.queryMethod.Size = new System.Drawing.Size(186, 29);
            this.queryMethod.TabIndex = 10;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(19, 99);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(79, 21);
            this.label18.TabIndex = 9;
            this.label18.Text = "知识点";
            // 
            // queryPoint
            // 
            this.queryPoint.FormattingEnabled = true;
            this.queryPoint.Location = new System.Drawing.Point(151, 91);
            this.queryPoint.Name = "queryPoint";
            this.queryPoint.Size = new System.Drawing.Size(186, 29);
            this.queryPoint.TabIndex = 8;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(19, 43);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(56, 21);
            this.label19.TabIndex = 7;
            this.label19.Text = "章节";
            // 
            // queryChapter
            // 
            this.queryChapter.FormattingEnabled = true;
            this.queryChapter.Items.AddRange(new object[] {
            "",
            "集合命题",
            "不等式章",
            "函数基本性质",
            "幂指对函数",
            "三角比章",
            "数列与数学归纳法",
            "排列组合与二项式定理",
            "概率初步",
            "数理统计等",
            "复数初步",
            "向量初步",
            "坐标平面上的直线",
            "圆锥曲线",
            "空间图形"});
            this.queryChapter.Location = new System.Drawing.Point(151, 35);
            this.queryChapter.Name = "queryChapter";
            this.queryChapter.Size = new System.Drawing.Size(186, 29);
            this.queryChapter.TabIndex = 6;
            this.queryChapter.SelectedIndexChanged += new System.EventHandler(this.queryChapter_SelectedIndexChanged);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(279, 246);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(172, 52);
            this.button6.TabIndex = 5;
            this.button6.Text = "开始查询";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click_1);
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.White;
            this.groupBox4.Controls.Add(this.topic);
            this.groupBox4.Controls.Add(this.label20);
            this.groupBox4.Controls.Add(this.button7);
            this.groupBox4.Controls.Add(this.button8);
            this.groupBox4.Controls.Add(this.degree);
            this.groupBox4.Controls.Add(this.point);
            this.groupBox4.Controls.Add(this.method);
            this.groupBox4.Controls.Add(this.chapter);
            this.groupBox4.Controls.Add(this.label21);
            this.groupBox4.Controls.Add(this.label22);
            this.groupBox4.Controls.Add(this.label23);
            this.groupBox4.Controls.Add(this.label24);
            this.groupBox4.Controls.Add(this.D);
            this.groupBox4.Controls.Add(this.label25);
            this.groupBox4.Controls.Add(this.C);
            this.groupBox4.Controls.Add(this.label26);
            this.groupBox4.Controls.Add(this.B);
            this.groupBox4.Controls.Add(this.label27);
            this.groupBox4.Controls.Add(this.A);
            this.groupBox4.Controls.Add(this.label28);
            this.groupBox4.Controls.Add(this.answer);
            this.groupBox4.Controls.Add(this.label29);
            this.groupBox4.Controls.Add(this.number);
            this.groupBox4.Controls.Add(this.label30);
            this.groupBox4.Font = new System.Drawing.Font("苏新诗古印宋简", 15.75F, System.Drawing.FontStyle.Bold);
            this.groupBox4.Location = new System.Drawing.Point(12, 382);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1224, 278);
            this.groupBox4.TabIndex = 37;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "修改题目";
            // 
            // topic
            // 
            this.topic.Location = new System.Drawing.Point(131, 103);
            this.topic.Name = "topic";
            this.topic.Size = new System.Drawing.Size(307, 28);
            this.topic.TabIndex = 36;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(28, 106);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(56, 21);
            this.label20.TabIndex = 35;
            this.label20.Text = "题目";
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(918, 182);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(110, 57);
            this.button7.TabIndex = 34;
            this.button7.Text = "删除";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(725, 182);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(110, 57);
            this.button8.TabIndex = 33;
            this.button8.Text = "更新";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // degree
            // 
            this.degree.Location = new System.Drawing.Point(1021, 97);
            this.degree.Name = "degree";
            this.degree.Size = new System.Drawing.Size(91, 28);
            this.degree.TabIndex = 32;
            // 
            // point
            // 
            this.point.Location = new System.Drawing.Point(765, 99);
            this.point.Name = "point";
            this.point.Size = new System.Drawing.Size(91, 28);
            this.point.TabIndex = 31;
            // 
            // method
            // 
            this.method.Location = new System.Drawing.Point(1021, 55);
            this.method.Name = "method";
            this.method.Size = new System.Drawing.Size(91, 28);
            this.method.TabIndex = 30;
            // 
            // chapter
            // 
            this.chapter.Location = new System.Drawing.Point(765, 55);
            this.chapter.Name = "chapter";
            this.chapter.Size = new System.Drawing.Size(91, 28);
            this.chapter.TabIndex = 29;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(887, 100);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(102, 21);
            this.label21.TabIndex = 28;
            this.label21.Text = "难易程度";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(887, 59);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(102, 21);
            this.label22.TabIndex = 27;
            this.label22.Text = "思想方法";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(674, 103);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(79, 21);
            this.label23.TabIndex = 26;
            this.label23.Text = "知识点";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(674, 62);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(56, 21);
            this.label24.TabIndex = 25;
            this.label24.Text = "章节";
            // 
            // D
            // 
            this.D.Location = new System.Drawing.Point(459, 206);
            this.D.Name = "D";
            this.D.Size = new System.Drawing.Size(91, 28);
            this.D.TabIndex = 24;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(333, 213);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(72, 21);
            this.label25.TabIndex = 23;
            this.label25.Text = "答案D";
            // 
            // C
            // 
            this.C.Location = new System.Drawing.Point(131, 206);
            this.C.Name = "C";
            this.C.Size = new System.Drawing.Size(91, 28);
            this.C.TabIndex = 22;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(28, 209);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(70, 21);
            this.label26.TabIndex = 21;
            this.label26.Text = "答案C";
            // 
            // B
            // 
            this.B.Location = new System.Drawing.Point(459, 158);
            this.B.Name = "B";
            this.B.Size = new System.Drawing.Size(91, 28);
            this.B.TabIndex = 20;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(334, 165);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(71, 21);
            this.label27.TabIndex = 19;
            this.label27.Text = "答案B";
            // 
            // A
            // 
            this.A.Location = new System.Drawing.Point(131, 158);
            this.A.Name = "A";
            this.A.Size = new System.Drawing.Size(91, 28);
            this.A.TabIndex = 18;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(28, 161);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(73, 21);
            this.label28.TabIndex = 17;
            this.label28.Text = "答案A";
            // 
            // answer
            // 
            this.answer.Location = new System.Drawing.Point(347, 55);
            this.answer.Name = "answer";
            this.answer.Size = new System.Drawing.Size(91, 28);
            this.answer.TabIndex = 16;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(265, 62);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(56, 21);
            this.label29.TabIndex = 15;
            this.label29.Text = "答案";
            // 
            // number
            // 
            this.number.Location = new System.Drawing.Point(131, 59);
            this.number.Name = "number";
            this.number.ReadOnly = true;
            this.number.Size = new System.Drawing.Size(91, 28);
            this.number.TabIndex = 10;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(28, 59);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(56, 21);
            this.label30.TabIndex = 9;
            this.label30.Text = "题号";
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 82);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(774, 277);
            this.dataGridView1.TabIndex = 38;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.BackColor = System.Drawing.Color.Transparent;
            this.radioButton1.Checked = true;
            this.radioButton1.Font = new System.Drawing.Font("苏新诗古印宋简", 15.75F, System.Drawing.FontStyle.Bold);
            this.radioButton1.Location = new System.Drawing.Point(38, 38);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(97, 25);
            this.radioButton1.TabIndex = 39;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "选择题";
            this.radioButton1.UseVisualStyleBackColor = false;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.BackColor = System.Drawing.Color.Transparent;
            this.radioButton2.Font = new System.Drawing.Font("苏新诗古印宋简", 15.75F, System.Drawing.FontStyle.Bold);
            this.radioButton2.Location = new System.Drawing.Point(217, 38);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(97, 25);
            this.radioButton2.TabIndex = 40;
            this.radioButton2.Text = "填空题";
            this.radioButton2.UseVisualStyleBackColor = false;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.BackColor = System.Drawing.Color.Transparent;
            this.radioButton3.Font = new System.Drawing.Font("苏新诗古印宋简", 15.75F, System.Drawing.FontStyle.Bold);
            this.radioButton3.Location = new System.Drawing.Point(414, 38);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(97, 25);
            this.radioButton3.TabIndex = 41;
            this.radioButton3.Text = "简答题";
            this.radioButton3.UseVisualStyleBackColor = false;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // UDTiku
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1350, 730);
            this.Controls.Add(this.radioButton3);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.button4);
            this.Name = "UDTiku";
            this.Text = "题库管理";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.UDTiku_FormClosed);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox queryDegree;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox queryMethod;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox queryPoint;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ComboBox queryChapter;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox topic;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.TextBox degree;
        private System.Windows.Forms.TextBox point;
        private System.Windows.Forms.TextBox method;
        private System.Windows.Forms.TextBox chapter;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox D;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox C;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox B;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TextBox A;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.TextBox answer;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.TextBox number;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
    }
}