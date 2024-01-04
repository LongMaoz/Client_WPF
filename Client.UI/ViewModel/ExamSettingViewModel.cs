using Client.Service.Interface;
using System.Collections.Generic;
using Client.Model.Model.SqlLite;
using Client.Service.Services;
using Client.Model.Utilities;
using Client.Dto.Client;
using CommunityToolkit.Mvvm;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Security.Policy;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Linq;

namespace Client.UI.ViewModel;

public partial class ExamSettingViewModel : ObservableObject
{
    private HttpClientService _httpService;
    public ExamSettingViewModel(HttpClientService httpService)
    {
        _httpService = httpService;
    }

    private ObservableCollection<GradeDto> _gradeLst;
    public ObservableCollection<GradeDto> GradeLst
    {
        get { return _gradeLst; }
        set
        {
            _gradeLst = value;
            OnPropertyChanged();   // 触发PropertyChanged事件
        }
    }

    private ObservableCollection<ExamTaskDto> _examTaskLst;
    public ObservableCollection<ExamTaskDto> ExamTaskLst
    {
        get { return _examTaskLst; }
        set
        {
            _examTaskLst = value;
            OnPropertyChanged();   // 触发PropertyChanged事件
        }
    }

    [ObservableProperty]
    private GradeDto? _gradSelectItem;

    [ObservableProperty]
    private ExamTaskDto? _taskSelectItem;

    public async Task GetSchoolData()
    {
        var response = await _httpService.PostAsync<ApiResponse<ObservableCollection<GradeDto>>>($"http://192.168.1.138:2326/api/ClientApi/GetGradeFilter");
        GradeLst = response.Success ? response.Data : new ObservableCollection<GradeDto>();
        GradSelectItem = GradeLst.FirstOrDefault();
    }

    public async Task GetExmaTaskData()
    {
        //考试任务信息加载
        Dictionary<string, string> dic = new Dictionary<string, string>()
        {
            { "TeacherId", "144" },
            { "GradeCode", GradSelectItem.Code }
        };
        var response = await _httpService.PostJsonAsync<ApiResponse<ObservableCollection<ExamTaskDto>>>($"http://192.168.1.138:2326/api/ClientApi/GetExamReviewTaskFilter", dic);
        ExamTaskLst = response.Success ? response.Data : new ObservableCollection<ExamTaskDto>();
        TaskSelectItem = ExamTaskLst.FirstOrDefault();
    }
}