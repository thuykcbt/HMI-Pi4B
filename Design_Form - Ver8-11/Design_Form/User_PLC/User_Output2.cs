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
    public partial class User_Output2 : UserControl
    {

        PLC_Communication.WordConvert convert = new  PLC_Communication.WordConvert();
        List<Label> labels = new List<Label>();
        public User_Output2()
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
            //labels.Add(label31);
            labels.Add(label32);
            label1.Text = "Y040";
            label3.Text = "Y041";
            label5.Text = "Y042";
            label7.Text = "Y043";
            label9.Text = "Y044";
            label11.Text = "Y045";
            label13.Text = "Y046";
            label15.Text = "Y047";
            label17.Text = "Y050";
            label19.Text = "Y051";
            label21.Text = "Y052";
            label23.Text = "Y053";
            label25.Text = "Y054";
            label27.Text = "Y055";
            label29.Text = "Y056";
            label32.Text = "Y057";
            label2.Text = "Cyl Mov Product NG";
            label4.Text = "Cyl Up/Down Product NG";
            label6.Text = "Vacuum Prodcut NG";
            label8.Text = "Blow Prodcut NG";
            label10.Text = "Spear";
            label12.Text = "Spear";
            label14.Text = "Spear";
            label16.Text = "Spear";
            label18.Text = "Cyl Transfer up/down tool 1";
            label20.Text = "Vacuum Tool 1";
            label22.Text = "Blow Tool 1";
            label24.Text = "Cyl Transfer up/down tool 2";
            label26.Text = "Vacuum Tool 2";
            label28.Text = "Blow Tool 2";
            label30.Text = "Vacuum Buffer 2";
            label33.Text = "Blow Buffer 3";
        }
        public void load_Data()
        {
            bool[] result = new bool[16];
            result=convert.WordTo16Bit(PLC_Communication.Model_PLC.IO_Resigter[7]);
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
