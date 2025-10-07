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
    public partial class Barcode2D : DevExpress.XtraEditors.XtraUserControl
    {
        public Barcode2D()
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
                Barcode_2D tool = (Barcode_2D)Job_Model.Statatic_Model.model_run.Cameras[a].Jobs[b].Images[d].Tools[c];
                for (int i = 0; i < Job_Model.Statatic_Model.model_run.Cameras[a].Jobs[b].Images[d].Tools.Count; i++)
                {
                    if (Job_Model.Statatic_Model.model_run.Cameras[a].Jobs[b].Images[d].Tools[i].ToolName == "Fixture")
                    {
                        combo_master.Items.Add(Job_Model.Statatic_Model.model_run.Cameras[a].Jobs[b].Images[d].Tools[i].ToolName + ": " + i.ToString());
                    }

                }
                index_follow = tool.index_follow;
                combo_master.Text = tool.master_follow;
                numeric_Blur.Value = tool.Blur;
                combo_Codetype.Text = tool.Codetype;
                numeric_SetupMax.Value =(decimal)tool.max_leng_code;
                numeric_SetupMin.Value = (decimal)tool.min_leng_code;
                comboBox1.Text= tool.item_check;
                Th_max.Value = (decimal)tool.threshold_Max;
                TH_Min.Value = (decimal)tool.threshold_Min;
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
            Barcode_2D tool = (Barcode_2D)Job_Model.Statatic_Model.model_run.Cameras[a].Jobs[b].Images[d].Tools[c];
            tool.master_follow = combo_master.Text;
            tool.Blur =(int)numeric_Blur.Value;
            tool.Codetype = combo_Codetype.Text;
            tool.max_leng_code = (int)numeric_SetupMax.Value;
            tool.min_leng_code = (int) numeric_SetupMin.Value;
            tool.index_follow = index_follow;
            tool.item_check =comboBox1.Text;
            tool.threshold_Max = (int)Th_max.Value;
            tool.threshold_Min = (int)TH_Min.Value;
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
    }
}
