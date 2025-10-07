using DevExpress.Utils.Win.Hook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Timers;

namespace Design_Form.Job_Model
{
    public class GlobalKeyboardHook
    {
        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;

        private LowLevelKeyboardProc _proc;
        private IntPtr _hookID = IntPtr.Zero;
       // private Timer _clearBufferTimer;
        public int ClearBufferInterval = 1000;

        public event Action<string> OnBarcodeScanned;
        public string _buffer = "";

        public GlobalKeyboardHook()
        {
            //_clearBufferTimer = new Timer(ClearBufferInterval);
            //_clearBufferTimer.Elapsed += ClearBufferOnTimeout;
            //_clearBufferTimer.AutoReset = false; // Không tự động lặp lại, chỉ kích hoạt một lần.
            _proc = HookCallback;
            _hookID = SetHook(_proc);
        }

        public void Dispose()
        {
            UnhookWindowsHookEx(_hookID);
        }

        private IntPtr SetHook(LowLevelKeyboardProc proc)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(WH_KEYBOARD_LL, proc, GetModuleHandle(curModule.ModuleName), 0);
            }
        }

        private IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN)
            {
                int vkCode = Marshal.ReadInt32(lParam);
                char keyChar = (char)vkCode;
                //if(ClearBufferInterval==1000)
                //{
                //    _buffer = "0";
                //    ClearBufferInterval = 0;
                //}    
                // Add character to buffer
                if (char.IsLetterOrDigit(keyChar) || keyChar == '\n')
                {
                    _buffer += keyChar;

                }
                // Check if the barcode is complete
                if (keyChar == '\r'&& _buffer.Length==15) // Scanner thường gửi "Enter" sau khi quét
                {
                    string _buffer1 = _buffer;
                    _buffer = ""; // Clear buffer
                    OnBarcodeScanned?.Invoke(_buffer1.Trim());
                    
                }
            }
            return CallNextHookEx(_hookID, nCode, wParam, lParam);
        }
        private void ClearBufferOnTimeout(object sender, ElapsedEventArgs e)
        {
            // Xóa buffer khi Timer hết hạn
            _buffer = "";
            Console.WriteLine("Buffer cleared due to timeout.");
        }

        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);
    }
}
