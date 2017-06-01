namespace QLSVLog
{
    partial class EmployeesList
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.employeesView = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.add = new System.Windows.Forms.Button();
            this.delete = new System.Windows.Forms.Button();
            this.update = new System.Windows.Forms.Button();
            this.save = new System.Windows.Forms.Button();
            this.none = new System.Windows.Forms.Button();
            this.exit = new System.Windows.Forms.Button();
            this.employeeIDBox = new System.Windows.Forms.TextBox();
            this.emailBox = new System.Windows.Forms.TextBox();
            this.usernameBox = new System.Windows.Forms.TextBox();
            this.fullnameBox = new System.Windows.Forms.TextBox();
            this.salaryBox = new System.Windows.Forms.TextBox();
            this.passwordBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.employeesView)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.passwordBox);
            this.groupBox1.Controls.Add(this.salaryBox);
            this.groupBox1.Controls.Add(this.fullnameBox);
            this.groupBox1.Controls.Add(this.usernameBox);
            this.groupBox1.Controls.Add(this.emailBox);
            this.groupBox1.Controls.Add(this.employeeIDBox);
            this.groupBox1.Location = new System.Drawing.Point(25, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(544, 114);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin nhân viên";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.employeesView);
            this.groupBox2.Location = new System.Drawing.Point(25, 132);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(544, 246);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // employeesView
            // 
            this.employeesView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.employeesView.Location = new System.Drawing.Point(6, 19);
            this.employeesView.Name = "employeesView";
            this.employeesView.Size = new System.Drawing.Size(532, 157);
            this.employeesView.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.exit);
            this.groupBox3.Controls.Add(this.none);
            this.groupBox3.Controls.Add(this.save);
            this.groupBox3.Controls.Add(this.update);
            this.groupBox3.Controls.Add(this.delete);
            this.groupBox3.Controls.Add(this.add);
            this.groupBox3.Location = new System.Drawing.Point(6, 182);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(532, 58);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            // 
            // add
            // 
            this.add.Location = new System.Drawing.Point(6, 24);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(75, 23);
            this.add.TabIndex = 0;
            this.add.Text = "Thêm";
            this.add.UseVisualStyleBackColor = true;
            this.add.Click += new System.EventHandler(this.add_Click);
            // 
            // delete
            // 
            this.delete.Location = new System.Drawing.Point(87, 24);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(75, 23);
            this.delete.TabIndex = 1;
            this.delete.Text = "Xóa";
            this.delete.UseVisualStyleBackColor = true;
            this.delete.Click += new System.EventHandler(this.delete_Click);
            // 
            // update
            // 
            this.update.Location = new System.Drawing.Point(168, 24);
            this.update.Name = "update";
            this.update.Size = new System.Drawing.Size(75, 23);
            this.update.TabIndex = 2;
            this.update.Text = "Sửa";
            this.update.UseVisualStyleBackColor = true;
            this.update.Click += new System.EventHandler(this.update_Click);
            // 
            // save
            // 
            this.save.Location = new System.Drawing.Point(289, 24);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(75, 23);
            this.save.TabIndex = 3;
            this.save.Text = "Ghi/Lưu";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // none
            // 
            this.none.Location = new System.Drawing.Point(370, 24);
            this.none.Name = "none";
            this.none.Size = new System.Drawing.Size(75, 23);
            this.none.TabIndex = 4;
            this.none.Text = "Không";
            this.none.UseVisualStyleBackColor = true;
            this.none.Click += new System.EventHandler(this.none_Click);
            // 
            // exit
            // 
            this.exit.Location = new System.Drawing.Point(451, 24);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(75, 23);
            this.exit.TabIndex = 5;
            this.exit.Text = "Thoát";
            this.exit.UseVisualStyleBackColor = true;
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // employeeIDBox
            // 
            this.employeeIDBox.Location = new System.Drawing.Point(91, 19);
            this.employeeIDBox.Name = "employeeIDBox";
            this.employeeIDBox.Size = new System.Drawing.Size(100, 20);
            this.employeeIDBox.TabIndex = 0;
            // 
            // emailBox
            // 
            this.emailBox.Location = new System.Drawing.Point(91, 55);
            this.emailBox.Name = "emailBox";
            this.emailBox.Size = new System.Drawing.Size(100, 20);
            this.emailBox.TabIndex = 1;
            // 
            // usernameBox
            // 
            this.usernameBox.Location = new System.Drawing.Point(91, 88);
            this.usernameBox.Name = "usernameBox";
            this.usernameBox.Size = new System.Drawing.Size(100, 20);
            this.usernameBox.TabIndex = 2;
            // 
            // fullnameBox
            // 
            this.fullnameBox.Location = new System.Drawing.Point(295, 17);
            this.fullnameBox.Name = "fullnameBox";
            this.fullnameBox.Size = new System.Drawing.Size(243, 20);
            this.fullnameBox.TabIndex = 3;
            // 
            // salaryBox
            // 
            this.salaryBox.Location = new System.Drawing.Point(295, 52);
            this.salaryBox.Name = "salaryBox";
            this.salaryBox.Size = new System.Drawing.Size(243, 20);
            this.salaryBox.TabIndex = 4;
            // 
            // passwordBox
            // 
            this.passwordBox.Location = new System.Drawing.Point(295, 88);
            this.passwordBox.Name = "passwordBox";
            this.passwordBox.PasswordChar = '*';
            this.passwordBox.Size = new System.Drawing.Size(243, 20);
            this.passwordBox.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 14);
            this.label1.TabIndex = 6;
            this.label1.Text = "Mã NV";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 14);
            this.label2.TabIndex = 7;
            this.label2.Text = "Email";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 14);
            this.label3.TabIndex = 8;
            this.label3.Text = "Tên đăng nhập";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(199, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 14);
            this.label4.TabIndex = 9;
            this.label4.Text = "Họ tên";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(199, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 14);
            this.label5.TabIndex = 10;
            this.label5.Text = "Lương";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(199, 94);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 14);
            this.label6.TabIndex = 11;
            this.label6.Text = "Mật khẩu";
            // 
            // EmployeesList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 390);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "EmployeesList";
            this.Text = "Danh sách nhân viên";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.employeesView)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView employeesView;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button exit;
        private System.Windows.Forms.Button none;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.Button update;
        private System.Windows.Forms.Button delete;
        private System.Windows.Forms.Button add;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox passwordBox;
        private System.Windows.Forms.TextBox salaryBox;
        private System.Windows.Forms.TextBox fullnameBox;
        private System.Windows.Forms.TextBox usernameBox;
        private System.Windows.Forms.TextBox emailBox;
        private System.Windows.Forms.TextBox employeeIDBox;
    }
}