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
using DevExpress.Internal.WinApi.Windows.UI.Notifications;

namespace Design_Form.User_PLC
{
    public partial class ConveyorCam: UserControl
    {
        PLC_Communication.WordConvert convert = new PLC_Communication.WordConvert();
        public ConveyorCam()
        {
            InitializeComponent();
        }
        public void load_data()
        {
            bool[] result = new bool[16];
            bool[] result1 = new bool[16];
            bool[] result2 = new bool[16];
            result = convert.WordTo16Bit(PLC_Communication.Model_PLC.IO_Resigter[7]);
            result1 = convert.WordTo16Bit(PLC_Communication.Model_PLC.IO_Resigter[6]);
            result2 = convert.WordTo16Bit(PLC_Communication.Model_PLC.IO_Resigter[5]);
            button1.BackColor =result[7] ? Color.DarkKhaki : Color.LightGray;
            button2.BackColor = result[7] ? Color.LightGray : Color.DarkKhaki;
            button3.BackColor = result[6] ? Color.DarkKhaki : Color.LightGray;
            button4.BackColor = result[6] ? Color.LightGray : Color.DarkKhaki;
            //button5.BackColor = result1[6] ? Color.DarkKhaki : Color.LightGray;
           // button7.BackColor = result1[7] ? Color.DarkKhaki : Color.LightGray;
            button9.BackColor = result[4] ? Color.DarkKhaki : Color.LightGray;
            button10.BackColor = result[4] ? Color.LightGray : Color.DarkKhaki;
            button11.BackColor = result2[6] ? Color.DarkKhaki : Color.LightGray;
            button12.BackColor = result2[6] ? Color.LightGray : Color.DarkKhaki;
            button13.BackColor = result2[7] ? Color.DarkKhaki : Color.LightGray;
            button14.BackColor = result2[7] ? Color.LightGray : Color.DarkKhaki;
        }

        private void button1_MouseUp(object sender, MouseEventArgs e)
        {
            PLC_Communication.Model_PLC.man2[10] = false;
        }

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            PLC_Communication.Model_PLC.man2[10] = true;
        }

        private void button2_MouseUp(object sender, MouseEventArgs e)
        {
            PLC_Communication.Model_PLC.man2[11] = false;
        }

        private void button2_MouseDown(object sender, MouseEventArgs e)
        {
            PLC_Communication.Model_PLC.man2[11] = true;
        }

        private void button3_MouseUp(object sender, MouseEventArgs e)
        {
            PLC_Communication.Model_PLC.man2[8] = false;
        }

        private void button3_MouseDown(object sender, MouseEventArgs e)
        {
            PLC_Communication.Model_PLC.man2[8] = true;
        }

        private void button4_MouseUp(object sender, MouseEventArgs e)
        {
            PLC_Communication.Model_PLC.man2[9] = false;
        }

        private void button4_MouseDown(object sender, MouseEventArgs e)
        {
            PLC_Communication.Model_PLC.man2[9] = true;
        }

        private void button5_MouseUp(object sender, MouseEventArgs e)
        {
            PLC_Communication.Model_PLC.man2[12] = true;
        }

        private void button5_MouseDown(object sender, MouseEventArgs e)
        {
            PLC_Communication.Model_PLC.man2[12] = true;
        }

    
        private void button7_MouseUp(object sender, MouseEventArgs e)
        {
            PLC_Communication.Model_PLC.man2[13] = true;
        }

        private void button7_MouseDown(object sender, MouseEventArgs e)
        {
            PLC_Communication.Model_PLC.man2[13] = true;
        }

        private void button9_MouseDown(object sender, MouseEventArgs e)
        {
            PLC_Communication.Model_PLC.button_jog1[10] = true;
        }

        private void button9_MouseUp(object sender, MouseEventArgs e)
        {
            PLC_Communication.Model_PLC.button_jog1[10] = false;
        }

        private void button10_MouseDown(object sender, MouseEventArgs e)
        {
            PLC_Communication.Model_PLC.button_jog1[11] = true;
        }

        private void button10_MouseUp(object sender, MouseEventArgs e)
        {
            PLC_Communication.Model_PLC.button_jog1[11] = false;
        }

        private void button11_MouseDown(object sender, MouseEventArgs e)
        {
            PLC_Communication.Model_PLC.button_jog1[12] = true;
        }

        private void button11_MouseUp(object sender, MouseEventArgs e)
        {
            PLC_Communication.Model_PLC.button_jog1[12] = false;
        }

        private void button12_MouseDown(object sender, MouseEventArgs e)
        {
            PLC_Communication.Model_PLC.button_jog1[13] = true;
        }

        private void button12_MouseUp(object sender, MouseEventArgs e)
        {
            PLC_Communication.Model_PLC.button_jog1[13] = false;
        }

        private void button13_MouseDown(object sender, MouseEventArgs e)
        {
            PLC_Communication.Model_PLC.button_jog1[14] = true;
        }

        private void button13_MouseUp(object sender, MouseEventArgs e)
        {
            PLC_Communication.Model_PLC.button_jog1[14] = false;
        }

        private void button14_MouseDown(object sender, MouseEventArgs e)
        {
            PLC_Communication.Model_PLC.button_jog1[15] = true;
        }

        private void button14_MouseUp(object sender, MouseEventArgs e)
        {
            PLC_Communication.Model_PLC.button_jog1[15] = false ;
        }
    }
}
