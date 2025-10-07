using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Design_Form.User_PLC
{
    public partial class User_Input2 : UserControl
    {

        PLC_Communication.WordConvert convert = new  PLC_Communication.WordConvert();
        List<Label> labels = new List<Label>();
        public User_Input2()
        {
            InitializeComponent();
            inital_label();
        }
        private void inital_label()
        {
            labels.Add(label1);
            labels.Add(label3);
            labels.Add(label5);
            labels.Add(label7);
            labels.Add(label9);
            labels.Add(label11);
            labels.Add(label13);
            labels.Add(label15);
            labels.Add(label17);
            labels.Add(label19);
            labels.Add(label21);
            labels.Add(label23);
            labels.Add(label25);
            labels.Add(label27);
            labels.Add(label29);
            labels.Add(label32);
            label1.Text = "X040";
            label3.Text = "X041";
            label5.Text = "X042";
            label7.Text = "X043";
            label9.Text = "X044";
            label11.Text = "X045";
            label13.Text = "X046";
            label15.Text = "X047";
            label17.Text = "X050";
            label19.Text = "X051";
            label21.Text = "X052";
            label23.Text = "X053";
            label25.Text = "X054";
            label27.Text = "X055";
            label29.Text = "X056";
            label32.Text = "X057";
            label2.Text = "SS Cyl Mov Product NG FW";
            label4.Text = "SS Cyl Mov Product NG BW";
            label6.Text = "SS Cyl Down Product NG FW";
            label8.Text = "SS Cyl Up Product NG BW";
            label10.Text = "SS Vacuum Transfer NG CV";
            label12.Text = "SS Buffer Vacuum ";
            label14.Text = "CV_NG_SS_Input";
            label16.Text = "CV_NG_SS_Output";
            label18.Text = "Limit - R1";
            label20.Text = "Home R1";
            label22.Text = "Limit + R1";
            label24.Text = "Alarm R1";
            label26.Text = "Servo Ready R1";
            label28.Text = "Limit - R2";
            label30.Text = "Home R2";
            label33.Text = "Limit + R2";
        }
        public void load_Data()
        {
            bool[] result = new bool[16];
            result=convert.WordTo16Bit(PLC_Communication.Model_PLC.Read_from_PLc[2]);
            for (int i = 0; i < labels.Count; i++)
            {
                if (result[i])
                {
                    labels[i].BackColor = Color.Green;
                }
                else
                {
                    labels[i].BackColor = Color.Gray;
                }
            }
        }
    }
}
