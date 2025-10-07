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
    public partial class CaliHandEye : DevExpress.XtraEditors.XtraUserControl
    {
        public CaliHandEye()
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
               Cal_Hand_Eye_Tool tool = (Cal_Hand_Eye_Tool)Job_Model.Statatic_Model.model_run.Cameras[a].Jobs[b].Images[d].Tools[c];
                StepAngle.Value = tool.step_angle;
                StepX.Value = tool.step_x;
                StepY.Value = tool.step_y;
                JumpX.Value =(decimal)tool.jump_x;
                JumpY.Value = (decimal)tool.jump_y;
                JumpAngle.Value = (decimal)tool.jump_angle;
              
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
            Cal_Hand_Eye_Tool tool = (Cal_Hand_Eye_Tool)Job_Model.Statatic_Model.model_run.Cameras[a].Jobs[b].Images[d].Tools[c];
            tool.step_x =(int) StepX.Value;
            tool.step_y = (int)StepY.Value;
            tool.step_angle = (int)StepAngle.Value;
            tool.jump_x = (double)JumpX.Value;
            tool.jump_y = (double)JumpY.Value;
            tool.jump_angle = (double)JumpAngle.Value;
            Job_Model.Statatic_Model.model_run.Cameras[a].Jobs[b].Images[d].Tools[c] = tool;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Save_para();
        }

    

        private void tabPane1_Click(object sender, EventArgs e)
        {



















































        }
    }
}
