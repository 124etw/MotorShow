using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace motorshow2
{
    public partial class equipment_W : Form
    {

        Peremen peremen = new Peremen();
        public equipment_W()
        {
            InitializeComponent();
            this.FormClosing += new FormClosingEventHandler(this.equipment_W_FormClosing);
            edit.ApplyCommonFormProperties(this);
        }
        EditForms edit = new EditForms();

        string equipment;
        string engine_capacity;
        string body_type;
        string engine_type;
        string box_type;
        string price;
        string model;

        bool dost;
        public void AssignValues_E(string eqm, string engine_c, string body_t, string eng_type, string box_t, string pr, string model)
        {
            this.equipment = eqm;
            this.engine_capacity = engine_c;
            this.body_type = body_t;
            this.engine_type = eng_type;
            this.box_type = box_t;
            this.price = pr;
            this.model = model;

        }
        public void ent(bool enter)
        {

            if (enter == true)
            {
                dost = true;
                textBox1.Text = equipment;
                textBox2.Text = engine_capacity;
                textBox3.Text = body_type;
                textBox4.Text = engine_type;
                textBox5.Text = box_type;
                textBox6.Text = price;
                textBox7.Text = model;



            }
        }

        private void equipment_W_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            equipment = textBox1.Text;
            engine_capacity = textBox2.Text;
            body_type = textBox3.Text;
            engine_type = textBox4.Text;
            body_type = textBox5.Text;
            price = textBox6.Text;
            model = textBox7.Text;


            // Проверка наличия значений перед вставкой в базу данных
            if (string.IsNullOrEmpty(equipment) ||
                string.IsNullOrEmpty(engine_type) ||
                string.IsNullOrEmpty(body_type) ||
                string.IsNullOrEmpty(engine_capacity) ||
                string.IsNullOrEmpty(body_type) ||
                   string.IsNullOrEmpty(price) ||
                string.IsNullOrEmpty(model))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.");
                return;
            }
            if (dost == true) { UpdateEquipmentRecord(equipment, engine_capacity, body_type, engine_type, body_type, price, model); return; }
            InsertDataIntoDatabase(equipment, engine_capacity, body_type, engine_type, body_type, price, model);
        }
        private void InsertDataIntoDatabase(string value, string value1, string value2, string value3, string value4, string value5, string value6)
        {
            Peremen peremen = new Peremen();
            using (NpgsqlConnection conn = new NpgsqlConnection(peremen.dotNet))
            {
                conn.Open();
                string request = "INSERT INTO equipments (equipment, engine_capacity, body_type, engine_type, box_type, price, model) VALUES (@value, @value1, @value2, @value3, @value4, @value5, @value6)";

                using (NpgsqlCommand cmd = new NpgsqlCommand(request, conn))
                {
                    cmd.Parameters.AddWithValue("@value", value);
                    cmd.Parameters.AddWithValue("@value1", value1);
                    cmd.Parameters.AddWithValue("@value2", value2);
                    cmd.Parameters.AddWithValue("@value3", value3);
                    cmd.Parameters.AddWithValue("@value4", value4);

                    // Преобразуйте строку в числовой формат (decimal)
                    decimal priceValue;
                    if (decimal.TryParse(value5, out priceValue))
                    {
                        cmd.Parameters.AddWithValue("@value5", priceValue);
                    }
                    else
                    {
                        // Если преобразование не удалось, установите значение по умолчанию или обработайте ошибку по вашему усмотрению.
                        cmd.Parameters.AddWithValue("@value5", 0); // Пример: устанавливаем 0 в случае ошибки.
                    }

                    cmd.Parameters.AddWithValue("@value6", value6);
                    cmd.ExecuteNonQuery();
                }
            }
        }


        public void UpdateEquipmentRecord(string equipment, string engineCapacity, string bodyType, string engineType, string boxType, string price, string model)
        {
            // Замените строку подключения на свою

            // SQL-запрос UPDATE
            string updateQuery = "UPDATE equipments SET " +
                                 "engine_capacity = @engineCapacity, body_type = @bodyType, " +
                                 "engine_type = @engineType, box_type = @boxType, " +
                                 "price = @price, model = @model " +
                                 "WHERE equipment = @equipment";

            NpgsqlConnection connection = new NpgsqlConnection(peremen.dotNet);
            connection.Open();
            NpgsqlCommand command = new NpgsqlCommand(updateQuery, connection);

            int ValuePrice;
            Int32.TryParse(price, out ValuePrice);
            command.Parameters.AddWithValue("@equipment", equipment);
            command.Parameters.AddWithValue("@engineCapacity", engineCapacity);
            command.Parameters.AddWithValue("@bodyType", bodyType);
            command.Parameters.AddWithValue("@engineType", engineType);
            command.Parameters.AddWithValue("@boxType", boxType);
            command.Parameters.AddWithValue("@price", ValuePrice);
            command.Parameters.AddWithValue("@model", model);

            // Открываем соединение


            try
            {
                // Выполняем запрос UPDATE
                int rowsAffected = command.ExecuteNonQuery();

                // Проверяем, успешно ли обновлена запись
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Запись успешно обновлена!");
                }
                else
                {
                    MessageBox.Show("Ошибка при обновлении записи в базе данных!");
                }
            }
            catch (Npgsql.PostgresException ex)
            {
                // Выводим сообщение об ошибке, если возникла ошибка PostgreSQL
                MessageBox.Show($"Ошибка PostgreSQL: {ex.Message}");
            }
        }

        private void equipment_W_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true; 

                this.Hide(); 

                

            }
        }
    }
}



