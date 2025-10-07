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
    public partial class Teach_Point_Axis4_1 : UserControl
    {
        List<Button> button_list_X;

        public Teach_Point_Axis4_1()
        {
            InitializeComponent();
            inital_buttun_select_AxisX();
            update_label_page1();
        }
        private void inital_buttun_select_AxisX()
        {
            button_list_X = new List<Button>();
            button_list_X.Add(button1);
            button_list_X.Add(button2);
            button_list_X.Add(button3);
            button_list_X.Add(button4);
            button_list_X.Add(button5);
            button_list_X.Add(button6);
            button_list_X.Add(button7);
            button_list_X.Add(button8);
            button_list_X.Add(button9);
            button_list_X.Add(button10);
            for (int i = 0; i < button_list_X.Count; i++)
            {
                button_list_X[i].BackColor = Color.Gray;
                button_list_X[i].Click += Button_Click_X;
            }
        }
        private void Button_Click_X(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            if (clickedButton != null)
            {
                int index = button_list_X.IndexOf(clickedButton);
                for (int i = 0; i < button_list_X.Count; i++)
                {
                    button_list_X[i].BackColor = Color.Gray;
                }
                button_list_X[index].BackColor = Color.Green;
                if (index_page == 0)
                {
                    PLC_Communication.Model_PLC.index_pos_call_ax4 = index ;
                }
                if (index_page == 1)
                {
                    PLC_Communication.Model_PLC.index_pos_call_ax4 = index  + 10;
                }
            }
        }

        private void simpleButton36_MouseUp(object sender, MouseEventArgs e)
        {
            PLC_Communication.Model_PLC.Button_momentory[14] = false;
        }

        private void simpleButton36_MouseDown(object sender, MouseEventArgs e)
        {
            PLC_Communication.Model_PLC.Button_momentory[14] = true;
        }

        private void simpleButton35_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton35_MouseUp(object sender, MouseEventArgs e)
        {
            PLC_Communication.Model_PLC.Button_momentory[15] = false;
        }

        private void simpleButton35_MouseDown(object sender, MouseEventArgs e)
        {
            PLC_Communication.Model_PLC.Button_momentory[15] = true;
        }

        private void simpleButton34_MouseDown(object sender, MouseEventArgs e)
        {
            PLC_Communication.Model_PLC.Button_momentory_1[0] = true;
        }

        private void simpleButton34_MouseUp(object sender, MouseEventArgs e)
        {
            PLC_Communication.Model_PLC.Button_momentory_1[0] = false;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (index_page == 0)
            {
                PLC_Communication.Model_PLC.pose_wirte_ax4[0] = (int)(numericUpDown1.Value * 1000);
            }
            if (index_page == 1)
            {
                PLC_Communication.Model_PLC.pose_wirte_ax4[10] = (int)(numericUpDown1.Value * 1000);
            }
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            if (index_page == 0)
            {
                PLC_Communication.Model_PLC.pose_wirte_ax4[1] = (int)(numericUpDown2.Value * 1000);
            }
            if (index_page == 1)
            {
                PLC_Communication.Model_PLC.pose_wirte_ax4[11] = (int)(numericUpDown2.Value * 1000);
            }
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            if (index_page == 0)
            {
                PLC_Communication.Model_PLC.pose_wirte_ax4[2] = (int)(numericUpDown3.Value * 1000);
            }
            if (index_page == 1)
            {
                PLC_Communication.Model_PLC.pose_wirte_ax4[12] = (int)(numericUpDown3.Value * 1000);
            }
        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            if (index_page == 0)
            {
                PLC_Communication.Model_PLC.pose_wirte_ax4[3] = (int)(numericUpDown4.Value * 1000);
            }
            if (index_page == 1)
            {
                PLC_Communication.Model_PLC.pose_wirte_ax4[13] = (int)(numericUpDown4.Value * 1000);
            }
        }

        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {
            if (index_page == 0)
            {
                PLC_Communication.Model_PLC.pose_wirte_ax4[4] = (int)(numericUpDown5.Value * 1000);
            }
            if (index_page == 1)
            {
                PLC_Communication.Model_PLC.pose_wirte_ax4[14] = (int)(numericUpDown5.Value * 1000);
            }
        }

        private void numericUpDown6_ValueChanged(object sender, EventArgs e)
        {
            if (index_page == 0)
            {
                PLC_Communication.Model_PLC.pose_wirte_ax4[5] = (int)(numericUpDown6.Value * 1000);
            }
            if (index_page == 1)
            {
                PLC_Communication.Model_PLC.pose_wirte_ax4[15] = (int)(numericUpDown6.Value * 1000);
            }
        }

        private void numericUpDown7_ValueChanged(object sender, EventArgs e)
        {
            if (index_page == 0)
            {
                PLC_Communication.Model_PLC.pose_wirte_ax4[6] = (int)(numericUpDown7.Value * 1000);
            }
            if (index_page == 1)
            {
                PLC_Communication.Model_PLC.pose_wirte_ax4[16] = (int)(numericUpDown7.Value * 1000);
            }
        }

        private void numericUpDown8_ValueChanged(object sender, EventArgs e)
        {
            if (index_page == 0)
            {
                PLC_Communication.Model_PLC.pose_wirte_ax4[7] = (int)(numericUpDown8.Value * 1000);
            }
            if (index_page == 1)
            {
                PLC_Communication.Model_PLC.pose_wirte_ax4[17] = (int)(numericUpDown8.Value * 1000);
            }
        }

        private void numericUpDown9_ValueChanged(object sender, EventArgs e)
        {
            if (index_page == 0)
            {
                PLC_Communication.Model_PLC.pose_wirte_ax4[8] = (int)(numericUpDown9.Value * 1000);
            }
            if (index_page == 1)
            {
                PLC_Communication.Model_PLC.pose_wirte_ax4[18] = (int)(numericUpDown9.Value * 1000);
            }
        }

        private void numericUpDown10_ValueChanged(object sender, EventArgs e)
        {
            if (index_page == 0)
            {
                PLC_Communication.Model_PLC.pose_wirte_ax4[9] = (int)(numericUpDown10.Value * 1000);
            }
            if (index_page == 1)
            {
                PLC_Communication.Model_PLC.pose_wirte_ax4[19] = (int)(numericUpDown10.Value * 1000);
            }
        }
        public void load_data()
        {
            label1.BackColor = PLC_Communication.Model_PLC.lamp_status_ax4[0] ? Color.DarkKhaki : Color.Red;
            label2.BackColor = PLC_Communication.Model_PLC.lamp_status_ax4[1] ? Color.Red : Color.DarkKhaki;
            label3.BackColor = PLC_Communication.Model_PLC.lamp_status_ax4[2] ? Color.DarkKhaki : Color.Red;
            label4.BackColor = PLC_Communication.Model_PLC.lamp_status_ax4[3] ? Color.Red : Color.DarkKhaki;
            simpleButton35.Appearance.BackColor = PLC_Communication.Model_PLC.lamp_status_ax4[4] ? Color.DarkKhaki : Color.Transparent;
            if (index_page == 0)
            {
                label10.BackColor = PLC_Communication.Model_PLC.lamp_status_ax4_pos[0] ? Color.DarkKhaki : Color.LightGray;
                label12.BackColor = PLC_Communication.Model_PLC.lamp_status_ax4_pos[1] ? Color.DarkKhaki : Color.LightGray;
                label14.BackColor = PLC_Communication.Model_PLC.lamp_status_ax4_pos[2] ? Color.DarkKhaki : Color.LightGray;
                label16.BackColor = PLC_Communication.Model_PLC.lamp_status_ax4_pos[3] ? Color.DarkKhaki : Color.LightGray;
                label18.BackColor = PLC_Communication.Model_PLC.lamp_status_ax4_pos[4] ? Color.DarkKhaki : Color.LightGray;
                label20.BackColor = PLC_Communication.Model_PLC.lamp_status_ax4_pos[5] ? Color.DarkKhaki : Color.LightGray;
                label22.BackColor = PLC_Communication.Model_PLC.lamp_status_ax4_pos[6] ? Color.DarkKhaki : Color.LightGray;
                label24.BackColor = PLC_Communication.Model_PLC.lamp_status_ax4_pos[7] ? Color.DarkKhaki : Color.LightGray;
                label26.BackColor = PLC_Communication.Model_PLC.lamp_status_ax4_pos[8] ? Color.DarkKhaki : Color.LightGray;
                label28.BackColor = PLC_Communication.Model_PLC.lamp_status_ax4_pos[9] ? Color.DarkKhaki : Color.LightGray;
            }
            if (index_page == 1)
            {
                label10.BackColor = PLC_Communication.Model_PLC.lamp_status_ax4_pos[10] ? Color.DarkKhaki : Color.LightGray;
                label12.BackColor = PLC_Communication.Model_PLC.lamp_status_ax4_pos[11] ? Color.DarkKhaki : Color.LightGray;
                label14.BackColor = PLC_Communication.Model_PLC.lamp_status_ax4_pos[12] ? Color.DarkKhaki : Color.LightGray;
                label16.BackColor = PLC_Communication.Model_PLC.lamp_status_ax4_pos[13] ? Color.DarkKhaki : Color.LightGray;
                label18.BackColor = PLC_Communication.Model_PLC.lamp_status_ax4_pos[14] ? Color.DarkKhaki : Color.LightGray;
                label20.BackColor = PLC_Communication.Model_PLC.lamp_status_ax4_pos[15] ? Color.DarkKhaki : Color.LightGray;
                label22.BackColor = PLC_Communication.Model_PLC.lamp_status_ax4_pos1[0] ? Color.DarkKhaki : Color.LightGray;
                label24.BackColor = PLC_Communication.Model_PLC.lamp_status_ax4_pos1[1] ? Color.DarkKhaki : Color.LightGray;
                label26.BackColor = PLC_Communication.Model_PLC.lamp_status_ax4_pos1[2] ? Color.DarkKhaki : Color.LightGray;
                label28.BackColor = PLC_Communication.Model_PLC.lamp_status_ax4_pos1[3] ? Color.DarkKhaki : Color.LightGray;
            }

        }
        public void load_data_pos()
        {
            update_label_page1();
            // Postion load data
            numericUpDown1.Value = (decimal)PLC_Communication.Model_PLC.pose_read_ax4[0] / 1000;
            numericUpDown2.Value = (decimal)PLC_Communication.Model_PLC.pose_read_ax4[1] / 1000;
            numericUpDown3.Value = (decimal)PLC_Communication.Model_PLC.pose_read_ax4[2] / 1000;
            numericUpDown4.Value = (decimal)PLC_Communication.Model_PLC.pose_read_ax4[3] / 1000;
            numericUpDown5.Value = (decimal)PLC_Communication.Model_PLC.pose_read_ax4[4] / 1000;
            numericUpDown6.Value = (decimal)PLC_Communication.Model_PLC.pose_read_ax4[5] / 1000;
            numericUpDown7.Value = (decimal)PLC_Communication.Model_PLC.pose_read_ax4[6] / 1000;
            numericUpDown8.Value = (decimal)PLC_Communication.Model_PLC.pose_read_ax4[7] / 1000;
            numericUpDown9.Value = (decimal)PLC_Communication.Model_PLC.pose_read_ax4[8] / 1000;
            numericUpDown10.Value = (decimal)PLC_Communication.Model_PLC.pose_read_ax4[9] / 1000;
            // Speed load data
            numericUpDown11.Value = (decimal)PLC_Communication.Model_PLC.speed_read_ax4[0];
            numericUpDown12.Value = (decimal)PLC_Communication.Model_PLC.speed_read_ax4[1];
            numericUpDown13.Value = (decimal)PLC_Communication.Model_PLC.speed_read_ax4[2];
            numericUpDown14.Value = (decimal)PLC_Communication.Model_PLC.speed_read_ax4[3];
            numericUpDown15.Value = (decimal)PLC_Communication.Model_PLC.speed_read_ax4[4];
            numericUpDown16.Value = (decimal)PLC_Communication.Model_PLC.speed_read_ax4[5];
            numericUpDown17.Value = (decimal)PLC_Communication.Model_PLC.speed_read_ax4[6];
            numericUpDown18.Value = (decimal)PLC_Communication.Model_PLC.speed_read_ax4[7];
            numericUpDown19.Value = (decimal)PLC_Communication.Model_PLC.speed_read_ax4[8];
            numericUpDown20.Value = (decimal)PLC_Communication.Model_PLC.speed_read_ax4[9];

        }

        private void numericUpDown11_ValueChanged(object sender, EventArgs e)
        {
            if (index_page == 0)
            {
                PLC_Communication.Model_PLC.speed_wirte_ax4[0] = (int)numericUpDown11.Value;
            }
            if (index_page == 1)
            {
                PLC_Communication.Model_PLC.speed_wirte_ax4[10] = (int)numericUpDown11.Value;
            }
        }

        private void numericUpDown12_ValueChanged(object sender, EventArgs e)
        {
            if (index_page == 0)
            {
                PLC_Communication.Model_PLC.speed_wirte_ax4[1] = (int)numericUpDown12.Value;
            }
            if (index_page == 1)
            {
                PLC_Communication.Model_PLC.speed_wirte_ax4[11] = (int)numericUpDown12.Value;
            }
        }

        private void numericUpDown13_ValueChanged(object sender, EventArgs e)
        {
            if (index_page == 0)
            {
                PLC_Communication.Model_PLC.speed_wirte_ax4[2] = (int)numericUpDown13.Value;
            }
            if (index_page == 1)
            {
                PLC_Communication.Model_PLC.speed_wirte_ax4[12] = (int)numericUpDown13.Value;
            }
        }

        private void numericUpDown14_ValueChanged(object sender, EventArgs e)
        {
            if (index_page == 0)
            {
                PLC_Communication.Model_PLC.speed_wirte_ax4[3] = (int)numericUpDown14.Value;
            }
            if (index_page == 1)
            {
                PLC_Communication.Model_PLC.speed_wirte_ax4[13] = (int)numericUpDown14.Value;
            }
        }

        private void numericUpDown15_ValueChanged(object sender, EventArgs e)
        {
            if (index_page == 0)
            {
                PLC_Communication.Model_PLC.speed_wirte_ax4[4] = (int)numericUpDown15.Value;
            }
            if (index_page == 1)
            {
                PLC_Communication.Model_PLC.speed_wirte_ax4[14] = (int)numericUpDown15.Value;
            }
        }

        private void numericUpDown16_ValueChanged(object sender, EventArgs e)
        {
            if (index_page == 0)
            {
                PLC_Communication.Model_PLC.speed_wirte_ax4[5] = (int)numericUpDown16.Value;
            }
            if (index_page == 1)
            {
                PLC_Communication.Model_PLC.speed_wirte_ax4[15] = (int)numericUpDown16.Value;
            }
        }

        private void numericUpDown17_ValueChanged(object sender, EventArgs e)
        {
            if (index_page == 0)
            {
                PLC_Communication.Model_PLC.speed_wirte_ax4[6] = (int)numericUpDown17.Value;
            }
            if (index_page == 1)
            {
                PLC_Communication.Model_PLC.speed_wirte_ax4[16] = (int)numericUpDown17.Value;
            }
        }

        private void numericUpDown18_ValueChanged(object sender, EventArgs e)
        {
            if (index_page == 0)
            {
                PLC_Communication.Model_PLC.speed_wirte_ax4[7] = (int)numericUpDown18.Value;
            }
            if (index_page == 1)
            {
                PLC_Communication.Model_PLC.speed_wirte_ax4[17] = (int)numericUpDown18.Value;
            }
        }

        private void numericUpDown19_ValueChanged(object sender, EventArgs e)
        {
            if (index_page == 0)
            {
                PLC_Communication.Model_PLC.speed_wirte_ax4[8] = (int)numericUpDown19.Value;
            }
            if (index_page == 1)
            {
                PLC_Communication.Model_PLC.speed_wirte_ax4[18] = (int)numericUpDown19.Value;
            }
        }

        private void numericUpDown20_ValueChanged(object sender, EventArgs e)
        {
            if (index_page == 0)
            {
                PLC_Communication.Model_PLC.speed_wirte_ax4[9] = (int)numericUpDown20.Value;
            }
            if (index_page == 1)
            {
                PLC_Communication.Model_PLC.speed_wirte_ax4[19] = (int)numericUpDown20.Value;
            }
        }
        public int index_page = 0;
        public void update_label_page1()
        {
            label10.Text = "Home Pos";
            label12.Text = "Check Point 1";
            label14.Text = "Check Point 2";
            label16.Text = "Check Point 3";
            label18.Text = "Check Point 4";
            label20.Text = "Check Point 5";
            label22.Text = "Check Point 6";
            label24.Text = "Check Point 7";
            label26.Text = "Check Point 8";
            label28.Text = "Check Point 9";
        }
        public void update_label_page2()
        {
            label10.Text = "Check Point 10";
            label12.Text = "Check Point 11";
            label14.Text = "Check Point 12";
            label16.Text = "Check Point 13";
            label18.Text = "Check Point 14";
            label20.Text = "Check Point 15";
            label22.Text = "Check Point 16";
            label24.Text = "Check Point 17";
            label26.Text = "Check Point 18";
            label28.Text = "Check Point 19";
        }
        public void load_data_page2()
        {
            update_label_page2();
            // Postion load data
            numericUpDown1.Value = (decimal)PLC_Communication.Model_PLC.pose_read_ax4[10] / 1000;
            numericUpDown2.Value = (decimal)PLC_Communication.Model_PLC.pose_read_ax4[11] / 1000;
            numericUpDown3.Value = (decimal)PLC_Communication.Model_PLC.pose_read_ax4[12] / 1000;
            numericUpDown4.Value = (decimal)PLC_Communication.Model_PLC.pose_read_ax4[13] / 1000;
            numericUpDown5.Value = (decimal)PLC_Communication.Model_PLC.pose_read_ax4[14] / 1000;
            numericUpDown6.Value = (decimal)PLC_Communication.Model_PLC.pose_read_ax4[15] / 1000;
            numericUpDown7.Value = (decimal)PLC_Communication.Model_PLC.pose_read_ax4[16] / 1000;
            numericUpDown8.Value = (decimal)PLC_Communication.Model_PLC.pose_read_ax4[17] / 1000;
            numericUpDown9.Value = (decimal)PLC_Communication.Model_PLC.pose_read_ax4[18] / 1000;
            numericUpDown10.Value = (decimal)PLC_Communication.Model_PLC.pose_read_ax4[19] / 1000;
            // Speed load data
            numericUpDown11.Value = (decimal)PLC_Communication.Model_PLC.speed_read_ax4[10];
            numericUpDown12.Value = (decimal)PLC_Communication.Model_PLC.speed_read_ax4[11];
            numericUpDown13.Value = (decimal)PLC_Communication.Model_PLC.speed_read_ax4[12];
            numericUpDown14.Value = (decimal)PLC_Communication.Model_PLC.speed_read_ax4[13];
            numericUpDown15.Value = (decimal)PLC_Communication.Model_PLC.speed_read_ax4[14];
            numericUpDown16.Value = (decimal)PLC_Communication.Model_PLC.speed_read_ax4[15];
            numericUpDown17.Value = (decimal)PLC_Communication.Model_PLC.speed_read_ax4[16];
            numericUpDown18.Value = (decimal)PLC_Communication.Model_PLC.speed_read_ax4[17];
            numericUpDown19.Value = (decimal)PLC_Communication.Model_PLC.speed_read_ax4[18];
            numericUpDown20.Value = (decimal)PLC_Communication.Model_PLC.speed_read_ax4[19];
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            update_label_page2();
            index_page = 1;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            update_label_page1();
            index_page = 0;
        }


    }

}
