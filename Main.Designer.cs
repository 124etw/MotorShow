namespace motorshow2
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            button1 = new Button();
            dateTimePicker1 = new DateTimePicker();
            button4 = new Button();
            pictureBox1 = new PictureBox();
            textBox1 = new TextBox();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            progressBar1 = new ProgressBar();
            listBox1 = new ListBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(3, 56);
            button1.Margin = new Padding(3, 2, 3, 2);
            button1.Name = "button1";
            button1.Size = new Size(141, 40);
            button1.TabIndex = 1;
            button1.Text = "Составление ДКП";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(159, 2);
            dateTimePicker1.Margin = new Padding(3, 2, 3, 2);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(200, 23);
            dateTimePicker1.TabIndex = 4;
            // 
            // button4
            // 
            button4.Location = new Point(3, 2);
            button4.Margin = new Padding(3, 2, 3, 2);
            button4.Name = "button4";
            button4.Size = new Size(141, 40);
            button4.TabIndex = 6;
            button4.Text = "Статистика";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(2, 2);
            pictureBox1.Margin = new Padding(3, 2, 3, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(139, 169);
            pictureBox1.TabIndex = 7;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(159, 42);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(200, 97);
            textBox1.TabIndex = 8;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Location = new Point(-7, 190);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(370, 183);
            tabControl1.TabIndex = 9;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(button4);
            tabPage1.Controls.Add(button1);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(362, 155);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Основные функции";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(-7, 174);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(366, 19);
            progressBar1.TabIndex = 10;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(-7, 373);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(370, 34);
            listBox1.TabIndex = 11;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(357, 404);
            Controls.Add(listBox1);
            Controls.Add(progressBar1);
            Controls.Add(tabControl1);
            Controls.Add(textBox1);
            Controls.Add(pictureBox1);
            Controls.Add(dateTimePicker1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Main";
            Text = "Главное меню";
       
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button button1;
        private DateTimePicker dateTimePicker1;
        private Button button4;
        private PictureBox pictureBox1;
        private TextBox textBox1;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private ProgressBar progressBar1;
        private ListBox listBox1;
    }
}