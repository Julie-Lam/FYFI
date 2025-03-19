using FyFi.CustomerInterface.Classes;
using System.Data.SqlClient;

namespace FyFi.CustomerInterface.DatabaseLayer
{

    public class DatabaseHelper
    {

        private readonly string _connectionString = "data source=DESKTOP-O06HF0H;initial catalog=FyfiDatabase;trusted_connection=true";

        public MonthlyCapture GetMonthlyCaptureById(int monthlyCaptureId) 
        {

            MonthlyCapture? monthlyCapture = null; 

            var query = "SELECT * FROM MonthlyCapture WHERE MonthlyCaptureId = " + monthlyCaptureId;
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, conn);
                command.Connection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read()) 
                {
                    monthlyCapture = new MonthlyCapture()
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

            var query = "SELECT * FROM MonthlyCaptureItem WHERE MonthlyCaptureItemId = " + monthlyCaptureItemId;

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, conn);
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


    }
}
