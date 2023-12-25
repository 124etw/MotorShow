namespace motorshow2
{
    partial class AdminMaincs
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
            pictureBox1 = new PictureBox();
            dateTimePicker1 = new DateTimePicker();
            textBox1 = new TextBox();
            textBox3 = new TextBox();
            progressBar1 = new ProgressBar();
            tabPage1 = new TabPage();
            button2 = new Button();
            button3 = new Button();
            tabControl1 = new TabControl();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            tabPage1.SuspendLayout();
            tabControl1.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.ErrorImage = Properties.Resources._2023_12_03_23_34_15;
            pictureBox1.InitialImage = null;
            pictureBox1.Location = new Point(0, 1);
            pictureBox1.Margin = new Padding(3, 2, 3, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(145, 162);
            pictureBox1.TabIndex = 14;
            pictureBox1.TabStop = false;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(151, 1);
            dateTimePicker1.Margin = new Padding(3, 2, 3, 2);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(176, 23);
            dateTimePicker1.TabIndex = 11;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(151, 29);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(176, 107);
            textBox1.TabIndex = 15;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(-14, 393);
            textBox3.Multiline = true;
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(341, 38);
            textBox3.TabIndex = 17;
            textBox3.TextChanged += textBox3_TextChanged;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(0, 158);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(327, 10);
            progressBar1.TabIndex = 18;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(button2);
            tabPage1.Controls.Add(button3);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(319, 191);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Основные инструменты";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(-4, 0);
            button2.Margin = new Padding(3, 2, 3, 2);
            button2.Name = "button2";
            button2.Size = new Size(133, 55);
            button2.TabIndex = 10;
            button2.Text = "Измение базы данных авто";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(180, 0);
            button3.Margin = new Padding(3, 2, 3, 2);
            button3.Name = "button3";
            button3.Size = new Size(133, 50);
            button3.TabIndex = 12;
            button3.Text = "Редактировние рабочего персонала";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Location = new Point(0, 168);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(327, 219);
            tabControl1.TabIndex = 19;
            // 
            // AdminMaincs
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(322, 412);
            Controls.Add(tabControl1);
            Controls.Add(progressBar1);
            Controls.Add(textBox3);
            Controls.Add(textBox1);
            Controls.Add(pictureBox1);
            Controls.Add(dateTimePicker1);
            Name = "AdminMaincs";
            Text = "Главное меню";
            Load += AdminMaincs_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            tabPage1.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private DateTimePicker dateTimePicker1;
        private TextBox textBox1;
        private TextBox textBox3;
        private ProgressBar progressBar1;
        private TabPage tabPage1;
        private Button button2;
        private Button button3;
        private TabControl tabControl1;
    }
}