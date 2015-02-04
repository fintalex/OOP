using System.Windows;
using Log4NetLibrary;

namespace Log4NetFramework.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ILogService logService = new FileLogService(typeof(MainWindow));
            logService.Info("Just an information from WPF app");
            tbStatus.Text = "Log is written successfully";
           
        }
    }
}
