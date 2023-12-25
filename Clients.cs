using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace motorshow2
{
    public partial class Clients : Form
    {
        public Clients()
        {
            InitializeComponent();
            editForms.ApplyCommonFormProperties(this);
        }
        EditForms editForms=new EditForms();
        public string last_name;
        public string first_name;
        public string potronomic;
        public string series_and_number;
        public string address_residence;
        public string phon;
        public string email;
       
        private void button1_Click(object sender, EventArgs e)
        {
            first_name = textBox3.Text;
            last_name = textBox6.Text;
            potronomic = textBox4.Text;
            series_and_number = textBox7.Text;
            address_residence = textBox8.Text;
            phon = textBox2.Text;
            email = textBox1.Text;

            // Проверка наличия значений перед вставкой в базу данных
            if (string.IsNullOrEmpty(first_name) ||
                string.IsNullOrEmpty(last_name) ||
                string.IsNullOrEmpty(potronomic) ||
                string.IsNullOrEmpty(series_and_number) ||
                string.IsNullOrEmpty(address_residence) ||
                   string.IsNullOrEmpty(phon) ||
                string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.");
                return;
            }

            InsertDataIntoDatabase(last_name, first_name, potronomic, series_and_number, address_residence, phon, email);

            // Очищаем текстовые поля после вставки данных



            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
        
        }
        //private void button4_Click(object sender, EventArgs e)
        //{
        //    using (NpgsqlConnection connection = new NpgsqlConnection())
        //    {
        //        connection.Open();

        //        // 1. Удаление строки
        //        string deleteQuery = "DELETE FROM Equipments WHERE equipment ='Сar2';";
        //        using (NpgsqlCommand deleteCmd = new NpgsqlCommand(deleteQuery, connection))
        //        {
        //            deleteCmd.ExecuteNonQuery();
        //        }

        //    }

        private void InsertDataIntoDatabase(string value, string value1, string value2, string value3, string value4, string value5, string value6)
        {
    
            int Ivalue5 = 0;
            Int32.TryParse(value5, out Ivalue5);
            Peremen peremen = new Peremen();
            using (NpgsqlConnection conn = new NpgsqlConnection(peremen.dotNet))
            {
                conn.Open();
                string request = "INSERT INTO client ( first_name, last_name, patronymic, Series_and_Number, ADDRESS_RESIDENCE, phon, email) VALUES ( @value, @value1, @value2, @value3, @value4, @value5, @value6)";

                using (NpgsqlCommand cmd = new NpgsqlCommand(request, conn))
                {
                   
                    cmd.Parameters.AddWithValue("@value", value);
                    cmd.Parameters.AddWithValue("@value1", value1);
                    cmd.Parameters.AddWithValue("@value2", value2);
                    cmd.Parameters.AddWithValue("@value3", value3);
                    cmd.Parameters.AddWithValue("@value4", value4);
                    cmd.Parameters.AddWithValue("@value5", Ivalue5);
                    cmd.Parameters.AddWithValue("@value6", value6);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
