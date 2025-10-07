﻿using Design_Form.Job_Model;
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
    public partial class ParaLine : DevExpress.XtraEditors.XtraUserControl
    {
        int index_follow = -1;
        public ParaLine()
        {
            InitializeComponent();
        }
        public void load_parameter()
        {
            try
            {
                int a = Job_Model.Statatic_Model.camera_index;
                int b = Job_Model.Statatic_Model.job_index;
                int c = Job_Model.Statatic_Model.tool_index;
                int d = Job_Model.Statatic_Model.image_index;
                combo_master.Items.Clear();
                FindLineTool findLine = (FindLineTool)Job_Model.Statatic_Model.model_run.Cameras[a].Jobs[b].Images[d].Tools[c];
                for(int i = 0;i< Job_Model.Statatic_Model.model_run.Cameras[a].Jobs[b].Images[d].Tools.Count;i++)
                {
                    if(Job_Model.Statatic_Model.model_run.Cameras[a].Jobs[b].Images[d].Tools[i].ToolName=="Fixture")
                    {
                        combo_master.Items.Add(Job_Model.Statatic_Model.model_run.Cameras[a].Jobs[b].Images[d].Tools[i].ToolName+": "+i.ToString());
                    }    
               
                }    

                combo_master.Text = findLine.folow_master;
               // decimal test = Convert.ToDecimal(Job_Model.Statatic_Model.model_run.Cameras[a].Jobs[b].Tools[c].para_Tool[1].Value);
                numeric_Sigma.Value = findLine.sigma;
                numeric_Length.Value =findLine.Length1 ;
                numeric_Length2.Value =findLine.Length2 ;
                numeric_Threshold.Value =findLine.Threshold ;
                combo_Result.Text =findLine.combo_Result ;
                combo_Light_to_Dark.Text =findLine.combo_Light_to_Dark ;
            }

            catch (Exception ex) 
            {
                MessageBox.Show(ex.ToString());
            }
           
        }
        // Button Save Tool
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            int a = Job_Model.Statatic_Model.camera_index;
            int b = Job_Model.Statatic_Model.job_index;
            int c = Job_Model.Statatic_Model.tool_index;
            int d = Job_Model.Statatic_Model.image_index;
            FindLineTool findLine =(FindLineTool) Job_Model.Statatic_Model.model_run.Cameras[a].Jobs[b].Images[d].Tools[c];
            //Sigma index 0
            findLine.index_follow = index_follow;
            findLine.folow_master = combo_master.Text;
            findLine.sigma = numeric_Sigma.Value;
            findLine.Length1 = numeric_Length.Value;
            findLine.Length2 = numeric_Length2.Value;
            findLine.Threshold = numeric_Threshold.Value;
            findLine.combo_Result =combo_Result.Text;
            findLine.combo_Light_to_Dark = combo_Light_to_Dark.Text;
            Job_Model.Statatic_Model.model_run.Cameras[a].Jobs[b].Images[d].Tools[c]=findLine;



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
                if (combo_master.Text == "none")
                {
                    index_follow = -1;
                    break;
                }

            }
        }
    }
}
