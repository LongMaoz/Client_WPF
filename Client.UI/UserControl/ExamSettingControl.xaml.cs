using Client.UI.ViewModel;
using HandyControl.Controls;
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

namespace Client.UI.UserControl
{
    /// <summary>
    /// ExamSettingControl.xaml 的交互逻辑
    /// </summary>
    public partial class ExamSettingControl : System.Windows.Controls.UserControl
    {
        private ExamSettingViewModel _viewModel;
        public ExamSettingControl(ExamSettingViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            this.DataContext = _viewModel;
            this.Loaded += ExamSettingControl_Loaded;
        }

        private async void ExamSettingControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.Loaded -= ExamSettingControl_Loaded;
            await _viewModel.GetGradData();
        }

        private async void GradCombox_Selected(object sender, RoutedEventArgs e)
        {
            _viewModel.ExamSubjectItem = null;
            _viewModel.ExamSubjectLst = null;
            await _viewModel.GetExmaTaskData();
        }

        private async void ExamTaskCombox_Selected(object sender, SelectionChangedEventArgs e)
        {
            await _viewModel.GetExamSubject();
        }
    }
}
