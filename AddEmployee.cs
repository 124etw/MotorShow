using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace motorshow2
{
    public partial class AddEmployee : Form
    {
        Peremen peremen = new Peremen();
        private NpgsqlDataAdapter dataAdapter;
        private DataTable dataTable;
        EditForms editForms = new EditForms();

        EmployeeAdd employeeAdd = new EmployeeAdd();
        SystemControlAdd employeeControlAdd = new SystemControlAdd();
        PositionAdd positionAdd = new PositionAdd();

        bool vols = true;
        public AddEmployee()
        {
            InitializeComponent();
            selectBox(comboBox1);
            editForms.ApplyCommonFormProperties(this);
        }



        List<string> key_combox = new List<string>()
        {
            {"employee"},
            {"system_control"},
            {"position"},

        };
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void viewTable(string key)
        {
            // Не используйте using для dataAdapter и dataTable здесь

            NpgsqlConnection connection = new NpgsqlConnection(peremen.dotNet);
            connection.Open();
            string SQL = $"SELECT * FROM {key};";

            NpgsqlCommand command = new NpgsqlCommand(SQL, connection);
            dataAdapter = new NpgsqlDataAdapter(command);
            dataTable = new DataTable();

            // Автоматически создаем команды для вставки, обновления и удаления


            dataAdapter.Fill(dataTable);
            dataGridView1.ReadOnly = false;

            // Привязываем DataTable к DataGridView
            dataGridView1.DataSource = dataTable;

            // Убираем столбец id_employee из отображения
            string columnNameToRemove = "id_employee";
            int columnIndexToRemove = dataTable.Columns.IndexOf(columnNameToRemove);
            if (columnIndexToRemove != -1)
            {
                dataTable.Columns.RemoveAt(columnIndexToRemove);
            }
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                switch (column.Name)
                {
                    case " first_name":
                        column.HeaderText = "Имя";
                        break;
                    case "last_name":
                        column.HeaderText = "Фамилия";
                        break;
                    case "patronymic":
                        column.HeaderText = "Отчество";
                        break;
                    case "salary":
                        column.HeaderText = "Зарплата";
                        break;
                    case "email":
                        column.HeaderText = "Почта";
                        break;
                    case "id_position":
                        column.HeaderText = "Номер должности";
                        break;
                    case "address_residence":
                        column.HeaderText = "Адрес регистрации";
                        break;
                    case "idificator":
                        column.HeaderText = "Индификатор доступа";
                        break;

                    case "series_and_number":
                        column.HeaderText = "Серия и Номер ";
                        break;
                    case "position":
                        column.HeaderText = "Должность";
                        break;
                    case "identifier_user":
                        column.HeaderText = "Номер индификкатора ";
                        break;
                    case "login":
                        column.HeaderText = "Логин";
                        break;
                    case "password":
                        column.HeaderText = "Пароль";
                        break;
                }
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:

                    employeeAdd.Show();
                    break;
                case 1:

                    employeeControlAdd.Show();
                    break;
                case 2:

                    positionAdd.Show();
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
                    Isql = "last_name";
                    delet(sql, Isql);
                    break;
                case 1:
                    sql = comboBox1.Text;
                    Isql = "identifier_user";
                    delet(sql, Isql);
                    break;
                case 2:
                    sql = comboBox1.Text;
                    Isql = "position";
                    delet(sql, Isql);
                    break;

            }
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

        private void button3_Click(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    AssignValuesToVariables_E();
                    employeeAdd.ent(vols);
                    employeeAdd.Show();
                    break;
                case 1:
                    AssignValuesToVariables_C();
                    employeeControlAdd.ent(vols);
                    employeeControlAdd.Show();
                    break;
                case 2:
                    AssignValuesToVariables_S();
                    positionAdd.ent(vols);
                    positionAdd.Show();
                    break;

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
                employeeAdd.AssignValues_E(
                 dataGridView1.Rows[rowIndex].Cells["first_name"].Value.ToString(),
                 dataGridView1.Rows[rowIndex].Cells["last_name"].Value.ToString(),
                 dataGridView1.Rows[rowIndex].Cells["patronymic"].Value.ToString(),
                 dataGridView1.Rows[rowIndex].Cells["date_of_birth"].Value.ToString(),
                 dataGridView1.Rows[rowIndex].Cells["salary"].Value.ToString(),
                 dataGridView1.Rows[rowIndex].Cells["email"].Value.ToString(),
                 dataGridView1.Rows[rowIndex].Cells["address_residence"].Value.ToString(),
                 dataGridView1.Rows[rowIndex].Cells["idificator"].Value.ToString(),
                 dataGridView1.Rows[rowIndex].Cells["series_and_number"].Value.ToString()
             );

                // Опционально, выводим сообщение об успешном присвоении значений
                MessageBox.Show("Значения успешно присвоены переменным!");
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите строку для присвоения значений переменным.");
            }
        }

        public void AssignValuesToVariables_S()
        {
            // Проверяем, выбрана ли строка в DataGridView
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Получаем индекс выбранной строки
                int rowIndex = dataGridView1.SelectedRows[0].Index;

                // Присваиваем значения переменным из выбранной строки
                positionAdd.AssignValues_P(
                  dataGridView1.Rows[rowIndex].Cells["id_position"].Value.ToString(),
                  dataGridView1.Rows[rowIndex].Cells["position"].Value.ToString()

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
                employeeControlAdd.AssignValues_C(
                    dataGridView1.Rows[rowIndex].Cells["identifier_user"].Value.ToString(),
                  dataGridView1.Rows[rowIndex].Cells["login"].Value.ToString(),
                  dataGridView1.Rows[rowIndex].Cells["password"].Value.ToString()

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