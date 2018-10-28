using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tianyue.Domain.Configuration;
using Tianyue.Service;
using Tianyue.Strategy.Contract.Configuration;

namespace Tianyue.Strategy.Configuration
{

    public partial class SystemStrategy : AbstractSystemStrategy
    {
        ///// <summary>
        ///// 获取患者登录所有区域
        ///// </summary>
        ///// <returns></returns>
        //public override List<User> GetUserList()
        //{
        //    return TianyueRepository.UserService.GetUserList();
        //}

        ///// <summary>
        ///// 修改患者登陆区域名字,仅允许修改备注(<see cref="WardAreaEntity.Memo"/>)
        ///// </summary>
        ///// <returns></returns>
        //public override bool UpdateWardArea(WardAreaEntity wardAreaEntity)
        //{
        //    return UIRepository.DictSrv.UpdateWardArea(wardAreaEntity);
        //}


        ///// <summary>
        ///// 获取二级病区字典
        ///// </summary>
        ///// <returns></returns>
        //public override List<ChildWardAreaEntity> GetChildWardArea(string where)
        //{
        //    return UIRepository.DictSrv.GetChildWardArea(where);
        //}

        ///// <summary>
        ///// 增加或修改二级病区数据，数据存在则修改，数据不存在则增加。
        ///// </summary>
        ///// <param name="childWardAreas"></param>
        ///// <returns></returns>
        //public override Boolean UpdateChildWardArea(List<ChildWardAreaEntity> childWardAreas)
        //{
        //    return UIRepository.DictSrv.UpdateChildWardArea(childWardAreas);
        //}

        //public override List<BedEntity> GetAllBeds()
        //{
        //    return UIRepository.BedSrv.GetAllBeds();
        //}

        //public override List<BedEntity> GetAllEmptyBeds()
        //{
        //    return UIRepository.BedSrv.GetAllEmptyBeds();
        //}

        //public override List<BedEntity> GetAllAvailBeds()
        //{
        //    return UIRepository.BedSrv.GetAllAvailBeds();
        //}

        //public override bool UpdateBedInfo(BedEntity entity)
        //{
        //    return UIRepository.BedSrv.UpdateBedInfo(entity);
        //}

        //public override bool ChangeBed(int inHouseID, BedEntity oldBed, BedEntity newBed)
        //{
        //    return UIRepository.BedSrv.ChangeBedsAvailabilityStatus(inHouseID, oldBed, newBed);
        //}

        //public override PatientInfoEntity UpdatePatientInfo(PatientInfoEntity patInfo)
        //{
        //    return UIRepository.PatientSrv.UpdatePatientInfo(patInfo);
        //}

        //public override PatientInfoEntity GetPatientInfo(int id)
        //{
        //    return UIRepository.PatientSrv.GetPatientInfo(id);
        //}

        //public override PatientInfoEntity GetPatientInfoByPvid(Guid pvid)
        //{
        //    return UIRepository.PatientSrv.GetPatientInfoByPvid(pvid);
        //}

        //#region View_PatientList

        //public override List<PatientListView> GetPatientListViews(params ConditionArgs[] args)
        //{
        //    return UIRepository.PatientSrv.GetPatientListViews(args);
        //}

        //public override List<PatientListView> GetPatientListViewByDept(string deptName)
        //{
        //    ConditionArgs arg = null;
        //    if (!string.IsNullOrEmpty(deptName))
        //    {
        //        arg = new ConditionArgs
        //        {
        //            PreConnector = ConnectorEnum.And,
        //            MidConnector = ConnectorEnum.Or,
        //            JudgeType = JudgmentEnum.Equal,
        //            Key = new List<string> { "DeptName", "WardArea" },
        //            Value = deptName
        //        };
        //        return UIRepository.PatientSrv.GetPatientListViews(arg);
        //    }
        //    return UIRepository.PatientSrv.GetPatientListViews();
        //}

        //public override List<PatientListView> GetPatientListViewsByCondition(string where)
        //{
        //    return UIRepository.PatientSrv.GetPatientListViewsBySql(where);
        //}

        //public override List<PatientListView> GetPatientListViewsByCondition(PatientListBtnEnum btnEnum, string wardArea = null)
        //{
        //    switch (btnEnum)
        //    {
        //        case PatientListBtnEnum.MyPat:
        //            var user = AppContext.UserEntity;
        //            if (user != null)
        //            {
        //                if (user.UserType == ((int)UserTypeEnum.Nurse).ToString())
        //                {
        //                    return UIRepository.PatientSrv.GetPatientListViews(
        //                        new ConditionArgs
        //                        {
        //                            PreConnector = ConnectorEnum.And,
        //                            JudgeType = JudgmentEnum.Equal,
        //                            Key = "NurseCode",
        //                            Value = user.EmployeeNumber
        //                        });
        //                }
        //                else
        //                {
        //                    return UIRepository.PatientSrv.GetPatientListViews(
        //                        new ConditionArgs
        //                        {
        //                            PreConnector = ConnectorEnum.And,
        //                            JudgeType = JudgmentEnum.Equal,
        //                            Key = "DutyDocCode",
        //                            Value = user.EmployeeNumber
        //                        }
        //                        //只获取责任医生
        //                        //,
        //                        // new ConditionArgs
        //                        // {
        //                        //     PreConnector = ConnectorEnum.Or,
        //                        //     JudgeType = JudgmentEnum.Equal,
        //                        //     Key = "FstTreatCode",
        //                        //     Value = user.UserName
        //                        // }
        //                         );
        //                }
        //            }
        //            else
        //            {
        //                return UIRepository.PatientSrv.GetPatientListViews();
        //            }

        //        case PatientListBtnEnum.Indept:
        //            return UIRepository.PatientSrv.GetPatientListViews(
        //                new ConditionArgs
        //                {
        //                    PreConnector = ConnectorEnum.And,
        //                    JudgeType = JudgmentEnum.In,
        //                    Key = "Status",
        //                    Value = new List<string> { "0", "1", "3" }
        //                });

        //        case PatientListBtnEnum.UnIndept:
        //            return UIRepository.PatientSrv.GetPatientListViews(
        //              new ConditionArgs
        //              {
        //                  PreConnector = ConnectorEnum.And,
        //                  JudgeType = JudgmentEnum.EqualOrGreaterThan,
        //                  Key = "Status",
        //                  Value = "100"
        //              });
        //        case PatientListBtnEnum.GreenRoad:
        //            return UIRepository.PatientSrv.GetPatientListViewsBySql(" AND ISNULL(GreenRoad,'')<>''");

        //        case PatientListBtnEnum.Red:
        //        case PatientListBtnEnum.Yellow:
        //        case PatientListBtnEnum.Green:
        //        case PatientListBtnEnum.Observation:
        //            return UIRepository.PatientSrv.GetPatientListViewsBySql(string.Format(" AND Status<>100 AND WardArea='{0}'", wardArea));
        //        case PatientListBtnEnum.RedTimeOut:
        //            var redRTime = AppSettingCfg.RTimeRedColor; //设置滞留时间标准
        //            return UIRepository.PatientSrv.GetPatientListViewsBySql(
        //                string.Format(" AND Status<>100 AND WardArea='{0}' AND DATEDIFF(MINUTE,InAreaTime,GETDATE()) >= {1}", wardArea, redRTime * 60)); //抢救区滞留大于2小时为抢救区滞留超时 
        //        case PatientListBtnEnum.YellowTimeOut:
        //            var yellowRTime = AppSettingCfg.RTimeYellowColor; //设置滞留时间标准
        //            return UIRepository.PatientSrv.GetPatientListViewsBySql(
        //                string.Format(" AND Status<>100 AND WardArea='{0}' AND DATEDIFF(MINUTE,InAreaTime,GETDATE()) >= {1}", wardArea, yellowRTime * 60));//黄区滞留大于12小时为黄区滞留超时
        //        case PatientListBtnEnum.TriageTimeOut:
        //            var triageRTime = AppSettingCfg.RTimeTriage;
        //            return UIRepository.PatientSrv.GetPatientListViewsBySql(string.Format(" AND Status = 100 AND TriageLevel IN('一级','二级') AND DATEDIFF(SECOND,TriageDT,GETDATE()) >= {0}", triageRTime * 60));
        //        default:
        //            return UIRepository.PatientSrv.GetPatientListViews();
        //    }
        //}

        //#endregion View_PatientList

        //#region Pat_PatientInHouse

        //public override PatientInHouseEntity GetPatientInHouseByID(int ID)
        //{
        //    var pats = UIRepository.PatientSrv.GetPatientInHouse(new ConditionArgs
        //    {
        //        PreConnector = ConnectorEnum.And,
        //        JudgeType = JudgmentEnum.Equal,
        //        Key = "ID",
        //        Value = ID,
        //    });

        //    if (pats != null)
        //    {
        //        return pats.FirstOrDefault();
        //    }
        //    return null;
        //}

        //public override List<PatientInHouseEntity> GetPatientInHouseByPatID(string patientID)
        //{
        //    var pats = UIRepository.PatientSrv.GetPatientInHouse(new ConditionArgs
        //    {
        //        PreConnector = ConnectorEnum.And,
        //        JudgeType = JudgmentEnum.Equal,
        //        Key = "PatientID",
        //        Value = patientID,
        //    });

        //    return pats;
        //}

        ///// <summary>
        ///// 根据患者ecis 唯一标识 pvid 查询当前在科记录
        ///// </summary>
        ///// <returns></returns>
        //public override PatientInHouseEntity GetPatientInHouseByPVID(Guid pvid)
        //{
        //    if (pvid == null || pvid == Guid.Empty)
        //        return null;
        //    var pats = UIRepository.PatientSrv.GetPatientInHouse(new ConditionArgs
        //    {
        //        PreConnector = ConnectorEnum.And,
        //        JudgeType = JudgmentEnum.Equal,
        //        Key = "PVID",
        //        Value = pvid,
        //    });

        //    return pats == null ? null : pats.FirstOrDefault();
        //}

        //public override PatientInHouseEntity ModifyPatientInHouse(PatientInHouseEntity entity)
        //{
        //    return UIRepository.PatientSrv.ModifyPatientInHouse(entity);
        //}

        //#endregion Pat_PatientInHouse

        //#region PatientQueryView

        ///// <summary>
        ///// 模糊查询
        ///// </summary>
        ///// <param name="isFuzzyQuery">是否模糊</param>
        ///// <param name="registerDTStart">挂号起始时间</param>
        ///// <param name="registerDTEnd">挂号结束时间</param>
        ///// <param name="arg">筛选值</param>
        ///// <returns></returns>
        //public override List<PatientQueryView> PatQuery_Fuzzy(DateTime? registerDTStart, DateTime? registerDTEnd, string fuzzlVal, object arg)
        //{
        //    List<ConditionArgs> cArgs = new List<ConditionArgs>();
        //    if (registerDTStart.HasValue)
        //    {
        //        cArgs.Add(new ConditionArgs
        //        {
        //            PreConnector = ConnectorEnum.And,
        //            JudgeType = JudgmentEnum.EqualOrGreaterThan,
        //            Key = "RegisterDT",
        //            Value = registerDTStart.Value
        //        });
        //    }

        //    if (registerDTEnd.HasValue)
        //    {
        //        cArgs.Add(new ConditionArgs
        //        {
        //            PreConnector = ConnectorEnum.And,
        //            JudgeType = JudgmentEnum.LessThan,
        //            Key = "RegisterDT",
        //            Value = registerDTEnd.Value.AddDays(1)
        //        });
        //    }

        //    if (!string.IsNullOrEmpty(fuzzlVal))
        //    {
        //        var keystr = "BedNo,PatientID,PatientName,ChargeType,DiagnoseName,GreenRoad,FstTreatName,Status";
        //        var keys = keystr.Split(',').ToList();
        //        cArgs.Add(new ConditionArgs
        //        {
        //            PreConnector = ConnectorEnum.And,
        //            MidConnector = ConnectorEnum.Or,
        //            JudgeType = JudgmentEnum.LikeAll,
        //            Key = keys,//"BedNo,PatientID,PatientName,ChargeType,DiagnoseName,GreenRoad,FstTreatName,Status",
        //            Value = fuzzlVal
        //        });
        //    }

        //    return UIRepository.PatientSrv.GetPatientQueryView(cArgs.ToArray());
        //}

        ///// <summary>
        ///// 精确查询
        ///// </summary>
        ///// <param name="isFuzzyQuery">是否模糊</param>
        ///// <param name="registerDTStart">挂号起始时间</param>
        ///// <param name="registerDTEnd">挂号结束时间</param>
        ///// <param name="arg">筛选值,为PatientQueryView 数据类型</param>
        ///// <returns></returns>
        //public override List<PatientQueryView> PatQuery_Combined(DateTime? registerDTStart, DateTime? registerDTEnd, object arg)
        //{
        //    List<ConditionArgs> cArgs = new List<ConditionArgs>();
        //    if (registerDTStart.HasValue)
        //    {
        //        cArgs.Add(new ConditionArgs
        //        {
        //            PreConnector = ConnectorEnum.And,
        //            JudgeType = JudgmentEnum.EqualOrGreaterThan,
        //            Key = "RegisterDT",
        //            Value = registerDTStart.Value
        //        });
        //    }

        //    if (registerDTEnd.HasValue)
        //    {
        //        cArgs.Add(new ConditionArgs
        //        {
        //            PreConnector = ConnectorEnum.And,
        //            JudgeType = JudgmentEnum.LessThan,
        //            Key = "RegisterDT",
        //            Value = registerDTEnd.Value.AddDays(1)
        //        });
        //    }

        //    var pat = arg as PatientQueryView;
        //    if (!string.IsNullOrWhiteSpace(pat.PatientID))
        //    {
        //        cArgs.Add(new ConditionArgs
        //        {
        //            PreConnector = ConnectorEnum.And,
        //            JudgeType = JudgmentEnum.Equal,
        //            Key = "PatientID",
        //            Value = pat.PatientID
        //        });
        //    }
        //    if (!string.IsNullOrWhiteSpace(pat.PatientName))
        //    {
        //        cArgs.Add(new ConditionArgs
        //        {
        //            PreConnector = ConnectorEnum.And,
        //            JudgeType = JudgmentEnum.Equal,
        //            Key = "PatientName",
        //            Value = pat.PatientName
        //        });
        //    }
        //    if (!string.IsNullOrWhiteSpace(pat.VisitId))
        //    {
        //        cArgs.Add(new ConditionArgs
        //        {
        //            PreConnector = ConnectorEnum.And,
        //            JudgeType = JudgmentEnum.Equal,
        //            Key = "VisitId",
        //            Value = pat.VisitId
        //        });
        //    }
        //    if (!string.IsNullOrWhiteSpace(pat.DiagnoseName))
        //    {
        //        cArgs.Add(new ConditionArgs
        //        {
        //            PreConnector = ConnectorEnum.And,
        //            JudgeType = JudgmentEnum.LikeAll,
        //            Key = "DiagnoseName",
        //            Value = pat.DiagnoseName
        //        });
        //    }

        //    if (pat.Status != null)
        //    {
        //        cArgs.Add(new ConditionArgs
        //        {
        //            PreConnector = ConnectorEnum.And,
        //            JudgeType = JudgmentEnum.Equal,
        //            Key = "Status",
        //            Value = pat.Status
        //        });
        //    }
        //    if (!string.IsNullOrWhiteSpace(pat.FstTreatName))
        //    {
        //        cArgs.Add(new ConditionArgs
        //        {
        //            PreConnector = ConnectorEnum.And,
        //            JudgeType = JudgmentEnum.Equal,
        //            Key = "FstTreatName",
        //            Value = pat.FstTreatName
        //        });
        //    }

        //    if (!string.IsNullOrEmpty(pat.GreenRoad))
        //    {
        //        var gRoads = pat.GreenRoad.Split(',').ToList();

        //        cArgs.Add(new ConditionArgs
        //        {
        //            PreConnector = ConnectorEnum.And,
        //            MidConnector = ConnectorEnum.Or,
        //            // JudgeType = JudgmentEnum.Equal,
        //            JudgeType = JudgmentEnum.LikeAll,
        //            Key = "GreenRoad",
        //            Value = gRoads
        //        });
        //    }

        //    return UIRepository.PatientSrv.GetPatientQueryView(cArgs.ToArray());
        //}

        //#endregion PatientQueryView

        //public override void DataGridViewToExcel(System.Windows.Forms.DataGridView dgv)
        //{
        //    UIRepository.PatientSrv.DataGridViewToExcel(dgv);
        //}

        //#region 字典

        //public override List<GreenEntity> GetGreens()
        //{
        //    return UIRepository.DictSrv.GetGreens();
        //}

        //#endregion 字典

        //public override List<PatientListView> GetEmgPatientListViewByCriteria(DocPatCriteria docPatCri)
        //{
        //    //0  抢救区/留观区
        //    //1  时间   //     datediff(HOUR,RegisterDt,GETDATE())<=78
        //    //2  我的病人
        //    //3. 文本查询
        //    var docParams = new List<ConditionArgs>();

        //    docParams.Add(new ConditionArgs
        //    {
        //        PreConnector = ConnectorEnum.And,
        //        JudgeType = JudgmentEnum.Equal,
        //        Key = "WardArea",
        //        Value = docPatCri.AreaName
        //    });


        //    int hours = -1;
        //    switch (docPatCri.EmgCondition)
        //    {
        //        case EmgConditionEnum.Hours12:
        //            hours = 12;
        //            break;

        //        case EmgConditionEnum.Hours24:
        //            hours = 24;
        //            break;

        //        case EmgConditionEnum.Hours72:
        //            hours = 72;
        //            break;

        //        default:
        //            //DONOTHING
        //            break;
        //    }
        //    if (hours != -1)
        //    {
        //        docParams.Add(new ConditionArgs
        //        {
        //            PreConnector = ConnectorEnum.And,
        //            JudgeType = JudgmentEnum.EqualOrLessThan,
        //            Key = "DATEDIFF(HOUR,RegisterDt,GETDATE())",
        //            Value = hours
        //        });
        //    }

        //    //我的病人

        //    if (docPatCri.SearchMyPatient)
        //    {
        //        docParams.Add(new ConditionArgs
        //        {
        //            PreConnector = ConnectorEnum.And,
        //            JudgeType = JudgmentEnum.Equal,
        //            MidConnector = ConnectorEnum.Or,
        //            //Key = new List<string>() { "FstTreatCode", "DutyDocCode", "NurseCode" },
        //            //只显示责任医生
        //            Key = new List<string>() { "DutyDocCode", "NurseCode" },
        //            Value = AppContext.UserEntity.EmployeeNumber
        //        });
        //    }

        //    // 文本查询
        //    if (!string.IsNullOrEmpty(docPatCri.SearchText))
        //    {
        //        docParams.Add(new ConditionArgs
        //        {
        //            PreConnector = ConnectorEnum.And,
        //            JudgeType = JudgmentEnum.LikeAll,
        //            Key = new List<string>() { "PatientName", "BedNo", "PatientID" },
        //            MidConnector = ConnectorEnum.Or,
        //            Value = docPatCri.SearchText
        //        });
        //    }

        //    return UIRepository.PatientSrv.GetPatientListViews(docParams.ToArray());
        //}

        //public override List<PatientListView> GetObsPatientListViewByCriteria(DocPatCriteria docPatCri)
        //{
        //    //0  抢救区/留观区
        //    //1  时间   //     datediff(HOUR,RegisterDt,GETDATE())<=78
        //    //2  我的病人
        //    //3. 文本查询
        //    var docParams = new List<ConditionArgs>();

        //    docParams.Add(new ConditionArgs
        //    {
        //        PreConnector = ConnectorEnum.And,
        //        JudgeType = JudgmentEnum.Equal,
        //        Key = "WardArea",
        //        Value = docPatCri.AreaName
        //    });

        //    int hours = -1;
        //    switch (docPatCri.EmgCondition)
        //    {
        //        case EmgConditionEnum.Hours12:
        //            hours = 12;
        //            break;

        //        case EmgConditionEnum.Hours24:
        //            hours = 24;
        //            break;

        //        case EmgConditionEnum.Hours72:
        //            hours = 72;
        //            break;

        //        default:
        //            //DONOTHING
        //            break;
        //    }
        //    if (hours != -1)
        //    {
        //        docParams.Add(new ConditionArgs
        //        {
        //            PreConnector = ConnectorEnum.And,
        //            JudgeType = JudgmentEnum.EqualOrLessThan,
        //            Key = "DATEDIFF(HOUR,RegisterDt,GETDATE())",
        //            Value = hours
        //        });
        //    }

        //    //我的病人
        //    if (docPatCri.SearchMyPatient)
        //    {
        //        docParams.Add(new ConditionArgs
        //        {
        //            PreConnector = ConnectorEnum.And,
        //            JudgeType = JudgmentEnum.Equal,
        //            MidConnector = ConnectorEnum.Or,
        //            //Key = new List<string>() { "FstTreatCode", "DutyDocCode", "NurseCode" },
        //            //只显示责任医生
        //            Key = new List<string>() { "DutyDocCode", "NurseCode" },
        //            Value = AppContext.UserEntity.EmployeeNumber
        //        });
        //    }

        //    // 文本查询
        //    if (!string.IsNullOrEmpty(docPatCri.SearchText))
        //    {
        //        docParams.Add(new ConditionArgs
        //        {
        //            PreConnector = ConnectorEnum.And,
        //            JudgeType = JudgmentEnum.LikeAll,
        //            Key = new List<string>() { "PatientName", "BedNo", "PatientID" },
        //            MidConnector = ConnectorEnum.Or,
        //            Value = docPatCri.SearchText
        //        });
        //    }

        //    return UIRepository.PatientSrv.GetPatientListViews(docParams.ToArray());
        //}

        //public override List<PatientListView> GetClinicPatientListViewByCriteria(Core.UI.DocPatCriteria docPatCri)
        //{
        //    //1  待诊、已诊
        //    //2  科室查询
        //    //3. 我的病人
        //    //4. 文本框过滤
        //    var docParams = new List<ConditionArgs>();

        //    //docParams.Add(new ConditionArgs
        //    //{
        //    //    PreConnector = ConnectorEnum.And,
        //    //    JudgeType = JudgmentEnum.Equal,
        //    //    MidConnector = ConnectorEnum.Or,
        //    //    Key = "TriageLevel",
        //    //    Value = new List<string>() { "三级", "四级" }
        //    //});

        //    if (docPatCri.SearchModel == SearchModelEnum.Yellow)
        //    {
        //        docParams.Add(new ConditionArgs
        //        {
        //            PreConnector = ConnectorEnum.And,
        //            JudgeType = JudgmentEnum.Equal,
        //            MidConnector = ConnectorEnum.Or,
        //            Key = "TriageLevel",
        //            Value = "三级"
        //        });
        //    }
        //    else if (docPatCri.SearchModel == SearchModelEnum.Clinic)
        //    {
        //        docParams.Add(new ConditionArgs
        //        {
        //            PreConnector = ConnectorEnum.And,
        //            JudgeType = JudgmentEnum.Equal,
        //            MidConnector = ConnectorEnum.Or,
        //            Key = "TriageLevel",
        //            Value = "四级"
        //        });
        //    }
        //    docParams.Add(new ConditionArgs
        //    {
        //        PreConnector = ConnectorEnum.And,
        //        JudgeType = JudgmentEnum.Equal,
        //        Key = "WardArea",
        //        Value = ""
        //    });

        //    docParams.Add(new ConditionArgs
        //    {
        //        PreConnector = ConnectorEnum.Or,
        //        JudgeType = JudgmentEnum.Equal,
        //        Key = "WardArea",
        //        Value = docPatCri.AreaName
        //    });

        //    //待诊
        //    var statusList = new List<string>();
        //    if (docPatCri.SearchMenu == SearchModelEnum.Admissions) //已诊
        //    {
        //        statusList.Add("1");
        //    }
        //    else  //待诊
        //    {
        //        statusList.Add("0");
        //        statusList.Add("3");
        //        statusList.Add("100");
        //        statusList.Add("101");
        //    }

        //    docParams.Add(new ConditionArgs
        //    {
        //        PreConnector = ConnectorEnum.And,
        //        JudgeType = JudgmentEnum.Equal,
        //        MidConnector = ConnectorEnum.Or,
        //        Key = "Status",
        //        Value = statusList
        //    });

        //    //科室
        //    if (!string.IsNullOrEmpty(docPatCri.ClinicCondition))
        //    {
        //        docParams.Add(new ConditionArgs
        //        {
        //            PreConnector = ConnectorEnum.And,
        //            JudgeType = JudgmentEnum.Equal,
        //            MidConnector = ConnectorEnum.Or,
        //            Key = "DeptName",
        //            Value = new List<string>(docPatCri.ClinicCondition.Replace(" ", "").Split(','))
        //        });
        //    }

        //    //我的病人
        //    if (docPatCri.SearchMyPatient)
        //    {
        //        docParams.Add(new ConditionArgs
        //        {
        //            PreConnector = ConnectorEnum.And,
        //            JudgeType = JudgmentEnum.Equal,
        //            MidConnector = ConnectorEnum.Or,
        //            //Key = new List<string>() { "FstTreatCode", "DutyDocCode", "NurseCode" },
        //            //只显示责任医生
        //            Key = new List<string>() { "DutyDocCode", "NurseCode" },
        //            Value = AppContext.UserEntity.EmployeeNumber
        //        });
        //    }

        //    // 文本查询
        //    if (!string.IsNullOrEmpty(docPatCri.SearchText))
        //    {
        //        docParams.Add(new ConditionArgs
        //        {
        //            PreConnector = ConnectorEnum.And,
        //            JudgeType = JudgmentEnum.LikeAll,
        //            Key = new List<string>() { "PatientName", "BedNo", "PatientID" },
        //            MidConnector = ConnectorEnum.Or,
        //            Value = docPatCri.SearchText
        //        });
        //    }

        //    return UIRepository.PatientSrv.GetPatientListViews(docParams.ToArray());
        //}

        //public override List<PatientListView> GetICUPatientListViewByCriteria(DocPatCriteria docPatCri)
        //{
        //    //2  我的病人
        //    //3. 文本查询
        //    var docParams = new List<ConditionArgs>();

        //    //我的病人

        //    if (docPatCri.SearchMyPatient)
        //    {
        //        docParams.Add(new ConditionArgs
        //        {
        //            PreConnector = ConnectorEnum.And,
        //            JudgeType = JudgmentEnum.Equal,
        //            MidConnector = ConnectorEnum.Or,
        //            //Key = new List<string>() { "FstTreatCode", "DutyDocCode", "NurseCode" },
        //            //只显示责任医生
        //            Key = new List<string>() { "DutyDocCode", "NurseCode" },
        //            Value = AppContext.UserEntity.EmployeeNumber
        //        });
        //    }

        //    // 文本查询
        //    if (!string.IsNullOrEmpty(docPatCri.SearchText))
        //    {
        //        docParams.Add(new ConditionArgs
        //        {
        //            PreConnector = ConnectorEnum.And,
        //            JudgeType = JudgmentEnum.LikeAll,
        //            Key = new List<string>() { "PatientName", "BedNo", "PatientID" },
        //            MidConnector = ConnectorEnum.Or,
        //            Value = docPatCri.SearchText
        //        });
        //    }

        //    return UIRepository.PatientSrv.GetPatientListViews(docParams.ToArray());
        //}


        //public override PatStatisticsEntity GetPatStatisticsEntity(string userID)
        //{
        //    return UIRepository.PatientSrv.GetPatStatisticsEntity(userID);
        //}

        ///// <summary>
        ///// 获取患者未执行医嘱
        ///// </summary>
        ///// <param name="pvid"></param>
        ///// <returns></returns>
        //public override List<PatNonExecutionEntity> GetPatNonExecutionByPVID(Guid pvid)
        //{
        //    return UIRepository.PatientSrv.GetPatNonExecution(new ConditionArgs
        //    {
        //        PreConnector = ConnectorEnum.And,
        //        JudgeType = JudgmentEnum.Equal,
        //        Key = "PVID",
        //        Value = pvid
        //    });
        //}

        ///// <summary>
        ///// 获取病人信息，包括分诊信息，在科信息等
        ///// </summary>
        ///// <param name="PVID"></param>
        ///// <returns></returns>
        //public override PatientVisitEntity GetPatientVisitByPVID(Guid PVID)
        //{
        //    return UIRepository.PatientSrv.GetPatientVisitByPVID(PVID);
        //}

        //public override TimeLineEntity GetTimeLine(Guid PVID)
        //{
        //    return UIRepository.PatientSrv.GetTimeLine(PVID);
        //}

        //public override DoctorPatientEntity GetDoctorPatientEntity(Guid PVID)
        //{
        //    return UIRepository.PatientSrv.GetDoctorPatientEntity(PVID);
        //}

        //public override bool UpdateTriageLevel(Guid pvid, string newLevel, string changeLvInfo, string changeReason)
        //{
        //    return UIRepository.PatientSrv.UpdateTriageLevel(pvid, newLevel, changeLvInfo, changeReason);
        //}
    }
}
