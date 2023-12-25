using Npgsql;
using System.Data;
using Microsoft;
using Xceed.Words.NET;
using System.Diagnostics;
using Spire.Pdf.General.Render.Font;

namespace motorshow2
{
    public partial class Contract : Form
    {
        DataClients dt = new DataClients();
        Peremen peremen = new Peremen();
        ST sT = new ST();
        EditForms edit=new EditForms();
        public Contract()
        {

            InitializeComponent();
            peremen.FillComboBoxWithVins(comboBox2, "SELECT model FROM models");
            edit.ApplyCommonFormProperties(this);
          

        }









        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox3.Text = string.Empty;
            comboBox4.Text = string.Empty;

            comboBox3.Items.Clear();
            comboBox4.Items.Clear();

            string poisk = "equipment";
            ComboBox comboBox = new ComboBox();
            comboBox = comboBox3;
            
       

            string selectedBrand = comboBox2.SelectedItem?.ToString();

            string model = selectedBrand;
            string SQL = $"SELECT  equipment FROM equipments WHERE model = '{model}';"; 

            peremen.SearchBox(comboBox, SQL, model, poisk);
            
            }




        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox4.Text = string.Empty;
            comboBox4.Items.Clear();
            string data = "equipments";
            string poisk = "vin";
            Peremen peremen = new Peremen();
            peremen.UpdateComboBox(comboBox3, dataGridView1, data);
            ComboBox comboBox = new ComboBox();
            comboBox = comboBox4;
            string vin = comboBox3.SelectedItem?.ToString();
            string SQL = $"SELECT  vin FROM car WHERE equipment = '{vin}';";
            peremen.SearchBox(comboBox, SQL, vin, poisk);
  
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        public class ComboBoxItem
        {
            public string Text { get; set; }
            public object Value { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Clients clients = new Clients();
            clients.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
        
            string data = "Car";
            Peremen peremen = new Peremen();
            peremen.UpdateComboBox(comboBox3, dataGridView1, data);
        }


        private void ClearComboBoxText(ComboBox comboBox)
        {
            comboBox.Text = string.Empty;
          comboBox.Items.Clear();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string searchText = textBox1.Text;
            Peremen peremen = new Peremen();
            string[] names = searchText.Split(' ');

         
            if (names.Length >= 3)
            {
                string firstName = names[0];
                string lastName = names[1];
                string patronymic = names[2];
                // Выполните запрос с параметрами для фильтрации данных
                string query = "SELECT * FROM client WHERE first_name ILIKE @firstName AND last_name ILIKE @lastName AND patronymic ILIKE @patronymic ";

                // Используйте NpgsqlDataAdapter для выполнения запроса
                using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(query, peremen.dotNet))
                {
                    // Создайте параметры для передачи значений поиска
                    adapter.SelectCommand.Parameters.AddWithValue("@firstName", "%" + firstName + "%");
                    adapter.SelectCommand.Parameters.AddWithValue("@lastName", "%" + lastName + "%");
                    adapter.SelectCommand.Parameters.AddWithValue("@patronymic", "%" + patronymic + "%");

                    // Создайте DataTable для хранения результатов
                    DataTable dt = new DataTable();

                    // Заполните DataTable данными из базы данных
                    adapter.Fill(dt);

                    // Отобразите результаты в DataGridView
                    dataGridView1.DataSource = dt;
                }
            }
            else
            {
                // Если введено только одно слово (например, только имя или только фамилия),
                // выполните соответствующий запрос для поиска по одному полю
                string query = "SELECT * FROM client WHERE first_name ILIKE @searchText OR last_name ILIKE @searchText OR  patronymic ILIKE @searchText ";

                // Используйте NpgsqlDataAdapter для выполнения запроса
                using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(query, peremen.dotNet))
                {
                    // Создайте параметр для передачи значения поиска
                    adapter.SelectCommand.Parameters.AddWithValue("@searchText", "%" + searchText + "%");

                    // Создайте DataTable для хранения результатов
                    DataTable dt = new DataTable();

                    // Заполните DataTable данными из базы данных
                    adapter.Fill(dt);

                    // Отобразите результаты в DataGridView
                    dataGridView1.DataSource = dt;

                }
                dataGridView1.Columns["id_client"].Visible = false;
                foreach (DataGridViewColumn column in dataGridView1.Columns)
                {
                    switch (column.Name)
                    {
                        case "first_name":
                            column.HeaderText = "Имя";
                            break;
                        case "last_name":
                            column.HeaderText = "Фамилия";
                            break;
                        case "patronymic":
                            column.HeaderText = "Отчество";
                            break;
                        case "series_and_number":
                            column.HeaderText = "Серия и Номер паспорта";
                            break;
                        case "address_residence":
                            column.HeaderText = "Адрес прописки";
                            break;
                        case " phon":
                            column.HeaderText = "Телефон";
                            break;
                        case " email":
                            column.HeaderText = "Почта";
                            break;


                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {


            peremen.Print_Save(dt);
        }



        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count == 1)
                {
                    DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                    dt.id_client= selectedRow.Cells["id_client"].Value?.ToString();
                    dt.first_name = selectedRow.Cells["first_name"].Value?.ToString();
                    dt.last_name = selectedRow.Cells["last_name"].Value?.ToString();
                    dt.patronymic = selectedRow.Cells["patronymic"].Value?.ToString();
                    dt.series_and_number = selectedRow.Cells["series_and_number"].Value?.ToString();
                    dt.address_residence = selectedRow.Cells["address_residence"].Value?.ToString();
                    dt.phon = selectedRow.Cells["phon"].Value?.ToString();
                    dt.email = selectedRow.Cells["email"].Value?.ToString();
                }
                else if (dataGridView1.SelectedRows.Count > 1)
                {
                    throw new InvalidOperationException("Выбрано более одной строки. Пожалуйста, выберите только одну строку.");
                }
                else
                {
                    MessageBox.Show("Выберите строку в таблице ", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                if (string.IsNullOrWhiteSpace(dt.first_name) ||
               string.IsNullOrWhiteSpace(dt.last_name) ||
               string.IsNullOrWhiteSpace(dt.patronymic) ||
               string.IsNullOrWhiteSpace(dt.series_and_number) ||
               string.IsNullOrWhiteSpace(dt.address_residence) ||
               string.IsNullOrWhiteSpace(dt.phon) ||
               string.IsNullOrWhiteSpace(dt.email))
                {
                    MessageBox.Show("Заполните все поля в выбранной строке.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Прерывание выполнения метода, так как не все поля заполнены
                }
                addText(textBox2, dt);
            }

            catch
            {
                MessageBox.Show($"Пожалуйста выберите значение из результата поиска клиента  !");
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {



        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void addText(TextBox textBox, DataClients dt)
        {
            textBox2.Text = $"Имя: {dt.last_name}{Environment.NewLine}" +
                 $"Фамилия: {dt.first_name}{Environment.NewLine}" +
                 $"Отчество: {dt.patronymic}{Environment.NewLine}" +
                 $"Серия и номер паспорта: {dt.series_and_number}{Environment.NewLine}" +
                 $"Адрес прописки: {dt.address_residence}{Environment.NewLine}" +
                 $"Контактный телефон: {dt.phon}{Environment.NewLine}" +
                 $"Почта: {dt.email}";

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Main main = new Main();
            main.Show();
        }
    }


}
