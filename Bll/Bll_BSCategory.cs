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
    public class Bll_BSCategory
    {
        /// <summary>
        /// 表:BSCategory (查询所有内容
        /// </summary>
        /// <returns>所有内容</returns>
        public static List<BSCategory> Select_All()
        {
            return Dal_BSCategory.Select_All();
        }

        /// <summary>
        /// 表:BSCategory (根据
        /// </summary>
        /// <returns>所有内容</returns>
        public static List<BSCategory> Select_BLID(int BLID)
        {
            return Dal_BSCategory.Select_BLID(BLID);
        }

        /// <summary>
        /// 表:BSCategory (根据BSID删除数据
        /// </summary>
        /// <param name="BSID">所需BSID</param>
        /// <returns>执行成功的行数</returns>
        public static int Delete_BSID(int BSID)
        {
            return Dal_BSCategory.Delete_BSID(BSID);
        }

        /// <summary>
        /// 表:BSCategory (修改数据
        /// </summary>
        /// <param name="bSCategory">修改的数据</param>
        /// <returns>执行成功的行数</returns>
        public static int Update(BSCategory bSCategory)
        {
            return Dal_BSCategory.Update(bSCategory);
        }

        /// <summary>
        /// 表:BSCategory (根据BLID联合查询BSCategory与BLCategory的BLName,BLID,BSID
        /// </summary>
        /// <returns>所有内容</returns>
        public static List<BSCategory> Select_BLAndBS_BLID(int BLID)
        {
            return Dal_BSCategory.Select_BLAndBS_BLID(BLID);
        }

        /// <summary>
        /// 表:BSCategory (添加数据
        /// </summary>
        /// <param name="bSCategory">添加的数据</param>
        /// <returns>执行成功的行数</returns>
        public static int Insert(BSCategory bSCategory)
        {
            return Dal_BSCategory.Insert(bSCategory);
        }
    }
}
