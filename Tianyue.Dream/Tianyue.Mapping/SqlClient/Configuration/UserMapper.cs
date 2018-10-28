using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tianyue.Domain.Configuration;
using Tianyue.Utility.Helper;

namespace Tianyue.Mapping.SqlClient.Configuration
{

    public class UserMapper
    {
        public User UserEntityMapper(DbDataReader reader)
        {
            User user = new User();
            user.UID = reader.GetGuid("UID");
            user.UserName = reader.GetString("UserName");
            user.UserUniqueId = reader.GetString("UserUniqueId");
            user.Nickname = reader.GetString("Nickname");
            user.Password = reader.GetString("Password");
            user.UserType = reader.GetString("UserType");
            user.EmailAddress = reader.GetString("EmailAddress");
            user.PhoneNumber = reader.GetString("PhoneNumber");
            user.Disable = reader.GetBool("Disable");

            return user;
        }



      

    }
}
