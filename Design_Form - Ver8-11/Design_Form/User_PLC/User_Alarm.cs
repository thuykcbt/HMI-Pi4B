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
    public partial class User_Alarm : UserControl
    {
        List<PLC_Communication.AlarmList> alarmList = new List<PLC_Communication.AlarmList>();
        PLC_Communication.WordConvert convert = new  PLC_Communication.WordConvert();
        DataTable data_alrm = new DataTable();
        public User_Alarm()
        {
            InitializeComponent();
            inital_datatable();
            inital_alramlist();
        }
      
        private void inital_alramlist()
        {
            for (int i = 0; i < 100; i++)
            {
                PLC_Communication.AlarmList al_add = new PLC_Communication.AlarmList(i);
                alarmList.Add(al_add);
            }

        }
        private void inital_datatable()
        {
            data_alrm.Clear();
            data_alrm.Columns.Clear();
            data_alrm.Rows.Clear();
            data_alrm.Columns.Add("Date Time", typeof(string));
         //   data_alrm.Columns.Add("Error Code", typeof(string));
            data_alrm.Columns.Add("Name Code", typeof(string));
            dataGridView1.DataSource = data_alrm;
            dataGridView1.Columns[0].Width = 220;
        //    dataGridView1.Columns[1].Width = 120;
            dataGridView1.Columns[1].Width = 1000;
        }
        public void load_Data()
        {
            bool[] al1 = new bool[16];
            bool[] al2 = new bool[16];
            bool[] al3 = new bool[16];
            al1 = convert.WordTo16Bit(PLC_Communication.Model_PLC.Read_from_PLc[20]);
            al2 = convert.WordTo16Bit(PLC_Communication.Model_PLC.Read_from_PLc[21]);
            al3 = convert.WordTo16Bit(PLC_Communication.Model_PLC.Read_from_PLc[22]);
            data_alrm.Rows.Clear();
            for (int i = 0; i < 16; i++)
            {
                if (al1[i])
                {
                    if (!alarmList[i].alarm)
                    {
                        alarmList[i].date_Time = DateTime.Now.ToString();
                    }
                    alarmList[i].alarm = true;
                    data_alrm.Rows.Add(alarmList[i].date_Time, alarmList[i].name_Code);
                }
                else
                {
                    alarmList[i].alarm = false;
                }
            
            }
            for (int i = 0; i < 16; i++)
            {
                if (al2[i])
                {
                    if (!alarmList[16+i].alarm)
                    {
                        alarmList[16+i].date_Time = DateTime.Now.ToString();
                    }
                    alarmList[i+16].alarm = true;
                    data_alrm.Rows.Add(alarmList[i+16].date_Time, alarmList[i+16].name_Code);
                }
                else
                {
                    alarmList[i+16].alarm = false;
                }

            }
            for (int i = 0; i <16; i++)
            {
                if (al3[i])
                {
                    if (!alarmList[32 + i].alarm)
                    {
                        alarmList[32+i].date_Time = DateTime.Now.ToString();
                    }
                    alarmList[i + 32].alarm = true;
                    data_alrm.Rows.Add(alarmList[i + 32].date_Time, alarmList[i + 32].name_Code);
                }
                else
                {
                    alarmList[i + 32].alarm = false;
                }

            }
            dataGridView1.DataSource = data_alrm;
        }
    }
}
