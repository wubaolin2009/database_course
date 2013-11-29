namespace da1
{
    partial class SetupLine
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetupLine));
            this.comboBoxLine = new System.Windows.Forms.ComboBox();
            this.comboBoxBus = new System.Windows.Forms.ComboBox();
            this.comboBoxDriver = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonAddLine = new System.Windows.Forms.Button();
            this.buttonAddBus = new System.Windows.Forms.Button();
            this.buttonAddDriver = new System.Windows.Forms.Button();
            this.labelBus = new System.Windows.Forms.Label();
            this.labelDriver = new System.Windows.Forms.Label();
            this.textBoxPrice = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.labelLine = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBoxLine
            // 
            this.comboBoxLine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLine.FormattingEnabled = true;
            this.comboBoxLine.Location = new System.Drawing.Point(6, 43);
            this.comboBoxLine.Name = "comboBoxLine";
            this.comboBoxLine.Size = new System.Drawing.Size(155, 20);
            this.comboBoxLine.TabIndex = 0;
            this.comboBoxLine.TabStop = false;
            this.comboBoxLine.SelectedIndexChanged += new System.EventHandler(this.comboBoxLine_SelectedIndexChanged);
            // 
            // comboBoxBus
            // 
            this.comboBoxBus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxBus.FormattingEnabled = true;
            this.comboBoxBus.Location = new System.Drawing.Point(6, 44);
            this.comboBoxBus.Name = "comboBoxBus";
            this.comboBoxBus.Size = new System.Drawing.Size(155, 20);
            this.comboBoxBus.TabIndex = 2;
            this.comboBoxBus.TabStop = false;
            this.comboBoxBus.SelectedIndexChanged += new System.EventHandler(this.comboBoxBus_SelectedIndexChanged);
            // 
            // comboBoxDriver
            // 
            this.comboBoxDriver.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDriver.FormattingEnabled = true;
            this.comboBoxDriver.Location = new System.Drawing.Point(7, 43);
            this.comboBoxDriver.Name = "comboBoxDriver";
            this.comboBoxDriver.Size = new System.Drawing.Size(155, 20);
            this.comboBoxDriver.TabIndex = 4;
            this.comboBoxDriver.TabStop = false;
            this.comboBoxDriver.SelectedIndexChanged += new System.EventHandler(this.comboBoxDriver_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 12);
            this.label1.TabIndex = 100;
            this.label1.Text = "选择一条未运行的线路：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 12);
            this.label2.TabIndex = 100;
            this.label2.Text = "选择一条未运行的汽车：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(161, 12);
            this.label3.TabIndex = 100;
            this.label3.Text = "选择一位未分配任务的司机：";
            // 
            // buttonAdd
            // 
            this.buttonAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonAdd.Location = new System.Drawing.Point(183, 372);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(100, 25);
            this.buttonAdd.TabIndex = 4;
            this.buttonAdd.Text = "运行";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonClose.Location = new System.Drawing.Point(474, 372);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(100, 25);
            this.buttonClose.TabIndex = 5;
            this.buttonClose.Text = "关闭";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // buttonAddLine
            // 
            this.buttonAddLine.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonAddLine.Location = new System.Drawing.Point(87, 81);
            this.buttonAddLine.Name = "buttonAddLine";
            this.buttonAddLine.Size = new System.Drawing.Size(74, 25);
            this.buttonAddLine.TabIndex = 0;
            this.buttonAddLine.Text = "增加线路";
            this.buttonAddLine.UseVisualStyleBackColor = true;
            this.buttonAddLine.Click += new System.EventHandler(this.buttonAddLine_Click);
            // 
            // buttonAddBus
            // 
            this.buttonAddBus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonAddBus.Location = new System.Drawing.Point(87, 82);
            this.buttonAddBus.Name = "buttonAddBus";
            this.buttonAddBus.Size = new System.Drawing.Size(74, 25);
            this.buttonAddBus.TabIndex = 1;
            this.buttonAddBus.Text = "增加汽车";
            this.buttonAddBus.UseVisualStyleBackColor = true;
            this.buttonAddBus.Click += new System.EventHandler(this.buttonAddBus_Click);
            // 
            // buttonAddDriver
            // 
            this.buttonAddDriver.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonAddDriver.Location = new System.Drawing.Point(88, 81);
            this.buttonAddDriver.Name = "buttonAddDriver";
            this.buttonAddDriver.Size = new System.Drawing.Size(74, 25);
            this.buttonAddDriver.TabIndex = 2;
            this.buttonAddDriver.Text = "增加司机";
            this.buttonAddDriver.UseVisualStyleBackColor = true;
            this.buttonAddDriver.Click += new System.EventHandler(this.buttonAddDriver_Click);
            // 
            // labelBus
            // 
            this.labelBus.AutoSize = true;
            this.labelBus.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelBus.ForeColor = System.Drawing.Color.YellowGreen;
            this.labelBus.Location = new System.Drawing.Point(249, 18);
            this.labelBus.Name = "labelBus";
            this.labelBus.Size = new System.Drawing.Size(0, 16);
            this.labelBus.TabIndex = 7;
            this.labelBus.Tag = "9999";
            // 
            // labelDriver
            // 
            this.labelDriver.AutoSize = true;
            this.labelDriver.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelDriver.ForeColor = System.Drawing.Color.LightBlue;
            this.labelDriver.Location = new System.Drawing.Point(459, 18);
            this.labelDriver.Name = "labelDriver";
            this.labelDriver.Size = new System.Drawing.Size(0, 16);
            this.labelDriver.TabIndex = 7;
            this.labelDriver.Tag = "9999";
            // 
            // textBoxPrice
            // 
            this.textBoxPrice.Location = new System.Drawing.Point(9, 330);
            this.textBoxPrice.MaxLength = 4;
            this.textBoxPrice.Name = "textBoxPrice";
            this.textBoxPrice.Size = new System.Drawing.Size(198, 21);
            this.textBoxPrice.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 315);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 100;
            this.label7.Text = "车票价格：";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonAddLine);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.comboBoxLine);
            this.groupBox1.Location = new System.Drawing.Point(25, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(182, 118);
            this.groupBox1.TabIndex = 100;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "安排线路";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonAddBus);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.comboBoxBus);
            this.groupBox2.Location = new System.Drawing.Point(245, 7);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(182, 118);
            this.groupBox2.TabIndex = 100;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "安排汽车";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.buttonAddDriver);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.comboBoxDriver);
            this.groupBox3.Location = new System.Drawing.Point(463, 7);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(186, 118);
            this.groupBox3.TabIndex = 100;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "安排司机";
            // 
            // labelLine
            // 
            this.labelLine.AutoSize = true;
            this.labelLine.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelLine.ForeColor = System.Drawing.Color.Gold;
            this.labelLine.Location = new System.Drawing.Point(20, 18);
            this.labelLine.Name = "labelLine";
            this.labelLine.Size = new System.Drawing.Size(0, 16);
            this.labelLine.TabIndex = 7;
            this.labelLine.Tag = "9999";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.Controls.Add(this.labelLine);
            this.panel1.Controls.Add(this.labelDriver);
            this.panel1.Controls.Add(this.labelBus);
            this.panel1.Location = new System.Drawing.Point(8, 161);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(756, 145);
            this.panel1.TabIndex = 100;
            this.panel1.Tag = "9999";
            // 
            // SetupLine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(760, 422);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBoxPrice);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonAdd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "SetupLine";
            this.Text = "线路安装";
            this.Load += new System.EventHandler(this.AddTicket_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonAddLine;
        private System.Windows.Forms.Button buttonAddBus;
        private System.Windows.Forms.Button buttonAddDriver;
        private System.Windows.Forms.Label labelBus;
        private System.Windows.Forms.Label labelDriver;
        private System.Windows.Forms.Label label7;
        internal System.Windows.Forms.ComboBox comboBoxLine;
        internal System.Windows.Forms.ComboBox comboBoxBus;
        internal System.Windows.Forms.ComboBox comboBoxDriver;
        internal System.Windows.Forms.TextBox textBoxPrice;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label labelLine;
        private System.Windows.Forms.Panel panel1;
    }
}