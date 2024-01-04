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
using Client.UI.Message;
using Client.UI.UserControl;
using Client.UI.ViewModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using HandyControl.Controls;
using HandyControl.Data;
using HandyControl.Tools;

namespace Client.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : HandyControl.Controls.Window
    {
        private IAbstractFactory<TestWindow> _factory;
        private IAbstractFactory<DataTimeControl> _factory2;
        private IAbstractFactory<ExamSettingControl> _factory3;

        
        public MainWindow(MainViewModel viewModel, IAbstractFactory<TestWindow> factory,IAbstractFactory<DataTimeControl> factory2, IAbstractFactory<ExamSettingControl> factory3)
        {
            _factory = factory;
            _factory2 = factory2;
            _factory3 = factory3;
            InitializeComponent();
            this.DataContext = viewModel;
            this.Title = "云阅卷";
            ConfigHelper.Instance.SetWindowDefaultStyle();
        }
    }
}
