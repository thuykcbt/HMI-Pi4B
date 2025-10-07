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
    public partial class TransferPro: UserControl
    {
        PLC_Communication.WordConvert convert = new PLC_Communication.WordConvert();
        public TransferPro()
        {
            InitializeComponent();
        }
        public void load_data()
        {
            bool[] result = new bool[16];
            bool[] result1 = new bool[16];
            bool[] result2 = new bool[16];
            result = convert.WordTo16Bit(PLC_Communication.Model_PLC.IO_Resigter[1]);
            result1 = convert.WordTo16Bit(PLC_Communication.Model_PLC.IO_Resigter[3]);
            result2 = convert.WordTo16Bit(PLC_Communication.Model_PLC.IO_Resigter[6]);
            button1.BackColor =result[11] ? Color.DarkKhaki : Color.LightGray;
            button2.BackColor = result[10] ? Color.DarkKhaki : Color.LightGray;
            button3.BackColor = result[9] ? Color.DarkKhaki : Color.LightGray;
            button4.BackColor = result2[9] ? Color.LightGray : Color.DarkKhaki;
            button6.BackColor = result[14] ? Color.DarkKhaki : Color.LightGray;
            button5.BackColor = result[15] ? Color.DarkKhaki : Color.LightGray;
            button7.BackColor = result[13] ? Color.DarkKhaki : Color.LightGray;
            button8.BackColor = result2[12] ? Color.LightGray : Color.DarkKhaki;
        }

        private void button1_MouseUp(object sender, MouseEventArgs e)
        {
            PLC_Communication.Model_PLC.man1[9] = false;
        }

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            PLC_Communication.Model_PLC.man1[9] = true;
        }

        private void button2_MouseUp(object sender, MouseEventArgs e)
        {
            PLC_Communication.Model_PLC.man1[8] = false;
        }

        private void button2_MouseDown(object sender, MouseEventArgs e)
        {
            PLC_Communication.Model_PLC.man1[8] = true;
        }

        private void button3_MouseUp(object sender, MouseEventArgs e)
        {
            PLC_Communication.Model_PLC.man1[10] = false;
        }

        private void button3_MouseDown(object sender, MouseEventArgs e)
        {
            PLC_Communication.Model_PLC.man1[10] = true;
        }

        private void button4_MouseUp(object sender, MouseEventArgs e)
        {
            PLC_Communication.Model_PLC.man1[11] = false;
        }

        private void button4_MouseDown(object sender, MouseEventArgs e)
        {
            PLC_Communication.Model_PLC.man1[11] = true;
        }

        private void button5_MouseUp(object sender, MouseEventArgs e)
        {
            PLC_Communication.Model_PLC.man1[15] = false;
        }

        private void button5_MouseDown(object sender, MouseEventArgs e)
        {
            PLC_Communication.Model_PLC.man1[15] = true;
        }

        private void button6_MouseUp(object sender, MouseEventArgs e)
        {
            PLC_Communication.Model_PLC.man1[14] = false;
        }

        private void button6_MouseDown(object sender, MouseEventArgs e)
        {
            PLC_Communication.Model_PLC.man1[14] = true;
        }

        private void button7_MouseUp(object sender, MouseEventArgs e)
        {
            PLC_Communication.Model_PLC.man1[12] = false;
        }

        private void button7_MouseDown(object sender, MouseEventArgs e)
        {
            PLC_Communication.Model_PLC.man1[12] = true;
        }

        private void button8_MouseUp(object sender, MouseEventArgs e)
        {
            PLC_Communication.Model_PLC.man1[13] = false;
        }

        private void button8_MouseDown(object sender, MouseEventArgs e)
        {
            PLC_Communication.Model_PLC.man1[13] = true;
        }
    }
}
