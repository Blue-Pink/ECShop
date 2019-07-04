using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Dal;
using Model;
namespace Bll
{
    public class Bll_BLCategory
    {
        /// <summary>
        /// 表:BLCategory (查询所有内容
        /// </summary>
        /// <returns>所有内容</returns>
        public static List<BLCategory> Select_All()
        {
            return Dal_BLCategory.Select_All();
        }

        /// <summary>
        /// 表:BLCategory (添加一条数据
        /// </summary>
        /// <param name="bLCategory">添加的数据</param>
        /// <returns>执行成功的行数</returns>
        public static int Insert(BLCategory bLCategory)
        {
            return Dal_BLCategory.Insert(bLCategory);
        }

        /// <summary>
        /// 表:BLCategory (根据BLID删除数据
        /// </summary>
        /// <param name="BLID">所需BLID</param>
        /// <returns>执行成功行数</returns>
        public static int Delete_BLID(int BLID)
        {
            return Dal_BLCategory.Delete_BLID(BLID);
        }

        /// <summary>
        /// 表:BLCategory (修改数据
        /// </summary>
        /// <param name="bLCategory">修改的数据</param>
        /// <returns>执行成功的行数</returns>
        public static int Update(BLCategory bLCategory)
        {
            return Dal_BLCategory.Update(bLCategory);
        }

        /// <summary>
        /// 表:BLCategory (根据BLID查询
        /// </summary>
        /// <param name="BLID">所需BLID</param>
        /// <returns>查询结果</returns>
        public static BLCategory Select_BLID(int BLID)
        {
            return Dal_BLCategory.Select_BLID(BLID);
        }
    }
}
