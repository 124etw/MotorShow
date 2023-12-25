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
    public partial class models_w : Form
    {
        string model;
        string brand;
        bool dost;
        Peremen peremen = new Peremen();
        public models_w()
        {
            InitializeComponent();
            this.FormClosing += new FormClosingEventHandler(this.models_w_FormClosing);
            editForms.ApplyCommonFormProperties(this);
        }
        EditForms editForms = new EditForms();


        public void AssignValues_M(string eqm, string engine_c)
        {
            this.model = eqm;
            this.brand = engine_c;


        }
        public void ent(bool enter)
        {

            if (enter == true)
            {
                dost = true;
                textBox1.Text = model;
                textBox2.Text = brand;

            }
        }



        private void button1_Click(object sender, EventArgs e)
        {

            model = textBox1.Text;
            brand = textBox2.Text;
            if (string.IsNullOrEmpty(model) ||
                  string.IsNullOrEmpty(brand))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.");
                return;
            }
            if (dost == true) { UpdateEquipmentRecord(model, brand); return; }
            InsertDataIntoDatabase(model, brand);
        }

        public void UpdateEquipmentRecord(string model, string brand)
        {
            // Замените строку подключения на свою

            // SQL-запрос UPDATE
            string updateQuery = "UPDATE models SET " +
                                 "model = @model, brand = @brand";


            NpgsqlConnection connection = new NpgsqlConnection(peremen.dotNet);
            connection.Open();
            NpgsqlCommand command = new NpgsqlCommand(updateQuery, connection);


            command.Parameters.AddWithValue("@model", model);
            command.Parameters.AddWithValue("@brand", brand);


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
                MessageBox.Show($"Не изменяйте данное поле так как нарушает цеостность базы!");
            }
        }

        private void InsertDataIntoDatabase(string value, string value1)
        {


            Peremen peremen = new Peremen();
            using (NpgsqlConnection conn = new NpgsqlConnection(peremen.dotNet))
            {
                conn.Open();
                string request = "INSERT INTO models (model,brand) VALUES ( @value, @value1)";

                using (NpgsqlCommand cmd = new NpgsqlCommand(request, conn))
                {

                    cmd.Parameters.AddWithValue("@value", value);
                    cmd.Parameters.AddWithValue("@value1", value1);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void models_w_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true; 

                this.Hide(); 

               
            }
        }
    }

}



