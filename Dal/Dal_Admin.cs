using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Model;
namespace Dal
{
    public class Dal_Admin
    {
        /// <summary>
        /// 表:Admin (查询对应数据的行数
        /// </summary>
        /// <param name="admin">对应数据</param>
        /// <returns>查询结果</returns>
        public static int Login(Admin admin)
        {
            return Convert.ToInt32(DBHelp.ExecuteScalar(
                "select count(*) from Admin where AName=@AName and APassword=@APassword",
                new SqlParameter[] {
                    new SqlParameter("@AName",admin.AName),
                    new SqlParameter("@APassword",admin.APassword),
            }));
        }
    }
}
