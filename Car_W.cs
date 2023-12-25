using motorshow2;
using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace motorshow2
{
    public partial class Car_W : Form
    {
        public Car_W()
        {
            InitializeComponent();
            this.FormClosing += new FormClosingEventHandler(this.Car_W_FormClosing);
            editForms.ApplyCommonFormProperties(this);
        }
        EditForms editForms = new EditForms();
        Peremen peremen = new Peremen();

        public string vin;
        public string engine_number;
        public string equipment;
        public string year_release;
        public string mileage;
        public string chassis_number;
        public string body_number;
        public string body_color;

        bool dost;

        public void AssignValues(string vin, string engineNumber, string equip, string year, string mile, string chassis, string body, string color)
        {
            this.vin = vin;
            this.engine_number = engineNumber;
            this.equipment = equip;
            this.year_release = year;
            this.mileage = mile;
            this.chassis_number = chassis;
            this.body_number = body;
            this.body_color = color;
        }
        public void ent(bool enter)
        {

            if (enter == true)
            {
                dost = true;
                textBox1.Text = vin;
                textBox2.Text = engine_number;
                textBox3.Text = equipment;
                textBox4.Text = year_release;
                textBox5.Text = mileage;
                textBox6.Text = chassis_number;
                textBox7.Text = body_number;
                textBox8.Text = body_color;


            }
        }

        private void InsertDataIntoDatabase(string value, string value1, string value2, string value3, string value4, string value5, string value6, string value7)
        {

            Peremen peremen = new Peremen();
            using (NpgsqlConnection conn = new NpgsqlConnection(peremen.dotNet))
            {
                conn.Open();
                string request = "INSERT INTO car (vin,engine_number, equipment , year_release, mileage , chassis_number , body_number ,body_color) VALUES ( @value, @value1, @value2, @value3, @value4, @value5, @value6,@value7)";

                using (NpgsqlCommand cmd = new NpgsqlCommand(request, conn))
                {
                    int valueMilage;
                    Int32.TryParse(value4, out valueMilage);
                    cmd.Parameters.AddWithValue("@value", value);
                    cmd.Parameters.AddWithValue("@value1", value1);
                    cmd.Parameters.AddWithValue("@value2", value2);
                    cmd.Parameters.AddWithValue("@value3", value3);
                    cmd.Parameters.AddWithValue("@value4", valueMilage);
                    cmd.Parameters.AddWithValue("@value5", value5);
                    cmd.Parameters.AddWithValue("@value6", value6);
                    cmd.Parameters.AddWithValue("@value7", value7);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void UpdateCarRecord(string vin, string engineNumber, string equipment, string yearRelease, string mileage, string chassisNumber, string bodyNumber, string bodyColor)
        {

            string updateQuery = "UPDATE car SET engine_number = @engineNumber, equipment = @equipment, " +
                                 "year_release = @yearRelease, mileage = @mileage, " +
                                 "chassis_number = @chassisNumber, body_number = @bodyNumber, body_color = @bodyColor " +
                                 "WHERE vin = @vin";

            using (NpgsqlConnection connection = new NpgsqlConnection(peremen.dotNet))
            {
                using (NpgsqlCommand command = new NpgsqlCommand(updateQuery, connection))
                {
                    int valuemilage;
                    Int32.TryParse(mileage, out valuemilage);
                    // Добавляем параметры
                    command.Parameters.AddWithValue("@vin", vin);
                    command.Parameters.AddWithValue("@engineNumber", engineNumber);
                    command.Parameters.AddWithValue("@equipment", equipment);
                    command.Parameters.AddWithValue("@yearRelease", yearRelease);
                    command.Parameters.AddWithValue("@mileage", valuemilage);
                    command.Parameters.AddWithValue("@chassisNumber", chassisNumber);
                    command.Parameters.AddWithValue("@bodyNumber", bodyNumber);
                    command.Parameters.AddWithValue("@bodyColor", bodyColor);

                    // Открываем соединение
                    connection.Open();

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
            }
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {


            vin = textBox1.Text;
            engine_number = textBox2.Text;
            equipment = textBox3.Text;
            year_release = textBox4.Text;
            mileage = textBox5.Text;
            chassis_number = textBox6.Text;
            body_number = textBox7.Text;
            body_color = textBox8.Text;
            if (string.IsNullOrEmpty(vin) ||
                string.IsNullOrEmpty(engine_number) ||
                string.IsNullOrEmpty(equipment) ||
                string.IsNullOrEmpty(year_release) ||
                string.IsNullOrEmpty(mileage) ||
                   string.IsNullOrEmpty(chassis_number) ||
                string.IsNullOrEmpty(body_number) ||
                    string.IsNullOrEmpty(body_color))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.");
                return;
            }
            if (dost == true)
            {
                UpdateCarRecord(vin, engine_number, equipment, year_release, mileage, chassis_number, body_number, body_color);
                return;
            }
            InsertDataIntoDatabase(vin, engine_number, equipment, year_release, mileage, chassis_number, body_number, body_color);
        }

        private void Car_W_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;

                this.Hide();
            }
        }
    }

}

