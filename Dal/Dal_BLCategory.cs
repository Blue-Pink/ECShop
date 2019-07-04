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
    public class Dal_BLCategory
    {
        /// <summary>
        /// 表:BLCategory (查询所有内容
        /// </summary>
        /// <returns>所有内容</returns>
        public static List<BLCategory> Select_All() {
            List<BLCategory> bLCategories = new List<BLCategory>();
            using (SqlDataReader dataReader=DBHelp.ExecuteSqlDataReader("Select * from BLCategory",null))
            {
                while (dataReader.Read())
                {
                    bLCategories.Add(new BLCategory()
                    {
                        BLID = Convert.ToInt32(dataReader["BLID"]),
                        BLName = Convert.ToString(dataReader["BLName"]),
                    }); 
                }
                return bLCategories;
            }
        }

        /// <summary>
        /// 表:BLCategory (添加一条数据
        /// </summary>
        /// <param name="bLCategory">添加的数据</param>
        /// <returns>执行成功的行数</returns>
        public static int Insert(BLCategory bLCategory)
        {
            return DBHelp.ExecuteNonQuery(
                "insert into BLCategory values(@BLName)",
                new SqlParameter[] {
                    new SqlParameter("@BLName",bLCategory.BLName)
            });
        }

        /// <summary>
        /// 表:BLCategory (根据BLID删除数据
        /// </summary>
        /// <param name="BLID">所需BLID</param>
        /// <returns>执行成功行数</returns>
        public static int Delete_BLID(int BLID)
        {
            return DBHelp.ExecuteNonQuery(
                "delete from BLCategory where BLID=@BLID",
                new SqlParameter[] {
                    new SqlParameter("@BLID",BLID)
                });
        }

        /// <summary>
        /// 表:BLCategory (修改数据
        /// </summary>
        /// <param name="bLCategory">修改的数据</param>
        /// <returns>执行成功的行数</returns>
        public static int Update(BLCategory bLCategory)
        {
            return DBHelp.ExecuteNonQuery(
                "update BLCategory set BLName=@BLName where BLID=@BLID",
                new SqlParameter[] {
                    new SqlParameter("@BLName",bLCategory.BLName),
                    new SqlParameter("@BLID",bLCategory.BLID),
                });
        }

        /// <summary>
        /// 表:BLCategory (根据BLID查询
        /// </summary>
        /// <param name="BLID">所需BLID</param>
        /// <returns>查询结果</returns>
        public static BLCategory Select_BLID(int BLID)
        {
            BLCategory bLCategory = null;
            using (SqlDataReader dataReader=DBHelp.ExecuteSqlDataReader(
                "select * from BLCategory where BLID=@BLID",
                new SqlParameter[] {
                    new SqlParameter("@BLID",BLID)
                }))
            {
                while (dataReader.Read())
                {
                    bLCategory = new BLCategory()
                    {
                        BLID=Convert.ToInt32(dataReader["BLID"]),
                        BLName=Convert.ToString(dataReader["BLName"]),
                    };
                }
                return bLCategory;
            }
        }
    }
}
