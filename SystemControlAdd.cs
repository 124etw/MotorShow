using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace motorshow2
{
    
    public partial class SystemControlAdd : Form
    {
        public SystemControlAdd()
        {
            InitializeComponent();
        }
Peremen peremen = new Peremen();
        string login;
        string password;
        string id;
        bool dost;
        public void AssignValues_C(string login, string password,string id)
        {
            this.login =login;
            this.password = password;
            this.id = id;


        }
        public void ent(bool enter)
        {

            if (enter == true)
            {
                dost = true;
                textBox1.Text = login;
                textBox2.Text = password;
                textBox3.Text = id;


            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Успешно добавленно");
            login = textBox1.Text;
            password = textBox2.Text;
            id = textBox3.Text;
            int intValue;
            int.TryParse(id,out intValue);
            if (string.IsNullOrEmpty(login) ||
                string.IsNullOrEmpty(id) ||
             string.IsNullOrEmpty(password))

            {
                MessageBox.Show("Пожалуйста, заполните все поля.");
                return;
            }
            if(dost==true) { UpdateControlRecord(id,login, password); return; }
            InsertDataIntoDatabase(intValue,login, password);
        }


        private void InsertDataIntoDatabase(int value ,string value1, string value2)
        {
            Peremen peremen = new Peremen();
            using (NpgsqlConnection conn = new NpgsqlConnection(peremen.dotNet))
            {
                conn.Open();
                string request = "INSERT INTO system_control ( identifier_user,login,password) VALUES (@value, @value1,@value2)";

                using (NpgsqlCommand cmd = new NpgsqlCommand(request, conn))
                {
                   

                    cmd.Parameters.AddWithValue("@value", value);
                    cmd.Parameters.AddWithValue("@value1", value1);
                    cmd.Parameters.AddWithValue("@value2", value2);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Успешно Добавили в таблицу");


                }
            }

        }
        public void UpdateControlRecord(string id ,string login, string password)
        {
            
            string updateQuery = "UPDATE models SET " + "identifier_user=@id"+
                                 "login = @login, password = @password";


            NpgsqlConnection connection = new NpgsqlConnection(peremen.dotNet);
            connection.Open();
            NpgsqlCommand command = new NpgsqlCommand(updateQuery, connection);
            int Idif;
            Int32.TryParse(id, out Idif);
            command.Parameters.AddWithValue("@id", Idif);
            command.Parameters.AddWithValue("@login", login);
            command.Parameters.AddWithValue("@password", password);


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
