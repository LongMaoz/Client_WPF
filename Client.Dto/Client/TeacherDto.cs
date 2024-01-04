using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System;

namespace Client.Dto.Client;

public class TeacherDto
{
    public int Id { get; set; }
    public Int32 TeacherId
    {
        get;
        set;
    }

    [DisplayName("教工号")]
    public string TeacherCode { get; set; }
    [DisplayName("姓名")]
    public string Name { get; set; }
    [DisplayName("性别")]
    public bool Sex { get; set; }
    [DisplayName("学校")]
    public int SchoolID { get; set; }
    [DisplayName("专业职称")]
    public string Professional { get; set; }
    [DisplayName("身份证号")]
    public string IDcard { get; set; }
    [DisplayName("手机")]
    public string Phone { get; set; }
    [DisplayName("邮箱")]
    public string Email { get; set; }
    [DisplayName("QQ")]
    public string QQ { get; set; }
    [DisplayName("教师状态")]
    public string State { get; set; }
    [DisplayName("登陆密码")]
    public string PassWord { get; set; }
    [DisplayName("参加工作年月")]
    [UIHint("WdatePicker")]
    public DateTime? WorkingYear { get; set; }
    [DisplayName("地址")]
    public string Address { get; set; }
    [DisplayName("性别")]
    public string SexChinese { get; set; }
    [DisplayName("教师状态")]
    public string StateChinese { get; set; }
    [DisplayName("办公室电话")]
    public string OfficePhone { get; set; }
    [DisplayName("联系电话")]
    public string Telephone { get; set; }
    [DisplayName("专业学科")]
    public string Disciplines { get; set; }
    [DisplayName("任教组合")]
    public string TeachingCombination { get; set; }
    public string TeachingClassNames { get; set; }
    public string ExternalTeacherID { get; set; }


    [DisplayName("任教组合代码")]
    public string TeachingCode { get; set; }
    [DisplayName("任职组合")]
    public string OfficeCombination { get; set; }
    [DisplayName("任职组合代码")]
    public string OfficeCode { get; set; }
    [DisplayName("类型")]
    public string ClassType { get; set; }
    [DisplayName("年级编号")]
    public string GradeCode { get; set; }

    [DisplayName("年级名称")]
    public string Cr_GradeName { get; set; }

    [DisplayName("学校代码")]
    public string SchoolTypeCode { get; set; }
    [DisplayName("班级编号")]
    public string ClassNumber { get; set; }
    [DisplayName("类型")]
    public string Type { get; set; }
    [DisplayName("任教/任职:年段.班级;")]
    public string Teaching { get; set; }
    [DisplayName("信息")]
    public List<string> TeachingContent { get; set; }
    [DisplayName("是否存在错误")]
    public bool IsError { get; set; }
    [DisplayName("错误描述")]
    public string ErrorMessage { get; set; }
    public string UserName { get; set; }
    public string UserId { get; set; }
    public string SchoolName { get; set; }
    public string TrueName_SZXY { get; set; }
    /// <summary>
    /// 是否存在数据
    /// </summary>
    [DisplayName("是否存在数据")]
    public bool IsAny { get; set; }

    /// <summary>
    /// 任教科目代码
    /// </summary>
    public string SubjectCode { get; set; }

    /// <summary>
    /// 任教科目名称显示
    /// </summary>
    public string SubjectNameView { get; set; }

    /// <summary>
    /// 任教科目名称
    /// </summary>
    public string SubjectName { get; set; }

    /// <summary>
    /// 是否是正式员工1=非临时、0=临时
    /// </summary>
    public bool IsFormal { get; set; }

    /// <summary>
    /// 科目管理员教师id
    /// </summary>
    public int ManagerTeacherId { get; set; }
    /// <summary>
    /// 关联年级
    /// </summary>
    public string CR_GraderCode { get; set; }


    public int ClassID { get; set; }
    public string ClassName { get; set; }
}