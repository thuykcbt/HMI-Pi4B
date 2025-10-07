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
    public partial class User_Input3 : UserControl
    {

        PLC_Communication.WordConvert convert = new  PLC_Communication.WordConvert();
        List<Label> labels = new List<Label>();
        public User_Input3()
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
            label1.Text = "X060";
            label3.Text = "X061";
            label5.Text = "X062";
            label7.Text = "X063";
            label9.Text = "X064";
            label11.Text = "X065";
            label13.Text = "X066";
            label15.Text = "X067";
            label17.Text = "X070";
            label19.Text = "X071";
            label21.Text = "X072";
            label23.Text = "X073";
            label25.Text = "X074";
            label27.Text = "X075";
            label29.Text = "X076";
            label32.Text = "X077";
            label2.Text = "Alarm R2";
            label4.Text = "Servo Ready R2";
            label6.Text = "Limit - R3";
            label8.Text = "Home R3";
            label10.Text = "Limit + R3";
            label12.Text = "Alarm R3";
            label14.Text = "Servo Ready R3";
            label16.Text = "Spear";
            label18.Text = "Spear";
            label20.Text = "Spear";
            label22.Text = "Spear";
            label24.Text = "Spear";
            label26.Text = "Spear";
            label28.Text = "Spear";
            label30.Text = "Spear";
            label33.Text = "Spear";
        }
        public void load_Data()
        {
            bool[] result = new bool[16];
            result=convert.WordTo16Bit(PLC_Communication.Model_PLC.Read_from_PLc[3]);
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
