using Design_Form.User_PLC;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Design_Form
{
    public partial class Monitor_Form : DevExpress.XtraEditors.XtraForm
    {
        public Monitor_Form()
        {
            InitializeComponent();
            inital_user();

        }
        PLC_Communication.WordConvert convert_plc = new PLC_Communication.WordConvert();
        User_PLC.User_Input user_input1;
        User_PLC.User_Input1 user_input2;
        User_PLC.User_Input2 user_input3;
        User_PLC.User_Input3 user_input4 = new User_PLC.User_Input3();
        User_PLC.User_Output user_output1;
        User_PLC.User_Output1 user_output2;
        User_PLC.User_Output2 user_output3;
        User_PLC.User_Alarm user_alarm1;
        User_PLC.CycleTime cycleTime = new User_PLC.CycleTime();
        User_PLC.Data_Machine data_Machine = new User_PLC.Data_Machine();
        List<SimpleButton> input = new List<SimpleButton>();
        List<SimpleButton> output = new List<SimpleButton>();
        private void inital_user()
        {
            user_input1  = new User_PLC.User_Input();
            user_input2 = new User_PLC.User_Input1();
            user_input3 = new User_PLC.User_Input2();
            user_output1 = new User_PLC.User_Output();
            user_output2 = new User_PLC.User_Output1();
            user_output3 = new User_PLC.User_Output2();
            user_alarm1 = new User_PLC.User_Alarm();
            input.Add(simpleButton2);
            input.Add(simpleButton3);
            input.Add(simpleButton4);
            input.Add(simpleButton8);
            output.Add(simpleButton5);
            output.Add(simpleButton6);
            output.Add(simpleButton7);
            panel1.Controls.Add(user_input1);
            panel1.Controls.Add(user_input2);
            panel1.Controls.Add(user_input3);
            panel1.Controls.Add(user_input4);
            panel2.Controls.Add(user_output1);
            panel2.Controls.Add(user_output2);
            panel2.Controls.Add(user_output3);

            panel3.Controls.Add(user_alarm1);
            panel5.Controls.Add(cycleTime);
            panel6.Controls.Add(data_Machine);
            user_input1.Dock= DockStyle.Fill;
            user_input2.Dock = DockStyle.Fill;
            user_input3.Dock = DockStyle.Fill;
            user_input4.Dock = DockStyle.Fill;
            user_output1.Dock= DockStyle.Fill;
            user_output2.Dock = DockStyle.Fill;
            user_output3.Dock = DockStyle.Fill;
            user_alarm1.Dock= DockStyle.Fill;
            cycleTime.Dock = DockStyle.Fill;
            data_Machine.Dock = DockStyle.Fill;
        }
        private void select_user(Panel a,int select,List<SimpleButton> b)
        {
            for(int i=0;i<a.Controls.Count;i++)
            {
                if(i==select)
                {
                    a.Controls[i].Show();
                    b[i].Appearance.BackColor = Color.Khaki;
                }
                else
                {
                    a.Controls[i].Hide();
                    b[i].Appearance.BackColor = Color.Transparent;
                }    
            }    
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(user_input1!=null)
            {
                user_input1.load_Data();
                user_input2.load_Data();
                user_input3.load_Data();
                user_input4.load_Data();
                user_output1.load_Data();
                user_output2.load_Data();
                user_output3.load_Data();
                user_alarm1.load_Data();
                cycleTime.loaddata();
                data_Machine.loaddata();
            }    
           
        }
        private void simpleButton1_MouseDown(object sender, MouseEventArgs e)
        {
            PLC_Communication.Model_PLC.Button_momentory[0]=true;
        }

        private void simpleButton1_MouseUp(object sender, MouseEventArgs e)
        {
            PLC_Communication.Model_PLC.Button_momentory[0] = false;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            select_user(panel1, 0, input);
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            select_user(panel1, 1, input);
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            select_user(panel1, 2, input);
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            select_user(panel2, 0, output);
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            select_user(panel2, 1, output);
        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            select_user(panel2, 2, output);
        }

        private void simpleButton8_Click(object sender, EventArgs e)
        {
            select_user(panel1, 3, input);
        }
    }
}