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
    public partial class User_Input1 : UserControl
    {

        PLC_Communication.WordConvert convert = new  PLC_Communication.WordConvert();
        List<Label> labels = new List<Label>();
        public User_Input1()
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
            label1.Text = "X020";
            label3.Text = "X021";
            label5.Text = "X022";
            label7.Text = "X023";
            label9.Text = "X024";
            label11.Text = "X025";
            label13.Text = "X026";
            label15.Text = "X027";
            label17.Text = "X030";
            label19.Text = "X031";
            label21.Text = "X032";
            label23.Text = "X033";
            label25.Text = "X034";
            label27.Text = "X035";
            label29.Text = "X036";
            label32.Text = "X037";
            label2.Text = "CYL Load Mov FW";
            label4.Text = "CYL Load Mov BW";
            label6.Text = "CYL Load Up FW";
            label8.Text = "CYL Load Down BW";
            label10.Text = "SS Load Vacuum";
            label12.Text = "Spear";
            label14.Text = "CV_OK_SS_Input";
            label16.Text = "CV_OK_SS_Output";
            label18.Text = "Sensor Check Buffer 1";
            label20.Text = "Sensor Tool Vacuum 1";
            label22.Text = "Sensor Up/Down Tool 1 FW";
            label24.Text = "Sensor Up/Down Tool 1 BW";
            label26.Text = "Sensor Check Buffer 2";
            label28.Text = "Sensor Tool Vacuum 2";
            label30.Text = "Sensor Up/Down Tool 2 FW";
            label33.Text = "Sensor Up/Down Tool 2 BW";
        }
        public void load_Data()
        {
            bool[] result = new bool[16];
            result=convert.WordTo16Bit(PLC_Communication.Model_PLC.Read_from_PLc[1]);
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
