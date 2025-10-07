using DevExpress.XtraEditors;
using HalconDotNet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Design_Form
{
    public partial class Confirm_Data : DevExpress.XtraEditors.XtraForm
    {
        HalconDotNet.HSmartWindowControl HSmartWindowControl1;
        public string Result = "NG";
        public Confirm_Data()
        {
            InitializeComponent();
            inital_display_Halcon();
        }
        private void inital_display_Halcon()
        {
            HSmartWindowControl1 = new HalconDotNet.HSmartWindowControl();
            panel1.Controls.Add(HSmartWindowControl1);
            HSmartWindowControl1.Show();
            HSmartWindowControl1.Dock = DockStyle.Fill;
            HSmartWindowControl1.Load += DisplayHalcon_Load1;

        }
        private void DisplayHalcon_Load1(object sender, EventArgs e)
        {
            try
            {
                HSmartWindowControl1.MouseWheel += HSmartWindowControl1.HSmartWindowControl_MouseWheel;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void load_data_Item1(string Data_Item)
        {
            if (Data_Item == "OK")
            {
                Confirm_OK.Enabled = false;
                Confirm_Ng.Enabled = true;
                Result = "OK";
            }
            if(Data_Item == "NG")
            {
                Confirm_OK.Enabled = true;
                Confirm_Ng.Enabled = false;
                Result = "NG";
            }    
        }

        private void Confirm_OK_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
            "Bạn có chắc chắn muốn đổi NG thành OK?", // Nội dung thông báo
            "Xác nhận",                       // Tiêu đề cửa sổ
            MessageBoxButtons.YesNo,          // Các nút: Yes và No
            MessageBoxIcon.Question           // Biểu tượng dấu hỏi
        );
            if (result == DialogResult.Yes)
            {
                Result = "OK";
                Confirm_OK.Enabled = false;
                Confirm_Ng.Enabled = true;
            }
            else
            {
                Result = "NG";

            }  
               

        }

        private void Confirm_Ng_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
            "Bạn có chắc chắn muốn đổi OK thành NG?", // Nội dung thông báo
            "Xác nhận",                       // Tiêu đề cửa sổ
            MessageBoxButtons.YesNo,          // Các nút: Yes và No
            MessageBoxIcon.Question           // Biểu tượng dấu hỏi
        );
            if (result == DialogResult.Yes)
            {
                Result = "NG";
                Confirm_OK.Enabled = true;
                Confirm_Ng.Enabled = false;
            }
            else
                Result = "OK";
        }
        public string resul_update()
        {
            return Result;
        }
    }
}