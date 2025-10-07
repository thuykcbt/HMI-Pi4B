using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Internal.WinApi.Windows.UI.Notifications;
using DevExpress.XtraPrinting;

namespace Design_Form.User_PLC
{
    public partial class Data_Machine: UserControl
    {

        List<Button> Button_confirm = new List<Button>();
        List<Button> Button_clear = new List<Button>();
        List<Label> lamp_data = new List<Label>();
        List<ComboBox> select_Data = new List<ComboBox>();
        PLC_Communication.WordConvert convert = new PLC_Communication.WordConvert();
        bool check_update = false;
        public Data_Machine()
        {
            InitializeComponent();
            lamp_data.Add(label7);
            lamp_data.Add(label8);
            lamp_data.Add(label9);
            lamp_data.Add(label10);
            lamp_data.Add(label11);
            lamp_data.Add(label12);
            Button_confirm.Add(button7);
            Button_confirm.Add(button8);
            Button_confirm.Add(button9);
            Button_confirm.Add(button10);
            Button_confirm.Add(button11);
            Button_confirm.Add(button12);
            Button_clear.Add(button1);
            Button_clear.Add(button2);
            Button_clear.Add(button3);
            Button_clear.Add(button4);
            Button_clear.Add(button5);
            Button_clear.Add(button6);
            select_Data.Add(comboBox1);
            select_Data.Add(comboBox2);
            select_Data.Add(comboBox3);
            select_Data.Add(comboBox4);
            select_Data.Add(comboBox5);
            select_Data.Add(comboBox6);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PLC_Communication.Model_PLC.Control_Data[0] = 99;
            PLC_Communication.Model_PLC.agree_write = true;
        }
        private void send_confirm_Data(int index)
        {
            if (select_Data[index].SelectedIndex==0)
            {
                PLC_Communication.Model_PLC.Control_Data[index] = 99;
            }
            if (select_Data[index].SelectedIndex == 1)
            {
                PLC_Communication.Model_PLC.Control_Data[index] = 1;
            }
            PLC_Communication.Model_PLC.agree_write = true;
        }
        public void loaddata()
        {
            if (PLC_Communication.Model_PLC.IO_Resigter[11] == 0)
            {
                lamp_data[0].BackColor = Color.Gray;
            }
            if (PLC_Communication.Model_PLC.IO_Resigter[11] == 1)
            {
                lamp_data[0].BackColor = Color.Green;
            }
            if (PLC_Communication.Model_PLC.IO_Resigter[12] == 0)
            {
                lamp_data[1].BackColor = Color.Gray;
            }
            if (PLC_Communication.Model_PLC.IO_Resigter[12] == 1)
            {
                lamp_data[1].BackColor = Color.Red;
            }
            if (PLC_Communication.Model_PLC.IO_Resigter[12] == 2)
            {
                lamp_data[1].BackColor = Color.Green;
            }
            if (PLC_Communication.Model_PLC.IO_Resigter[12] == 3)
            {
                lamp_data[1].BackColor = Color.Red;
            }
            if (PLC_Communication.Model_PLC.IO_Resigter[13] == 0)
            {
                lamp_data[2].BackColor = Color.Gray;
            }
            if (PLC_Communication.Model_PLC.IO_Resigter[13] == 1)
            {
                lamp_data[2].BackColor = Color.Red;
            }
            if (PLC_Communication.Model_PLC.IO_Resigter[13] == 2)
            {
                lamp_data[2].BackColor = Color.Green;
            }
            if (PLC_Communication.Model_PLC.IO_Resigter[13] == 3)
            {
                lamp_data[2].BackColor = Color.Red;
            }
            if (PLC_Communication.Model_PLC.IO_Resigter[13] == 4)
            {
                lamp_data[2].BackColor = Color.Green;
            }
            if (PLC_Communication.Model_PLC.IO_Resigter[13] == 5)
            {
                lamp_data[2].BackColor = Color.Red;
            }
            if (PLC_Communication.Model_PLC.IO_Resigter[14] == 0)
            {
                lamp_data[3].BackColor = Color.Gray;
            }
            if (PLC_Communication.Model_PLC.IO_Resigter[14] == 1)
            {
                lamp_data[3].BackColor = Color.Red;
            }
            if (PLC_Communication.Model_PLC.IO_Resigter[14] == 2)
            {
                lamp_data[3].BackColor = Color.Green;
            }
            if (PLC_Communication.Model_PLC.IO_Resigter[14] == 3)
            {
                lamp_data[3].BackColor = Color.Red;
            }
            if (PLC_Communication.Model_PLC.IO_Resigter[15] == 0)
            {
                lamp_data[4].BackColor = Color.Gray;
            }
            if (PLC_Communication.Model_PLC.IO_Resigter[15] == 4)
            {
                lamp_data[4].BackColor = Color.Green;
            }
            if (PLC_Communication.Model_PLC.IO_Resigter[16] == 0)
            {
                lamp_data[5].BackColor = Color.Gray;
            }
            if (PLC_Communication.Model_PLC.IO_Resigter[16] == 3)
            {
                lamp_data[5].BackColor = Color.Green;
            }
            if (PLC_Communication.Model_PLC.IO_Resigter[16] == 5)
            {
                lamp_data[5].BackColor = Color.Green;
            }
        }
        private void button7_Click(object sender, EventArgs e)
        {
            send_confirm_Data(0);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            send_confirm_Data(1);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            send_confirm_Data(2);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            send_confirm_Data(3);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            send_confirm_Data(4);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            send_confirm_Data(5);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PLC_Communication.Model_PLC.Control_Data[1] = 99;
            PLC_Communication.Model_PLC.agree_write = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PLC_Communication.Model_PLC.Control_Data[2] = 99;
            PLC_Communication.Model_PLC.agree_write = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            PLC_Communication.Model_PLC.Control_Data[3] = 99;
            PLC_Communication.Model_PLC.agree_write = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            PLC_Communication.Model_PLC.Control_Data[4] = 99;
            PLC_Communication.Model_PLC.agree_write = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            PLC_Communication.Model_PLC.Control_Data[5] = 99;
            PLC_Communication.Model_PLC.agree_write = true;
        }
    }
}
