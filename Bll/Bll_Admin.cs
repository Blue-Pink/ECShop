using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using Model;
namespace Bll
{
    public class Bll_Admin
    {
        /// <summary>
        /// 表:Admin (查询对应数据的行数
        /// </summary>
        /// <param name="admin">对应数据</param>
        /// <returns>查询结果</returns>
        public static int Login(Admin admin)
        {
            return Dal_Admin.Login(admin);
        }
    }
}
