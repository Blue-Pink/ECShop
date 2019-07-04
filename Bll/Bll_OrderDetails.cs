using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Dal;
namespace Bll
{
    public class Bll_OrderDetails
    {
        /// <summary>
        /// 表：OrderDetails （添加一条数据
        /// </summary>
        /// <param name="orderDetail">添加的数据</param>
        /// <returns>执行成功的行数</returns>
        public static int Insert(OrderDetails orderDetail)
        {
            return Dal_OrderDetails.Insert(orderDetail);
        }

        /// <summary>
        /// 表:OrderDetails (根据OID查询
        /// </summary>
        /// <param name="OID">所需OID</param>
        /// <returns>查询结果</returns>
        public static List<OrderDetails> Select_OID(string OID)
        {
            return Dal_OrderDetails.Select_OID(OID);
        }
    }
}
