using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tianyue.Domain.Configuration;

namespace Tianyue.Strategy.Contract.Configuration
{

    public abstract partial class AbstractSystemStrategy
    {
        ///// <summary>
        ///// 获取患者登录所有区域
        ///// </summary>
        ///// <returns></returns>
        //public abstract List<User> GetUserList();

        ///// <summary>
        ///// 修改患者登陆区域名字,仅允许修改备注(<see cref="WardAreaEntity.Memo"/>)
        ///// </summary>
        ///// <returns></returns>
        //public abstract Boolean UpdateWardArea(WardAreaEntity wardAreaEntity);


        //public abstract List<ChildWardAreaEntity> GetChildWardArea(string where);

        ///// <summary>
        ///// 增加或修改二级病区数据，数据存在则修改，数据不存在则增加。
        ///// </summary>
        ///// <param name="childWardAreas"></param>
        ///// <returns></returns>
        //public abstract Boolean UpdateChildWardArea(List<ChildWardAreaEntity> childWardAreas);

        ///// <summary>
        ///// 获取所有床位信息
        ///// </summary>
        ///// <returns></returns>
        //public abstract List<BedEntity> GetAllBeds();

        //public abstract List<BedEntity> GetAllEmptyBeds();

        //public abstract List<BedEntity> GetAllAvailBeds();

        //public abstract bool UpdateBedInfo(BedEntity entity);

        //public abstract bool ChangeBed(int inHouseID, BedEntity oldBed, BedEntity newBed);

        ///// <summary>
        ///// 更新患者信息
        ///// </summary>
        ///// <returns></returns>
        //public abstract PatientInfoEntity UpdatePatientInfo(PatientInfoEntity patInfo);

        ///// <summary>
        ///// 获取所有的患者信息
        ///// </summary>
        ///// <returns></returns>
        //public abstract List<PatientListView> GetPatientListViews(params ConditionArgs[] args);

        ///// <summary>
        ///// 根据科室获取所有患者
        ///// </summary>
        ///// <param name="deptName"></param>
        ///// <returns></returns>
        //public abstract List<PatientListView> GetPatientListViewByDept(string deptName);

        ///// <summary>
        ///// 根据条件获取数据
        ///// </summary>
        ///// <param name="obj"></param>
        ///// <returns></returns>
        //public abstract List<PatientListView> GetPatientListViewsByCondition(string where);

        //public abstract List<PatientListView> GetPatientListViewsByCondition(PatientListBtnEnum btnEnum, string wardArea = null);

        //public abstract PatientInfoEntity GetPatientInfo(int id);

        //public abstract PatientInfoEntity GetPatientInfoByPvid(Guid pvid);

        //public abstract void DataGridViewToExcel(System.Windows.Forms.DataGridView dgv);

        //public abstract List<PatientListView> GetEmgPatientListViewByCriteria(DocPatCriteria docPatCri);

        //public abstract List<PatientListView> GetObsPatientListViewByCriteria(DocPatCriteria docPatCri);

        //public abstract List<PatientListView> GetClinicPatientListViewByCriteria(DocPatCriteria docPatCri);

        //public abstract List<PatientListView> GetICUPatientListViewByCriteria(DocPatCriteria docPatCri);

        //public abstract PatStatisticsEntity GetPatStatisticsEntity(string userID);

        ///// <summary>
        ///// 获取患者未执行医嘱
        ///// </summary>
        ///// <param name="pvid"></param>
        ///// <returns></returns>
        //public abstract List<PatNonExecutionEntity> GetPatNonExecutionByPVID(Guid pvid);

        //#region 字典

        //public abstract List<GreenEntity> GetGreens();

        //#endregion 字典
    }
}
