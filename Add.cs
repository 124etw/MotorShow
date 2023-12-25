using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;

namespace motorshow2
{
    public partial class Add : Form
    {
        Peremen peremen = new Peremen();
        private NpgsqlDataAdapter dataAdapter;
        private DataTable dataTable;
        EditForms editForms = new EditForms();

        Car_W cart = new Car_W();

        equipment_W equipmentt = new equipment_W();

        models_w modelst = new models_w();

        Country country = new Country();

        bool ent = true;
        bool entF = false;

        List<string> key_combox = new List<string>()
        {
            {"car"},
            {"equipments"},
            {"models"},
            {"brand" }
        };

        public Add()
        {
            InitializeComponent();
            selectBox(comboBox1);
            dataGridView1.CellEndEdit += dataGridView1_CellEndEdit;
            editForms.ApplyCommonFormProperties(this);
        }



        private void button3_Click(object sender, EventArgs e)
        {
            AdminMaincs adminMaincs = new AdminMaincs();
            adminMaincs.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql;
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    sql = comboBox1.Text;
                    viewTable(sql);
                    break;
                case 1:
                    sql = comboBox1.Text;
                    viewTable(sql);
                    break;
                case 2:
                    sql = comboBox1.Text;
                    viewTable(sql);
                    break;
                case 3:
                    sql = comboBox1.Text;
                    viewTable(sql);
                    break;
            }
        }
        public void selectBox(ComboBox box)
        {
            foreach (string key in key_combox)
            {
                box.Items.Add(key);
            }
        }

        public void viewTable(string key)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(peremen.dotNet))
            {
                connection.Open();
                string SQL = $"SELECT * FROM {key} ;";

                using (NpgsqlCommand command = new NpgsqlCommand(SQL, connection))
                {
                    using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command))
                    {

                        dataAdapter = new NpgsqlDataAdapter(command);
                        dataTable = new DataTable();
                        dataAdapter.Fill(dataTable);
                        dataGridView1.ReadOnly = false;
                        // Привязываем DataTable к DataGridView
                        dataGridView1.DataSource = dataTable;

                        foreach (DataGridViewColumn column in dataGridView1.Columns)
                        {
                            switch (column.Name)
                            {
                                case "vin":
                                    column.HeaderText = "Вин";
                                    break;
                                case "engine_number":
                                    column.HeaderText = "Номер двигателя";
                                    break;
                                case "equipment":
                                    column.HeaderText = "Комплектация";
                                    break;
                                case "year_release":
                                    column.HeaderText = "Год выпуска";
                                    break;
                                case "mileage":
                                    column.HeaderText = "Пробег";
                                    break;
                                case "chassis_number":
                                    column.HeaderText = "Номер шасси";
                                    break;
                                case "body_number":
                                    column.HeaderText = "Номер кузова";
                                    break;
                                case "body_color":
                                    column.HeaderText = "Цвет кузова";
                                    break;

                                case "engine_capacity":
                                    column.HeaderText = "Объём двигателя";
                                    break;
                                case "body_type":
                                    column.HeaderText = "Тип кузова";
                                    break;
                                case "engine_type":
                                    column.HeaderText = "Тип двигателя";
                                    break;
                                case "box_type":
                                    column.HeaderText = "Тип коробк";
                                    break;
                                case "price":
                                    column.HeaderText = "Цена";
                                    break;
                                case "model":
                                    column.HeaderText = "Модель";
                                    break;
                                case "brand":
                                    column.HeaderText = "Бренд";
                                    break;
                                case "country":
                                    column.HeaderText = "Страна";
                                    break;
                                case "mark":
                                    column.HeaderText = "Марка";
                                    break;
                            }
                        }




                    }

                }

            }

        }




        private void SaveChan_Click(object sender, EventArgs e)
        {

            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    Car_W cart = new Car_W();
                    cart.Show();
                    break;
                case 1:
                    equipment_W equipmentt = new equipment_W();
                    equipmentt.Show();
                    break;
                case 2:
                    models_w modelst = new models_w();
                    modelst.Show();
                    break;
                case 3:
                    Country country = new Country();
                    country.Show();
                    break;
            }
        }





        private void button2_Click(object sender, EventArgs e)
        {
            string sql;
            string Isql;
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    sql = comboBox1.Text;
                    Isql = "vin";
                    delet(sql, Isql);
                    break;
                case 1:
                    sql = comboBox1.Text;
                    Isql = "equipment";
                    delet(sql, Isql);
                    break;
                case 2:
                    sql = comboBox1.Text;
                    Isql = "model";
                    delet(sql, Isql);
                    break;
                case 3:
                    sql = comboBox1.Text;
                    Isql = "mark";
                    delet(sql, Isql);
                    break;
            }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        public void delet(string sql, string iSql)
        {
            // Проверяем, выбрана ли строка в DataGridView
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Получаем индекс выбранной строки
                int rowIndex = dataGridView1.SelectedRows[0].Index;

                // Получаем значение из выбранной строки
                string modelValue = dataGridView1.Rows[rowIndex].Cells[iSql].Value.ToString();

                // Составляем DELETE SQL-запрос с использованием параметризации
                string deleteQuery = $"DELETE FROM {sql} WHERE {iSql} = @model";

                // Создаем подключение к базе данных (замените на вашу строку подключения)
                using (NpgsqlConnection connection = new NpgsqlConnection(peremen.dotNet))
                {
                    // Создаем команду SQL
                    using (NpgsqlCommand command = new NpgsqlCommand(deleteQuery, connection))
                    {
                        // Добавляем параметры
                        command.Parameters.AddWithValue("@model", modelValue);

                        // Открываем соединение
                        connection.Open();

                        try
                        {
                            // Выполняем запрос DELETE
                            int rowsAffected = command.ExecuteNonQuery();

                            // Проверяем, успешно ли удалена строка
                            if (rowsAffected > 0)
                            {
                                // Удаляем строку из DataGridView
                                dataGridView1.Rows.RemoveAt(rowIndex);

                                // Опционально, выводим сообщение об успешном удалении
                                MessageBox.Show("Строка успешно удалена!");
                            }
                            else
                            {
                                // Выводим сообщение об ошибке, если строка не была удалена
                                MessageBox.Show("Ошибка при удалении строки из базы данных!");
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
            else
            {
                MessageBox.Show("Пожалуйста, выберите строку для удаления.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    AssignValuesToVariables();
                    cart.ent(ent);
                    cart.Show();
                    break;
                case 1:

                    AssignValuesToVariables_E();
                    equipmentt.ent(ent);
                    equipmentt.Show();
                    break;
                case 2:
                    AssignValuesToVariables_M();
                    modelst.ent(ent);
                    modelst.Show();
                    break;
                case 3:
                    AssignValuesToVariables_C();
                    country.ent(ent);
                    country.Show();
                    break;
            }
        }

        public void AssignValuesToVariables()
        {
            // Проверяем, выбрана ли строка в DataGridView
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Получаем индекс выбранной строки
                int rowIndex = dataGridView1.SelectedRows[0].Index;

                // Присваиваем значения переменным из выбранной строки
                cart.AssignValues(
                 dataGridView1.Rows[rowIndex].Cells["Vin"].Value.ToString(),
                 dataGridView1.Rows[rowIndex].Cells["engine_number"].Value.ToString(),
                 dataGridView1.Rows[rowIndex].Cells["equipment"].Value.ToString(),
                 dataGridView1.Rows[rowIndex].Cells["year_release"].Value.ToString(),
                 dataGridView1.Rows[rowIndex].Cells["mileage"].Value.ToString(),
                 dataGridView1.Rows[rowIndex].Cells["chassis_number"].Value.ToString(),
                 dataGridView1.Rows[rowIndex].Cells["body_number"].Value.ToString(),
                 dataGridView1.Rows[rowIndex].Cells["body_number"].Value.ToString()
             );

                // Опционально, выводим сообщение об успешном присвоении значений
                MessageBox.Show("Значения успешно присвоены переменным!");
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите строку для присвоения значений переменным.");
            }
        }

        public void AssignValuesToVariables_E()
        {
            // Проверяем, выбрана ли строка в DataGridView
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Получаем индекс выбранной строки
                int rowIndex = dataGridView1.SelectedRows[0].Index;

                // Присваиваем значения переменным из выбранной строки
                equipmentt.AssignValues_E(
                 dataGridView1.Rows[rowIndex].Cells["equipment"].Value.ToString(),
                 dataGridView1.Rows[rowIndex].Cells["engine_capacity"].Value.ToString(),
                 dataGridView1.Rows[rowIndex].Cells["body_type"].Value.ToString(),
                 dataGridView1.Rows[rowIndex].Cells["engine_type"].Value.ToString(),
                 dataGridView1.Rows[rowIndex].Cells["box_type"].Value.ToString(),
                 dataGridView1.Rows[rowIndex].Cells["price"].Value.ToString(),
                 dataGridView1.Rows[rowIndex].Cells["model"].Value.ToString()
             );

                // Опционально, выводим сообщение об успешном присвоении значений
                MessageBox.Show("Значения успешно присвоены переменным!");
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите строку для присвоения значений переменным.");
            }
        }

        public void AssignValuesToVariables_M()
        {
            // Проверяем, выбрана ли строка в DataGridView
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Получаем индекс выбранной строки
                int rowIndex = dataGridView1.SelectedRows[0].Index;

                // Присваиваем значения переменным из выбранной строки
                modelst.AssignValues_M(
                  dataGridView1.Rows[rowIndex].Cells["model"].Value.ToString(),
                  dataGridView1.Rows[rowIndex].Cells["brand"].Value.ToString()

              );

                // Опционально, выводим сообщение об успешном присвоении значений
                MessageBox.Show("Значения успешно присвоены переменным!");
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите строку для присвоения значений переменным.");
            }
        }

        public void AssignValuesToVariables_C()
        {
            // Проверяем, выбрана ли строка в DataGridView
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Получаем индекс выбранной строки
                int rowIndex = dataGridView1.SelectedRows[0].Index;

                // Присваиваем значения переменным из выбранной строки
                country.AssignValues_C(
                  dataGridView1.Rows[rowIndex].Cells["mark"].Value.ToString(),
                  dataGridView1.Rows[rowIndex].Cells["country"].Value.ToString()

              );

                // Опционально, выводим сообщение об успешном присвоении значений
                MessageBox.Show("Значения успешно присвоены переменным!");
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите строку для присвоения значений переменным.");
            }
        }




    }
}




