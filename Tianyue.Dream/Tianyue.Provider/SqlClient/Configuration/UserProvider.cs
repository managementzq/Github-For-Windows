using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tianyue.Domain.Configuration;
using Tianyue.Mapping.SqlClient;
using Tianyue.Mapping.SqlClient.Configuration;

namespace Tianyue.Provider.SqlClient.Configuration
{

    public class UserProvider : SqlServerProvider
    {
        public UserProvider(string dbConn) :
            base(dbConn)
        {
        }
        
        private UserMapper userMapper = new UserMapper();

        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <param name="includeNoDisable">是否包含禁用的</param>
        /// <returns></returns>
        public List<User> GetUserList(bool includeNoDisable)
        {
            var sqlstr = "SELECT * FROM sys_User where 1=1 ";
            if (!includeNoDisable)
            {
                sqlstr += "and Disable = 0  ";
            }
          
            return GetList<User>(sqlstr, userMapper.UserEntityMapper);
        }

        public User GetUserById(int id)
        {
            string getUserByIdSql = " SELECT lUser.*, (SELECT DisplayName FROM dbo.sys_User WHERE ID=lUser.[Owner]) ParentName  FROM dbo.sys_User  lUser  WHERE lUser.ID='{0}'";

            var data = GetList<User>(string.Format(getUserByIdSql, id), userMapper.UserEntityMapper);

            return data.FirstOrDefault();
        }
        
        internal bool ChangePassowrd(string userName, string encrptPassword)
        {
            string sql = "UPDATE dbo.sys_User SET [Password]='{0}',Addtional3 = CONVERT(VARCHAR(16),GETDATE(),121) WHERE UserName='{1}'";
            return ExecuteNonQuery(string.Format(sql, encrptPassword, userName));
        }

    }
}
