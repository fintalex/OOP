using System;
using System.Windows.Forms;
using Log4NetLibrary;

namespace Log4NetFramework.WinForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ILogService logService = new FileLogService(typeof(Form1));
            logService.Error("Just an information from Windows Form app");
            label1.Text = "Log is written successfully";
        }
    }
}
