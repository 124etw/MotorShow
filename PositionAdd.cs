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
    public partial class PositionAdd : Form
    {
        string position;
        string id_positon;
        bool dost;
        Peremen peremen = new Peremen();
        public PositionAdd()
        {
            InitializeComponent();
        }
        public void AssignValues_P(string eqm, string engine_c)
        {
            this.position = eqm;
            this.id_positon = engine_c;


        }
        public void ent(bool enter)
        {

            if (enter == true)
            {
                dost = true;
                textBox1.Text = position;
                textBox2.Text = id_positon;

            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            id_positon = textBox1.Text;
            position = textBox2.Text;
            if (string.IsNullOrEmpty(id_positon) ||
             string.IsNullOrEmpty(position))

            {
                MessageBox.Show("Пожалуйста, заполните все поля.");
                return;
            }
            if (dost==true)
            {
                UpdatePositionRecord(id_positon, position);
                return;
            }
                InsertDataIntoDatabase(id_positon, position);
        }


        private void InsertDataIntoDatabase(string value, string value1)
        {
            Peremen peremen = new Peremen();
            using (NpgsqlConnection conn = new NpgsqlConnection(peremen.dotNet))
            {
                conn.Open();
                string request = "INSERT INTO POSITION (id_position,position) VALUES (@value, @value1)";

                using (NpgsqlCommand cmd = new NpgsqlCommand(request, conn))
                {
                    int.TryParse(id_positon, out int intValue);

                    cmd.Parameters.AddWithValue("@value", intValue);
                    cmd.Parameters.AddWithValue("@value1", value1);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Успешно Добавили в таблицу");


                }
            }

        }
        public void UpdatePositionRecord(string id_position, string position)
        {
            // Замените строку подключения на свою

            // SQL-запрос UPDATE
            string updateQuery = "UPDATE position SET " +
                                 "id_position = @id_position,  position = @position";


            NpgsqlConnection connection = new NpgsqlConnection(peremen.dotNet);
            connection.Open();
            NpgsqlCommand command = new NpgsqlCommand(updateQuery, connection);


            command.Parameters.AddWithValue("@po", id_position);
            command.Parameters.AddWithValue("@password", position);


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
    }
}
