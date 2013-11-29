namespace da1
{
    partial class ChangeLineRun
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.buttonSetup1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button7 = new System.Windows.Forms.Button();
            this.buttonUnset1 = new System.Windows.Forms.Button();
            this.textBoxBus = new System.Windows.Forms.TextBox();
            this.textBoxLine1 = new System.Windows.Forms.TextBox();
            this.buttonSearchBus = new System.Windows.Forms.Button();
            this.ButtonSearchLine = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.buttonSetup2 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button8 = new System.Windows.Forms.Button();
            this.buttonUnSet2 = new System.Windows.Forms.Button();
            this.textBoxDriver = new System.Windows.Forms.TextBox();
            this.textBoxLine2 = new System.Windows.Forms.TextBox();
            this.buttonSearchDriver = new System.Windows.Forms.Button();
            this.buttonSearchLine2 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(659, 277);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.buttonSetup1);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.button7);
            this.tabPage1.Controls.Add(this.buttonUnset1);
            this.tabPage1.Controls.Add(this.textBoxBus);
            this.tabPage1.Controls.Add(this.textBoxLine1);
            this.tabPage1.Controls.Add(this.buttonSearchBus);
            this.tabPage1.Controls.Add(this.ButtonSearchLine);
            this.tabPage1.Location = new System.Drawing.Point(4, 21);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(651, 252);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // buttonSetup1
            // 
            this.buttonSetup1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSetup1.Location = new System.Drawing.Point(90, 178);
            this.buttonSetup1.Name = "buttonSetup1";
            this.buttonSetup1.Size = new System.Drawing.Size(100, 25);
            this.buttonSetup1.TabIndex = 8;
            this.buttonSetup1.Text = "安装";
            this.buttonSetup1.UseVisualStyleBackColor = true;
            this.buttonSetup1.Click += new System.EventHandler(this.buttonSetup1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.label2.Location = new System.Drawing.Point(357, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 14);
            this.label2.TabIndex = 7;
            this.label2.Tag = "9999";
            this.label2.Text = "汽车:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.label1.Location = new System.Drawing.Point(25, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 14);
            this.label1.TabIndex = 6;
            this.label1.Tag = "9999";
            this.label1.Text = "线路：";
            // 
            // button7
            // 
            this.button7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button7.Location = new System.Drawing.Point(461, 178);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(100, 25);
            this.button7.TabIndex = 5;
            this.button7.Text = "关闭";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // buttonUnset1
            // 
            this.buttonUnset1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonUnset1.Location = new System.Drawing.Point(280, 178);
            this.buttonUnset1.Name = "buttonUnset1";
            this.buttonUnset1.Size = new System.Drawing.Size(100, 25);
            this.buttonUnset1.TabIndex = 4;
            this.buttonUnset1.Text = "卸载";
            this.buttonUnset1.UseVisualStyleBackColor = true;
            this.buttonUnset1.Click += new System.EventHandler(this.buttonUnset1_Click);
            // 
            // textBoxBus
            // 
            this.textBoxBus.Enabled = false;
            this.textBoxBus.Font = new System.Drawing.Font("黑体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxBus.ForeColor = System.Drawing.Color.DarkSeaGreen;
            this.textBoxBus.Location = new System.Drawing.Point(416, 68);
            this.textBoxBus.Name = "textBoxBus";
            this.textBoxBus.Size = new System.Drawing.Size(100, 23);
            this.textBoxBus.TabIndex = 3;
            this.textBoxBus.Tag = "9999";
            // 
            // textBoxLine1
            // 
            this.textBoxLine1.Enabled = false;
            this.textBoxLine1.Font = new System.Drawing.Font("黑体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxLine1.ForeColor = System.Drawing.Color.DarkSeaGreen;
            this.textBoxLine1.Location = new System.Drawing.Point(83, 68);
            this.textBoxLine1.Name = "textBoxLine1";
            this.textBoxLine1.Size = new System.Drawing.Size(100, 23);
            this.textBoxLine1.TabIndex = 2;
            this.textBoxLine1.Tag = "9999";
            // 
            // buttonSearchBus
            // 
            this.buttonSearchBus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSearchBus.Location = new System.Drawing.Point(538, 66);
            this.buttonSearchBus.Name = "buttonSearchBus";
            this.buttonSearchBus.Size = new System.Drawing.Size(75, 23);
            this.buttonSearchBus.TabIndex = 1;
            this.buttonSearchBus.Text = "查找汽车";
            this.buttonSearchBus.UseVisualStyleBackColor = true;
            this.buttonSearchBus.Click += new System.EventHandler(this.buttonSearchBus_Click);
            // 
            // ButtonSearchLine
            // 
            this.ButtonSearchLine.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonSearchLine.Location = new System.Drawing.Point(230, 66);
            this.ButtonSearchLine.Name = "ButtonSearchLine";
            this.ButtonSearchLine.Size = new System.Drawing.Size(75, 23);
            this.ButtonSearchLine.TabIndex = 0;
            this.ButtonSearchLine.Text = "查找线路";
            this.ButtonSearchLine.UseVisualStyleBackColor = true;
            this.ButtonSearchLine.Click += new System.EventHandler(this.ButtonSearchLine_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.buttonSetup2);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.button8);
            this.tabPage2.Controls.Add(this.buttonUnSet2);
            this.tabPage2.Controls.Add(this.textBoxDriver);
            this.tabPage2.Controls.Add(this.textBoxLine2);
            this.tabPage2.Controls.Add(this.buttonSearchDriver);
            this.tabPage2.Controls.Add(this.buttonSearchLine2);
            this.tabPage2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabPage2.Location = new System.Drawing.Point(4, 21);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(651, 252);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // buttonSetup2
            // 
            this.buttonSetup2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSetup2.Location = new System.Drawing.Point(90, 178);
            this.buttonSetup2.Name = "buttonSetup2";
            this.buttonSetup2.Size = new System.Drawing.Size(100, 25);
            this.buttonSetup2.TabIndex = 8;
            this.buttonSetup2.Text = "安装";
            this.buttonSetup2.UseVisualStyleBackColor = true;
            this.buttonSetup2.Click += new System.EventHandler(this.buttonSetup2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.label4.Location = new System.Drawing.Point(357, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 14);
            this.label4.TabIndex = 7;
            this.label4.Tag = "9999";
            this.label4.Text = "司机：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.label3.Location = new System.Drawing.Point(25, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 14);
            this.label3.TabIndex = 6;
            this.label3.Tag = "9999";
            this.label3.Text = "线路：";
            // 
            // button8
            // 
            this.button8.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button8.Location = new System.Drawing.Point(461, 178);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(100, 25);
            this.button8.TabIndex = 5;
            this.button8.Text = "关闭";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // buttonUnSet2
            // 
            this.buttonUnSet2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonUnSet2.Location = new System.Drawing.Point(280, 178);
            this.buttonUnSet2.Name = "buttonUnSet2";
            this.buttonUnSet2.Size = new System.Drawing.Size(100, 25);
            this.buttonUnSet2.TabIndex = 4;
            this.buttonUnSet2.Text = "卸载";
            this.buttonUnSet2.UseVisualStyleBackColor = true;
            this.buttonUnSet2.Click += new System.EventHandler(this.buttonUnSet2_Click);
            // 
            // textBoxDriver
            // 
            this.textBoxDriver.Enabled = false;
            this.textBoxDriver.Font = new System.Drawing.Font("黑体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxDriver.ForeColor = System.Drawing.Color.DarkSeaGreen;
            this.textBoxDriver.Location = new System.Drawing.Point(416, 68);
            this.textBoxDriver.Name = "textBoxDriver";
            this.textBoxDriver.Size = new System.Drawing.Size(100, 23);
            this.textBoxDriver.TabIndex = 3;
            this.textBoxDriver.Tag = "9999";
            // 
            // textBoxLine2
            // 
            this.textBoxLine2.Enabled = false;
            this.textBoxLine2.Font = new System.Drawing.Font("黑体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxLine2.ForeColor = System.Drawing.Color.DarkSeaGreen;
            this.textBoxLine2.Location = new System.Drawing.Point(83, 68);
            this.textBoxLine2.Name = "textBoxLine2";
            this.textBoxLine2.Size = new System.Drawing.Size(100, 23);
            this.textBoxLine2.TabIndex = 2;
            this.textBoxLine2.Tag = "9999";
            // 
            // buttonSearchDriver
            // 
            this.buttonSearchDriver.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSearchDriver.Location = new System.Drawing.Point(538, 66);
            this.buttonSearchDriver.Name = "buttonSearchDriver";
            this.buttonSearchDriver.Size = new System.Drawing.Size(75, 23);
            this.buttonSearchDriver.TabIndex = 1;
            this.buttonSearchDriver.Text = "查找司机";
            this.buttonSearchDriver.UseVisualStyleBackColor = true;
            this.buttonSearchDriver.Click += new System.EventHandler(this.button5_Click);
            // 
            // buttonSearchLine2
            // 
            this.buttonSearchLine2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSearchLine2.Location = new System.Drawing.Point(230, 66);
            this.buttonSearchLine2.Name = "buttonSearchLine2";
            this.buttonSearchLine2.Size = new System.Drawing.Size(75, 23);
            this.buttonSearchLine2.TabIndex = 0;
            this.buttonSearchLine2.Text = "查找线路";
            this.buttonSearchLine2.UseVisualStyleBackColor = true;
            this.buttonSearchLine2.Click += new System.EventHandler(this.buttonSearchLine2_Click);
            // 
            // ChangeLineRun
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 280);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "ChangeLineRun";
            this.Text = "ChangeBusDriver";
            this.Load += new System.EventHandler(this.ChangeLineRun_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button buttonUnset1;
        private System.Windows.Forms.TextBox textBoxBus;
        private System.Windows.Forms.TextBox textBoxLine1;
        private System.Windows.Forms.Button buttonSearchBus;
        private System.Windows.Forms.Button ButtonSearchLine;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button buttonUnSet2;
        private System.Windows.Forms.TextBox textBoxDriver;
        private System.Windows.Forms.TextBox textBoxLine2;
        private System.Windows.Forms.Button buttonSearchDriver;
        private System.Windows.Forms.Button buttonSearchLine2;
        private System.Windows.Forms.Button buttonSetup1;
        private System.Windows.Forms.Button buttonSetup2;
    }
}