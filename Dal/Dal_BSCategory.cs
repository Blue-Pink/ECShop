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
    public class Dal_BSCategory
    {
        /// <summary>
        /// 表:BSCategory (联合查询BSCategory与BLCategory的BLName,BLID,BSID
        /// </summary>
        /// <returns>所有内容</returns>
        public static List<BSCategory> Select_All()
        {
            List<BSCategory> bSCategories = new List<BSCategory>();
            using (SqlDataReader dataReader = DBHelp.ExecuteSqlDataReader(
                "select a.BLID,a.BSID,a.BLName as 'BLName',b.BLName as 'BLName1' from BSCategory a cross join BLCategory b where a.BLID=b.BLID",
                null))
            {
                while (dataReader.Read())
                {
                    bSCategories.Add(new BSCategory()
                    {
                        BLID = Convert.ToInt32(dataReader["BLID"]),
                        BLName = Convert.ToString(dataReader["BLName"]),
                        BSID = Convert.ToInt32(dataReader["BSID"]),
                        BLName1=Convert.ToString(dataReader["BLName1"])
                    });
                }
                return bSCategories;
            }
        }

        /// <summary>
        /// 表:BSCategory (根据BLID联合查询BSCategory与BLCategory的BLName,BLID,BSID
        /// </summary>
        /// <returns>所有内容</returns>
        public static List<BSCategory> Select_BLAndBS_BLID(int BLID)
        {
            List<BSCategory> bSCategories = new List<BSCategory>();
            using (SqlDataReader dataReader = DBHelp.ExecuteSqlDataReader(
                "select a.BLID,a.BSID,a.BLName as 'BLName',b.BLName as 'BLName1' from BSCategory a cross join BLCategory b where a.BLID=b.BLID and a.BLID=@BLID",
                new SqlParameter[] {
                    new SqlParameter("@BLID",BLID),
                }))
            {
                while (dataReader.Read())
                {
                    bSCategories.Add(new BSCategory()
                    {
                        BLID = Convert.ToInt32(dataReader["BLID"]),
                        BLName = Convert.ToString(dataReader["BLName"]),
                        BSID = Convert.ToInt32(dataReader["BSID"]),
                        BLName1 = Convert.ToString(dataReader["BLName1"])
                    });
                }
                return bSCategories;
            }
        }

        /// <summary>
        /// 表:BSCategory (根据
        /// </summary>
        /// <returns>所有内容</returns>
        public static List<BSCategory> Select_BLID(int BLID)
        {
            List<BSCategory> bSCategories = new List<BSCategory>();
            using (SqlDataReader dataReader = DBHelp.ExecuteSqlDataReader("select * from BSCategory where BLID=@BLID", new SqlParameter[] { new SqlParameter("@BLID", BLID) }))
            {
                while (dataReader.Read())
                {
                    bSCategories.Add(new BSCategory()
                    {
                        BLID = Convert.ToInt32(dataReader["BLID"]),
                        BLName = Convert.ToString(dataReader["BLName"]),
                        BSID = Convert.ToInt32(dataReader["BSID"])
                    });
                }
                return bSCategories;
            }
        }

        /// <summary>
        /// 表:BSCategory (根据BSID删除数据
        /// </summary>
        /// <param name="BSID">所需BSID</param>
        /// <returns>执行成功的行数</returns>
        public static int Delete_BSID(int BSID)
        {
            return DBHelp.ExecuteNonQuery(
                "delete from BSCategory where BSID=@BSID",
                new SqlParameter[] {
                    new SqlParameter("@BSID",BSID)
                });
        }

        /// <summary>
        /// 表:BSCategory (修改数据
        /// </summary>
        /// <param name="bSCategory">修改的数据</param>
        /// <returns>执行成功的行数</returns>
        public static int Update(BSCategory bSCategory)
        {
            return DBHelp.ExecuteNonQuery(
                "update BSCategory set BLName=@BLName,BLID=@BLID where BSID=@BSID",
                new SqlParameter[] {
                    new SqlParameter("@BLName",bSCategory.BLName),
                    new SqlParameter("@BSID",bSCategory.BSID),
                    new SqlParameter("@BLID",bSCategory.BLID)
                });
        }

        /// <summary>
        /// 表:BSCategory (添加数据
        /// </summary>
        /// <param name="bSCategory">添加的数据</param>
        /// <returns>执行成功的行数</returns>
        public static int Insert(BSCategory bSCategory)
        {
            return DBHelp.ExecuteNonQuery(
                "insert into BSCategory values(@BLID,@BLName)",
                new SqlParameter[] {
                    new SqlParameter("@BLID",bSCategory.BLID),
                    new SqlParameter("@BLName",bSCategory.BLName),
                });
        }
    }
}
