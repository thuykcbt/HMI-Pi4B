using Design_Form.Job_Model;
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

namespace Design_Form.UserForm
{
    public partial class HistogramPara : DevExpress.XtraEditors.XtraUserControl
    {
        public HistogramPara()
        {
            InitializeComponent();
        }
        int index_follow = -1;
        public void load_parameter()
        {
            try
            {
                int a = Job_Model.Statatic_Model.camera_index;
                int b = Job_Model.Statatic_Model.job_index;
                int c = Job_Model.Statatic_Model.tool_index;
                int d = Job_Model.Statatic_Model.image_index;
                combo_master.Items.Clear();
                combo_master.Items.Add("none");
               HistogramTool tool = (HistogramTool)Job_Model.Statatic_Model.model_run.Cameras[a].Jobs[b].Images[d].Tools[c];
                for (int i = 0; i < Job_Model.Statatic_Model.model_run.Cameras[a].Jobs[b].Images[d].Tools.Count; i++)
                {
                    if (Job_Model.Statatic_Model.model_run.Cameras[a].Jobs[b].Images[d].Tools[i].ToolName == "Fixture")
                    {
                        combo_master.Items.Add(Job_Model.Statatic_Model.model_run.Cameras[a].Jobs[b].Images[d].Tools[i].ToolName + ": " + i.ToString());
                    }

                }
                index_follow = tool.index_follow;
                combo_master.Text = tool.master_follow;
                numeric_PixelHigh.Value = tool.pixel_high;
                numeric_PixelLow.Value = tool.pixel_low;
                numeric_SetupMax.Value =(decimal)tool.max_setup;
                numeric_SetupMin.Value =(decimal)tool.min_setup;
                Thresh_High.Value = (decimal)tool.threshold_high;
                Thresh_Low.Value = (decimal)tool.threshold_low;
                Min_Size.Value = (decimal)tool.nomal_size_min;
                Max_Size.Value = (decimal)tool.nomal_size_max;
                comboBox1.Text= tool.item_check;
                Ck_Contour.Checked= tool.find_contour;
                max_deviation.Value = (decimal)tool.max_deviation;
                min_deviation.Value = (decimal)tool.min_deviation;
                Max_Mean.Value = (decimal)tool.max_mean;
                Min_Mean.Value =(decimal)tool.min_mean;
            }

            catch (Exception ex) 
            {
                MessageBox.Show(ex.ToString());
            }
           
        }
        // Button Save Tool
        
       

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
           Save_para();
        }
        private void Save_para()
        {
            int a = Job_Model.Statatic_Model.camera_index;
            int b = Job_Model.Statatic_Model.job_index;
            int c = Job_Model.Statatic_Model.tool_index;
            int d = Job_Model.Statatic_Model.image_index;
            HistogramTool tool = (HistogramTool)Job_Model.Statatic_Model.model_run.Cameras[a].Jobs[b].Images[d].Tools[c];
            tool.master_follow = combo_master.Text;
            tool.pixel_high =(int)numeric_PixelHigh.Value;
            tool.pixel_low =(int)numeric_PixelLow.Value;
            tool.max_setup = (double)numeric_SetupMax.Value;
            tool.min_setup = (double) numeric_SetupMin.Value;
            tool.index_follow = index_follow;
            tool.find_contour= Ck_Contour.Checked;
            tool.threshold_high= (int) Thresh_High.Value;
            tool.threshold_low= (int)Thresh_Low.Value;
            tool.nomal_size_max= (int)Max_Size.Value;
            tool.nomal_size_min= (int)Min_Size.Value;
            tool.item_check = comboBox1.Text;
            tool.max_deviation = (double)max_deviation.Value;
            tool.min_deviation =(double)min_deviation.Value;
            tool.max_mean = (double)Max_Mean.Value;
            tool.min_mean = (double)Min_Mean.Value;
            Job_Model.Statatic_Model.model_run.Cameras[a].Jobs[b].Images[d].Tools[c] = tool;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Save_para();
        }

        private void combo_master_SelectedIndexChanged(object sender, EventArgs e)
        {
            int a = Job_Model.Statatic_Model.camera_index;
            int b = Job_Model.Statatic_Model.job_index;
            int c = Job_Model.Statatic_Model.tool_index;
            int d = Job_Model.Statatic_Model.image_index;
            string buffer1 = combo_master.Text;
            
            //  combo_master.Items.Clear();
            for (int i = 0; i < Statatic_Model.model_run.Cameras[a].Jobs[b].Images[d].Tools.Count; i++)
            {
                if (combo_master.Text == "Fixture: " + i.ToString())
                {
                    index_follow = i;
                }
                if(combo_master.Text == "none")
                {
                    index_follow = -1;
                    break;
                }
            }
        }

        private void tabPane1_Click(object sender, EventArgs e)
        {
        }
    }
}
