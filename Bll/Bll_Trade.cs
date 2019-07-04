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
    public class Bll_Trade
    {
        /// <summary>
        /// 表:Trade (添加数据
        /// </summary>
        /// <param name="trade">添加的数据</param>
        /// <returns>执行成功的行数</returns>
        public static int Insert(Trade trade)
        {
            return Dal_Trade.Insert(trade);
        }

        /// <summary>
        /// 表:Trade (判断数据是否存在
        /// </summary>
        /// <param name="trade">判断的数据</param>
        /// <returns>是否存在</returns>
        public static bool Exits(Trade trade)
        {
            return Dal_Trade.Exits(trade);
        }

        /// <summary>
        /// 表:Trade (修改BCount
        /// </summary>
        /// <param name="trade">修改的数据</param>
        /// <returns>执行成功的行数</returns>
        public static int Update_BCount(Trade trade)
        {
            return Dal_Trade.Update_BCount(trade);
        }

        /// <summary>
        /// 表:Trade (根据TID修改BCount
        /// </summary>
        /// <param name="trade">修改的数据</param>
        /// <returns>执行成功的行数</returns>
        public static int Update_BCount(int BCount, int TID)
        {
            return Dal_Trade.Update_BCount(BCount, TID);
        }

        /// <summary>
        /// 表:Trade、Book (根据MID查询数据
        /// </summary>
        /// <param name="MID">MID</param>
        /// <returns>查询结果集</returns>
        public static List<Trade> Select_TradeAndBook_MID(int MID)
        {
            return Dal_Trade.Select_TradeAndBook_MID(MID);
        }

        /// <summary>
        /// 表:Trade、Book (根据TID查询数据
        /// </summary>
        /// <param name="TID">所需TID</param>
        /// <returns>查询结果</returns>
        public static Trade Select_TradeAndBook_TID(int TID)
        {
            return Dal_Trade.Select_TradeAndBook_TID(TID);
        }
        /// <summary>
        /// 表:Trade (根据TID删除数据
        /// </summary>
        /// <param name="TID">所需TID</param>
        /// <returns>执行成功行数</returns>
        public static int Delete_TID(int TID)
        {
            return Dal_Trade.Delete_TID(TID);
        }

        /// <summary>
        /// 表：Trade （根据MID删除数据
        /// </summary>
        /// <param name="MID">所需MID</param>
        /// <returns>执行成功的行数</returns>
        public static int Delelte_MID(int MID)
        {
            return Dal_Trade.Delelte_MID(MID);
        }
    }
}
