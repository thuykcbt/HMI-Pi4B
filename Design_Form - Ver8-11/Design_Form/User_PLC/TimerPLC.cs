using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Design_Form.User_PLC
{
    public partial class TimerPLC : UserControl
    {
        List<NumericUpDown> list_para = new List<NumericUpDown>();
        public TimerPLC()
        {
            InitializeComponent();
            list_para.Add(numericUpDown1);
            list_para.Add(numericUpDown2);
            list_para.Add(numericUpDown3);
            list_para.Add(numericUpDown4);
            list_para.Add(numericUpDown5);
            list_para.Add(numericUpDown6);
            list_para.Add(numericUpDown7);
            list_para.Add(numericUpDown8);
            list_para.Add(numericUpDown9);
            list_para.Add(numericUpDown10);
            read_para();
        }
    
      public void read_para()
     {
            for (int i = 0; i < list_para.Count; i++)
            {
                list_para[i].Value = PLC_Communication.Model_PLC.parameter_read[40+i]/10;
            }
            numericUpDown11.Value = PLC_Communication.Model_PLC.parameter_read[34];
            numericUpDown12.Value = PLC_Communication.Model_PLC.parameter_read[35];
        }
        public void save_para()
        {
            for (int i = 0; i < list_para.Count; i++)
            {
                PLC_Communication.Model_PLC.parameter_write[40 + i] = (int)list_para[i].Value*10;
            }
            PLC_Communication.Model_PLC.parameter_write[34] = (int)numericUpDown11.Value;
            PLC_Communication.Model_PLC.parameter_write[35] = (int)numericUpDown12.Value;
            PLC_Communication.Model_PLC.parameter_write[45] = (int)(numericUpDown1.Value*10);
            PLC_Communication.Model_PLC.parameter_write[46] = (int)(numericUpDown2.Value*10);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
