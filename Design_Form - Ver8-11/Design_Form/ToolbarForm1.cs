using Design_Form.Job_Model;
using DevExpress.DocumentServices.ServiceModel.DataContracts;
using DevExpress.Export.Xl;
using DevExpress.XtraBars;
using DevExpress.XtraSplashScreen;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Design_Form
{
    public partial class VisionSoftware : DevExpress.XtraEditors.XtraForm
    {
        int current_Window = 0;
        private Form activeForm;
        private Button currentButton;
        Form1 form1;
        Setting setting;
        LiveCamera livecamera;
        ReportForm report;
        PLC_Form plc_Form;
        Monitor_Form monitor_Form;
        PopUp_NG Popup_NG;
        private GlobalKeyboardHook _keyboardHook;
        public VisionSoftware()
        {
            InitializeComponent();
            inital_form();
            inital_hockup();
            inital_button_cam();
            timer1.Enabled = true;
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("Liquid Sky");
            
        }
        private void inital_hockup()
        {
            try
            {
                _keyboardHook = new GlobalKeyboardHook();
                _keyboardHook.OnBarcodeScanned += barcode =>
                {
                    
                    // MessageBox.Show($"Barcode: {barcode}");
                    show_popup_ng(barcode);
                    Console.WriteLine(barcode.ToString());
                };

            }
            catch (Exception ex)
            {
                MessageBox.Show("No Data Code Found");
                Job_Model.Statatic_Model.wirtelog.Log(ex.ToString());
            }
        }
        private void inital_form()
        {
            if (form1 == null)
            { form1 = new Form1(); }
            if (setting == null)
            { setting = new Setting(); }
            if(livecamera == null)
            { livecamera = new LiveCamera(); }
            if(report == null)
            { report = new ReportForm(); }  
            if(plc_Form == null)
            { plc_Form = new PLC_Form(); }
            if(monitor_Form == null)
            { monitor_Form = new Monitor_Form();}    
        }
        private void ToolbarForm1_Load(object sender, EventArgs e)
        {
            Check_level_Login();
            ShowChildForm(form1);


        }
        private void Check_level_Login()
        {
            if (Login.level_passwork == "Operator")
            {
              //  barButtonSetting.Enabled = false;
            }
        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }
        private void load_inital_form()
        {
            
        }
        private void ShowChildForm(Form childForm)
        {
           try
            {
                if (this.Mainpanel.Controls.Count > 0)
                {
                    this.Mainpanel.Controls.Remove(activeForm);
                }
                if (activeForm != null)
                    activeForm.Hide();
                activeForm = childForm;
                // Cài đặt Child Form
                childForm.TopLevel = false; // Form không phải cửa sổ độc lập
                childForm.FormBorderStyle = FormBorderStyle.None; // Loại bỏ viền Form
                childForm.Dock = DockStyle.Fill; // Phủ kín Panel
                Mainpanel.Controls.Add(childForm);
                Mainpanel.Tag = childForm;
                childForm.Show();
            }
           
             catch (Exception ex)
            {
                Job_Model.Statatic_Model.wirtelog.Log(ex.ToString());
            }
        }

        private void barButtonSetting_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (current_Window != 1)
                {

                    SplashScreenManager.ShowForm(this, typeof(WaitForm1), true, true, false);
                    ShowChildForm(setting);
                    // clean_up();
                    SplashScreenManager.CloseForm();
                    current_Window = 1;
                    barButtonSetting.Enabled = false;
                    btnLivecamera.Enabled = true;
                    btn_Home.Enabled = true;
                    setting.timer1.Enabled = true;
                    barReport.Enabled = true;
                    bar_Monitor.Enabled = true;
                    barPLC_Form.Enabled = true;
                    livecamera.stop_livecamera1();
                    monitor_Form.timer1.Enabled=false;
                    plc_Form.timer1.Enabled = false;
                    plc_Form.stop_livecamera1();
                    plc_Form.stop_livecamera2();

                }
            }
            catch (Exception ex) { Job_Model.Statatic_Model.wirtelog.Log(ex.ToString()); }
            
        }

        private void btn_Home_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (current_Window != 0)
                {
                    btn_Home.Enabled = false;
                    btnLivecamera.Enabled = true;
                    barButtonSetting.Enabled = true;
                    barReport.Enabled = true;
                    bar_Monitor.Enabled = true;
                    barPLC_Form.Enabled = true;
                    ShowChildForm(form1);
                    current_Window = 0;
                    setting.timer1.Enabled = false;
                    livecamera.stop_livecamera1();
                    form1.label1.Text = Job_Model.Statatic_Model.model_run.Name_Model.ToString();
                    monitor_Form.timer1.Enabled = false;
                    plc_Form.timer1.Enabled = false;
                    plc_Form.stop_livecamera1();
                    plc_Form.stop_livecamera2();
                }
            }
            catch (Exception ex) { Job_Model.Statatic_Model.wirtelog.Log(ex.ToString()); }
           
        }

        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (current_Window != 2)
                {
                    btn_Home.Enabled = true;
                    barButtonSetting.Enabled = true;
                    barReport.Enabled = true;
                    bar_Monitor.Enabled = true;
                    barPLC_Form.Enabled = true;
                    btnLivecamera.Enabled = false;
                    ShowChildForm(livecamera);
                    current_Window = 2;
                    setting.timer1.Enabled = false;
                    monitor_Form.timer1.Enabled = false;
                    plc_Form.timer1.Enabled = false;
                    plc_Form.stop_livecamera1();
                    plc_Form.stop_livecamera2();
                }
            }
            catch (Exception ex) { Job_Model.Statatic_Model.wirtelog.Log(ex.ToString()); }
            
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (current_Window != 3)
                {
                    btn_Home.Enabled = true;
                    barButtonSetting.Enabled = true;
                    btnLivecamera.Enabled = true;
                    bar_Monitor.Enabled = true;
                    barPLC_Form.Enabled = true;
                    barReport.Enabled = false;
                    ShowChildForm(report);
                    current_Window = 3;
                    setting.timer1.Enabled = false;
                    livecamera.stop_livecamera1();
                    monitor_Form.timer1.Enabled = false;
                    plc_Form.timer1.Enabled = false;
                    plc_Form.stop_livecamera1();
                    plc_Form.stop_livecamera2();
                }
            }
            catch (Exception ex) { Job_Model.Statatic_Model.wirtelog.Log(ex.ToString()); }
            
        }
        private void barPLC_Form_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (current_Window != 4)
                {
                    btn_Home.Enabled = true;
                    barButtonSetting.Enabled = true;
                    btnLivecamera.Enabled = true;
                    barReport.Enabled = true;
                    bar_Monitor.Enabled = true;
                    barPLC_Form.Enabled = false;
                    ShowChildForm(plc_Form);
                    current_Window = 4;
                    setting.timer1.Enabled = false;
                    livecamera.stop_livecamera1();
                    monitor_Form.timer1.Enabled = false;
                    plc_Form.timer1.Enabled = true;
                    plc_Form.loaddata_pose();
                }
            }
            catch(Exception ex)
            {
                Job_Model.Statatic_Model.wirtelog.Log(ex.ToString());
            }
           
        }

        private void barButtonItem4_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (current_Window != 5)
                {
                    btn_Home.Enabled = true;
                    barButtonSetting.Enabled = true;
                    btnLivecamera.Enabled = true;
                    barReport.Enabled = true;
                    bar_Monitor.Enabled = false;
                    barPLC_Form.Enabled = true;
                    ShowChildForm(monitor_Form);
                    current_Window = 5;
                    setting.timer1.Enabled = false;
                    livecamera.stop_livecamera1();
                    monitor_Form.timer1.Enabled = true;
                    plc_Form.timer1.Enabled = false;
                    plc_Form.stop_livecamera1();
                    plc_Form.stop_livecamera2();
                }
            }
            catch (Exception ex)
            {
                Job_Model.Statatic_Model.wirtelog.Log(ex.ToString());
            }
           
        }
        List<BarStaticItem> bars_button = new List<BarStaticItem>();
        
        private void inital_button_cam()
        {
          
            bars_button.Add(bar_Camera1);
            bars_button.Add(bar_Camera2);
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                
                if (_keyboardHook.ClearBufferInterval < 1000)
                {
                    _keyboardHook.ClearBufferInterval += 100;
                }
                if (_keyboardHook.ClearBufferInterval >= 1000)
                {
                    _keyboardHook._buffer = "";
                    _keyboardHook.ClearBufferInterval = 0;
                }

                if (PLC_Communication.Model_PLC.connect)
                {
                    barPLC_Connect.ImageOptions.SvgImage = Properties.Resources.ok;
                }
                else
                {
                    barPLC_Connect.ImageOptions.SvgImage = Properties.Resources.failure;
                }
                for (int i = 0; i < Job_Model.Statatic_Model.Dino_lites.Count; i++)
                {
                    if (Job_Model.Statatic_Model.Dino_lites[i].lamp_vision_connected)
                    {
                        bars_button[i].ImageOptions.SvgImage = Properties.Resources.ok;
                    }
                    else
                    {
                        bars_button[i].ImageOptions.SvgImage = Properties.Resources.failure;
                    }
                }
            }
            catch (Exception ex)
            {

            }
           
        }

        private void ToolbarForm1_FormClosing(object sender, FormClosingEventArgs e)
        {
            form1.stop_livecamera1();
            form1.stop_plc();
            plc_Form.stop_livecamera1();
            plc_Form.stop_livecamera2();
            string debugFolder = AppDomain.CurrentDomain.BaseDirectory;
            string name_file = "Machine_Config.cam";
            string file_path = Path.Combine(debugFolder, name_file);
            var settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto,
                Formatting = Formatting.Indented
            };

            string json = JsonConvert.SerializeObject(Job_Model.Statatic_Model.config_machine, settings);
            File.WriteAllText(file_path, json);

        }

        private void barButtonItem4_ItemClick_2(object sender, ItemClickEventArgs e)
        {
           
        }
        private void show_popup_ng(string data_code)
        {
            try
            {
                Popup_NG = new PopUp_NG();
                Popup_NG.barcode_check = data_code;
                Popup_NG.load_result_now(data_code);
                Popup_NG.ShowDialog();
            }
            catch (Exception ex)
            {
                Job_Model.Statatic_Model.wirtelog.Log(ex.ToString());
             
            }
         
            
        }

       
    }
}