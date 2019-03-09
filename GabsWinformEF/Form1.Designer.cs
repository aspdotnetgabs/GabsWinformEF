namespace GabsWinformEF
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chkChessy = new System.Windows.Forms.CheckBox();
            this.chkMeaty = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.txtChessy = new System.Windows.Forms.TextBox();
            this.txtMeaty = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Customer Name";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(114, 35);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 1;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(114, 78);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 3;
            this.textBox2.Text = "Address";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Address";
            // 
            // chkChessy
            // 
            this.chkChessy.AutoSize = true;
            this.chkChessy.Location = new System.Drawing.Point(296, 42);
            this.chkChessy.Name = "chkChessy";
            this.chkChessy.Size = new System.Drawing.Size(88, 17);
            this.chkChessy.TabIndex = 4;
            this.chkChessy.Text = "Chessy Pizza";
            this.chkChessy.UseVisualStyleBackColor = true;
            // 
            // chkMeaty
            // 
            this.chkMeaty.AutoSize = true;
            this.chkMeaty.Location = new System.Drawing.Point(296, 94);
            this.chkMeaty.Name = "chkMeaty";
            this.chkMeaty.Size = new System.Drawing.Size(83, 17);
            this.chkMeaty.TabIndex = 5;
            this.chkMeaty.Text = "Meaty Pizza";
            this.chkMeaty.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(296, 144);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(79, 17);
            this.checkBox3.TabIndex = 6;
            this.checkBox3.Text = "Vege Pizza";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // txtChessy
            // 
            this.txtChessy.Location = new System.Drawing.Point(391, 42);
            this.txtChessy.Name = "txtChessy";
            this.txtChessy.Size = new System.Drawing.Size(42, 20);
            this.txtChessy.TabIndex = 7;
            this.txtChessy.Text = "1";
            // 
            // txtMeaty
            // 
            this.txtMeaty.Location = new System.Drawing.Point(391, 85);
            this.txtMeaty.Name = "txtMeaty";
            this.txtMeaty.Size = new System.Drawing.Size(42, 20);
            this.txtMeaty.TabIndex = 8;
            this.txtMeaty.Text = "1";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(391, 141);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(42, 20);
            this.textBox5.TabIndex = 9;
            this.textBox5.Text = "1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(340, 210);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Check out";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(114, 118);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 11;
            this.button2.Text = "Create Order";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.txtMeaty);
            this.Controls.Add(this.txtChessy);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.chkMeaty);
            this.Controls.Add(this.chkChessy);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkChessy;
        private System.Windows.Forms.CheckBox chkMeaty;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.TextBox txtChessy;
        private System.Windows.Forms.TextBox txtMeaty;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}