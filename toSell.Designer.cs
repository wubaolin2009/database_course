namespace da1
{
    partial class toSell
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(toSell));
            this.buttonSell = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.labelLinNum = new System.Windows.Forms.Label();
            this.labelStart = new System.Windows.Forms.Label();
            this.labelEnd = new System.Windows.Forms.Label();
            this.labelDate = new System.Windows.Forms.Label();
            this.labelcount = new System.Windows.Forms.Label();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.labelMoney = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonSell
            // 
            this.buttonSell.Location = new System.Drawing.Point(291, 314);
            this.buttonSell.Name = "buttonSell";
            this.buttonSell.Size = new System.Drawing.Size(100, 40);
            this.buttonSell.TabIndex = 0;
            this.buttonSell.Text = "售票\r\n";
            this.buttonSell.UseVisualStyleBackColor = true;
            this.buttonSell.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.MediumSlateBlue;
            this.label1.Location = new System.Drawing.Point(9, 377);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 16);
            this.label1.TabIndex = 2;
            this.label1.Tag = "9999";
            this.label1.Text = "剩余的座位数：";
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(291, 377);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(100, 40);
            this.buttonClose.TabIndex = 1;
            this.buttonClose.Text = "关闭 ";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.button2_Click);
            // 
            // labelLinNum
            // 
            this.labelLinNum.AutoSize = true;
            this.labelLinNum.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelLinNum.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.labelLinNum.Location = new System.Drawing.Point(3, 4);
            this.labelLinNum.Name = "labelLinNum";
            this.labelLinNum.Size = new System.Drawing.Size(62, 16);
            this.labelLinNum.TabIndex = 4;
            this.labelLinNum.Text = "label2";
            this.labelLinNum.Click += new System.EventHandler(this.labelLinNum_Click);
            // 
            // labelStart
            // 
            this.labelStart.AutoSize = true;
            this.labelStart.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelStart.ForeColor = System.Drawing.Color.DodgerBlue;
            this.labelStart.Location = new System.Drawing.Point(3, 2);
            this.labelStart.Name = "labelStart";
            this.labelStart.Size = new System.Drawing.Size(62, 16);
            this.labelStart.TabIndex = 5;
            this.labelStart.Text = "label2";
            this.labelStart.Click += new System.EventHandler(this.labelStart_Click);
            // 
            // labelEnd
            // 
            this.labelEnd.AutoSize = true;
            this.labelEnd.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelEnd.ForeColor = System.Drawing.Color.RoyalBlue;
            this.labelEnd.Location = new System.Drawing.Point(5, 2);
            this.labelEnd.Name = "labelEnd";
            this.labelEnd.Size = new System.Drawing.Size(62, 16);
            this.labelEnd.TabIndex = 5;
            this.labelEnd.Tag = "9999";
            this.labelEnd.Text = "label2";
            // 
            // labelDate
            // 
            this.labelDate.AutoSize = true;
            this.labelDate.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelDate.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.labelDate.Location = new System.Drawing.Point(5, 4);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(62, 16);
            this.labelDate.TabIndex = 6;
            this.labelDate.Tag = "9999";
            this.labelDate.Text = "label2";
            // 
            // labelcount
            // 
            this.labelcount.AutoSize = true;
            this.labelcount.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelcount.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.labelcount.Location = new System.Drawing.Point(120, 377);
            this.labelcount.Name = "labelcount";
            this.labelcount.Size = new System.Drawing.Size(62, 16);
            this.labelcount.TabIndex = 7;
            this.labelcount.Tag = "9999";
            this.labelcount.Text = "label2";
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(1, 121);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(253, 244);
            this.checkedListBox1.TabIndex = 100;
            this.checkedListBox1.Tag = "9999";
            // 
            // labelMoney
            // 
            this.labelMoney.AutoSize = true;
            this.labelMoney.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelMoney.ForeColor = System.Drawing.Color.MediumTurquoise;
            this.labelMoney.Location = new System.Drawing.Point(37, 411);
            this.labelMoney.Name = "labelMoney";
            this.labelMoney.Size = new System.Drawing.Size(62, 16);
            this.labelMoney.TabIndex = 9;
            this.labelMoney.Tag = "9999";
            this.labelMoney.Text = "label2";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(287, 121);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(104, 150);
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel3);
            this.groupBox1.Controls.Add(this.panel4);
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(6, 14);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(395, 98);
            this.groupBox1.TabIndex = 101;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "当前车票信息";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel3.Controls.Add(this.labelEnd);
            this.panel3.Location = new System.Drawing.Point(247, 56);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(138, 22);
            this.panel3.TabIndex = 102;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel4.Controls.Add(this.labelStart);
            this.panel4.Location = new System.Drawing.Point(61, 56);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(138, 22);
            this.panel4.TabIndex = 9;
            this.panel4.Tag = "9999";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel2.Controls.Add(this.labelDate);
            this.panel2.Location = new System.Drawing.Point(247, 20);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(138, 22);
            this.panel2.TabIndex = 8;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.Controls.Add(this.labelLinNum);
            this.panel1.Location = new System.Drawing.Point(61, 20);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(138, 22);
            this.panel1.TabIndex = 7;
            this.panel1.Tag = "9999";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 3;
            this.label5.Text = "出发站";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(205, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "终点站";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(212, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "日期";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "线路编号";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // toSell
            // 
            this.AcceptButton = this.buttonSell;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(413, 458);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.labelMoney);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.labelcount);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonSell);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "toSell";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "toSell";
            this.Load += new System.EventHandler(this.toSell_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonSell;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonClose;
        internal System.Windows.Forms.CheckedListBox checkedListBox1;
        internal System.Windows.Forms.Label labelLinNum;
        internal System.Windows.Forms.Label labelStart;
        internal System.Windows.Forms.Label labelEnd;
        internal System.Windows.Forms.Label labelDate;
        internal System.Windows.Forms.Label labelcount;
        internal System.Windows.Forms.Label labelMoney;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel2;
    }
}