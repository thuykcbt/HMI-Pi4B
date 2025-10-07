using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.UserSkins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading;

namespace Design_Form
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]

        static void Main()
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Screen[] screens = Screen.AllScreens;
            //Screen mainScreen = Screen.PrimaryScreen;
           // Screen secondaryScreen = screens.FirstOrDefault(s => !s.Primary);
            //while (true)
            //{
            //    Login login = new Login();
            //    if (login.ShowDialog() == DialogResult.OK)
            //    {
            //        Application.Run(new VisionSoftware());
            //    }
            //    else 
            //    {
            //        break;  
            //    }
            //}
            //DevExpress.UserSkins.BonusSkins.Register();
            //DevExpress.Skins.SkinManager.EnableFormSkins();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
         //   Form1 mainForm = new Form1();
        //    ShowBarcodeError displayForm = new ShowBarcodeError();
            // Mở form điều khiển ở màn hình chính
            //mainForm.StartPosition = FormStartPosition.Manual;
            //mainForm.Location = Screen.PrimaryScreen.Bounds.Location;

            //// Mở form hiển thị ở màn hình phụ
            //Screen secondaryScreen = Screen.AllScreens.FirstOrDefault(s => !s.Primary);
            //if (secondaryScreen != null)
            //{
            //    displayForm.StartPosition = FormStartPosition.Manual;
            //    displayForm.Location = secondaryScreen.Bounds.Location;
            //    displayForm.WindowState = FormWindowState.Maximized;
            //    displayForm.Show();
            //}

            // Thread.Sleep(1000);
            //   if (login.ShowDialog() == DialogResult.OK)
            //   {
             Application.Run(new VisionSoftware());
           // Application.Run(displayForm);
            // Application.Run(login);
            //     }

        }
    }
}
