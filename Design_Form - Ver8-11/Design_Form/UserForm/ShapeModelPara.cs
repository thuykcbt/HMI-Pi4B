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
    public partial class ShapeModelPara : DevExpress.XtraEditors.XtraUserControl
    {
        public ShapeModelPara()
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
                ShapeModelTool shapeModel = (ShapeModelTool)Job_Model.Statatic_Model.model_run.Cameras[a].Jobs[b].Images[d].Tools[c];
                for (int i = 0; i < Job_Model.Statatic_Model.model_run.Cameras[a].Jobs[b].Images[d].Tools.Count; i++)
                {
                    if (Job_Model.Statatic_Model.model_run.Cameras[a].Jobs[b].Images[d].Tools[i].ToolName == "Fixture")
                    {
                        combo_master.Items.Add(Job_Model.Statatic_Model.model_run.Cameras[a].Jobs[b].Images[d].Tools[i].ToolName + ": " + i.ToString());
                    }

                }

                combo_master.Text = shapeModel.folow_master;
                numeric_AgStart.Value =(decimal) shapeModel.Ag_Start;
                numeric_AgEnd.Value = (decimal)shapeModel.Ag_End;
                numeric_MinScore.Value = (decimal)shapeModel.Min_Score;
                numeric_NumberMatch.Value = (decimal)shapeModel.Number_of_match;
                numeric_Greediness.Value = (decimal)shapeModel.Greediness;
                numeric_Constact.Value = (decimal)shapeModel.Constract;
                numeric_MinConstract.Value = (decimal)shapeModel.MinConstract;
                numeric_Overlap.Value = (decimal)shapeModel.Max_Overlap;
                combo_SubPixel.Text = shapeModel.Sub_pixel;
                label1.Text = shapeModel.File_Model;
                numeric_MaxScore.Value =(decimal) shapeModel.max_score;
                Min_score.Value = (decimal) shapeModel.min_score;
                comboBox1.Text= shapeModel.item_check;
                Max_Phi.Value = (decimal)shapeModel.max_phi;
                Min_Phi.Value = (decimal)shapeModel.min_phi;
              

            }

            catch (Exception ex) 
            {
                MessageBox.Show(ex.ToString());
            }
           
        }
        // Button Save Tool
        
        private void simpleButton3_Click(object sender, EventArgs e)
        {
            int a = Job_Model.Statatic_Model.camera_index;
            int b = Job_Model.Statatic_Model.job_index;
            int c = Job_Model.Statatic_Model.tool_index;
            int d = Job_Model.Statatic_Model.image_index;
            ShapeModelTool shapeModel = (ShapeModelTool)Job_Model.Statatic_Model.model_run.Cameras[a].Jobs[b].Images[d].Tools[c];
            FolderBrowserDialog saveFileDialog = new FolderBrowserDialog();
            //saveFileDialog.Filter = "Model Files (*.model)|*.model"; // Bộ lọc định dạng file;
            //saveFileDialog.Title = "Save As";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                shapeModel.File_Model = saveFileDialog.SelectedPath;
                Job_Model.Statatic_Model.model_run.Cameras[a].Jobs[b].Images[d].Tools[c] = shapeModel;
                label1.Text = saveFileDialog.SelectedPath;
            }
        }

       

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
            ShapeModelTool shapeModel = (ShapeModelTool)Job_Model.Statatic_Model.model_run.Cameras[a].Jobs[b].Images[d].Tools[c];
            shapeModel.index_follow= index_follow;
            shapeModel.folow_master = combo_master.Text;
            shapeModel.Ag_Start =(double) numeric_AgStart.Value;
            shapeModel.Ag_End = (double)numeric_AgEnd.Value;
            shapeModel.Number_of_match = (double)numeric_NumberMatch.Value;
            shapeModel.Max_Overlap = (double)numeric_Overlap.Value;
            shapeModel.Greediness = (double)numeric_Greediness.Value;
            shapeModel.Min_Score = (double)numeric_MinScore.Value;
            shapeModel.Constract = (double)numeric_Constact.Value;
            shapeModel.MinConstract = (double)numeric_MinConstract.Value;
            shapeModel.Sub_pixel = combo_SubPixel.Text;
            shapeModel.max_score = (double)numeric_MaxScore.Value;
            shapeModel.min_score = (double)Min_score.Value;
            shapeModel.item_check = comboBox1.Text;
            shapeModel.max_phi = (double)Max_Phi.Value;
            shapeModel.min_phi = (double)Min_Phi.Value;
            Job_Model.Statatic_Model.model_run.Cameras[a].Jobs[b].Images[d].Tools[c] = shapeModel;
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
