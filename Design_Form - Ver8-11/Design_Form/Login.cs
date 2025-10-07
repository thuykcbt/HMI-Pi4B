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
    public partial class Login : DevExpress.XtraEditors.XtraForm
    {
        public static string level_passwork = null;
        const string pass_Admin = "admin";
        public Login()
        {
            InitializeComponent();
        }
    }
}