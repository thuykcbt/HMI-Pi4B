using Design_Form.Job_Model;
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

namespace Design_Form.UserForm
{
  
    public partial class User_Calib : UserControl
    {
        int index_follow = -1;
        int roate_image=-1;
        public User_Calib()
        {
            InitializeComponent();
        }
        public void load_para()
        {
            try
            {
                int a = Job_Model.Statatic_Model.camera_index;
                int b = Job_Model.Statatic_Model.job_index;
                int c = Job_Model.Statatic_Model.tool_index;
                int d = Job_Model.Statatic_Model.image_index;
             
                Calibrate_Plate_Tool tool = (Calibrate_Plate_Tool)Job_Model.Statatic_Model.model_run.Cameras[a].Jobs[b].Images[d].Tools[c];

                label1.Text = tool.file_image_calib;
                label2.Text = tool.file_paracam;
                label3.Text = tool.file_Pose_Came;
                label4.Text = tool.file_Calib_describe;
                focus.Value =(decimal) tool.focus;
                Thickness.Value = (decimal)tool.Thick_Ness;
                Cell_Width.Value = (decimal)tool.Cell_Width;
                Cell_Height.Value = (decimal)tool.Cell_Height;


            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

       
        //Button Save
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            int a = Job_Model.Statatic_Model.camera_index;
            int b = Job_Model.Statatic_Model.job_index;
            int c = Job_Model.Statatic_Model.tool_index;
            int d = Job_Model.Statatic_Model.image_index;
            Calibrate_Plate_Tool tool = (Calibrate_Plate_Tool)Job_Model.Statatic_Model.model_run.Cameras[a].Jobs[b].Images[d].Tools[c];
            //Sigma index 0
            tool.file_image_calib = label1.Text;
            tool.file_paracam = label2.Text;
            tool.file_Pose_Came = label3.Text;
            tool.file_Calib_describe = label4.Text;
            tool.focus=(double) focus.Value;
            tool.Thick_Ness= (double)Thickness.Value;
            tool.Cell_Height=(double)Cell_Height.Value;
            tool.Cell_Width=(double)Cell_Width.Value;
            Job_Model.Statatic_Model.model_run.Cameras[a].Jobs[b].Images[d].Tools[c] = tool;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog saveFileDialog = new FolderBrowserDialog();
          

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                
                label1.Text = saveFileDialog.SelectedPath;
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog saveFileDialog = new FolderBrowserDialog();


            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {

                label2.Text = saveFileDialog.SelectedPath;
            }
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog saveFileDialog = new FolderBrowserDialog();


            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {

                label3.Text = saveFileDialog.SelectedPath;
            }
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Job Files (*.cpd)|*.cpd"; // Bộ lọc định dạng file
            openFileDialog1.Title = "Chọn file để mở"; // Tiêu đề của hộp thoại
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                label4.Text=openFileDialog1.FileName;

            }
        }
    }
    
}
