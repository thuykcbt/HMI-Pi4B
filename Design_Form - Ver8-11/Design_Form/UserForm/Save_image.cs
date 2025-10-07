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
  
    public partial class Save_image : UserControl
    {
        int index_follow = -1;
        int roate_image=-1;
        public Save_image()
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
             
                Save_Image_Tool tool = (Save_Image_Tool)Job_Model.Statatic_Model.model_run.Cameras[a].Jobs[b].Images[d].Tools[c];

                label1.Text = tool.file_name_OK;
                label2.Text = tool.file_name_NG;
                Save_Image_OK.Checked = tool.Save_OK;
                Save_Image_NG.Checked = tool.Save_NG;



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
            Save_Image_Tool tool = (Save_Image_Tool)Job_Model.Statatic_Model.model_run.Cameras[a].Jobs[b].Images[d].Tools[c];
            //Sigma index 0
            tool.file_name_OK = label1.Text;
            tool.file_name_NG = label2.Text;
            tool.Save_OK = Save_Image_OK.Checked;
            tool.Save_NG = Save_Image_NG.Checked;
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
    }
    
}
