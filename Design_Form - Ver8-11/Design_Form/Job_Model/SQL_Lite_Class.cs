using DevExpress.Xpo.DB.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Linq.Mapping;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Design_Form.Job_Model
{
    public class SQL_Lite_Class
    {
        private readonly string databasePath;
        public SQL_Lite_Class(string databasePath)
        {
            this.databasePath = databasePath;
            InitializeDatabase();
        }
        private SQLiteConnection GetConnection()
        {
            //try
           // {
                return new SQLiteConnection($"Data Source={databasePath};Version=3;");
           // }
           // catch (Exception ex)
           // {

           // }
           
        }
        public void InitializeDatabase()
        {
            //try
            //{
                using (var connection = GetConnection())
                {
                    connection.Open();
                    string createProducts = @"
                CREATE TABLE IF NOT EXISTS Products (
                    ProductId INTEGER PRIMARY KEY AUTOINCREMENT,
                    Barcode TEXT,
                    CameraID INTEGER,
                    Result TEXT,
                    Date TEXT,
                    Job1 TEXT,
                    Job2 TEXT,
                    Job3 TEXT,
                    Job4 TEXT,
                    Job5 TEXT,
                    Job6 TEXT,
                    Job7 TEXT,
                    Job8 TEXT,
                    Job9 TEXT,
                    Job10 TEXT,
                    Job11 TEXT,
                    Job12 TEXT,
                    Job13 TEXT,
                    Job14 TEXT,
                    Job15 TEXT,
                    Job16 TEXT,
                    Job17 TEXT,
                    Job18 TEXT,
                    Job19 TEXT,
                    Job20 TEXT
                );";
                    using (var command = new SQLiteCommand(createProducts, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
            //}
            //catch (Exception ex)
            //{

            //}
            
              
           // }
        }
        //public void InsertProduct(Manager_Result product,int ID_Cam)
        //{
        //    try
        //    {
        //        SQLiteConnection connection = GetConnection();

        //        connection.Open();
        //        string query = "INSERT INTO Products (Barcode,CameraID,Result,Date,Job1,Job2,Job3,Job4,Job5,Job6,Job7,Job8,Job9,Job10,Job11,Job12,Job13,Job14,Job15,Job16,Job17,Job18,Job19,Job20) VALUES (@Barcode,@CameraID,@Result,@Date,@Job1,@Job2,@Job3,@Job4,@Job5,@Job6,@Job7,@Job8,@Job9,@Job10,@Job11,@Job12,@Job13,@Job14,@Job15,@Job16,@Job17,@Job18,@Job19,@Job20); SELECT last_insert_rowid();";
        //        var command = new SQLiteCommand(query, connection);

        //        command.Parameters.AddWithValue("@Barcode", product.Code);
        //        command.Parameters.AddWithValue("@CameraID", ID_Cam);
        //        command.Parameters.AddWithValue("@Result", product.result_product);
        //        command.Parameters.AddWithValue("@Date", DateTime.Now);

        //        for (int i = 0; i < product.Job_Check.Count; i++)
        //        {
        //            string a = "@Job" + (i+1).ToString();
        //            command.Parameters.AddWithValue(a, product.Job_Check[i].result);
        //        }
        //        command.ExecuteNonQuery();
        //    }
        //    catch (Exception ex) { Job_Model.Statatic_Model.wirtelog.Log(ex.ToString()); }



        //}
        public void InsertProduct(Manager_Result product, int ID_Cam)
        {
            try
            {
                using (SQLiteConnection connection = GetConnection())
                {
                    connection.Open();
                    string query = @"INSERT INTO Products (Barcode,CameraID,Result,Date,Job1,Job2,Job3,Job4,Job5,Job6,Job7,Job8,Job9,Job10,
                          Job11,Job12,Job13,Job14,Job15,Job16,Job17,Job18,Job19,Job20) 
                          VALUES (@Barcode,@CameraID,@Result,@Date,@Job1,@Job2,@Job3,@Job4,@Job5,@Job6,@Job7,@Job8,@Job9,@Job10,
                          @Job11,@Job12,@Job13,@Job14,@Job15,@Job16,@Job17,@Job18,@Job19,@Job20); 
                          SELECT last_insert_rowid();";

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Barcode", product.Code);
                        command.Parameters.AddWithValue("@CameraID", ID_Cam);
                        command.Parameters.AddWithValue("@Result", product.result_product);
                        command.Parameters.AddWithValue("@Date", DateTime.Now);

                        // Thêm các Job parameter (tối đa 20)
                        int jobCount = Math.Min(product.Job_Check.Count, 20);
                        for (int i = 0; i < jobCount; i++)
                        {
                            command.Parameters.AddWithValue($"@Job{i + 1}", product.Job_Check[i].result);
                        }

                        // Thêm các Job còn lại là null nếu không đủ 20
                        for (int i = jobCount; i < 20; i++)
                        {
                            command.Parameters.AddWithValue($"@Job{i + 1}", DBNull.Value);
                        }
                        command.ExecuteNonQuery();
                        // Lấy ID vừa insert


                    }
                }
            }
            catch (Exception ex)
            {
                Job_Model.Statatic_Model.wirtelog.Log(ex.ToString());

            }
        }
        public DataTable GetAllData(string query)
        {
            try
            {
                using (var connection = GetConnection())
                {
                    connection.Open();
                    using (var command = new SQLiteCommand(query, connection))
                    {
                        using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);
                            return dataTable;
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                return null;
            }
            
        }
        public Manager_Result load_Data_Product(string code)
        {

            Manager_Result result = new Manager_Result(20);
            DataTable dataTable = new DataTable();
            using (var connection = GetConnection())
            {
                connection.Open();
                string query = @"
                SELECT Products.ProductId,Products.Barcode, Products.Result, Products.Date,  Products.Job1, Products.Job2, Products.Job3,Products.Job4,Products.Job5,Products.Job6,Products.Job7,Products.Job8,Products.Job9,Products.Job10,Products.Job11,Products.Job12,Products.Job13,Products.Job14,Products.Job15,Products.Job16,Products.Job17,Products.Job18,Products.Job19,Products.Job20
                FROM Products
                WHERE Products.Barcode = @Barcode";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Barcode", code);

                    using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(command))
                    {

                        adapter.Fill(dataTable);
                        DataRow row = dataTable.Rows[0];
                        result.Code = row["Barcode"].ToString();
                        result.result_product = row["Result"].ToString();
                        result.dateTime = row["Date"].ToString();
                        result.Job_Check[0].result = row["Job1"].ToString();
                        result.Job_Check[1].result = row["Job2"].ToString();
                        result.Job_Check[2].result = row["Job3"].ToString();
                        result.Job_Check[3].result = row["Job4"].ToString();
                        result.Job_Check[4].result = row["Job5"].ToString();
                        result.Job_Check[5].result = row["Job6"].ToString();
                        result.Job_Check[6].result = row["Job7"].ToString();
                        result.Job_Check[7].result = row["Job8"].ToString();
                        result.Job_Check[8].result = row["Job9"].ToString();
                        result.Job_Check[9].result = row["Job10"].ToString();
                        result.Job_Check[10].result = row["Job11"].ToString();
                        result.Job_Check[11].result = row["Job12"].ToString();
                        result.Job_Check[12].result = row["Job13"].ToString();
                        result.Job_Check[13].result = row["Job14"].ToString();
                        result.Job_Check[14].result = row["Job15"].ToString();
                        result.Job_Check[15].result = row["Job16"].ToString();
                        result.Job_Check[16].result = row["Job17"].ToString();
                        result.Job_Check[17].result = row["Job18"].ToString();
                        result.Job_Check[18].result = row["Job19"].ToString();
                        result.Job_Check[19].result = row["Job20"].ToString();

                    }
                }
            }

            return result;

        }
        public DataTable GetProductsByDateRange(DateTime startDate, DateTime endDate)
        {
            try
            {
                using (var connection = GetConnection())
                {
                    connection.Open();
                    string query = @"SELECT * FROM Products WHERE Date BETWEEN @StartDate AND @EndDate";
                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@StartDate", startDate);
                        command.Parameters.AddWithValue("@EndDate", endDate);
                        using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);
                            return dataTable;
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                return null;
            }

        }
        public void UpdateProduct(string result,string[] Job, string Barcode)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                // Lưu dữ liệu cũ vào AuditLog
        //        string backupQuery = @"
        //    INSERT INTO AuditLog (ProductId, OldBarcode, UpdatedTime)
        //    SELECT ProductId, Barcode, datetime('now') FROM Products WHERE Barcode = @Barcode;
        //";
        //        using (var backupCmd = new SQLiteCommand(backupQuery, connection))
        //        {
        //            backupCmd.Parameters.AddWithValue("@Barcode", Barcode);
        //            backupCmd.ExecuteNonQuery();
        //        }

                // Cập nhật dữ liệu mới
                string updateQuery = "UPDATE Products SET Result=@Result,Job1= @Job1,Job2= @Job2,Job3= @Job3,Job4= @Job4,Job5= @Job5,Job6= @Job6,Job7= @Job7,Job8= @Job8,Job9= @Job9,Job10= @Job10,Job11= @Job11,Job12= @Job12,Job13= @Job13,Job14= @Job14,Job15= @Job15,Job16= @Job16,Job17= @Job17,Job18= @Job18,Job19= @Job19,Job20= @Job20 WHERE Barcode = @Barcode;";
                using (var updateCmd = new SQLiteCommand(updateQuery, connection))
                {
                    updateCmd.Parameters.AddWithValue("@Result", result);
                    updateCmd.Parameters.AddWithValue("@Job1", Job[0]);
                    updateCmd.Parameters.AddWithValue("@Job2", Job[1]);
                    updateCmd.Parameters.AddWithValue("@Job3", Job[2]);
                    updateCmd.Parameters.AddWithValue("@Job4", Job[3]);
                    updateCmd.Parameters.AddWithValue("@Job5", Job[4]);
                    updateCmd.Parameters.AddWithValue("@Job6", Job[5]);
                    updateCmd.Parameters.AddWithValue("@Job7", Job[6]);
                    updateCmd.Parameters.AddWithValue("@Job8", Job[7]);
                    updateCmd.Parameters.AddWithValue("@Job9", Job[8]);
                    updateCmd.Parameters.AddWithValue("@Job10", Job[9]);
                    updateCmd.Parameters.AddWithValue("@Job11", Job[10]);
                    updateCmd.Parameters.AddWithValue("@Job12", Job[11]);
                    updateCmd.Parameters.AddWithValue("@Job13", Job[12]);
                    updateCmd.Parameters.AddWithValue("@Job14", Job[13]);
                    updateCmd.Parameters.AddWithValue("@Job15", Job[14]);
                    updateCmd.Parameters.AddWithValue("@Job16", Job[15]);
                    updateCmd.Parameters.AddWithValue("@Job17", Job[16]);
                    updateCmd.Parameters.AddWithValue("@Job18", Job[17]);
                    updateCmd.Parameters.AddWithValue("@Job19", Job[18]);
                    updateCmd.Parameters.AddWithValue("@Job20", Job[19]);
                    updateCmd.Parameters.AddWithValue("@Barcode", Barcode);
                    updateCmd.ExecuteNonQuery();
                }
            }

           
        }
    }
}
 

