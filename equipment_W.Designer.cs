namespace motorshow2
{
    partial class equipment_W
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
            button1 = new Button();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            textBox5 = new TextBox();
            textBox6 = new TextBox();
            textBox7 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(47, 307);
            button1.Margin = new Padding(3, 2, 3, 2);
            button1.Name = "button1";
            button1.Size = new Size(137, 22);
            button1.TabIndex = 0;
            button1.Text = "Сохранить";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(10, 9);
            textBox1.Margin = new Padding(3, 2, 3, 2);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(263, 23);
            textBox1.TabIndex = 1;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(10, 44);
            textBox2.Margin = new Padding(3, 2, 3, 2);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(263, 23);
            textBox2.TabIndex = 2;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(10, 88);
            textBox3.Margin = new Padding(3, 2, 3, 2);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(263, 23);
            textBox3.TabIndex = 3;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(10, 132);
            textBox4.Margin = new Padding(3, 2, 3, 2);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(263, 23);
            textBox4.TabIndex = 4;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(10, 185);
            textBox5.Margin = new Padding(3, 2, 3, 2);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(263, 23);
            textBox5.TabIndex = 5;
            // 
            // textBox6
            // 
            textBox6.Location = new Point(10, 233);
            textBox6.Margin = new Padding(3, 2, 3, 2);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(263, 23);
            textBox6.TabIndex = 6;
            // 
            // textBox7
            // 
            textBox7.Location = new Point(10, 273);
            textBox7.Margin = new Padding(3, 2, 3, 2);
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(263, 23);
            textBox7.TabIndex = 7;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(278, 11);
            label1.Name = "label1";
            label1.Size = new Size(87, 15);
            label1.TabIndex = 8;
            label1.Text = "Комплектация";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(278, 49);
            label2.Name = "label2";
            label2.Size = new Size(102, 15);
            label2.TabIndex = 9;
            label2.Text = "Объём двигателя";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(278, 137);
            label3.Name = "label3";
            label3.Size = new Size(84, 15);
            label3.TabIndex = 10;
            label3.Text = "Тип двигателя";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(278, 93);
            label4.Name = "label4";
            label4.Size = new Size(66, 15);
            label4.TabIndex = 11;
            label4.Text = "Тип кузова";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(278, 190);
            label5.Name = "label5";
            label5.Size = new Size(77, 15);
            label5.TabIndex = 12;
            label5.Text = "Тип коробки";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(278, 238);
            label6.Name = "label6";
            label6.Size = new Size(35, 15);
            label6.TabIndex = 13;
            label6.Text = "Цена";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(278, 278);
            label7.Name = "label7";
            label7.Size = new Size(50, 15);
            label7.TabIndex = 14;
            label7.Text = "Модель";
            // 
            // equipment_W
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 338);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox7);
            Controls.Add(textBox6);
            Controls.Add(textBox5);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(button1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "equipment_W";
            Text = "Комплектация";
            FormClosing += equipment_W_FormClosing;
            Load += equipment_W_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private TextBox textBox5;
        private TextBox textBox6;
        private TextBox textBox7;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
    }
}