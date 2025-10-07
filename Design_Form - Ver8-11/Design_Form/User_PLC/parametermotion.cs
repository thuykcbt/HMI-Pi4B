using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection.Emit;

namespace Design_Form.User_PLC
{
    public partial class parametermotion: UserControl
    {
        public parametermotion()
        {
            InitializeComponent();
            inital_para();
        }
        List<NumericUpDown> list_para = new List<NumericUpDown>();
        List<Button> EnableSV = new List<Button>(0);
        PLC_Communication.WordConvert convert = new PLC_Communication.WordConvert();
        private void inital_para()
        {
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
            list_para.Add(numericUpDown11);
            list_para.Add(numericUpDown12);
            list_para.Add(numericUpDown13);
            list_para.Add(numericUpDown14);
            list_para.Add(numericUpDown15);
            list_para.Add(numericUpDown16);
            list_para.Add(numericUpDown17);
            list_para.Add(numericUpDown18);
            list_para.Add(numericUpDown19);
            list_para.Add(numericUpDown20);
            list_para.Add(numericUpDown21);
            list_para.Add(numericUpDown22);
            list_para.Add(numericUpDown23);
            list_para.Add(numericUpDown24);
            list_para.Add(numericUpDown25);
            list_para.Add(numericUpDown26);
            list_para.Add(numericUpDown27);
            list_para.Add(numericUpDown28);
            list_para.Add(numericUpDown29);
            list_para.Add(numericUpDown30);
            EnableSV.Add(button2);
            EnableSV.Add(button3);
            EnableSV.Add(button4);
            EnableSV.Add(button5);
            EnableSV.Add(button6);
            EnableSV.Add(button7);
            EnableSV.Add(button8);
            EnableSV.Add(button9);
            EnableSV.Add(button10);
            EnableSV.Add(button11);
            read_para();
          //  load_Data();

        }
        public void load_Data()
        {
            bool[] result = new bool[16];
            result = convert.WordTo16Bit(PLC_Communication.Model_PLC.IO_Resigter[4]);
            for (int i = 0; i < EnableSV.Count; i++)
            {
                if (result[i])
                {
                    EnableSV[i].BackColor = Color.Khaki;
                }
                else
                {
                    EnableSV[i].BackColor = Color.Gray;
                }
            }
        }
        public void write_servoenable(int index)
        {
           
            if (PLC_Communication.Model_PLC.button_jog2[index])
            {
                PLC_Communication.Model_PLC.button_jog2[index] = false;
            }   
            else
            {
                PLC_Communication.Model_PLC.button_jog2[index] = true;
            }
         //   load_Data();
        }
        public void read_para()
        {
            for (int i = 0; i < list_para.Count; i++)
            {
                list_para[i].Value = PLC_Communication.Model_PLC.parameter_read[i];
            }    
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            for (int i = 0; i < list_para.Count; i++)
            {
                PLC_Communication.Model_PLC.parameter_write[i] = (int)list_para[i].Value;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            write_servoenable(0);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            write_servoenable(1);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            write_servoenable(2);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            write_servoenable(3);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            write_servoenable(4);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            write_servoenable(5);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            write_servoenable(6);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            write_servoenable(7);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            write_servoenable(8);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            write_servoenable(9);
        }
    }
}
