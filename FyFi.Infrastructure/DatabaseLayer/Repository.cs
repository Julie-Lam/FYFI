using System.Data.SqlClient;
using System.Data;
using FyFi.Domain.Classes;
using FyFi.Domain.Interfaces;

namespace FyFi.Infrastructure.DatabaseLayer
{

    public class Repository : IRepository
    {

        private readonly string _connectionString = "data source=DESKTOP-O06HF0H;initial catalog=FyfiDatabase;trusted_connection=true";

        public MonthlyCapture GetMonthlyCaptureById(int monthlyCaptureId)
        {

            MonthlyCapture? monthlyCapture = null;


            monthlyCapture = new MonthlyCapture() { MonthlyCaptureId = 1, MonthlyCaptureDate = DateTime.Now};
            /*
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
                        MonthlyCaptureDate = (DateTime)reader["MonthlyCaptureDate"],


                        CaptureItems = GetMonthlyCaptureItemsByCaptureId(monthlyCaptureId)
                    };
                }

            }
            */

            return monthlyCapture;
        }

        private List<MonthlyCaptureItem> GetMonthlyCaptureItemsByCaptureId(int monthlyCaptureId)
        {

            var monthlyCaptureItems = new List<MonthlyCaptureItem>();

            var query = "SELECT * FROM MonthlyCaptureItem WHERE MonthlyCaptureId = @monthlyCaptureId";
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.Add("@monthlyCaptureId", SqlDbType.Int).Value = monthlyCaptureId;
                command.Connection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    monthlyCaptureItems.Add(
                        new MonthlyCaptureItem()
                        {
                            MonthlyCaptureItemId = (int)reader["MonthlyCaptureItemId"],
                            MonthlyCaptureId = (int)reader["MonthlyCaptureId"],
                            ItemName = (string)reader["ItemName"],
                            ItemAmount = (decimal)reader["ItemAmount"]
                        }
                    );

                }
            }

            return monthlyCaptureItems;
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


        public int SaveMonthlyCapture(ref MonthlyCapture monthlyCapture)
        {
            var affectedRows = 0;

            var query = "INSERT INTO MonthlyCapture (MonthlyCaptureDate) " +
                        "OUTPUT Inserted.MonthlyCaptureId " +
                        $"VALUES (@captureDate)";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.Add("@captureDate", SqlDbType.DateTime).Value = monthlyCapture.MonthlyCaptureDate;

                command.Connection.Open();

                var pkId = (int)command.ExecuteScalar();
                if (pkId > 0)
                    affectedRows += 1;

                monthlyCapture.MonthlyCaptureId = pkId;
            }

            foreach (var item in monthlyCapture.CaptureItems)
            {
                affectedRows += SaveMonthlyCaptureItem(item, monthlyCapture.MonthlyCaptureId);
            }

            return affectedRows;

        }

        public int UpdateMonthlyCapture(MonthlyCapture monthlyCapture)
        {
            if (monthlyCapture.MonthlyCaptureId == 0)
                throw new Exception("Cannot update invalid monthly capture");


            var affectedRows = 0;
            foreach (var item in monthlyCapture.CaptureItems)
            {
                //Insert the cpature item if it's new, otherwise update 
                affectedRows = item.MonthlyCaptureItemId == 0 ? SaveMonthlyCaptureItem(item, monthlyCapture.MonthlyCaptureId) : UpdateMonthlyCaptureItem(item);
            }

            return affectedRows;
        }


        public int SaveMonthlyCaptureItem(MonthlyCaptureItem captureItem, int monthlyCaptureId)
        {
            var affectedRows = 0;

            var query = "INSERT INTO MonthlyCaptureItem (MonthlyCaptureId, ItemName, ItemAmount) " +
                        "OUTPUT Inserted.MonthlyCaptureItemId " +
                        "VALUES (@monthlyCaptureId, @itemName, @itemAmount)";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.Add("@monthlyCaptureId", SqlDbType.Int).Value = monthlyCaptureId;
                command.Parameters.Add("@itemName", SqlDbType.VarChar).Value = captureItem.ItemName;
                command.Parameters.Add("@itemAmount", SqlDbType.Decimal).Value = captureItem.ItemAmount;

                command.Connection.Open();

                var pkId = (int)command.ExecuteScalar();
                if (pkId > 0)
                    affectedRows += 1;

                captureItem.MonthlyCaptureItemId = pkId;

            }

            return affectedRows;
        }

        public int UpdateMonthlyCaptureItem(MonthlyCaptureItem captureItem)
        {
            if (captureItem.MonthlyCaptureItemId == 0)
                throw new Exception("Cannot update invalid captureItem");


            var affectedRows = 0;

            var query = "UPDATE MonthlyCaptureItem " +
                "SET ItemName = @itemName, " +
                    "ItemAmount = @itemAmount " +
                "WHERE MonthlyCaptureItemId = @monthlyCaptureItemId";


            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.Add("@itemName", SqlDbType.VarChar).Value = captureItem.ItemName;
                command.Parameters.Add("@itemAmount", SqlDbType.Decimal).Value = captureItem.ItemAmount;
                command.Parameters.Add("@monthlyCaptureItemId", SqlDbType.Int).Value = captureItem.MonthlyCaptureItemId;


                command.Connection.Open();

                affectedRows = command.ExecuteNonQuery();

            }

            return affectedRows;
        }

        public int DeleteMonthlyCaptureItemById(int monthlyCaptureItemId)
        {
            if (monthlyCaptureItemId == 0)
                throw new Exception("Cannot delete invalid captureItem");


            var affectedRows = 0;

            var query = "DELETE MonthlyCaptureItem " +
                        "WHERE MonthlyCaptureItemId = @monthlyCaptureItemId";


            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.Add("@monthlyCaptureItemId", SqlDbType.Int).Value = monthlyCaptureItemId;
                command.Connection.Open();

                affectedRows = command.ExecuteNonQuery();

            }

            return affectedRows;
        }
    }
}
