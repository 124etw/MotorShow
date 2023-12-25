namespace motorshow2
{
    partial class Add
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
            tabPage1 = new TabPage();
            button1 = new Button();
            SaveChan = new Button();
            button3 = new Button();
            button2 = new Button();
            comboBox1 = new ComboBox();
            dataGridView1 = new DataGridView();
            tabControl1 = new TabControl();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            tabControl1.SuspendLayout();
            SuspendLayout();
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(button1);
            tabPage1.Controls.Add(SaveChan);
            tabPage1.Controls.Add(button3);
            tabPage1.Controls.Add(button2);
            tabPage1.Controls.Add(comboBox1);
            tabPage1.Controls.Add(dataGridView1);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Margin = new Padding(3, 2, 3, 2);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3, 2, 3, 2);
            tabPage1.Size = new Size(1041, 388);
            tabPage1.TabIndex = 0;
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(955, 53);
            button1.Name = "button1";
            button1.Size = new Size(82, 22);
            button1.TabIndex = 9;
            button1.Text = "Изменить";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // SaveChan
            // 
            SaveChan.Location = new Point(955, 8);
            SaveChan.Margin = new Padding(3, 2, 3, 2);
            SaveChan.Name = "SaveChan";
            SaveChan.Size = new Size(82, 22);
            SaveChan.TabIndex = 8;
            SaveChan.Text = "Добавить";
            SaveChan.UseVisualStyleBackColor = true;
            SaveChan.Click += SaveChan_Click;
            // 
            // button3
            // 
            button3.Location = new Point(953, 152);
            button3.Margin = new Padding(3, 2, 3, 2);
            button3.Name = "button3";
            button3.Size = new Size(82, 22);
            button3.TabIndex = 7;
            button3.Text = "Назад";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.Location = new Point(953, 95);
            button2.Margin = new Padding(3, 2, 3, 2);
            button2.Name = "button2";
            button2.Size = new Size(82, 22);
            button2.TabIndex = 6;
            button2.Text = "Удалить";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(7, 7);
            comboBox1.Margin = new Padding(3, 2, 3, 2);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(946, 23);
            comboBox1.TabIndex = 3;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(5, 32);
            dataGridView1.Margin = new Padding(3, 2, 3, 2);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(948, 352);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            dataGridView1.CellEndEdit += dataGridView1_CellEndEdit;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Location = new Point(0, 2);
            tabControl1.Margin = new Padding(3, 2, 3, 2);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1049, 416);
            tabControl1.TabIndex = 0;
            // 
            // Add
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1048, 416);
            Controls.Add(tabControl1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Add";
            Text = "База Машин";
            tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            tabControl1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TabPage tabPage1;
        private Button button3;
        private Button button2;
        private ComboBox comboBox1;
        private DataGridView dataGridView1;
        private TabControl tabControl1;
        private Button btnSaveChanges;
        private Button SaveChan;
        private Button button1;
    }
}