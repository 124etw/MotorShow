using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace motorshow2
{
    public partial class Statistic : Form
    {
        DataEmployee employee = new DataEmployee();
        string Last_Name_E;
        string First_Name_E;
        string Patronymic_E;
        string id_employee;
        string Last_Name_C;
        string First_Name_C;
        string Patronymic_C;
        string id_client;

        string vin;

        private Dictionary<string, string> paymentMethodsDictionary;
        private Dictionary<string, string> statusDictionary;
        public Statistic()
        {
            InitializeComponent();
            InitializePaymentMethodsDictionary();
            InitializeStatusDictionary();
            viewTable();
            editForm.ApplyCommonFormProperties(this);

        }
       EditForms editForm=new EditForms();  
        Peremen peremen = new Peremen();
        private NpgsqlDataAdapter dataAdapter;
        private DataTable dataTable;


        private void button1_Click(object sender, EventArgs e)
        {
            AdminMaincs adminMaincs = new AdminMaincs();
            adminMaincs.Show();
        }

        private void viewTable()
        {
            NpgsqlConnection connection = new NpgsqlConnection(peremen.dotNet);
            connection.Open();
            string SQL = $"SELECT * FROM  contract;";
            NpgsqlCommand command = new NpgsqlCommand(SQL, connection);
            dataAdapter = new NpgsqlDataAdapter(command);
            dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            dataGridView1.ReadOnly = false;
            dataGridView1.DataSource = dataTable;
            dataGridView1.Columns["id_client"].Visible = false;
            dataGridView1.Columns["id_employee"].Visible = false;
            dataGridView1.Columns["id_contract"].Visible = false;
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                switch (column.Name)
                {
                    case "date":
                        column.HeaderText = "Дата заключения";
                        break;
                    case "employee":
                        column.HeaderText = "Сотрудник ФИО";
                        break;
                    case "client":
                        column.HeaderText = "Клиент ФИО";
                        break;
                    case "vin":
                        column.HeaderText = "ВИН";
                        break;
                    case "payment_method":
                        column.HeaderText = "Способ оплаты";
                        break;
                    case "status":
                        column.HeaderText = "Статус";
                        break;
                   
                }
            }
        }

    


        public void load_peremen_Employee(DataEmployee data)
        {
            Last_Name_E = data.last_name;
            First_Name_E = data.first_name;
            Patronymic_E = data.patronymic;
            id_employee = data.Id_employee;

        }

        public void load_peremen_Clients(DataClients data)
        {
            Last_Name_C = data.last_name;
            First_Name_C = data.first_name;
            Patronymic_C = data.patronymic;
            id_client=data.id_client;
        }

        public void load_peremen_vin(ST st)
        {
            vin = st.vin;
        }
        public void InsertDataIntoTable()
        {
            DateTime myDate = DateTime.Now;

            // Подключение к базе данных
            using (NpgsqlConnection connection = new NpgsqlConnection(peremen.dotNet))
            {
                connection.Open();

                // SQL-запрос для вставки данных
                string insertContractSQL = "INSERT INTO contract (date, employee, client, vin, payment_method, status, id_client, id_employee) " +
                                           "VALUES (@date, @employee,@client, @vin, @payment_method, @status, @id_client, @id_employee)";

                using (NpgsqlCommand command = new NpgsqlCommand(insertContractSQL, connection))
                {
                    int IDE;
                    Int32.TryParse(id_employee, out IDE);
                    int IDC;
                    Int32.TryParse(id_client, out IDC);
                    command.Parameters.AddWithValue("@date", NpgsqlDbType.Date, myDate);
                    command.Parameters.AddWithValue("@employee", $"{Last_Name_E} {First_Name_E} {Patronymic_E}");
                    command.Parameters.AddWithValue("@client", $"{Last_Name_C} {First_Name_C} {Patronymic_C}");
                    command.Parameters.AddWithValue("@id_client", IDC);
                    command.Parameters.AddWithValue("@vin", vin);
                    command.Parameters.AddWithValue("@id_employee", IDE);
                    command.Parameters.AddWithValue("@payment_method", DBNull.Value); // Оставляем пустым
                    command.Parameters.AddWithValue("@status", DBNull.Value); // Оставляем пустым


                    command.ExecuteNonQuery();
                }



            }
        }
        

        private void InitializePaymentMethodsDictionary()
        {
            // Создаем словарь с соответствием русских и английских значений для payment_method
            paymentMethodsDictionary = new Dictionary<string, string>
        {

            { "Наличными", "Cash" },
            { "Картой", "Card" }
            // Добавьте другие значения при необходимости
        };

            // Устанавливаем источник данных для ComboBox
            comboBox1.DataSource = new BindingSource(paymentMethodsDictionary, null);
            comboBox1.DisplayMember = "Key";
            comboBox1.ValueMember = "Value";
        }

        private void InitializeStatusDictionary()
        {

            statusDictionary = new Dictionary<string, string>
        {
            { "Оплачено", "Paid" },

        };


            comboBox2.DataSource = new BindingSource(statusDictionary, null);
            comboBox2.DisplayMember = "Key";
            comboBox2.ValueMember = "Value";
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int rowIndex = dataGridView1.SelectedRows[0].Index;
                int idContract = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells["id_contract"].Value);

                // Получаем выбранное значение из ComboBox для payment_method
                string selectedPaymentMethod = comboBox1.SelectedValue?.ToString();

                // Получаем выбранное значение из ComboBox для status
                string selectedStatus = comboBox2.SelectedValue?.ToString();

                // Проверяем, что значения ComboBox были выбраны
                if (selectedPaymentMethod != null && selectedStatus != null)
                {
                    // Подключение к базе данных
                    using (NpgsqlConnection connection = new NpgsqlConnection(peremen.dotNet))
                    {
                        connection.Open();

                        // SQL-запрос для обновления данных
                        string SQL = "UPDATE contract SET payment_method = @payment_method, status = @status WHERE id_contract = @id_contract";

                        using (NpgsqlCommand command = new NpgsqlCommand(SQL, connection))
                        {


                            command.Parameters.AddWithValue("@payment_method", selectedPaymentMethod);

                            command.Parameters.AddWithValue("@status", selectedStatus);
                            command.Parameters.AddWithValue("@id_contract", idContract);

                            MessageBox.Show($"{selectedPaymentMethod}  {selectedStatus}");

                            // Выполнение запроса
                            command.ExecuteNonQuery();
                        }
                    }

                    // После обновления данных, обновим DataGridView
                    viewTable();
                }
                else
                {
                    MessageBox.Show("Выберите значения для обновления.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Выберите строку для обновления.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }


}
