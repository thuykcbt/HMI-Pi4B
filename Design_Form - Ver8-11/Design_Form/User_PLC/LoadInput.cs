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
    public partial class LoadInput: UserControl
    {
        PLC_Communication.WordConvert convert = new PLC_Communication.WordConvert();
        public LoadInput()
        {
            InitializeComponent();
        }
        public void load_data()
        {
            bool[] result = new bool[16];
            bool[] result1 = new bool[16];
            bool[] result2 = new bool[16];
            result = convert.WordTo16Bit(PLC_Communication.Model_PLC.IO_Resigter[0]);
            result1 = convert.WordTo16Bit(PLC_Communication.Model_PLC.IO_Resigter[1]);
            result2 = convert.WordTo16Bit(PLC_Communication.Model_PLC.IO_Resigter[6]);
            button1.BackColor =result[8] ? Color.DarkKhaki : Color.LightGray;
            button2.BackColor = result[9] ? Color.DarkKhaki : Color.LightGray;
            button3.BackColor = result1[0] ? Color.DarkKhaki : Color.LightGray;
            button4.BackColor = result1[1] ? Color.DarkKhaki : Color.LightGray;
            button5.BackColor = result1[2] ? Color.DarkKhaki : Color.LightGray;
            button6.BackColor = result1[3] ? Color.DarkKhaki : Color.LightGray;
            button7.BackColor = result1[4] ? Color.DarkKhaki : Color.LightGray;
            button8.BackColor = result2[2] ? Color.LightGray : Color.DarkKhaki;
            button9.BackColor = result[10] ? Color.DarkKhaki : Color.LightGray;
            button10.BackColor = result[11] ? Color.DarkKhaki : Color.LightGray;
        }

        private void button1_MouseUp(object sender, MouseEventArgs e)
        {
            PLC_Communication.Model_PLC.man1[0] = false;
        }

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            PLC_Communication.Model_PLC.man1[0] = true;
        }

        private void button2_MouseUp(object sender, MouseEventArgs e)
        {
            PLC_Communication.Model_PLC.man1[1] = false;
        }

        private void button2_MouseDown(object sender, MouseEventArgs e)
        {
            PLC_Communication.Model_PLC.man1[1] = true;
        }

        private void button3_MouseUp(object sender, MouseEventArgs e)
        {
            PLC_Communication.Model_PLC.man1[2] = false;
        }

        private void button3_MouseDown(object sender, MouseEventArgs e)
        {
            PLC_Communication.Model_PLC.man1[2] = true;
        }

        private void button4_MouseUp(object sender, MouseEventArgs e)
        {
            PLC_Communication.Model_PLC.man1[3] = false;
        }

        private void button4_MouseDown(object sender, MouseEventArgs e)
        {
            PLC_Communication.Model_PLC.man1[3] = true;
        }

        private void button5_MouseUp(object sender, MouseEventArgs e)
        {
            PLC_Communication.Model_PLC.man1[4] = false;
        }

        private void button5_MouseDown(object sender, MouseEventArgs e)
        {
            PLC_Communication.Model_PLC.man1[4] = true;
        }

        private void button6_MouseUp(object sender, MouseEventArgs e)
        {
            PLC_Communication.Model_PLC.man1[5] = false;
        }

        private void button6_MouseDown(object sender, MouseEventArgs e)
        {
            PLC_Communication.Model_PLC.man1[5] = true;
        }

        private void button7_MouseUp(object sender, MouseEventArgs e)
        {
            PLC_Communication.Model_PLC.man1[6] = false;
        }

        private void button7_MouseDown(object sender, MouseEventArgs e)
        {
            PLC_Communication.Model_PLC.man1[6] = true;
        }

        private void button8_MouseUp(object sender, MouseEventArgs e)
        {
            PLC_Communication.Model_PLC.man1[7] = false;
        }

        private void button8_MouseDown(object sender, MouseEventArgs e)
        {
            PLC_Communication.Model_PLC.man1[7] = true;
        }

        private void button9_MouseDown(object sender, MouseEventArgs e)
        {
            PLC_Communication.Model_PLC.man2[12] = true;
        }

        private void button9_MouseUp(object sender, MouseEventArgs e)
        {
            PLC_Communication.Model_PLC.man2[12] = false;
        }

        private void button10_MouseDown(object sender, MouseEventArgs e)
        {
            PLC_Communication.Model_PLC.man2[13] = true;
        }

        private void button10_MouseUp(object sender, MouseEventArgs e)
        {
            PLC_Communication.Model_PLC.man2[13] = false;
        }
    }
}
