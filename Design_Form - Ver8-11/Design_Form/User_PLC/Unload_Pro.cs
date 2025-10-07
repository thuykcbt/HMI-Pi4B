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
    public partial class Unload_Pro: UserControl
    {
        PLC_Communication.WordConvert convert = new PLC_Communication.WordConvert();
        public Unload_Pro()
        {
            InitializeComponent();
        }
        public void load_data()
        {
            bool[] result = new bool[16];
            bool[] result1 = new bool[16];
            bool[] result2 = new bool[16];
            bool[] result3 = new bool[16];
            result = convert.WordTo16Bit(PLC_Communication.Model_PLC.IO_Resigter[2]);
            result1 = convert.WordTo16Bit(PLC_Communication.Model_PLC.IO_Resigter[3]);
            result2 = convert.WordTo16Bit(PLC_Communication.Model_PLC.IO_Resigter[6]);
            result3 = convert.WordTo16Bit(PLC_Communication.Model_PLC.IO_Resigter[7]);

            button1.BackColor =result[0] ? Color.DarkKhaki : Color.LightGray;
            button2.BackColor = result[1] ? Color.DarkKhaki : Color.LightGray;
            button3.BackColor = result[3] ? Color.DarkKhaki : Color.LightGray;
            button4.BackColor = result[2] ? Color.DarkKhaki : Color.LightGray;
            button5.BackColor = result[4] ? Color.DarkKhaki : Color.LightGray;
            button6.BackColor = result3[2] ? Color.LightGray : Color.DarkKhaki;
            button7.BackColor = result[5] ? Color.DarkKhaki : Color.LightGray;
            button8.BackColor = result2[14] ? Color.LightGray : Color.DarkKhaki;
        }

        private void button1_MouseUp(object sender, MouseEventArgs e)
        {
            PLC_Communication.Model_PLC.man2[0] = false;
        }

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            PLC_Communication.Model_PLC.man2[0] = true;
        }

        private void button2_MouseUp(object sender, MouseEventArgs e)
        {
            PLC_Communication.Model_PLC.man2[1] = false;
        }

        private void button2_MouseDown(object sender, MouseEventArgs e)
        {
            PLC_Communication.Model_PLC.man2[1] = true;
        }

        private void button3_MouseUp(object sender, MouseEventArgs e)
        {
            PLC_Communication.Model_PLC.man2[3] = false;
        }

        private void button3_MouseDown(object sender, MouseEventArgs e)
        {
            PLC_Communication.Model_PLC.man2[3] = true;
        }

        private void button4_MouseUp(object sender, MouseEventArgs e)
        {
            PLC_Communication.Model_PLC.man2[2] = false;
        }

        private void button4_MouseDown(object sender, MouseEventArgs e)
        {
            PLC_Communication.Model_PLC.man2[2] = true;
        }

        private void button5_MouseUp(object sender, MouseEventArgs e)
        {
            PLC_Communication.Model_PLC.man2[4] = false;
        }

        private void button5_MouseDown(object sender, MouseEventArgs e)
        {
            PLC_Communication.Model_PLC.man2[4] = true;
        }

        private void button6_MouseUp(object sender, MouseEventArgs e)
        {
            PLC_Communication.Model_PLC.man2[5] = false;
        }

        private void button6_MouseDown(object sender, MouseEventArgs e)
        {
            PLC_Communication.Model_PLC.man2[5] = true;
        }

        private void button7_MouseUp(object sender, MouseEventArgs e)
        {
            PLC_Communication.Model_PLC.man2[6] = false;
        }

        private void button7_MouseDown(object sender, MouseEventArgs e)
        {
            PLC_Communication.Model_PLC.man2[6] = true;
        }

        private void button8_MouseUp(object sender, MouseEventArgs e)
        {
            PLC_Communication.Model_PLC.man2[7] = false;
        }

        private void button8_MouseDown(object sender, MouseEventArgs e)
        {
            PLC_Communication.Model_PLC.man2[7] = true;
        }
    }
}
