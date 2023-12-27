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
using AduSkin.Controls.Metro;
using Autofac.Core;
using Client.Service.Interface;

namespace Client.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        private readonly ITestService _service;
        public MainWindow(ITestService service)
        {
            _service = service;
            InitializeComponent();
        }

        private async void AduFlatButton_Click(object sender, RoutedEventArgs e)
        {
            string data = await _service.GetData();
            MessageBox.Show(data);
        }
    }
}
