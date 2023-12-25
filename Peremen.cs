using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using Xceed.Words.NET;
using static motorshow2.Contract;

namespace motorshow2
{
    public class Peremen
    {

        public string dotNet = "Server=localhost;Port=5432;DataBase=motorshow;User ID=postgres;Password=1234";
        public static ST st = new ST();
        public static DataClients dt = new DataClients();
        private static DataEmployee de= new DataEmployee();
   private static  Statistic statistic = new Statistic();
       
        public void SearchMark()
        {
            // Присваиваем значение выбранного элемента ComboBox переменной mark


            // Выполняем поиск комплектации по выбранной модели
            string query = $"SELECT brand FROM models  WHERE model = '{st.model}'";

            using (NpgsqlConnection connection = new NpgsqlConnection(dotNet))
            {
                connection.Open();

                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    try
                    {
                        // Выполняем запрос и присваиваем результат переменной configuration
                        st.mark = command.ExecuteScalar()?.ToString();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при выполнении запроса: {ex.Message}");
                    }
                }
            }
        }
        public void Proverka(string value, string value1)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(dotNet))
            {
                connection.Open();

                string query = @"
            SELECT e.*, sc.identifier_user
            FROM employee e
            JOIN system_control sc ON e.idificator = sc.identifier_user
            WHERE sc.login = @value AND sc.password = @value1;
        ";

                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@value", value);
                    command.Parameters.AddWithValue("@value1", value1);

                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            
                                de.Id_employee = reader["id_employee"].ToString();
                                de.first_name = reader["first_name"].ToString();
                                de.last_name = reader["last_name"].ToString();
                                de.patronymic = reader["patronymic"].ToString();
                                de.address_residence = reader["address_residence"].ToString();
                                de.idificator = reader["idificator"].ToString();
                                de.series_and_number = reader["series_and_number"].ToString();


                            }
                        
                      
                        else
                        {
                            MessageBox.Show($"Логин или пароль не верный");
                        }
                    }

                    switch (de.idificator)
                    {
                        case "1":
                           AdminMaincs admin = new AdminMaincs(de.last_name, de.first_name, de.patronymic);
                            admin.ShowDialog();
                           
                            break;
                        case "2":
                            Main main = new Main(de.last_name, de.first_name, de.patronymic);
                            
                            
                            main.ShowDialog();
                            break;

                    }
                 
                }
               

         
            
            }
        
        }

      
        public void UpdateComboBox(ComboBox comboBox, DataGridView dataGridView1, string data)
        {


            dataGridView1.DataSource = null;

            // Получаем выбранное значение из comboBox3 (Equipment)
            string selectedEquipment = comboBox.SelectedItem?.ToString();

            string selectDataQuery = $"SELECT * FROM  {data} WHERE equipment = '{selectedEquipment}';";
            Peremen peremen = new Peremen();
            // Проверяем, что значение не пусто
            if (!string.IsNullOrEmpty(selectedEquipment))
            {
                try
                {
                    // Подключаемся к базе данных
                    using (NpgsqlConnection connection = new NpgsqlConnection(peremen.dotNet))
                    {
                        connection.Open();

                        // Выполняем запрос и добавляем результаты в dataGridVew1
                        using (NpgsqlCommand command = new NpgsqlCommand(selectDataQuery, connection))
                        {
                            using (NpgsqlDataReader reader = command.ExecuteReader())
                            {
                                // Проверяем, есть ли данные
                                if (reader.Read() & (data == "equipments"))
                                {

                                    // Создаем объект ST и заполняем его данными из базы данных


                                    st.model = reader["model"].ToString();
                                    st.engine_type = reader["engine_type"].ToString();
                                    st.price = reader["price"].ToString();
                                    st.body_type = reader["body_type"].ToString();
                                      

                                }
                                else if ((data == "Car"))
                                {


                                    st.vin = reader["vin"].ToString();
                                    st.engine_number = reader["engine_number"].ToString();
                                    st.chassis_number = reader["chassis_number"].ToString();
                                    st.body_number = reader["body_number"].ToString();
                                    st.body_color = reader["body_color"].ToString();
                                    st.year_release = reader["year_release"].ToString();
                                    st.mileage = reader["mileage"].ToString();

                                }
                            }
                            using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command))
                            {
                                DataTable dataTable = new DataTable();
                                adapter.Fill(dataTable);
                                dataGridView1.DataSource = dataTable;

                            }
                            if (data == "equipments")
                            {
                                foreach (DataGridViewColumn column in dataGridView1.Columns)
                                {
                                    switch (column.Name)
                                    {
                                        case "equipment":
                                            column.HeaderText = "Комплектация";
                                            break;
                                        case "engine_capacity":
                                            column.HeaderText = "Объём двигателя";
                                            break;
                                        case "body_type":
                                            column.HeaderText = "Тип кузова";
                                            break;
                                        case "engine_type":
                                            column.HeaderText = "Тип двигаетля";
                                            break;
                                        case "box_type":
                                            column.HeaderText = "Тип коробки";
                                            break;
                                        case "price":
                                            column.HeaderText = "Цена";
                                            break;
                                        case "model":
                                            column.HeaderText = "Модель";
                                            break;


                                    }
                                }
                            }
                            else if (data == "Car")
                            {
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
                                            column.HeaderText = "пробег";
                                            break;
                                        case "chassis_number":
                                            column.HeaderText = "Номер шасси";
                                            break;
                                        case "body_number":
                                            column.HeaderText = "Номер кузова";
                                            break;
                                        case "body_color":
                                            column.HeaderText = "Цвет";
                                            break;


                                    }
                                }

                            }    
                          
                        }

                    }
                    SearchMark();
                }

                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка: {ex.Message}");
                }
            }
        }
        public void FillComboBoxWithVins(ComboBox comboBox, string query)
        {
            Peremen peremen = new Peremen();
            using (NpgsqlConnection connection = new NpgsqlConnection(peremen.dotNet))
            {
                connection.Open();

                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    try
                    {
                        using (NpgsqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                comboBox.Items.Add(reader[0].ToString());


                          
                            }
                           


                        }
                        
                       
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при выполнении запроса: {ex.Message}");
                    }



                }
            }
        }
        public void FillComboBoxWithVins_FIO(ComboBox comboBox, string query)
        {

            Peremen peremen = new Peremen();
            using (NpgsqlConnection connection = new NpgsqlConnection(peremen.dotNet))
            {
                connection.Open();

                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    try
                    {
                        using (NpgsqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Получаем значения VIN и ФИО

                                string fio = $"{reader["last_name"]} {reader["first_name"]} {reader["patronymic"]}";

                                // Добавляем в ComboBox
                                comboBox.Items.Add(new ComboBoxItem { Text = fio, Value = fio });
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка: {ex.Message}");
                    }
                }
            }
        }
        public void SearchBox(ComboBox comboBox, string selectModelsQuery, string vin, string poisk)
        {
    
            // Проверяем, что значение не пусто
            if (!string.IsNullOrEmpty(vin))
            {
                try
                {
                    using (NpgsqlConnection connection = new NpgsqlConnection(dotNet))
                    {
                        connection.Open();


                        using (NpgsqlCommand command = new NpgsqlCommand(selectModelsQuery, connection))
                        {
                            using (NpgsqlDataReader reader = command.ExecuteReader())
                            {
                                comboBox.Items.Clear();
                                while (reader.Read())
                                {

                                    comboBox.Items.Add(reader[poisk].ToString());
                                }
                            }

                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка: {ex.Message}");
                }
            }

        }


        public void Print_Save(DataClients dt)
        {
            DateTime myDate = DateTime.Now;
            string dateString = myDate.ToString("yyyy-MM-dd");
            // Путь к заготовленному документу
            string templatePath = "C:\\Users\\Рекс\\Desktop\\ИБ-121\\Курсач\\motorshow2\\dkp.docx";

            // Создаем документ DocX из шаблона
            var doc = DocX.Load(templatePath);

            // Заполняем словарь значениями переменных
            var variableValues_Car_Client = new Dictionary<string, string>
    {
               // Даные о машине
        { "vin", st.vin },
        { "model", st.model },
        { "body_type", st.body_type },
        { "chassis_number", st.chassis_number },
        { "mark", st.mark },
        { "engine_number", st.engine_number },
        { "body_color", st.body_color },
         { "body_number", st.body_number },
         { "engine_type", st.engine_type },
         { "price", st.price },
         { "mileage", st.mileage },
         { "year_release",  st.year_release },
        

        //Данные о клиенте 
        {  "first_name", dt.first_name},
        { "last_name", dt.last_name },
        { "patronymic", dt.patronymic},
          { "series_and_number", dt.series_and_number},
          { "address_residence", dt.address_residence},

          //Данные о работниках
          {  "Yfirst_name", de.first_name},
        { "Ylast_name", de.last_name },
        { "Ypatronymic", de.patronymic},
          { "Yseries_and_number", de.series_and_number},
          { "Yaddress_residence", de.address_residence},

          // Побочные данные
           { "date", dateString},
    };
           
       

           
            foreach (var entry in variableValues_Car_Client)
            {
                InsertVariable(doc, entry.Key, entry.Value);
            }
            

            // Сохраняем измененный документ
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Word Documents|*.docx";
            saveFileDialog.DefaultExt = "docx";
            saveFileDialog.AddExtension = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                doc.SaveAs(saveFileDialog.FileName);
                MessageBox.Show("Документ сохранен успешно!");

                statistic.load_peremen_Employee(de);
                statistic.load_peremen_Clients(dt);
                statistic.load_peremen_vin(st);
                statistic.InsertDataIntoTable();
            }
        }

        private void InsertVariable(DocX doc, string variableName, string variableValue)
        {
            foreach (var paragraph in doc.Paragraphs)
            {
                // Заменяем переменные в каждом параграфе
                paragraph.ReplaceText($"{{{{{variableName}}}}}", variableValue);
            }
        }

    }
}