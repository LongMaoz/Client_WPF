using System.ComponentModel;
using System;

namespace Client.Dto.Client;

public class ExamSubjectDto
{
    public int Id { get; set; }
    public Int32 ExamSubjectId
    {
        get => Id;

        set => Id = value;
    }




    public int ExamTaskID { get; set; }
    public string ExamSubjectCode { get; set; }
    public string Abbreviation { get; set; }
    public string Name { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public int TimeLength { get; set; }

    /// <summary>
    /// 总分
    /// </summary>
    public int FullScore { get; set; }

    /// <summary>
    /// 合格分
    /// </summary>
    public int PassScore { get; set; }



    /// <summary>
    /// 良好分
    /// </summary>
    public int MediumScore { get; set; }
    /// <summary>
    /// 低分
    /// </summary>
    public int LowScore { get; set; }
    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime CreateDate { get; set; }

    /// <summary>
    /// 修改时间
    /// </summary>
    public DateTime ModifyTime { get; set; }
    public string Creator { get; set; }
    public string FinalPaper { get; set; }
    public string FinalCard { get; set; }
    public string Standard { get; set; }
    public string TemplateImageAddress { get; set; }
    public string TemplateAddress { get; set; }
    public string TemplateUploader { get; set; }
    public string TemplateAuthor { get; set; }
    public string TemplateState { get; set; }
    public string SubjectAdmin { get; set; }
    /// <summary>
    /// 学科准备员
    /// </summary>
    public string SubjectReadier { get; set; }
    /// <summary>
    /// 是否识别完成
    /// </summary>
    public bool IsRecognizeFinish { get; set; }

    /// <summary>
    /// 题卡是否制作完成
    /// </summary>
    public bool IsSheetFinish { get; set; }

    /// <summary>
    /// 是否拆分科目
    /// </summary>
    public bool IsSingleAnalyze { get; set; }

    /// <summary>
    /// 试卷结构是否完成
    /// </summary>
    public bool IsQuestionFinish { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string PaperPath { get; set; }

    /// <summary>
    /// 优秀分
    /// </summary>
    public int GoodScore { get; set; }

    /// <summary>
    /// 科目管理员id
    /// </summary>
    public int ManageTeacherId { get; set; }


    public Boolean IsOnlineAssignFinish { get; set; }


    public ExamSubjectStartCheckStates StartCheckState { get; set; }

    /// <summary>
    /// 管理员是否具有成绩下发权限 （0：否 1：是）
    /// </summary>
    public int SystemPms { get; set; }

    /// <summary>
    /// 科目老师是否具有成绩下发权限 （0：否 1：是）
    /// </summary>
    public int TeacherPms { get; set; }

    /// <summary>
    /// 临时排序字段
    /// </summary>
    public int Sort { get; set; }

    public bool TryReview { get; set; }

    public DateTime EndTryReviewDate { get; set; }

    /// <summary>
    /// 考号识别类型
    /// </summary>
    public string NumberRecognizeMode { get; set; }

    /// <summary>
    /// 试评份数
    /// </summary>
    public int TryNum { get; set; }

    /// <summary>
    /// 试评类型 copies:试评份数 time:试评时间
    /// </summary>
    public string TryType { get; set; }

    //是否同步成绩到学业 0:未同步 1:已同步
    public int IsSync { get; set; }

    /// <summary>
    /// 是否单科发布   0:未发布 1:已发布
    /// </summary>
    public int IsRelease { get; set; }

    /// <summary>
    /// 手动制作答题卡:manual  组卷生成答题卡:setVolume  引用答题卡: reference
    /// </summary>
    public string SheetSource { get; set; }



}


public enum ExamSubjectStartCheckStates
{
    /// <summary>
    /// 准备
    /// </summary>
    [Description("准备")]
    Ready = 0,
    /// <summary>
    /// 部分准备
    /// </summary>
    [Description("部分准备")]
    HalfReady = 1,
    /// <summary>
    /// 开始阅卷中
    /// </summary>
    [Description("阅卷中")]
    Started = 2,
    /// <summary>
    /// 暂停阅卷
    /// </summary>
    [Description("暂停阅卷")]
    Stop = 3
}