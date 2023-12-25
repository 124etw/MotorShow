using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace motorshow2
{
    public partial class AdminMaincs : Form
    {

        public AdminMaincs()
        {
            InitializeComponent();
            editForms.ApplyCommonFormProperties(this);
        }
        public string Last_name;
        public string First_name;
        string Patronomic;
        EditForms editForms = new EditForms();
        public AdminMaincs(string valueLast, string valueFirst, string patronomic)
        {
            InitializeComponent();
            Last_name = valueLast;
            First_name = valueFirst;
            Patronomic = patronomic;
            entr();
            LoadImageFromUrl("C:\\Users\\Рекс\\Downloads\\file.PNG");

        }
        private void button2_Click(object sender, EventArgs e)
        {

            Add add = new Add();
            add.Show();
        }
        public void entr()
        {
            textBox1.ReadOnly = true;
            textBox1.Text = $"Имя: {Last_name}{Environment.NewLine}" +
                            $"Фамилия: {First_name}{Environment.NewLine}" +
                            $"Отчество: {Patronomic}{Environment.NewLine}";
        }
        private void button3_Click(object sender, EventArgs e)
        {

            AddEmployee add = new AddEmployee();
            add.Show();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            LoadImageFromUrl("C:\\Users\\Рекс\\Downloads\\file.PNG");
        }
        private void LoadImageFromUrl(string imageUrl)
        {
            try
            {
                using (WebClient webClient = new WebClient())
                {
                    // Загружаем изображение по URL
                    byte[] data = webClient.DownloadData(imageUrl);
                    using (MemoryStream stream = new MemoryStream(data))
                    {
                        Image originalImage = Image.FromStream(stream);

                        // Масштабируем изображение, чтобы оно полностью заполнило PictureBox
                        pictureBox1.Image = ScaleImage(originalImage, pictureBox1.Size);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке изображения: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Метод для масштабирования изображения
        private Image ScaleImage(Image image, Size newSize)
        {
            Bitmap newImage = new Bitmap(newSize.Width, newSize.Height);

            using (Graphics g = Graphics.FromImage(newImage))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(image, 0, 0, newSize.Width, newSize.Height);
            }

            return newImage;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void AdminMaincs_Load(object sender, EventArgs e)
        {

        }
    }


}
