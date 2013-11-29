namespace da1
{
    partial class LineInfo
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
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.textBoxStart = new System.Windows.Forms.TextBox();
            this.textBoxEnd = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonSc = new System.Windows.Forms.Button();
            this.radioButtonRun = new System.Windows.Forms.RadioButton();
            this.radioButtonRunNot = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxMinute = new System.Windows.Forms.TextBox();
            this.textBoxHour = new System.Windows.Forms.TextBox();
            this.radioButtonTimeAfter = new System.Windows.Forms.RadioButton();
            this.radioButtonTimeBefore = new System.Windows.Forms.RadioButton();
            this.buttonSa = new System.Windows.Forms.Button();
            this.buttonConfirm = new System.Windows.Forms.Button();
            this.buttonReject = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(-2, 166);
            this.dataGridView.MultiSelect = false;
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowTemplate.Height = 23;
            this.dataGridView.Size = new System.Drawing.Size(693, 239);
            this.dataGridView.TabIndex = 0;
            this.dataGridView.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dataGridView_UserAddedRow);
            this.dataGridView.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dataGridView_UserDeletingRow);
            this.dataGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellEndEdit);
            this.dataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridView_DataError);
            // 
            // textBoxStart
            // 
            this.textBoxStart.Location = new System.Drawing.Point(56, 12);
            this.textBoxStart.Name = "textBoxStart";
            this.textBoxStart.Size = new System.Drawing.Size(128, 21);
            this.textBoxStart.TabIndex = 0;
            // 
            // textBoxEnd
            // 
            this.textBoxEnd.Location = new System.Drawing.Point(271, 12);
            this.textBoxEnd.Name = "textBoxEnd";
            this.textBoxEnd.Size = new System.Drawing.Size(146, 21);
            this.textBoxEnd.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 100;
            this.label1.Text = "起点：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(224, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 100;
            this.label2.Text = "终点：";
            // 
            // buttonSc
            // 
            this.buttonSc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSc.Location = new System.Drawing.Point(517, 31);
            this.buttonSc.Name = "buttonSc";
            this.buttonSc.Size = new System.Drawing.Size(120, 50);
            this.buttonSc.TabIndex = 8;
            this.buttonSc.Text = "按条件查找";
            this.buttonSc.UseVisualStyleBackColor = true;
            this.buttonSc.Click += new System.EventHandler(this.buttonSc_Click);
            // 
            // radioButtonRun
            // 
            this.radioButtonRun.AutoSize = true;
            this.radioButtonRun.Location = new System.Drawing.Point(33, 20);
            this.radioButtonRun.Name = "radioButtonRun";
            this.radioButtonRun.Size = new System.Drawing.Size(71, 16);
            this.radioButtonRun.TabIndex = 2;
            this.radioButtonRun.TabStop = true;
            this.radioButtonRun.Text = "正在运行";
            this.radioButtonRun.UseVisualStyleBackColor = true;
            // 
            // radioButtonRunNot
            // 
            this.radioButtonRunNot.AutoSize = true;
            this.radioButtonRunNot.Location = new System.Drawing.Point(33, 64);
            this.radioButtonRunNot.Name = "radioButtonRunNot";
            this.radioButtonRunNot.Size = new System.Drawing.Size(71, 16);
            this.radioButtonRunNot.TabIndex = 3;
            this.radioButtonRunNot.TabStop = true;
            this.radioButtonRunNot.Text = "不在运行";
            this.radioButtonRunNot.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonRun);
            this.groupBox1.Controls.Add(this.radioButtonRunNot);
            this.groupBox1.Location = new System.Drawing.Point(12, 45);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 100);
            this.groupBox1.TabIndex = 100;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "选择是否运行";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.textBoxMinute);
            this.groupBox2.Controls.Add(this.textBoxHour);
            this.groupBox2.Controls.Add(this.radioButtonTimeAfter);
            this.groupBox2.Controls.Add(this.radioButtonTimeBefore);
            this.groupBox2.Location = new System.Drawing.Point(252, 45);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 100);
            this.groupBox2.TabIndex = 100;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "选择线路时间";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(87, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 200;
            this.label3.Text = "：";
            // 
            // textBoxMinute
            // 
            this.textBoxMinute.Location = new System.Drawing.Point(110, 59);
            this.textBoxMinute.MaxLength = 5;
            this.textBoxMinute.Name = "textBoxMinute";
            this.textBoxMinute.Size = new System.Drawing.Size(37, 21);
            this.textBoxMinute.TabIndex = 7;
            this.textBoxMinute.Text = "59";
            // 
            // textBoxHour
            // 
            this.textBoxHour.Location = new System.Drawing.Point(44, 59);
            this.textBoxHour.MaxLength = 5;
            this.textBoxHour.Name = "textBoxHour";
            this.textBoxHour.Size = new System.Drawing.Size(37, 21);
            this.textBoxHour.TabIndex = 6;
            this.textBoxHour.Text = "23";
            // 
            // radioButtonTimeAfter
            // 
            this.radioButtonTimeAfter.AutoSize = true;
            this.radioButtonTimeAfter.Location = new System.Drawing.Point(110, 20);
            this.radioButtonTimeAfter.Name = "radioButtonTimeAfter";
            this.radioButtonTimeAfter.Size = new System.Drawing.Size(83, 16);
            this.radioButtonTimeAfter.TabIndex = 5;
            this.radioButtonTimeAfter.TabStop = true;
            this.radioButtonTimeAfter.Text = "在此时间后";
            this.radioButtonTimeAfter.UseVisualStyleBackColor = true;
            // 
            // radioButtonTimeBefore
            // 
            this.radioButtonTimeBefore.AutoSize = true;
            this.radioButtonTimeBefore.Location = new System.Drawing.Point(9, 20);
            this.radioButtonTimeBefore.Name = "radioButtonTimeBefore";
            this.radioButtonTimeBefore.Size = new System.Drawing.Size(95, 16);
            this.radioButtonTimeBefore.TabIndex = 4;
            this.radioButtonTimeBefore.TabStop = true;
            this.radioButtonTimeBefore.Text = "在此时间之前";
            this.radioButtonTimeBefore.UseVisualStyleBackColor = true;
            // 
            // buttonSa
            // 
            this.buttonSa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSa.Location = new System.Drawing.Point(517, 115);
            this.buttonSa.Name = "buttonSa";
            this.buttonSa.Size = new System.Drawing.Size(120, 30);
            this.buttonSa.TabIndex = 9;
            this.buttonSa.Text = "显示全部线路";
            this.buttonSa.UseVisualStyleBackColor = true;
            this.buttonSa.Click += new System.EventHandler(this.buttonSa_Click);
            // 
            // buttonConfirm
            // 
            this.buttonConfirm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonConfirm.Location = new System.Drawing.Point(100, 424);
            this.buttonConfirm.Name = "buttonConfirm";
            this.buttonConfirm.Size = new System.Drawing.Size(100, 25);
            this.buttonConfirm.TabIndex = 10;
            this.buttonConfirm.Text = "确定更改";
            this.buttonConfirm.UseVisualStyleBackColor = true;
            this.buttonConfirm.Click += new System.EventHandler(this.buttonConfirm_Click);
            // 
            // buttonReject
            // 
            this.buttonReject.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonReject.Location = new System.Drawing.Point(296, 424);
            this.buttonReject.Name = "buttonReject";
            this.buttonReject.Size = new System.Drawing.Size(100, 25);
            this.buttonReject.TabIndex = 11;
            this.buttonReject.Text = "取消更改";
            this.buttonReject.UseVisualStyleBackColor = true;
            this.buttonReject.Click += new System.EventHandler(this.buttonReject_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonClose.Location = new System.Drawing.Point(490, 424);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(100, 25);
            this.buttonClose.TabIndex = 12;
            this.buttonClose.Text = "关闭";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // LineInfo
            // 
            this.AcceptButton = this.buttonSc;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 468);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonReject);
            this.Controls.Add(this.buttonConfirm);
            this.Controls.Add(this.buttonSa);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonSc);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxEnd);
            this.Controls.Add(this.textBoxStart);
            this.Controls.Add(this.dataGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "LineInfo";
            this.Text = "LineInfo";
            this.Load += new System.EventHandler(this.LineInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.TextBox textBoxStart;
        private System.Windows.Forms.TextBox textBoxEnd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonSc;
        protected System.Windows.Forms.RadioButton radioButtonRun;
        protected System.Windows.Forms.RadioButton radioButtonRunNot;
        protected System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioButtonTimeAfter;
        private System.Windows.Forms.RadioButton radioButtonTimeBefore;
        private System.Windows.Forms.TextBox textBoxMinute;
        private System.Windows.Forms.TextBox textBoxHour;
        protected System.Windows.Forms.Button buttonConfirm;
        protected System.Windows.Forms.Button buttonReject;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonClose;
        protected System.Windows.Forms.Button buttonSa;
    }
}