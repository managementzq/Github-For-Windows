using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tianyue.Mapping.SqlClient;

namespace Tianyue.Provider.SqlClient.Configuration
{

    public class SystemProvider : SqlServerProvider
    {
        public SystemProvider(string dbConn) :
            base(dbConn)
        {
        }

        /// <summary>
        /// 获取服务器当前时间
        /// </summary>
        /// <returns></returns>
        public DateTime GetServiceDate()
        {
            DateTime dtNow = new DateTime();
            try
            {
                object t = ExecuteScalar("SELECT GETDATE() AS [Time]");
                dtNow = Convert.ToDateTime(t);
            }
            catch
            {
                dtNow = DateTime.Now;
            }
            return dtNow;
        }
        

        //private GlobalMapper _mapper = new GlobalMapper();
        //public List<CommonSysDataEntity> GetCommonSysData(string where)
        //{
        //    try
        //    {
        //        var sql = "SELECT * FROM [ECISPlatform_Triage].[dbo].[Common_SysData] WHERE 1=1 ";
        //        if (!string.IsNullOrEmpty(where))
        //        {
        //            sql += where;
        //        }

        //        return GetList<CommonSysDataEntity>(sql, _mapper.GetCommonSysDataMapper);
        //    }
        //    catch (Exception ex)
        //    {
        //        NotifyError(ex);
        //        return null;
        //    }
        //}

        //public bool ModifyCommonSysData(List<CommonSysDataEntity> list)
        //{
        //    SqlConnection conn = new SqlConnection(_dbConnectionString);
        //    conn.Open();
        //    SqlTransaction tran = conn.BeginTransaction();
        //    try
        //    {
        //        foreach (var item in list)
        //        {
        //            UpdateCommonSysData(item.SubCode, item.SubValue, conn, tran);
        //        }
        //        tran.Commit();
        //        return true;
        //    }
        //    catch (SqlException err)
        //    {
        //        tran.Rollback();
        //        NotifyError(err);
        //        return false;
        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }
        //}

        private void UpdateCommonSysData(string subCode, string subValue, SqlConnection conn, SqlTransaction tran)
        {
            string sql = @"UPDATE [ECISPlatform_Triage].[dbo].[Common_SysData] 
                              SET SubValue = @SubValue
                            WHERE SubCode = @SubCode";
            IDataParameter[] parms = new IDataParameter[]{
                    new SqlParameter("SubCode",subCode),
                    new SqlParameter("SubValue",subValue),
                };
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandText = sql;
                cmd.Parameters.AddRange(parms.ToArray());
                cmd.Transaction = tran;
                cmd.ExecuteNonQuery();
            }
        }

        internal bool UpdateTriageLevel(Guid pvid, string newLevel, string changeLvInfo, string changeReason)
        {
            string UpdateTriageLevelSql = "  UPDATE  dbo.MH_TriageRecord SET ChangeLevel='{1}', ActTriageLevel='{2}',TriageMemo = '{3}' WHERE PVID='{0}'";
            return ExecuteNonQuery(string.Format(UpdateTriageLevelSql, pvid.ToString(), changeLvInfo, newLevel, changeReason));
        }
    }
}
