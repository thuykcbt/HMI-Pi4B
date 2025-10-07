using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Form.Monitor_Product_Error
{
    public class ProductError
    {
        public List<Job_error> Job_Error_Cam1 = new List<Job_error>();
        public List<Job_error> Job_Error_Cam2 = new List<Job_error>();
        public string Barcode { get; set; } = "none";
    }
    public class Job_error
    {
        public string name_job_err { get; set; }
        public int index_job { get; set; }
        public HObject Image_Error_Cam = new HObject();

    }
}
