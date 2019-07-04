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
    public class Bll_Book
    {
        /// <summary>
        /// 表:Book 查询(倒序 BDate 前 5)
        /// </summary>
        /// <returns>查询结果</returns>
        public static List<Book> DOrderBy_BDate()
        {
            return Dal_Book.DOrderBy_BDate();
        }

        /// <summary>
        /// 表:Book 查询(倒序 BSaleCount 前 5)
        /// </summary>
        /// <returns>查询结果</returns>
        public static List<Book> DOrderBy_BSaleCount()
        {
            return Dal_Book.DOrderBy_BSaleCount();
        }

        /// <summary>
        /// 表:Book 根据BLID子查询所有信息
        /// </summary>
        /// <param name="BLID">BLID</param>
        /// <returns>查询结果</returns>
        public static List<Book> Select_BLID(int BLID)
        {
            return Dal_Book.Select_BLID(BLID);
        }

        /// <summary>
        /// 表:Book 根据BID分页
        /// </summary>
        /// <param name="PageSize">页大小</param>
        /// <param name="PageIndex">当前页</param>
        /// <param name="BLID">子查询所需BLID</param>
        /// <returns>分页结果</returns>
        public static List<Book> TopPaging_BLID(int PageSize, int PageIndex, int BLID)
        {
            return Dal_Book.TopPaging_BLID(PageSize, PageIndex, BLID);
        }

        /// <summary>
        /// 表:Book 根据BSID子查询所有信息
        /// </summary>
        /// <param name="BSID">BSID</param>
        /// <returns>查询结果</returns>
        public static List<Book> Select_BSID(int BSID)
        {
            return Dal_Book.Select_BSID(BSID);
        }

        /// <summary>
        /// 表:Book 根据BID分页
        /// </summary>
        /// <param name="PageSize">页大小</param>
        /// <param name="PageIndex">当前页</param>
        /// <param name="BSID">子查询所需BSID</param>
        /// <returns>分页结果</returns>
        public static List<Book> TopPaging_BSID(int PageSize, int PageIndex, int BSID)
        {
            return Dal_Book.TopPaging_BSID(PageSize, PageIndex, BSID);
        }

        /// <summary>
        /// 表:Book 根据BID查询
        /// </summary>
        /// <param name="BID">BSID</param>
        /// <returns>查询结果</returns>
        public static Book Select_BID(int BID)
        {
            return Dal_Book.Select_BID(BID);
        }

        /// <summary>
        /// 表:Book (根据BID修改BCount
        /// </summary>
        /// <param name="book">修改的数据</param>
        /// <returns>执行成功的行数</returns>
        public static int Update_BCountAndBSaleCount(Book book)
        {
            return Dal_Book.Update_BCountAndBSaleCount(book);
        }

        /// <summary>
        /// 表:Book (根据BID查找BCount
        /// </summary>
        /// <param name="BID">参数数据</param>
        /// <returns>查询结果</returns>
        public static int Select_BCount(int BID)
        {
            return Dal_Book.Select_BCount(BID);
        }

        /// <summary>
        /// 表:Book (根据BName进行模糊查询
        /// </summary>
        /// <param name="BName"></param>
        /// <returns></returns>
        public static List<Book> DimSelect_BName(string BName)
        {
            return Dal.Dal_Book.DimSelect_BName(BName);
        }

        /// <summary>
        /// 表:Book (根据BName进行分页
        /// </summary>
        /// <param name="BName">所需参数BName</param>
        /// <param name="PageSize">页大小</param>
        /// <param name="PageIndex">当前页</param>
        /// <returns></returns>
        public static List<Book> TopPaging_BName(string BName, int PageSize, int PageIndex)
        {
            return Dal_Book.TopPaging_BName(BName, PageSize, PageIndex);
        }

        /// <summary>
        /// 表:Book (Top分页处理
        /// </summary>
        /// <param name="PageSize">页大小</param>
        /// <param name="PageIndex">当前页</param>
        /// <returns>分页结果</returns>
        public static List<Book> TopPaging(int PageSize, int PageIndex)
        {
            return Dal_Book.TopPaging(PageSize, PageIndex);
        }

        /// <summary>
        /// 表:Book (查询总行数
        /// </summary>
        /// <returns>查询结果</returns>
        public static int RowCount()
        {
            return Dal_Book.RowCount();
        }

        /// <summary>
        /// 表:Book (查询总行数
        /// </summary>
        /// <returns>查询结果</returns>
        public static int RowCount_BName(string BName)
        {
            return Dal_Book.RowCount_BName(BName);
        }

        /// <summary>
        /// 表:Book (添加一条数据
        /// </summary>
        /// <param name="book">添加的数据</param>
        /// <returns>执行成功的行数</returns>
        public static int Insert(Book book)
        {
            return Dal_Book.Insert(book);
        }

        /// <summary>
        /// 表:Book (查询最大的BISBN
        /// </summary>
        /// <returns>查询结果</returns>
        public static ulong Select_MaxBISBN()
        {
            return Dal_Book.Select_MaxBISBN();
        }

        /// <summary>
        /// 表:Book (查询最大的BID
        /// </summary>
        /// <returns>查询结果</returns>
        public static int Select_MaxBID()
        {
            return Dal_Book.Select_MaxBID();
        }

        // <summary>
        /// 表:Book (根据BID删除
        /// </summary>
        /// <param name="BID">所需BID</param>
        /// <returns>执行成功行数</returns>
        public static int Delete_BID(int BID)
        {
            return Dal_Book.Delete_BID(BID);
        }
        /// <summary>
        /// 表:Book (根据BID修改数据
        /// </summary>
        /// <param name="book">修改的数据</param>
        /// <returns>执行成功的行数</returns>
        public static int Update_BID(Book book)
        {
            return Dal_Book.Update_BID(book);
        }

        /// <summary>
        /// 表:Book (判断单个BID是否存在
        /// </summary>
        /// <param name="BID">所需BID</param>
        /// <returns>是否存在</returns>
        public static bool Exists_BID(int BID)
        {
            return Dal_Book.Exists_BID(BID);
        }
    }
}
