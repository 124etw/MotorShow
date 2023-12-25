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
using Npgsql;

namespace motorshow2
{
    public partial class EmployeeAdd : Form
    {
        public EmployeeAdd()
        {
            InitializeComponent();
            LoadPositionDataIntoDictionary();
            this.FormClosing += new FormClosingEventHandler(this.EmployeeAdd_FormClosing);
            editForms.ApplyCommonFormProperties(this);
        }
        EditForms editForms = new EditForms();
        Peremen peremen = new Peremen();
        private Dictionary<int, string> positionsDictionary = new Dictionary<int, string>();
        string first_name;
        string last_name;
        string patronymic;
        string date_of_birth;
        string salary;
        string email;
        string address_residence;
        string indificator;
        string series_and_number;

        int idpostion;

        bool dost;

        public void AssignValues_E(string FN, string LN, string PAT, string dATE, string salary, string email, string id, string ar, string sn)
        {
            this.first_name = FN;
            this.last_name = LN;
            this.patronymic = PAT;
            this.date_of_birth = dATE;
            this.salary = salary;
            this.email = email;
            this.address_residence = id;
            this.indificator = ar;
            this.series_and_number = sn;
        }
        public void ent(bool enter)
        {

            if (enter == true)
            {
                dost = true;
                textBox1.Text = first_name;
                textBox2.Text = last_name;
                textBox3.Text = patronymic;
                textBox4.Text = date_of_birth;
                textBox6.Text = salary;
                textBox5.Text = email;
                textBox8.Text = indificator;
                textBox9.Text = series_and_number;
                textBox10.Text = address_residence;



            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            last_name = textBox2.Text;
            first_name = textBox1.Text;
            patronymic = textBox3.Text;
            date_of_birth = textBox4.Text;
            salary = textBox5.Text;
            email = textBox6.Text;
            indificator = textBox8.Text;
            series_and_number = textBox9.Text;
            address_residence = textBox10.Text;



            if (string.IsNullOrEmpty(last_name) ||
                string.IsNullOrEmpty(first_name) ||
                string.IsNullOrEmpty(patronymic) ||
                string.IsNullOrEmpty(date_of_birth) ||
                string.IsNullOrEmpty(salary) ||
                   string.IsNullOrEmpty(email) ||
                string.IsNullOrEmpty(indificator) ||
                  string.IsNullOrEmpty(series_and_number) ||
                    string.IsNullOrEmpty(address_residence))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.");
                return;

            }
            if (dost == true)
            {
                UpdateEmployeeRecord(first_name, last_name, patronymic, date_of_birth, salary, email, idpostion, address_residence, indificator, series_and_number);
                return;
            }
            InsertDataIntoDatabase(first_name, last_name, patronymic, date_of_birth, salary, email, idpostion, address_residence, indificator, series_and_number);
        }
        private void InsertDataIntoDatabase(string value, string value1, string value2, string value3, string value4, string value5, int value6, string value7, string value8, string value9)
        {
            Peremen peremen = new Peremen();
            using (NpgsqlConnection conn = new NpgsqlConnection(peremen.dotNet))
            {
                conn.Open();
                string request = "INSERT INTO employee (first_name, last_name,patronymic,date_of_birth,salary ,email , id_position,address_residence , idificator ,series_and_number) VALUES (@value, @value1, @value2, @value3, @value4, @value5, @value6, @value7, @value8, @value9)";

                using (NpgsqlCommand cmd = new NpgsqlCommand(request, conn))
                {
                    DateTime.TryParse(date_of_birth, out DateTime dateValue);
                    cmd.Parameters.AddWithValue("@value", value);
                    cmd.Parameters.AddWithValue("@value1", value1);
                    cmd.Parameters.AddWithValue("@value2", value2);
                    cmd.Parameters.AddWithValue("@value3", dateValue);
                    cmd.Parameters.AddWithValue("@value5", value4);


                    decimal priceValue;
                    if (decimal.TryParse(value5, out priceValue))
                    {
                        cmd.Parameters.AddWithValue("@value4", priceValue);
                    }
                    else
                    {

                        cmd.Parameters.AddWithValue("@value4", 0);
                    }
                    int IDvalue;
                    int.TryParse(value8, out IDvalue);
                    cmd.Parameters.AddWithValue("@value6", value6);
                    cmd.Parameters.AddWithValue("@value7", value7);
                    cmd.Parameters.AddWithValue("@value8", IDvalue);
                    cmd.Parameters.AddWithValue("@value9", value9);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Успешно добавленно");
                }
            }
        }

        public void UpdateEmployeeRecord(string firstName, string lastName, string patronymic, string dateOfBirth, string salary, string email, int idPosition, string addressResidence, string indificator, string seriesAndNumber)
        {
            string updateQuery = "UPDATE employee SET last_name = @lastName, first_name = @firstName, patronymic = @patronymic, " +
                     "date_of_birth = @dateOfBirth, salary = @salary, email = @email, " +
                     "id_position = @idPosition, address_residence = @addressResidence, " +
                     "idificator = @indificator, WHERE series_and_number = @seriesAndNumber ";
                     


            using (NpgsqlConnection connection = new NpgsqlConnection(peremen.dotNet))
            {
                using (NpgsqlCommand command = new NpgsqlCommand(updateQuery, connection))
                {
                    DateTime.TryParse(dateOfBirth, out DateTime dateValue);
                    decimal priceValue;
                    decimal.TryParse(salary, out priceValue);
                    int indif;
                    Int32.TryParse(indificator, out indif);
                    command.Parameters.AddWithValue("@lastName", lastName);
                    command.Parameters.AddWithValue("@firstName", firstName);
                    command.Parameters.AddWithValue("@patronymic", patronymic);
                    command.Parameters.AddWithValue("@dateOfBirth", dateValue);
                    command.Parameters.AddWithValue("@salary", priceValue);
                    command.Parameters.AddWithValue("@email", email);
                    command.Parameters.AddWithValue("@idPosition", idPosition);
                    command.Parameters.AddWithValue("@addressResidence", addressResidence);
                    command.Parameters.AddWithValue("@indificator", indif);
                    command.Parameters.AddWithValue("@seriesAndNumber", seriesAndNumber);

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
                        MessageBox.Show($"Нарушает целостность БД , обратитесь к администратору!");
                    }
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != -1)
            {

                string selectedPosition = comboBox1.SelectedItem.ToString();



                if (positionsDictionary.ContainsValue(selectedPosition))
                {
                    idpostion = positionsDictionary.First(x => x.Value == selectedPosition).Key;

                }
            }

        }
        private void LoadPositionDataIntoDictionary()
        {

            Peremen peremen = new Peremen();
            using (NpgsqlConnection connection = new NpgsqlConnection(peremen.dotNet))
            {
                connection.Open();

                string sqlQuery = "SELECT * FROM position";

                using (NpgsqlCommand command = new NpgsqlCommand(sqlQuery, connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            int idPosition = reader.GetInt32(0);
                            string position = reader.GetString(1);

                            positionsDictionary.Add(idPosition, position);


                            comboBox1.Items.Add(position);
                        }
                    }
                }
            }
        }

        private void EmployeeAdd_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true; 

                this.Hide(); 

               
            }
        }
    }
}
