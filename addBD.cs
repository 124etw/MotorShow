using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
namespace motorshow2
{
    internal class addBD
    {
        Peremen peremen = new Peremen();
        public void SelectDataFromCarTable()
        {
            string query = "SELECT * FROM car";

            using (NpgsqlConnection connection = new NpgsqlConnection(peremen.dotNet))
            {
                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    connection.Open();

                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        // Перебор результатов запроса
                        while (reader.Read())
                        {
                            // Пример чтения значений из каждого столбца (поменяйте типы данных и названия столбцов по необходимости)
                            int id = Convert.ToInt32(reader["id"]);
                            string vin = reader["vin"].ToString();
                            string engineNumber = reader["engine_number"].ToString();
                            string equipment = reader["equipment"].ToString();
                            int yearRelease = Convert.ToInt32(reader["year_release"]);
                            int mileage = Convert.ToInt32(reader["mileage"]);
                            string chassisNumber = reader["chassis_number"].ToString();
                            string bodyNumber = reader["body_number"].ToString();
                            string bodyColor = reader["body_color"].ToString();

                            // Далее используйте прочитанные значения по вашему усмотрению
                            Console.WriteLine($"ID: {id}, Vin: {vin}, EngineNumber: {engineNumber}, Equipment: {equipment}, YearRelease: {yearRelease}, Mileage: {mileage}, ChassisNumber: {chassisNumber}, BodyNumber: {bodyNumber}, BodyColor: {bodyColor}");
                        }
                    }
                }
            }
        }



    }
}
  

