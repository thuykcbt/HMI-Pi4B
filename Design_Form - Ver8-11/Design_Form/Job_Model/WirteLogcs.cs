using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Form.Job_Model
{
    public class WirteLogcs
    {
        private readonly string logFilePath;

        public WirteLogcs(string logDirectory)
        {
            // Đảm bảo thư mục log tồn tại
            if (!Directory.Exists(logDirectory))
            {
                Directory.CreateDirectory(logDirectory);
            }

            // Đường dẫn log file
            logFilePath = Path.Combine(logDirectory, $"CameraLog_{DateTime.Now:yyyyMMdd}.log");
        }

        public void Log(string message)
        {
            try
            {
                // Thêm thời gian và ghi log vào file
                string logEntry = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}";
                File.AppendAllText(logFilePath, logEntry + Environment.NewLine);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing log: {ex.Message}");
            }
        }
    }
}
