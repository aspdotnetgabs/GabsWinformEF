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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.labelAvailableSeat1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMovieSeat1 = new System.Windows.Forms.TextBox();
            this.btnMovie1 = new System.Windows.Forms.Button();
            this.btnMovie2 = new System.Windows.Forms.Button();
            this.txtMovieSeat2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.labelAvailableSeat2 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(64, 102);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(126, 156);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(236, 102);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(126, 156);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Location = new System.Drawing.Point(407, 102);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(126, 156);
            this.pictureBox3.TabIndex = 2;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Location = new System.Drawing.Point(570, 102);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(126, 156);
            this.pictureBox4.TabIndex = 3;
            this.pictureBox4.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(233, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Screening Date:";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(323, 60);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 6;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // labelAvailableSeat1
            // 
            this.labelAvailableSeat1.AutoSize = true;
            this.labelAvailableSeat1.Location = new System.Drawing.Point(75, 261);
            this.labelAvailableSeat1.Name = "labelAvailableSeat1";
            this.labelAvailableSeat1.Size = new System.Drawing.Size(90, 13);
            this.labelAvailableSeat1.TabIndex = 7;
            this.labelAvailableSeat1.Text = "Available seats: 5";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(88, 283);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "No of seats:";
            // 
            // txtMovieSeat1
            // 
            this.txtMovieSeat1.Location = new System.Drawing.Point(78, 299);
            this.txtMovieSeat1.Name = "txtMovieSeat1";
            this.txtMovieSeat1.Size = new System.Drawing.Size(100, 20);
            this.txtMovieSeat1.TabIndex = 9;
            // 
            // btnMovie1
            // 
            this.btnMovie1.Location = new System.Drawing.Point(91, 326);
            this.btnMovie1.Name = "btnMovie1";
            this.btnMovie1.Size = new System.Drawing.Size(75, 23);
            this.btnMovie1.TabIndex = 10;
            this.btnMovie1.Text = "Reserve";
            this.btnMovie1.UseVisualStyleBackColor = true;
            this.btnMovie1.Click += new System.EventHandler(this.btnMovie1_Click);
            // 
            // btnMovie2
            // 
            this.btnMovie2.Location = new System.Drawing.Point(264, 326);
            this.btnMovie2.Name = "btnMovie2";
            this.btnMovie2.Size = new System.Drawing.Size(75, 23);
            this.btnMovie2.TabIndex = 14;
            this.btnMovie2.Text = "Reserve";
            this.btnMovie2.UseVisualStyleBackColor = true;
            this.btnMovie2.Click += new System.EventHandler(this.btnMovie2_Click);
            // 
            // txtMovieSeat2
            // 
            this.txtMovieSeat2.Location = new System.Drawing.Point(251, 299);
            this.txtMovieSeat2.Name = "txtMovieSeat2";
            this.txtMovieSeat2.Size = new System.Drawing.Size(100, 20);
            this.txtMovieSeat2.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(261, 283);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "No of seats:";
            // 
            // labelAvailableSeat2
            // 
            this.labelAvailableSeat2.AutoSize = true;
            this.labelAvailableSeat2.Location = new System.Drawing.Point(248, 261);
            this.labelAvailableSeat2.Name = "labelAvailableSeat2";
            this.labelAvailableSeat2.Size = new System.Drawing.Size(96, 13);
            this.labelAvailableSeat2.TabIndex = 11;
            this.labelAvailableSeat2.Text = "Available seats: 30";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(429, 326);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 18;
            this.button3.Text = "Reserve";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(416, 299);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 20);
            this.textBox3.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(426, 283);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "No of seats:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(413, 261);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Available seats: 28";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(603, 326);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 22;
            this.button4.Text = "Reserve";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(590, 299);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 20);
            this.textBox4.TabIndex = 21;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(600, 283);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "No of seats:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(587, 261);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(96, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "Available seats: 43";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnMovie2);
            this.Controls.Add(this.txtMovieSeat2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.labelAvailableSeat2);
            this.Controls.Add(this.btnMovie1);
            this.Controls.Add(this.txtMovieSeat1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelAvailableSeat1);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label labelAvailableSeat1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMovieSeat1;
        private System.Windows.Forms.Button btnMovie1;
        private System.Windows.Forms.Button btnMovie2;
        private System.Windows.Forms.TextBox txtMovieSeat2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelAvailableSeat2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
    }
}