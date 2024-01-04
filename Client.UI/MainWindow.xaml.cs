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
using Autofac.Core;
using Client.Service.Interface;
using Client.UI.Extensions;
using Client.UI.UserControl;
using HandyControl.Tools;

namespace Client.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : HandyControl.Controls.Window
    {
        private readonly ITestService _service;
        private IAbstractFactory<TestWindow> _factory;
        private IAbstractFactory<DataTimeControl> _factory2;
        private IAbstractFactory<ExamSettingControl> _factory3;

        
        public MainWindow(ITestService service, IAbstractFactory<TestWindow> factory,IAbstractFactory<DataTimeControl> factory2, IAbstractFactory<ExamSettingControl> factory3)
        {
            _service = service;
            _factory = factory;
            _factory2 = factory2;
            _factory3 = factory3;
            InitializeComponent();
            this.Title = "云阅卷";
            ConfigHelper.Instance.SetWindowDefaultStyle();
        }

        private async void AduFlatButton_Click(object sender, RoutedEventArgs e)
        {
            string data = await _service.GetData();
            HandyControl.Controls.MessageBox.Show(data);
            var testwindow = _factory.Create();
            testwindow.ShowDialog();
        }

        private void SelectionChange(object sender, RoutedEventArgs e)
        {
            GridPrincipal.Children.Clear();
            GridPrincipal.Children.Add(_factory3.Create());
        }
    }
}
