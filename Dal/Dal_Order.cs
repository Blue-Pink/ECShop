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
    public class Dal_Order
    {
        /// <summary>
        /// 表：Order （添加一条数据
        /// </summary>
        /// <param name="order">添加的数据</param>
        /// <returns>执行成功的行数</returns>
        public static int Insert(Order order)
        {
            return DBHelp.ExecuteNonQuery(
                "insert into [Order] values(@OID,@MID,@ODate,@OConsignee,@OAddress,@OTelephone,@OSumPrice,@OState)",
                new SqlParameter[] {
                    new SqlParameter("@OID",order.OID),
                    new SqlParameter("@MID",order.MID),
                    new SqlParameter("@ODate",order.ODate),
                    new SqlParameter("@OConsignee",order.OConsignee),
                    new SqlParameter("@OAddress",order.OAddress),
                    new SqlParameter("@OTelephone",order.OTelephone),
                    new SqlParameter("@OSumPrice",order.OSumPrice),
                    new SqlParameter("@OState",order.OState),
                });
        }

        /// <summary>
        /// 表：Order （获取新产生列OID
        /// </summary>
        /// <returns>新产生列OID</returns>
        public static string ObtainOID()
        {
            return DBHelp.ExecuteScalar("select dbo.ObtainOID()", null).ToString();
        }

        /// <summary>
        /// 表:Order (根据OState查询Order表总行数----1=新订单,2=订单确认,3=发货,4=订单结束
        /// </summary>
        /// <returns>查询结果</returns>
        public static int GetRowCount_State(int OState)
        {
            return Convert.ToInt32(DBHelp.ExecuteScalar(
                "select count(*) from [Order] where OState=@OState",
                new SqlParameter[] {
                    new SqlParameter("@OState",OState)
                }));
        }

        /// <summary>
        /// 表:Order (查询所有数据
        /// </summary>
        /// <returns>查询结果</returns>
        public static List<Order> Select_All()
        {
            List<Order> orders = new List<Order>();
            using (SqlDataReader dataReader = DBHelp.ExecuteSqlDataReader(
                "select * from [order]",
                null))
            {
                while (dataReader.Read())
                {
                    orders.Add(new Order()
                    {
                        MID = Convert.ToInt32(dataReader["MID"]),
                        OAddress = Convert.ToString(dataReader["OAddress"]),
                        OConsignee = Convert.ToString(dataReader["OConsignee"]),
                        ODate = Convert.ToString(dataReader["ODate"]),
                        OID = Convert.ToString(dataReader["OID"]),
                        OState = Enum.GetName(typeof(Order.enumOState), dataReader["Ostate"]),
                        OSumPrice = Convert.ToDouble(dataReader["OSumPrice"]),
                        OTelephone = Convert.ToString(dataReader["OTelephone"]),
                    });
                }
                return orders;
            }
        }

        /// <summary>
        /// 表:Order (分页查询
        /// </summary>
        /// <param name="pageindex">当前页</param>
        /// <param name="pagesize">页大小</param>
        /// <returns>查询结果</returns>
        public static List<Order> Paging(int pageindex, int pagesize)
        {
            List<Order> orders = new List<Order>();
            using (SqlDataReader dataReader = DBHelp.ExecuteSqlDataReader(
                "select * from (select ROW_NUMBER() over(order by oid) 'row' ,* from [Order]) a where  a.row between @start and @end",
                new SqlParameter[] {
                    new SqlParameter("@start",(pageindex-1)*pagesize+1),
                    new SqlParameter("@end",pageindex*pagesize)
                }))
            {
                while (dataReader.Read())
                {
                    orders.Add(new Order()
                    {
                        MID = Convert.ToInt32(dataReader["MID"]),
                        OAddress = Convert.ToString(dataReader["OAddress"]),
                        OConsignee = Convert.ToString(dataReader["OConsignee"]),
                        ODate = Convert.ToString(dataReader["ODate"]),
                        OID = Convert.ToString(dataReader["OID"]),
                        OState = Enum.GetName(typeof(Order.enumOState), dataReader["Ostate"]),
                        OSumPrice = Convert.ToDouble(dataReader["OSumPrice"]),
                        OTelephone = Convert.ToString(dataReader["OTelephone"]),
                    });
                }
                return orders;
            }
        }

        /// <summary>
        /// 表:Order (根据OID分页查询
        /// </summary>
        /// <param name="OID">所需OID</param>
        /// <param name="pageindex">当前页</param>
        /// <param name="pagesize">页大小</param>
        /// <returns>查询结果</returns>
        public static List<Order> Paging_OID(string OID, int pageindex, int pagesize)
        {
            List<Order> orders = new List<Order>();
            using (SqlDataReader dataReader = DBHelp.ExecuteSqlDataReader(
                "select * from (select ROW_NUMBER() over(order by oid) 'row' ,* from [Order]) a where  a.row between @start and @end and a.oid=@oid",
                new SqlParameter[] {
                    new SqlParameter("@start",(pageindex-1)*pagesize-1),
                    new SqlParameter("@end",pageindex*pagesize),
                    new SqlParameter("@oid",OID)
                }))
            {
                while (dataReader.Read())
                {
                    orders.Add(new Order()
                    {
                        MID = Convert.ToInt32(dataReader["MID"]),
                        OAddress = Convert.ToString(dataReader["OAddress"]),
                        OConsignee = Convert.ToString(dataReader["OConsignee"]),
                        ODate = Convert.ToString(dataReader["ODate"]),
                        OID = Convert.ToString(dataReader["OID"]),
                        OState = Enum.GetName(typeof(Order.enumOState), dataReader["Ostate"]),
                        OSumPrice = Convert.ToDouble(dataReader["OSumPrice"]),
                        OTelephone = Convert.ToString(dataReader["OTelephone"]),
                    });
                }
                return orders;
            }
        }

        /// <summary>
        /// 表:Order (根据OID查询
        /// </summary>
        /// <param name="OID">所需OID</param>
        /// <returns>查询结果</returns>
        public static List<Order> Select_OID(string OID)
        {
            List<Order> orders = new List<Order>();
            using (SqlDataReader dataReader = DBHelp.ExecuteSqlDataReader(
                "select * from [order] where oid=@oid",
                new SqlParameter[] {
                    new SqlParameter("@oid",OID)
                }))
            {
                while (dataReader.Read())
                {
                    orders.Add(new Order()
                    {
                        MID = Convert.ToInt32(dataReader["MID"]),
                        OAddress = Convert.ToString(dataReader["OAddress"]),
                        OConsignee = Convert.ToString(dataReader["OConsignee"]),
                        ODate = Convert.ToString(dataReader["ODate"]),
                        OID = Convert.ToString(dataReader["OID"]),
                        OState = Enum.GetName(typeof(Order.enumOState), dataReader["Ostate"]),
                        OSumPrice = Convert.ToDouble(dataReader["OSumPrice"]),
                        OTelephone = Convert.ToString(dataReader["OTelephone"]),
                    });
                }
                return orders;
            }
        }

        /// <summary>
        /// 表:Order (根据OConsignee查询
        /// </summary>
        /// <param name="OConsignee">所需OConsignee</param>
        /// <returns>查询结果</returns>
        public static List<Order> Select_OConsignee(string OConsignee)
        {
            List<Order> orders = new List<Order>();
            using (SqlDataReader dataReader = DBHelp.ExecuteSqlDataReader(
                "select * from [order] where OConsignee like '%'+@OConsignee+'%'",
                new SqlParameter[] {
                    new SqlParameter("@OConsignee",OConsignee)
                }))
            {
                while (dataReader.Read())
                {
                    orders.Add(new Order()
                    {
                        MID = Convert.ToInt32(dataReader["MID"]),
                        OAddress = Convert.ToString(dataReader["OAddress"]),
                        OConsignee = Convert.ToString(dataReader["OConsignee"]),
                        ODate = Convert.ToString(dataReader["ODate"]),
                        OID = Convert.ToString(dataReader["OID"]),
                        OState = Enum.GetName(typeof(Order.enumOState), dataReader["Ostate"]),
                        OSumPrice = Convert.ToDouble(dataReader["OSumPrice"]),
                        OTelephone = Convert.ToString(dataReader["OTelephone"]),
                    });
                }
                return orders;
            }
        }

        /// <summary>
        /// 表:Order (根据OConsignee分页查询
        /// </summary>
        /// <param name="OConsignee">所需OConsignee</param>
        /// <param name="pageindex">当前页</param>
        /// <param name="pagesize">页大小</param>
        /// <returns>查询结果</returns>
        public static List<Order> Paging_OConsignee(string OConsignee, int pageindex, int pagesize)
        {
            List<Order> orders = new List<Order>();
            using (SqlDataReader dataReader = DBHelp.ExecuteSqlDataReader(
                "select * from (select ROW_NUMBER() over(order by oid) 'row' ,* from [Order]) a where  a.row between @start and @end and a.OConsignee like '%'+@OConsignee+'%'",
                new SqlParameter[] {
                    new SqlParameter("@OConsignee",OConsignee),
                    new SqlParameter("@start",(pageindex-1)*pagesize-1),
                    new SqlParameter("@end",pageindex*pagesize),
                }))
            {
                while (dataReader.Read())
                {
                    orders.Add(new Order()
                    {
                        MID = Convert.ToInt32(dataReader["MID"]),
                        OAddress = Convert.ToString(dataReader["OAddress"]),
                        OConsignee = Convert.ToString(dataReader["OConsignee"]),
                        ODate = Convert.ToString(dataReader["ODate"]),
                        OID = Convert.ToString(dataReader["OID"]),
                        OState = Enum.GetName(typeof(Order.enumOState), dataReader["Ostate"]),
                        OSumPrice = Convert.ToDouble(dataReader["OSumPrice"]),
                        OTelephone = Convert.ToString(dataReader["OTelephone"]),
                    });
                }
                return orders;
            }
        }

        /// <summary>
        /// 表:Order (根据OID及OConsignee分页查询
        /// </summary>
        /// <param name="OConsignee">所需OConsignee</param>
        /// <param name="OID">所需OID</param>
        /// <returns>查询结果</returns>
        public static List<Order> Paging_OConsignee_OID(string OConsignee, string OID, int pageindex, int pagesize)
        {
            List<Order> orders = new List<Order>();
            using (SqlDataReader dataReader = DBHelp.ExecuteSqlDataReader(
                "select * from (select ROW_NUMBER() over(order by oid) 'row' ,* from [Order]) a where  a.row between @start and @end and a.OConsignee like '%'+@OConsignee+'%' and Oid=@Oid",
                new SqlParameter[] {
                    new SqlParameter("@OConsignee",OConsignee),
                    new SqlParameter("@OID",OID),
                    new SqlParameter("@start",(pageindex-1)*pagesize-1),
                    new SqlParameter("@end",pageindex*pagesize),
                }))
            {
                while (dataReader.Read())
                {
                    orders.Add(new Order()
                    {
                        MID = Convert.ToInt32(dataReader["MID"]),
                        OAddress = Convert.ToString(dataReader["OAddress"]),
                        OConsignee = Convert.ToString(dataReader["OConsignee"]),
                        ODate = Convert.ToString(dataReader["ODate"]),
                        OID = Convert.ToString(dataReader["OID"]),
                        OState = Enum.GetName(typeof(Order.enumOState), dataReader["Ostate"]),
                        OSumPrice = Convert.ToDouble(dataReader["OSumPrice"]),
                        OTelephone = Convert.ToString(dataReader["OTelephone"]),
                    });
                }
                return orders;
            }
        }

        /// <summary>
        /// 表:Order (根据OID及OConsignee查询
        /// </summary>
        /// <param name="OConsignee">所需OConsignee</param>
        /// <param name="OID">所需OID</param>
        /// <returns>查询结果</returns>
        public static List<Order> Select_OConsignee_OID(string OConsignee, string OID)
        {
            List<Order> orders = new List<Order>();
            using (SqlDataReader dataReader = DBHelp.ExecuteSqlDataReader(
                "select * from [order] where OConsignee like '%'+@OConsignee+'%' and OID=@OID",
                new SqlParameter[] {
                    new SqlParameter("@OConsignee",OConsignee),
                    new SqlParameter("@OID",OID),
                }))
            {
                while (dataReader.Read())
                {
                    orders.Add(new Order()
                    {
                        MID = Convert.ToInt32(dataReader["MID"]),
                        OAddress = Convert.ToString(dataReader["OAddress"]),
                        OConsignee = Convert.ToString(dataReader["OConsignee"]),
                        ODate = Convert.ToString(dataReader["ODate"]),
                        OID = Convert.ToString(dataReader["OID"]),
                        OState = Enum.GetName(typeof(Order.enumOState), dataReader["Ostate"]),
                        OSumPrice = Convert.ToDouble(dataReader["OSumPrice"]),
                        OTelephone = Convert.ToString(dataReader["OTelephone"]),
                    });
                }
                return orders;
            }
        }

        /// <summary>
        /// 表:Order (查询总行数
        /// </summary>
        /// <returns>查询结果</returns>
        public static int RowCount()
        {
            return Convert.ToInt32(DBHelp.ExecuteScalar("select count(*) from [Order]", null));
        }

        /// <summary>
        /// 表:Order (根据OID修改OState
        /// </summary>
        /// <param name="OID">所需OID</param>
        /// <param name="OState">所需OState</param>
        /// <returns></returns>
        public static int UpdateOState_OID(string OID,int OState)
        {
            return DBHelp.ExecuteNonQuery(
                "update  [Order] set OState=@OState where OID=@OID",
                new SqlParameter[] {
                    new SqlParameter("@OState",OState),
                    new SqlParameter("@OID",OID),
                });
        }

    }
}
