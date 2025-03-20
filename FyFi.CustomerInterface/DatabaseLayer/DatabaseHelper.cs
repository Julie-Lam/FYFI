using FyFi.CustomerInterface.Classes;
using System.Data.SqlClient;
using System.Data;

namespace FyFi.CustomerInterface.DatabaseLayer
{

    public class DatabaseHelper
    {

        private readonly string _connectionString = "data source=DESKTOP-O06HF0H;initial catalog=FyfiDatabase;trusted_connection=true";

        public MonthlyCaptureCls GetMonthlyCaptureById(int monthlyCaptureId) 
        {

            MonthlyCaptureCls? monthlyCapture = null;

            var query = "SELECT * FROM MonthlyCapture WHERE MonthlyCaptureId = @monthlyCaptureId";
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, conn);

                command.Connection.Open();
                command.Parameters.Add("@monthlyCaptureId", SqlDbType.Int).Value = monthlyCaptureId;
                var reader = command.ExecuteReader();

                while (reader.Read()) 
                {
                    monthlyCapture = new MonthlyCaptureCls()
                    {
                        MonthlyCaptureId = (int)reader["MonthlyCaptureId"],
                        MonthlyCaptureDate = (DateTime)reader["MonthlyCaptureDate"]
                    };
                }


            }

            return monthlyCapture; 
        }

        public MonthlyCaptureItem GetMonthlyCaptureItemById(int monthlyCaptureItemId)
        {
            MonthlyCaptureItem? monthlyCaptureItem = null; 

            var query = "SELECT * FROM MonthlyCaptureItem WHERE MonthlyCaptureItemId = @monthlyCaptureItemId";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.Add("@monthlyCaptureItemId", SqlDbType.Int).Value = monthlyCaptureItemId;
                command.Connection.Open(); 
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    monthlyCaptureItem = new MonthlyCaptureItem()
                    {
                        MonthlyCaptureItemId = (int)reader["MonthlyCaptureItemId"], 
                        MonthlyCaptureId = (int)reader["MonthlyCaptureId"], 
                        ItemName = (string)reader["ItemName"], 
                        ItemAmount = (decimal)reader["ItemAmount"]
                    }; 
                }
            }

            return monthlyCaptureItem; 

        }

        public int SaveMonthlyCapture(MonthlyCaptureCls monthlyCapture) 
        {
            var affectedRows = 0; 

            var query = "INSERT INTO MonthlyCapture (MonthlyCaptureDate) " +
                        $"VALUES (@captureDate)";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.Add("@captureDate", SqlDbType.DateTime).Value = monthlyCapture.MonthlyCaptureDate;

                command.Connection.Open();

                affectedRows = command.ExecuteNonQuery();

            }

            return affectedRows; 

        }

    }
}
