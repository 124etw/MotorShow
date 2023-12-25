using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace motorshow2
{
    public partial class Country : Form
    {

        string mark;
        string country;
        bool dost;
        Peremen peremen = new Peremen();
        public Country()
        {
            InitializeComponent();
            this.FormClosing += new FormClosingEventHandler(this.Country_FormClosing);
            edit.ApplyCommonFormProperties(this);
        }
        EditForms edit = new EditForms();

        public void AssignValues_C(string eqm, string engine_c)
        {
            this.mark = eqm;
            this.country = engine_c;


        }
        public void ent(bool enter)
        {

            if (enter == true)
            {
                dost = true;
                textBox1.Text = mark;
                textBox2.Text = country;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            mark = textBox1.Text;
            country = textBox2.Text;
            if (string.IsNullOrEmpty(mark) ||
                  string.IsNullOrEmpty(country))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.");
                return;
            }
            if (dost == true)
            {
                UpdateRecord(mark, country);
                return;
            }
            InsertDataIntoDatabase(mark, country);
        }

        public void UpdateRecord(string mark, string country)
        {
            // Замените строку подключения на свою

            // SQL-запрос UPDATE
            string updateQuery = "UPDATE brand SET " +
                                 "mark = @mark,  country = @country";


            NpgsqlConnection connection = new NpgsqlConnection(peremen.dotNet);
            connection.Open();
            NpgsqlCommand command = new NpgsqlCommand(updateQuery, connection);


            command.Parameters.AddWithValue("@mark", mark);
            command.Parameters.AddWithValue("@country", country);


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
                string request = "INSERT INTO brand (mark,country) VALUES ( @value, @value1)";

                using (NpgsqlCommand cmd = new NpgsqlCommand(request, conn))
                {

                    cmd.Parameters.AddWithValue("@value", value);
                    cmd.Parameters.AddWithValue("@value1", value1);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void Country_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true; 

                this.Hide(); 

            }
        }
    }

}


