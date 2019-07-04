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
    public class Dal_OrderDetails
    {
        /// <summary>
        /// 表：OrderDetails （添加一条数据
        /// </summary>
        /// <param name="orderDetail">添加的数据</param>
        /// <returns>执行成功的行数</returns>
        public static int Insert(OrderDetails orderDetail) {
            return DBHelp.ExecuteNonQuery(
                "insert into OrderDetails values(@OID,@BID,@BPrice,@BCount)",
                new SqlParameter[] {
                    new SqlParameter("@OID",orderDetail.OID),
                    new SqlParameter("@BID",orderDetail.BID),
                    new SqlParameter("@BPrice",orderDetail.BPrice),
                    new SqlParameter("@BCount",orderDetail.BCount),
                });
        }

        /// <summary>
        /// 表:OrderDetails (根据OID查询
        /// </summary>
        /// <param name="OID">所需OID</param>
        /// <returns>查询结果</returns>
        public static List<OrderDetails> Select_OID(string OID)
        {
            List<OrderDetails> orderDetails = new List<OrderDetails>();
            using (SqlDataReader dataReader=DBHelp.ExecuteSqlDataReader(
                "select * from OrderDetails where OID=@OID",
                new SqlParameter[] {
                    new SqlParameter("@OID",OID)
                }))
            {
                while (dataReader.Read())
                {
                    orderDetails.Add(new OrderDetails() {
                        OID=Convert.ToString(dataReader["OID"]),
                        BPrice =Convert.ToDecimal(dataReader["BPrice"]),
                        BID =Convert.ToInt32(dataReader["BID"]),
                        BCount=Convert.ToInt32(dataReader["BCount"]),
                    });
                }
                return orderDetails;
            }
        }
    }
}
