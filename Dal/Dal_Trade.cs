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
    public class Dal_Trade
    {
        /// <summary>
        /// 表:Trade (添加数据
        /// </summary>
        /// <param name="trade">添加的数据</param>
        /// <returns>执行成功的行数</returns>
        public static int Insert(Trade trade)
        {
            return DBHelp.ExecuteNonQuery(
                "insert into Trade values(@BID,@MID,@BCount)",
                new SqlParameter[] {
                    new SqlParameter("@BID",trade.BID),
                    new SqlParameter("@MID",trade.MID),
                    new SqlParameter("@BCount",trade.BCount),
                });
        }

        /// <summary>
        /// 表:Trade (判断数据是否存在
        /// </summary>
        /// <param name="trade">判断的数据</param>
        /// <returns>是否存在</returns>
        public static bool Exits(Trade trade)
        {
            return Convert.ToInt32(DBHelp.ExecuteScalar(
                "select count(*) from trade where BID=@BID and MID=@MID",
                new SqlParameter[] {
                    new SqlParameter("BID",trade.BID),
                    new SqlParameter("MID",trade.MID),
                })) > 0 ? true : false;
        }

        /// <summary>
        /// 表:Trade (根据MID与BID修改
        /// </summary>
        /// <param name="trade">修改的数据</param>
        /// <returns>执行成功的行数</returns>
        public static int Update_BCount(Trade trade)
        {
            return DBHelp.ExecuteNonQuery(
                "update Trade set BCount=BCount+@BCount where MID=@MID and BID=@BID",
                new SqlParameter[] {
                    new SqlParameter("@BCount",trade.BCount),
                    new SqlParameter("@MID",trade.MID),
                    new SqlParameter("@BID",trade.BID),
                });
        }

        /// <summary>
        /// 表:Trade (根据TID修改BCount
        /// </summary>
        /// <param name="trade">修改的数据</param>
        /// <returns>执行成功的行数</returns>
        public static int Update_BCount(int BCount,int TID)
        {
            return DBHelp.ExecuteNonQuery(
                "update Trade set BCount=@BCount where TID=@TID",
                new SqlParameter[] {
                    new SqlParameter("@BCount",BCount),
                    new SqlParameter("@TID",TID),
                });
        }

        /// <summary>
        /// 表:Trade、Book (根据MID查询数据
        /// </summary>
        /// <param name="MID">所需MID</param>
        /// <returns>查询结果集</returns>
        public static List<Trade> Select_TradeAndBook_MID(int MID)
        {
            List<Trade> trades = new List<Trade>();
            using (SqlDataReader dataReader = DBHelp.ExecuteSqlDataReader(
                "select * from Trade a cross join Book b where a.BID=b.BID and a.MID=@MID",
                new SqlParameter[] {
                    new SqlParameter("@MID",MID)
                }))
            {
                while (dataReader.Read())
                {
                    trades.Add(new Trade()
                    {
                        BID = Convert.ToInt32(dataReader["BID"]),
                        TID = Convert.ToInt32(dataReader["TID"]),
                        BPrice = Convert.ToDecimal(dataReader["BPrice"]),
                        BCount = Convert.ToInt32(dataReader["BCount"]),
                        BName = Convert.ToString(dataReader["BName"]),
                        BPic = Convert.ToString(dataReader["BPic"]),
                        MID = Convert.ToInt32(dataReader["MID"]),
                    });
                }
                return trades;
            }
        }

        /// <summary>
        /// 表:Trade、Book (根据TID查询数据
        /// </summary>
        /// <param name="TID">所需TID</param>
        /// <returns>查询结果</returns>
        public static Trade Select_TradeAndBook_TID(int TID)
        {
            Trade trade = null;
            using (SqlDataReader dataReader = DBHelp.ExecuteSqlDataReader(
                "select * from Trade a cross join Book b where a.BID=b.BID and a.TID=@TID",
                new SqlParameter[] {
                    new SqlParameter("@TID",TID)
                }))
            {
                while (dataReader.Read())
                {
                    trade = new Trade()
                    {
                        BID = Convert.ToInt32(dataReader["BID"]),
                        TID = Convert.ToInt32(dataReader["TID"]),
                        BPrice = Convert.ToDecimal(dataReader["BPrice"]),
                        BCount = Convert.ToInt32(dataReader["BCount"]),
                        BName = Convert.ToString(dataReader["BName"]),
                        BPic = Convert.ToString(dataReader["BPic"]),
                        MID = Convert.ToInt32(dataReader["MID"]),
                    };
                }
                return trade;
            }
        }

        /// <summary>
        /// 表:Trade (根据TID删除数据
        /// </summary>
        /// <param name="TID">所需TID</param>
        /// <returns>执行成功行数</returns>
        public static int Delete_TID(int TID)
        {
            return DBHelp.ExecuteNonQuery(
                "Delete from Trade where TID=@TID",
                new SqlParameter[] {
                    new SqlParameter("@TID",TID)
                });
        }

        /// <summary>
        /// 表：Trade （根据MID删除数据
        /// </summary>
        /// <param name="MID">所需MID</param>
        /// <returns>执行成功的行数</returns>
        public static int Delelte_MID(int MID)
        {
            return DBHelp.ExecuteNonQuery(
                "delete from trade where MID=@MID",
                new SqlParameter[] {
                    new SqlParameter("@MID",MID)
                });
        }
    }
}
