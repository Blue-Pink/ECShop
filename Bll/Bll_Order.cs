using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using Model;
namespace Bll
{
    public class Bll_Order
    {

        /// <summary>
        /// 表：Order （添加一条数据
        /// </summary>
        /// <param name="order">添加的数据</param>
        /// <returns>执行成功的行数</returns>
        public static int Insert(Order order)
        {
            return Dal_Order.Insert(order);
        }

        /// <summary>
        /// 表：Order （获取新产生列OID
        /// </summary>
        /// <returns>新产生列OID</returns>
        public static string ObtainOID()
        {
            return Dal_Order.ObtainOID();
        }

        /// <summary>
        /// 表:Order (根据OState查询Order表总行数----1=新订单,2=订单确认,3=发货,4=订单结束
        /// </summary>
        /// <returns>查询结果</returns>
        public static int GetRowCount_State(int OState)
        {
            return Dal_Order.GetRowCount_State(OState);
        }

        /// <summary>
        /// 表:Order (根据OID及OConsignee查询
        /// </summary>
        /// <param name="OConsignee">所需OConsignee</param>
        /// <param name="OID">所需OID</param>
        /// <returns>查询结果</returns>
        public static List<Order> Select_OConsignee_OID(string OConsignee, string OID)
        {
            return Dal_Order.Select_OConsignee_OID(OConsignee, OID);
        }

        /// <summary>
        /// 表:Order (根据OConsignee查询
        /// </summary>
        /// <param name="OConsignee">所需OConsignee</param>
        /// <returns>查询结果</returns>
        public static List<Order> Select_OConsignee(string OConsignee)
        {
            return Dal_Order.Select_OConsignee(OConsignee);
        }

        /// <summary>
        /// 表:Order (根据OID查询
        /// </summary>
        /// <param name="OID">所需OID</param>
        /// <returns>查询结果</returns>
        public static List<Order> Select_OID(string OID)
        {
            return Dal_Order.Select_OID(OID);
        }

        /// <summary>
        /// 表:Order (查询所有数据
        /// </summary>
        /// <returns>查询结果</returns>
        public static List<Order> Select_All()
        {
            return Dal_Order.Select_All();
        }

        /// <summary>
        /// 表:Order (分页查询
        /// </summary>
        /// <param name="pageindex">当前页</param>
        /// <param name="pagesize">页大小</param>
        /// <returns>查询结果</returns>
        public static List<Order> Paging(int pageindex, int pagesize)
        {
            return Dal_Order.Paging(pageindex, pagesize);
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
            return Dal_Order.Paging_OID(OID, pageindex, pagesize);
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
            return Dal_Order.Paging_OConsignee(OConsignee, pageindex, pagesize);
        }

        /// <summary>
        /// 表:Order (根据OID及OConsignee分页查询
        /// </summary>
        /// <param name="OConsignee">所需OConsignee</param>
        /// <param name="OID">所需OID</param>
        /// <returns>查询结果</returns>
        public static List<Order> Paging_OConsignee_OID(string OConsignee, string OID, int pageindex, int pagesize)
        {
            return Dal_Order.Paging_OConsignee_OID(OConsignee, OID, pageindex, pagesize);
        }

        /// <summary>
        /// 表:Order (查询总行数
        /// </summary>
        /// <returns>查询结果</returns>
        public static int RowCount()
        {
            return Dal_Order.RowCount();
        }

        /// <summary>
        /// 表:Order (根据OID修改OState
        /// </summary>
        /// <param name="OID">所需OID</param>
        /// <param name="OState">所需OState</param>
        /// <returns></returns>
        public static int UpdateOState_OID(string OID, int OState)
        {
            return Dal_Order.UpdateOState_OID(OID, OState);
        }
    }
}
