using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OATControlWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ASCOM.DriverAccess.Telescope _telescope;
        private OpenAstroTracker _oat;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnChoose_Click(object sender, RoutedEventArgs e)
        {
            var chooser = new ASCOM.Utilities.Chooser();
            chooser.DeviceType = "Telescope";
            String progID = chooser.Choose();
            lblTelescope.Content = progID;
        }

        private void btnOpen_Click(object sender, RoutedEventArgs e)
        {
            _oat = new OpenAstroTracker(txtComPort.Text);
        }

        private void txtSend_Click(object sender, RoutedEventArgs e)
        {
            String command = txtCommand.Text;
            tbLog.Text += command + "\n";
            String response = _oat.SendCommand(txtCommand.Text);
            tbLog.Text += response + "\n";
        }
    }
}
