using Design_Form.Job_Model;
using DevExpress.Utils.CommonDialogs;
using DevExpress.XtraBars.Docking;
using DevExpress.XtraEditors.Mask.Design;
using HalconDotNet;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
//using ActUtlType64Lib;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Design_Form.PLC_Communication;
using System.Diagnostics;
using DevExpress.XtraPrinting;
using Design_Form.User_PLC;
using DevExpress.ClipboardSource.SpreadsheetML;
using System.Windows.Media.Media3D;
using Design_Form.Monitor_Product_Error;
using DevExpress.Utils.Filtering.Internal;
using System.Net.Sockets;
//using LModbus;

namespace Design_Form
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
      //  ActUtlType64 act_connect;
        bool only_on = true;
        List<HFramegrabber> frameGrabbers = new List<HFramegrabber>();
        List<DockPanel> dockPanels = new List<DockPanel>();
        HalconDotNet.HSmartWindowControl HSmartWindowControl1;
        HalconDotNet.HSmartWindowControl HSmartWindowControl2;
       
        List<HalconDotNet.HSmartWindowControl> hSmartWindowControl = new List<HSmartWindowControl>();
        public bool run_camera1 = false;
        public Thread newThreadLive1;
        public bool run_ALLJOB = false;
        public Thread newThreadRunJob;
        public bool run_camera2 = false;
        public Thread newThreadLive2;
        public bool run_camera4 = false;
        public Thread newThreadLive4;
        public bool runallcamera = false;
        public Thread communication_PLC;
        public bool stop_thread_PLC=false;
        List<Thread> threads = new List<Thread>();
        public bool task1= false;
        public Task newtask1;
        public bool task2 = false;
        public Task newtask2;
        public bool trig = false;
        DataTable table_cam1, table_cam2, table_cam3;
        List<DataTable> tables_Cam;
        PLC_Communication.Model_PLC model_plc;
        private ModbusTCP LX5S;
        private string PLCHostIP = "192.168.1.100";
        private int PLCPort = 502;
        private Thread trd;
        private bool IsConnectPLC = false;
        public ProductError product_ng = new ProductError();
        public Form1()
        {
            InitializeComponent();
            Insert_camera();
            inital_display_Halcon();
            inital_Colum();
            inital_config_machine();
            inital_connect_PLC();
        }
        public void inital_connect_PLC()
        {
            LX5S = new ModbusTCP()
            {
                ID = 1,
                Mode_TCP_Serial = false
            };
            trd = new Thread(new ThreadStart(this.Work_PLC));
            trd.IsBackground = true;
            trd.Start();
        }
        Stopwatch cycletime = new Stopwatch();
        private void Work_PLC()
        {
            try
            {
                while (!stop_thread_PLC)
                {
                    if (LX5S != null)
                    {
                        if (LX5S != null)
                        {
                            if (!LX5S.ConnectTCP(PLCHostIP, PLCPort))
                            {
                                IsConnectPLC = false;
                                Thread.Sleep(1000);
                                PLC_Communication.Model_PLC.connect = false;
                            }
                            else
                            {
                                PLC_Communication.Model_PLC.connect = true;
                              //  cycletime.Restart();
                                PLC_Communication.Model_PLC.Read_from_PLc = LX5S.ReadHoldingRegistersTCPIP(4096, 1000);
                                PLC_Communication.Model_PLC.Read_from_PLc_1 = LX5S.ReadHoldingRegistersTCPIP(6196, 100);
                                PLC_Communication.Model_PLC.parameter_read = LX5S.ReadHoldingRegistersTCPIP(5116, 50);
                                if (only_on&&( PLC_Communication.Model_PLC.lamp_status_plc[0]|| PLC_Communication.Model_PLC.lamp_status_plc[1]|| PLC_Communication.Model_PLC.lamp_status_plc[2]))
                                {
                                    PLC_Communication.Model_PLC.parameter_write = PLC_Communication.Model_PLC.parameter_read;
                                    PLC_Communication.Model_PLC.update_to_read();
                                    PLC_Communication.Model_PLC.pose_wirte_ax1 = PLC_Communication.Model_PLC.pose_read_ax1;
                                    PLC_Communication.Model_PLC.pose_wirte_ax2 = PLC_Communication.Model_PLC.pose_read_ax2;
                                    PLC_Communication.Model_PLC.pose_wirte_ax3 = PLC_Communication.Model_PLC.pose_read_ax3;
                                    PLC_Communication.Model_PLC.pose_wirte_ax4 = PLC_Communication.Model_PLC.pose_read_ax4;
                                    PLC_Communication.Model_PLC.pose_wirte_ax5 = PLC_Communication.Model_PLC.pose_read_ax5;
                                    PLC_Communication.Model_PLC.pose_wirte_ax6 = PLC_Communication.Model_PLC.pose_read_ax6;
                                    PLC_Communication.Model_PLC.pose_wirte_ax7 = PLC_Communication.Model_PLC.pose_read_ax7;
                                    PLC_Communication.Model_PLC.pose_wirte_ax8 = PLC_Communication.Model_PLC.pose_read_ax8;
                                    PLC_Communication.Model_PLC.pose_wirte_ax9 = PLC_Communication.Model_PLC.pose_read_ax9;
                                    PLC_Communication.Model_PLC.pose_wirte_ax10 = PLC_Communication.Model_PLC.pose_read_ax10;
                                    PLC_Communication.Model_PLC.speed_wirte_ax1 = PLC_Communication.Model_PLC.speed_read_ax1;
                                    PLC_Communication.Model_PLC.speed_wirte_ax2 = PLC_Communication.Model_PLC.speed_read_ax2;
                                    PLC_Communication.Model_PLC.speed_wirte_ax3 = PLC_Communication.Model_PLC.speed_read_ax3;
                                    PLC_Communication.Model_PLC.speed_wirte_ax4 = PLC_Communication.Model_PLC.speed_read_ax4;
                                    PLC_Communication.Model_PLC.speed_wirte_ax5 = PLC_Communication.Model_PLC.speed_read_ax5;
                                    PLC_Communication.Model_PLC.speed_wirte_ax6 = PLC_Communication.Model_PLC.speed_read_ax6;
                                    PLC_Communication.Model_PLC.speed_wirte_ax7 = PLC_Communication.Model_PLC.speed_read_ax7;
                                    PLC_Communication.Model_PLC.speed_wirte_ax8 = PLC_Communication.Model_PLC.speed_read_ax8;
                                    PLC_Communication.Model_PLC.speed_wirte_ax9 = PLC_Communication.Model_PLC.speed_read_ax9;
                                    PLC_Communication.Model_PLC.speed_wirte_ax10 = PLC_Communication.Model_PLC.speed_read_ax10;

                                    only_on = false;
                                }
                                PLC_Communication.Model_PLC.update_to_read();
                                PLC_Communication.Model_PLC.update_to_write();
                               if(!only_on)
                                {
                                    int maxRegistersPerRequest = 123;  // Giới hạn theo Modbus TCP
                                    int index = 0;
                                    while (index < PLC_Communication.Model_PLC.Wirte_to_PLC.Length)
                                    {
                                        int chunkSize = Math.Min(maxRegistersPerRequest, PLC_Communication.Model_PLC.Wirte_to_PLC.Length - index);
                                        int[] chunkData = PLC_Communication.Model_PLC.Wirte_to_PLC.Skip(index).Take(chunkSize).ToArray();
                                        LX5S.WriteMultipleRegisters(5096 + index, chunkData);
                                        index += chunkSize;
                                    }
                                    LX5S.WriteMultipleRegisters(6296, PLC_Communication.Model_PLC.Wirte_to_PLC_1);
                                }
                            }
                        }
                    }
                    Thread.Sleep(10);

                }

            }
            catch (Exception ex)
            { }
        }
        public void inital_config_machine()
        {
            string debugFolder = AppDomain.CurrentDomain.BaseDirectory;
            string name_file = "Machine_Config.cam";
            string file_path = Path.Combine(debugFolder, name_file);
            if (!File.Exists(name_file))
            {
                wirte_config(file_path);
            }
            var settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            };

            string json = File.ReadAllText(name_file);
          
            Job_Model.Statatic_Model.config_machine = JsonConvert.DeserializeObject<Config_Machine>(json, settings);
            label4.Text = Job_Model.Statatic_Model.config_machine.cam1_ok.ToString();
            label6.Text = Job_Model.Statatic_Model.config_machine.cam1_ng.ToString();
            label8.Text = Job_Model.Statatic_Model.config_machine.cam1_total.ToString();
            label27.Text = Job_Model.Statatic_Model.config_machine.cam2_ok.ToString();
            label28.Text = Job_Model.Statatic_Model.config_machine.cam2_ng.ToString();
            label31.Text = Job_Model.Statatic_Model.config_machine.cam2_total.ToString();


        }
        public void wirte_config(string file_path)
        {
          Job_Model.Config_Machine config_Machine = new Job_Model.Config_Machine();
            //config_Machine.cam1_total = 0;
            //config_Machine.cam1_ok = 0;
            //config_Machine.cam1_ng = 0;
            //config_Machine.cam2_total = 0;
            //config_Machine.cam2_ok = 0;
            //config_Machine.cam2_ng = 0;
            var settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto,
                Formatting = Formatting.Indented
            };

            string json = JsonConvert.SerializeObject(config_Machine, settings);
            File.WriteAllText(file_path, json);
        }
        public void wirte_data_Result(Config_Machine config_Machine)
        {
            string debugFolder = AppDomain.CurrentDomain.BaseDirectory;
            string name_file = "Machine_Config.cam";
            string file_path = Path.Combine(debugFolder, name_file);

            var settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto,
                Formatting = Formatting.Indented
            };

            string json = JsonConvert.SerializeObject(config_Machine, settings);
            File.WriteAllText(file_path, json);
        }
        public void inital_Colum()
        {
            tables_Cam = new List<DataTable>();
            table_cam1 = new DataTable();
            table_cam2 = new DataTable();
            table_cam3 = new DataTable();
            table_cam1.Clear();
            table_cam1.Columns.Clear();
            table_cam1.Rows.Clear();
            table_cam1.Columns.Add("Job", typeof(string));
            table_cam1.Columns.Add("Result", typeof(string));
            table_cam1.Columns.Add("Barcode", typeof(string));
            table_cam1.Columns.Add("Date", typeof(string));
            table_cam2.Clear();
            table_cam2.Columns.Clear();
            table_cam2.Rows.Clear();
            table_cam2.Columns.Add("Job", typeof(string));
            table_cam2.Columns.Add("Result", typeof(string));
            table_cam2.Columns.Add("Barcode", typeof(string));
            table_cam2.Columns.Add("Date", typeof(string));
            table_cam3.Clear();
            table_cam3.Columns.Clear();
            table_cam3.Rows.Clear();
            table_cam3.Columns.Add("Job", typeof(string));
            table_cam3.Columns.Add("Result", typeof(string));
            table_cam3.Columns.Add("Barcode", typeof(string));
            table_cam3.Columns.Add("Date", typeof(string));
            dataGridView1.DataSource = table_cam1;
            dataGridView2.DataSource = table_cam2;
            dataGridView3.DataSource = table_cam3;
            dataGridView1.Columns[0].Width = 45;
            dataGridView1.Columns[1].Width = 55;
            dataGridView1.Columns[2].Width = 120;
            dataGridView1.Columns[3].Width = 100;
            tables_Cam.Add(table_cam1);
            tables_Cam.Add(table_cam2);
            tables_Cam.Add(table_cam3);
        }
      
      
        private void Insert_camera()
        {

           
            string debugFolder = AppDomain.CurrentDomain.BaseDirectory;
            string name_file = "Cam_Config.cam";
            string file_path = Path.Combine(debugFolder, name_file);
            if(!File.Exists(name_file))
            {
                wirte_camera();
            }
            var settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            };

            string json = File.ReadAllText(name_file);
            List<config_cam> cams = new List<config_cam>();
            cams = JsonConvert.DeserializeObject<List<config_cam>>(json, settings);
            Job_Model.Statatic_Model.model_run.total_camera = cams.Count;
            for(int i = 0;i<cams.Count;i++)
            {
                Job_Model.VisionHalcon cam1 = new Job_Model.VisionHalcon();
                cam1.Device = cams[i].device;
                cam1.name = cams[i].name;
                cam1.TriggerMode = cams[i].TriggerMode;
                cam1.Open_connect_Gige();
                Job_Model.Statatic_Model.Dino_lites.Add(cam1);
            }

        }
        private void wirte_camera()
        {
            List <config_cam> cams = new List<config_cam>();
            Job_Model.config_cam cam1 = new Job_Model.config_cam();
            cam1.device = "000cdf0a2ded_JAICorporation_GO5101MPGE";
            cam1.name = "GigEVision2";
            cam1.TriggerMode = "Off";
            Job_Model.config_cam cam2 = new Job_Model.config_cam();
            cam2.name = "USB3Vision";
            cam2.device = "CAM0";
            cams.Add(cam1);
            cams.Add(cam2);
            string debugFolder = AppDomain.CurrentDomain.BaseDirectory;
            string name_file = "Cam_Config.cam";
            string file_path = Path.Combine(debugFolder, name_file);
            var settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto,
                Formatting = Formatting.Indented
            };

            string json = JsonConvert.SerializeObject(cams, settings);
            File.WriteAllText(file_path, json);
        }
        Stopwatch ab = new Stopwatch();
        public bool[] anh1 = new bool[150];
       
        public void run_cam2()
        {
           
        }
        ShowBarcodeError showBarcodeError;
        private void Run_All_Job_only_one_task_camera2()
        {
           
           

        }
        public void run_cam1()
        {
         
        }
        string result_cam1 = "OK";
        string result_cam1_buff ="OK";  
        private void Run_All_Job_only_one_task()
        {
           
          
        }
        
      
        public void run_ALlJOB()
        {
           

          
        }
     
       
      
        public void stop_livecamera1()
        {
          
        }
        public void stop_plc()
        {
            stop_thread_PLC  = true;
            if (communication_PLC != null)
            { communication_PLC.Join(); }
        }
        private void inital_display_Halcon()
       {
            showBarcodeError = new ShowBarcodeError();
            // Mở form hiển thị ở màn hình phụ
            Screen secondaryScreen = Screen.AllScreens.FirstOrDefault(s => !s.Primary);
            if (secondaryScreen != null)
            {
                showBarcodeError.StartPosition = FormStartPosition.Manual;
                showBarcodeError.Location = secondaryScreen.Bounds.Location;
                showBarcodeError.WindowState = FormWindowState.Maximized;
                showBarcodeError.Show();
            }

            HSmartWindowControl1 = new HalconDotNet.HSmartWindowControl();
        panel_Cam1.Controls.Add(HSmartWindowControl1);
        HSmartWindowControl1.Show();
        HSmartWindowControl1.Dock = DockStyle.Fill;
        HSmartWindowControl1.Load += DisplayHalcon_Load1;
        HSmartWindowControl2 = new HalconDotNet.HSmartWindowControl();
        panel_Cam2.Controls.Add(HSmartWindowControl2);
        HSmartWindowControl2.Show();
        HSmartWindowControl2.Dock = DockStyle.Fill;
        HSmartWindowControl2.Load += DisplayHalcon_Load2;
  
      

        hSmartWindowControl.Add(HSmartWindowControl1);
        hSmartWindowControl.Add(HSmartWindowControl2);
      

        }
        private void DisplayHalcon_Load1(object sender, EventArgs e)
        {
            try
            {
                HSmartWindowControl1.MouseWheel += HSmartWindowControl1.HSmartWindowControl_MouseWheel;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void DisplayHalcon_Load2(object sender, EventArgs e)
        {
            try
            {
                HSmartWindowControl2.MouseWheel += HSmartWindowControl2.HSmartWindowControl_MouseWheel;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
   
       
        private void Form1_Load(object sender, EventArgs e)
        {
         
        }

       
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            wirte_data_Result(Statatic_Model.config_machine);
            stop_livecamera1();
            stop_plc();
        }
        private void dockPanel8_Click(object sender, EventArgs e)
        {

        }

      
        String result_job = "NG";
      

      

        private void timer1_Tick(object sender, EventArgs e)
        {
            result_alljob.Text = result_job;
            if (result_job == "OK")
            {
                panel1.BackColor = Color.Green;
            }
            if(result_job == "WAIT")
            {
                panel1.BackColor = Color.Yellow;
            }
            if (result_job == "NG")
            {
                panel1.BackColor = Color.Red;
            }
            if (PLC_Communication.Model_PLC.lamp_status_plc[0])
            {
                status_auto.Appearance.BackColor = Color.DarkKhaki;
            }
            else
            {
                status_auto.Appearance.BackColor = Color.Transparent;
            }
            if (PLC_Communication.Model_PLC.lamp_status_plc[1])
            {
                status_inital.Appearance.BackColor = Color.DarkKhaki;
            }
            else
            {
                status_inital.Appearance.BackColor = Color.Transparent;
            }
            if (PLC_Communication.Model_PLC.lamp_status_plc[2])
            {
                status_stop.Appearance.BackColor = Color.DarkKhaki;
            }
            else
            {
                status_stop.Appearance.BackColor = Color.Transparent;
            }
            if (PLC_Communication.Model_PLC.lamp_status_plc[3])
            {
                status_pause.Appearance.BackColor = Color.DarkKhaki;
            }
            else
            {
                status_pause.Appearance.BackColor = Color.Transparent;
            }
            update_status(0, statusU1,"Load ");
            update_status(1, statusU2,"Vision 1 ");
            update_status(2, statusU3,"Vision 2 ");
            update_status(3, statusU4,"Transfer ");
            update_status(4, statusU5, "Unload ");
            if (!PLC_Communication.Model_PLC.lamp_status_plc[0])
            {
                task1 = false;
                run_ALLJOB = false;
                task2 = false;
                run_camera1 = false;
                run_camera2 = false;
            }
            if (!task1 && !run_ALLJOB && PLC_Communication.Model_PLC.lamp_status_plc[0]&&!task2&&!run_camera1&&!run_camera2)
            {
                run_cam1();
                run_cam2();
                Run_All_Job_only_one_task_camera2();
                run_ALlJOB();

            }
            if (PLC_Communication.Model_PLC.lamp_status_plc[0])
            {
                label4.Text = Job_Model.Statatic_Model.config_machine.cam1_ok.ToString();
                label6.Text = Job_Model.Statatic_Model.config_machine.cam1_ng.ToString();
                Job_Model.Statatic_Model.config_machine.cam1_total = Job_Model.Statatic_Model.config_machine.cam1_ok + Job_Model.Statatic_Model.config_machine.cam1_ng;
                label8.Text = Job_Model.Statatic_Model.config_machine.cam1_total.ToString();
                label27.Text = Job_Model.Statatic_Model.config_machine.cam2_ok.ToString();
                label28.Text = Job_Model.Statatic_Model.config_machine.cam2_ng.ToString();
                Job_Model.Statatic_Model.config_machine.cam2_total = Job_Model.Statatic_Model.config_machine.cam2_ok + Job_Model.Statatic_Model.config_machine.cam2_ng;
                label31.Text = Job_Model.Statatic_Model.config_machine.cam2_total.ToString();
            }    

        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < tables_Cam.Count; i++)
            {
                tables_Cam[i].Rows.Clear();
                load_data_image_cam_NG(i);
                load_data_image_cam_OK(i);
            }
        }
        private void load_data_image_cam_OK(int index)
        {
                string file_path = Job_Model.Statatic_Model.model_run.File_Path_Image;
                int i = index + 1;
                string file_path_OK= file_path+"\\Camera" +i.ToString()+"\\OK";
                if(Directory.Exists(file_path_OK))
                {
                    string[] files = Directory.GetFiles(file_path_OK, "*.jpg");
                    foreach (string file in files)
                    {
                        string fileName = Path.GetFileNameWithoutExtension(file); // Lấy tên file không có đuôi .jpg
                        ExtractImageInfo(fileName, index);
                    }
                }    
        }
        private void load_data_image_cam_NG(int index)
        {
            string file_path = Job_Model.Statatic_Model.model_run.File_Path_Image;
            int i = index + 1;
            string file_path_OK = file_path + "\\Camera" + i.ToString() + "\\NG";
            if (Directory.Exists(file_path_OK))
            {
                string[] files = Directory.GetFiles(file_path_OK, "*.jpg");
                foreach (string file in files)
                {
                    string fileName = Path.GetFileNameWithoutExtension(file); // Lấy tên file không có đuôi .jpg
                    ExtractImageInfo(fileName, index);
                }
            }

        }
        private void ExtractImageInfo(string fileName,int a)
        {
            try
            {
                // Regex mẫu: YYYYMMDD_Barcode_OKorNG_Index
                string pattern = @"^(\d{8})_(\w+?)_(\w+?)_(\w+?)$";
                Match match = Regex.Match(fileName, pattern);

                if (match.Success)
                {
                    string date = match.Groups[1].Value;
                    string barcode = match.Groups[2].Value;
                    string result = match.Groups[3].Value;
                    string job = match.Groups[4].Value;
                    tables_Cam[a].Rows.Add(job, result, barcode, date);
                    // Chuyển đổi ngày YYYYMMDD -> YYYY-MM-DD
                }
                else
                {
                    Console.WriteLine($"Tên file không hợp lệ: {fileName}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Not Found Data" + ex.ToString());
                Job_Model.Statatic_Model.wirtelog.Log("AL002" + ex.ToString());
            }
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            for(int i = 0;i<tables_Cam.Count;i++)
            {
                tables_Cam[i].Rows.Clear();
                load_data_image_cam_OK(i);
            }    
           
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0) // Đảm bảo chọn đúng dòng
                {
                    HObject InputIMG;
                    string imageFolderPath = "";
                    DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                    string date = row.Cells[3].Value.ToString();
                    string barcode = row.Cells[2].Value.ToString();
                    string result = row.Cells[1].Value.ToString();
                    string job = row.Cells[0].Value.ToString();
                    string imageName = $"{date}_{barcode}_{result}_{job}.jpg";
                    if (result == "OK")
                    {
                        imageFolderPath = Job_Model.Statatic_Model.model_run.File_Path_Image + "\\Camera1\\OK";
                    }
                    if (result == "NG")
                    {
                        imageFolderPath = Job_Model.Statatic_Model.model_run.File_Path_Image + "\\Camera1\\NG";
                    }
                    string imagePath = Path.Combine(imageFolderPath, imageName);
                    HOperatorSet.ReadImage(out InputIMG, imagePath);
                    LoadAndDisplayImage(InputIMG, HSmartWindowControl1);

                }
                
            }
            catch(Exception ex)
            {
                MessageBox.Show("Not Found Data" + ex.ToString());
                Job_Model.Statatic_Model.wirtelog.Log("AL009" + ex.ToString());
            }
           
        }
        public void update_status(int index,Label label,string input)
        {
            
            if (PLC_Communication.Model_PLC.Status_unit[index]==0)
            {
                label.Text = input+"Error";
                label.BackColor = Color.Red;
            }
            if (PLC_Communication.Model_PLC.Status_unit[index] == 1)
            {
                label.Text = input + "Nomarl";
                label.BackColor = Color.BlueViolet;
            }
            if (PLC_Communication.Model_PLC.Status_unit[index] == 2)
            {
                label.Text = input + "IsHomed";
                label.BackColor = Color.Orange;
            }
            if (PLC_Communication.Model_PLC.Status_unit[index] == 3)
            {
                label.Text = input + "Homing";
                label.BackColor = Color.GreenYellow;
            }
            if (PLC_Communication.Model_PLC.Status_unit[index] == 4)
            {
                label.Text = input + "Auto";
                label.BackColor = Color.Green;
            }
            if (PLC_Communication.Model_PLC.Status_unit[index] == 5)
            {
                label.Text = input + "Pause";
                label.BackColor = Color.MistyRose;
            }

        }
        private void LoadAndDisplayImage(HObject image,HSmartWindowControl hSmartWindow)
        {
            try
            {
                // Load ảnh
                HOperatorSet.ClearWindow(hSmartWindow.HalconWindow);
                HOperatorSet.DispObj(image, hSmartWindow.HalconWindow);
                //hSmartWindow.HalconWindow.DispObj(image);
                HTuple imgWidth, imgHeight;
                // Lấy kích thước ảnh
                HOperatorSet.GetImageSize(image,out imgWidth, out imgHeight);

                // Lấy kích thước cửa sổ hiển thị
                int winWidth = hSmartWindow.Width;
                int winHeight = hSmartWindow.Height;
                

                // Tính toán tỷ lệ scale để ảnh FIT vào cửa sổ
                double scaleX = (double)winWidth / imgWidth;
                double scaleY = (double)winHeight / imgHeight;
                double scale = Math.Min(scaleX, scaleY); // Chọn tỷ lệ nhỏ nhất để fit
                int imgwidth1, imgheight1;
                imgwidth1 = (int)imgWidth;
                imgheight1 = (int)imgHeight;
                // Tính toán tọa độ để căn giữa ảnh
                int dispWidth = (int)(imgwidth1 * scale);
                int dispHeight = (int)(imgheight1 * scale);
                HTuple offsetX = (winWidth - dispWidth) / 2;
                HTuple offsetY = (winHeight - dispHeight) / 2;

                // Xóa nội dung cũ và thiết lập hiển thị ảnh đúng tỷ lệ
                HTuple row2, col2;
                row2 = imgHeight - 1 + offsetY;
                col2 = imgWidth - 1 + offsetX;
                hSmartWindow.HalconWindow.SetPart(-offsetY, -offsetX, row2, col2);
              
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi hiển thị ảnh: {ex.Message}");
            }
        }

        private void dockPanel6_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton8_MouseUp(object sender, MouseEventArgs e)
        {
            PLC_Communication.Model_PLC.Button_momentory[1] = false;
            
        }

        private void simpleButton8_MouseDown(object sender, MouseEventArgs e)
        {
            PLC_Communication.Model_PLC.Button_momentory[1] = true;
           
        }

        private void simpleButton9_MouseUp(object sender, MouseEventArgs e)
        {
            PLC_Communication.Model_PLC.Button_momentory[2] = false;
        }

        private void simpleButton9_MouseDown(object sender, MouseEventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Are you sure?", "Confirm", MessageBoxButtons.YesNo);
            if (dlr == DialogResult.Yes)
            {

                PLC_Communication.Model_PLC.Button_momentory[2] = true;
                PLC_Communication.Model_PLC.Auto_Result_PC[0] = false;
                PLC_Communication.Model_PLC.Auto_Result_PC[1] = false;
                Array.Clear(Job_Model.Statatic_Model.Dino_lites[0].input_image, 0, Job_Model.Statatic_Model.Dino_lites[0].input_image.GetLength(0));
                Array.Clear(Job_Model.Statatic_Model.Dino_lites[1].input_image, 0, Job_Model.Statatic_Model.Dino_lites[1].input_image.GetLength(0));
                HOperatorSet.ClearWindow(hSmartWindowControl[0].HalconWindow);
                HOperatorSet.ClearWindow(hSmartWindowControl[1].HalconWindow);
                Task.Delay(500).ContinueWith(_ =>
                {
                    PLC_Communication.Model_PLC.Button_momentory[2] = false;

                }
                    );
             
            }
        }

        private void simpleButton10_MouseUp(object sender, MouseEventArgs e)
        {
            PLC_Communication.Model_PLC.Button_momentory[3] = false;
        }

        private void simpleButton10_MouseDown(object sender, MouseEventArgs e)
        {
               PLC_Communication.Model_PLC.Button_momentory[3] = true;
           
        }

        private void simpleButton11_MouseUp(object sender, MouseEventArgs e)
        {
            PLC_Communication.Model_PLC.Button_momentory_2[6] = false;
        }

        private void simpleButton11_MouseDown(object sender, MouseEventArgs e)
        {
            PLC_Communication.Model_PLC.Button_momentory_2[6] = true;
        }

        private void simpleButton12_MouseUp(object sender, MouseEventArgs e)
        {
            PLC_Communication.Model_PLC.Button_momentory[0] = false;
        }

        private void simpleButton12_MouseDown(object sender, MouseEventArgs e)
        {
            PLC_Communication.Model_PLC.Button_momentory[0] = true;
        }

        private void dockPanel_Cam7_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton2_MouseDown(object sender, MouseEventArgs e)
        {
            PLC_Communication.Model_PLC.Button_momentory_2[7] = true;
        }

        private void simpleButton2_MouseUp(object sender, MouseEventArgs e)
        {
            PLC_Communication.Model_PLC.Button_momentory_2[7] = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Statatic_Model.config_machine.cam1_total = 0;
            Statatic_Model.config_machine.cam1_ok = 0;
            Statatic_Model.config_machine.cam1_ng = 0;
            Statatic_Model.config_machine.cam2_total = 0;
            Statatic_Model.config_machine.cam2_ok = 0;
            Statatic_Model.config_machine.cam2_ng = 0;
            label4.Text = Job_Model.Statatic_Model.config_machine.cam1_ok.ToString();
            label6.Text = Job_Model.Statatic_Model.config_machine.cam1_ng.ToString();
            label8.Text = Job_Model.Statatic_Model.config_machine.cam1_total.ToString();
            label27.Text = Job_Model.Statatic_Model.config_machine.cam2_ok.ToString();
            label28.Text = Job_Model.Statatic_Model.config_machine.cam2_ng.ToString();
            label31.Text = Job_Model.Statatic_Model.config_machine.cam2_total.ToString();
        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < tables_Cam.Count; i++)
            {
                tables_Cam[i].Rows.Clear();
                load_data_image_cam_NG(i);
            }
        }

     
    }
}
