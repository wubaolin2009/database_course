namespace da1
{
    partial class RegisterUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegisterUser));
            this.radioButtonMainTain = new System.Windows.Forms.RadioButton();
            this.radioButtonConductor = new System.Windows.Forms.RadioButton();
            this.radioButtonGuest = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxUserName = new System.Windows.Forms.TextBox();
            this.textBoxPwd1 = new System.Windows.Forms.TextBox();
            this.textBoxPwd2 = new System.Windows.Forms.TextBox();
            this.textBoxAge = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxPhone = new System.Windows.Forms.TextBox();
            this.buttonYes = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.labelIsRegisted = new System.Windows.Forms.Label();
            this.labelPwd = new System.Windows.Forms.Label();
            this.labelAge = new System.Windows.Forms.Label();
            this.labelPhone = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // radioButtonMainTain
            // 
            this.radioButtonMainTain.AutoSize = true;
            this.radioButtonMainTain.Location = new System.Drawing.Point(29, 44);
            this.radioButtonMainTain.Name = "radioButtonMainTain";
            this.radioButtonMainTain.Size = new System.Drawing.Size(71, 16);
            this.radioButtonMainTain.TabIndex = 100;
            this.radioButtonMainTain.Text = "MainTain";
            this.radioButtonMainTain.UseVisualStyleBackColor = true;
            // 
            // radioButtonConductor
            // 
            this.radioButtonConductor.AutoSize = true;
            this.radioButtonConductor.Location = new System.Drawing.Point(29, 77);
            this.radioButtonConductor.Name = "radioButtonConductor";
            this.radioButtonConductor.Size = new System.Drawing.Size(71, 16);
            this.radioButtonConductor.TabIndex = 100;
            this.radioButtonConductor.Text = "Condutor";
            this.radioButtonConductor.UseVisualStyleBackColor = true;
            // 
            // radioButtonGuest
            // 
            this.radioButtonGuest.AutoSize = true;
            this.radioButtonGuest.Location = new System.Drawing.Point(29, 109);
            this.radioButtonGuest.Name = "radioButtonGuest";
            this.radioButtonGuest.Size = new System.Drawing.Size(53, 16);
            this.radioButtonGuest.TabIndex = 8;
            this.radioButtonGuest.Text = "Guest";
            this.radioButtonGuest.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonGuest);
            this.groupBox1.Controls.Add(this.radioButtonConductor);
            this.groupBox1.Controls.Add(this.radioButtonMainTain);
            this.groupBox1.Location = new System.Drawing.Point(376, 218);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(141, 148);
            this.groupBox1.TabIndex = 100;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "用户权限";
            // 
            // textBoxUserName
            // 
            this.textBoxUserName.Location = new System.Drawing.Point(132, 24);
            this.textBoxUserName.Name = "textBoxUserName";
            this.textBoxUserName.Size = new System.Drawing.Size(150, 21);
            this.textBoxUserName.TabIndex = 0;
            this.textBoxUserName.Leave += new System.EventHandler(this.textBoxUserName_Leave);
            // 
            // textBoxPwd1
            // 
            this.textBoxPwd1.Location = new System.Drawing.Point(132, 87);
            this.textBoxPwd1.Name = "textBoxPwd1";
            this.textBoxPwd1.PasswordChar = '*';
            this.textBoxPwd1.Size = new System.Drawing.Size(150, 21);
            this.textBoxPwd1.TabIndex = 1;
            this.textBoxPwd1.Leave += new System.EventHandler(this.textBoxPwd1_Leave);
            // 
            // textBoxPwd2
            // 
            this.textBoxPwd2.Location = new System.Drawing.Point(132, 150);
            this.textBoxPwd2.Name = "textBoxPwd2";
            this.textBoxPwd2.PasswordChar = '*';
            this.textBoxPwd2.Size = new System.Drawing.Size(150, 21);
            this.textBoxPwd2.TabIndex = 2;
            this.textBoxPwd2.Leave += new System.EventHandler(this.textBoxPwd2_Leave);
            // 
            // textBoxAge
            // 
            this.textBoxAge.Location = new System.Drawing.Point(132, 276);
            this.textBoxAge.MaxLength = 2;
            this.textBoxAge.Name = "textBoxAge";
            this.textBoxAge.Size = new System.Drawing.Size(150, 21);
            this.textBoxAge.TabIndex = 4;
            this.textBoxAge.Leave += new System.EventHandler(this.textBoxAge_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(68, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "用户名：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(68, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 100;
            this.label2.Text = "密　码：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(56, 153);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 100;
            this.label3.Text = "确认密码：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(68, 279);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 100;
            this.label4.Text = "年　龄：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(56, 342);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 100;
            this.label5.Text = "手机号码：";
            // 
            // textBoxPhone
            // 
            this.textBoxPhone.ForeColor = System.Drawing.SystemColors.WindowText;
            this.textBoxPhone.Location = new System.Drawing.Point(132, 339);
            this.textBoxPhone.MaxLength = 12;
            this.textBoxPhone.Name = "textBoxPhone";
            this.textBoxPhone.Size = new System.Drawing.Size(150, 21);
            this.textBoxPhone.TabIndex = 5;
            this.textBoxPhone.Leave += new System.EventHandler(this.textBoxPhone_Leave);
            // 
            // buttonYes
            // 
            this.buttonYes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonYes.Location = new System.Drawing.Point(130, 422);
            this.buttonYes.Name = "buttonYes";
            this.buttonYes.Size = new System.Drawing.Size(100, 25);
            this.buttonYes.TabIndex = 6;
            this.buttonYes.Text = "确　定";
            this.buttonYes.UseVisualStyleBackColor = true;
            this.buttonYes.Click += new System.EventHandler(this.buttonYes_Click);
            // 
            // button2
            // 
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.Location = new System.Drawing.Point(346, 422);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 25);
            this.button2.TabIndex = 7;
            this.button2.Text = "取　消";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(132, 213);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(150, 21);
            this.textBoxName.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(56, 216);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 100;
            this.label6.Text = "真实姓名：";
            // 
            // labelIsRegisted
            // 
            this.labelIsRegisted.AutoSize = true;
            this.labelIsRegisted.Font = new System.Drawing.Font("楷体_GB2312", 10.5F, System.Drawing.FontStyle.Bold);
            this.labelIsRegisted.ForeColor = System.Drawing.Color.LightCoral;
            this.labelIsRegisted.Location = new System.Drawing.Point(67, 60);
            this.labelIsRegisted.Name = "labelIsRegisted";
            this.labelIsRegisted.Size = new System.Drawing.Size(0, 14);
            this.labelIsRegisted.TabIndex = 6;
            this.labelIsRegisted.Tag = "9999";
            // 
            // labelPwd
            // 
            this.labelPwd.AutoSize = true;
            this.labelPwd.Font = new System.Drawing.Font("楷体_GB2312", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelPwd.ForeColor = System.Drawing.Color.LightCoral;
            this.labelPwd.Location = new System.Drawing.Point(67, 119);
            this.labelPwd.Name = "labelPwd";
            this.labelPwd.Size = new System.Drawing.Size(0, 14);
            this.labelPwd.TabIndex = 6;
            this.labelPwd.Tag = "9999";
            // 
            // labelAge
            // 
            this.labelAge.AutoSize = true;
            this.labelAge.Font = new System.Drawing.Font("楷体_GB2312", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelAge.ForeColor = System.Drawing.Color.LightCoral;
            this.labelAge.Location = new System.Drawing.Point(67, 307);
            this.labelAge.Name = "labelAge";
            this.labelAge.Size = new System.Drawing.Size(0, 14);
            this.labelAge.TabIndex = 7;
            this.labelAge.Tag = "9999";
            // 
            // labelPhone
            // 
            this.labelPhone.AutoSize = true;
            this.labelPhone.Font = new System.Drawing.Font("楷体_GB2312", 10.5F, System.Drawing.FontStyle.Bold);
            this.labelPhone.ForeColor = System.Drawing.Color.LightCoral;
            this.labelPhone.Location = new System.Drawing.Point(67, 371);
            this.labelPhone.Name = "labelPhone";
            this.labelPhone.Size = new System.Drawing.Size(0, 14);
            this.labelPhone.TabIndex = 7;
            this.labelPhone.Tag = "9999";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Enabled = false;
            this.pictureBox1.Location = new System.Drawing.Point(361, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(167, 179);
            this.pictureBox1.TabIndex = 101;
            this.pictureBox1.TabStop = false;
            // 
            // RegisterUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(575, 483);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.labelPhone);
            this.Controls.Add(this.labelAge);
            this.Controls.Add(this.labelPwd);
            this.Controls.Add(this.labelIsRegisted);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.buttonYes);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxPhone);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.textBoxAge);
            this.Controls.Add(this.textBoxPwd2);
            this.Controls.Add(this.textBoxPwd1);
            this.Controls.Add(this.textBoxUserName);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "RegisterUser";
            this.Text = "RegisterUser";
            this.Load += new System.EventHandler(this.RegisterUser_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radioButtonMainTain;
        private System.Windows.Forms.RadioButton radioButtonConductor;
        private System.Windows.Forms.RadioButton radioButtonGuest;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxUserName;
        private System.Windows.Forms.TextBox textBoxPwd1;
        private System.Windows.Forms.TextBox textBoxPwd2;
        private System.Windows.Forms.TextBox textBoxAge;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxPhone;
        private System.Windows.Forms.Button buttonYes;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labelIsRegisted;
        private System.Windows.Forms.Label labelPwd;
        private System.Windows.Forms.Label labelAge;
        private System.Windows.Forms.Label labelPhone;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}