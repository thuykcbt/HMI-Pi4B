using DevExpress.Xpo.DB.Helpers;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OfficeOpenXml;
using System.IO;
using System.Data.Linq.Mapping;
using DevExpress.XtraEditors.Filtering.Templates;

namespace Design_Form
{
    public partial class ReportForm : DevExpress.XtraEditors.XtraForm
    {
        public ReportForm()
        {
            InitializeComponent();
             
        }
        DataTable dataTable;
        private void load_data()
        {
            try
            {
                string query = @"
                SELECT Products.ProductId,Products.Barcode, Products.Result, Products.Date,  Products.Item1, Products.Item2, Products.Item3,Products.Item4,Products.Item5,Products.Item6,Products.Item7,Products.Item8,Products.Item9,Products.Item10,Products.Item11,Products.Item12,Products.Item13,Products.Item14,Products.Item15,Products.Item16,Products.Item17,Products.Item18,Products.Item19,Products.Item20
                FROM Products
                ";

                dataTable = Job_Model.Statatic_Model.sql_lite.GetAllData(query);

                // Gán dữ liệu vào DataGridView
                dataGridView1.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}");
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            check_Old.Checked = false;
        }

        private void check_Old_CheckedChanged(object sender, EventArgs e)
        {
            check_update.Checked = false;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if(check_Old.Checked)
            {
                 dataTable = Job_Model.Statatic_Model.sql_lite.GetProductsByDateRange(dateTimePicker1.Value,dateTimePicker2.Value);

                // Gán dữ liệu vào DataGridView
                dataGridView1.DataSource = dataTable;
            }
            if(check_update.Checked)
            {
                dataTable = Job_Model.Statatic_Model.sql_lite_update.GetProductsByDateRange(dateTimePicker1.Value, dateTimePicker2.Value);

                // Gán dữ liệu vào DataGridView
                dataGridView1.DataSource = dataTable;
            }    
            //load_data();
        }

        private void simpleButton2_Click_1(object sender, EventArgs e)
        {
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Excel Files (*.csv)|*.csv"; // Bộ lọc định dạng file;
                saveFileDialog.Title = "Save As";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    dataTable.TableName = DateTime.Now.ToString("dd/MM/yyyy");
                    ExportDataTableToExcel(dataTable, saveFileDialog.FileName);
                }
                else
                {
                    return; // Nếu người dùng hủy Save, không làm gì cả
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.ToString());
                Job_Model.Statatic_Model.wirtelog.Log(ex.ToString());
            }
           
        }
        private void ExportDataTableToExcel(DataTable dt, string filePath)
        {
            using (ExcelPackage package = new ExcelPackage())
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add(dt.TableName);

                // Ghi tiêu đề cột
                for (int col = 0; col < dt.Columns.Count; col++)
                {
                    worksheet.Cells[1, col + 1].Value = dt.Columns[col].ColumnName;
                    worksheet.Cells[1, col + 1].Style.Font.Bold = true;
                }

                // Ghi dữ liệu vào sheet
                for (int row = 0; row < dt.Rows.Count; row++)
                {
                    for (int col = 0; col < dt.Columns.Count; col++)
                    {
                        worksheet.Cells[row + 2, col + 1].Value = dt.Rows[row][col];
                    }
                }

                // Lưu file Excel
              
                File.WriteAllBytes(filePath, package.GetAsByteArray());
            }
        }
    }
}