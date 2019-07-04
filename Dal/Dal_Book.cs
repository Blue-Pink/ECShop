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
    public class Dal_Book
    {
        /// <summary>
        /// 表:Book 查询(倒序 BDate 前 5)
        /// </summary>
        /// <returns>查询结果</returns>
        public static List<Book> DOrderBy_BDate()
        {
            List<Book> books = new List<Book>();
            using (SqlDataReader dataReader = DBHelp.ExecuteSqlDataReader("select top 5 * from book order by BDate desc", null))
            {
                while (dataReader.Read())
                {
                    books.Add(new Book()
                    {
                        BID = Convert.ToInt32(dataReader["BID"]),
                        BPic = Convert.ToString(dataReader["BPic"]),
                        BPrice = Convert.ToDecimal(dataReader["BPrice"]),
                        BName = Convert.ToString(dataReader["BName"]),
                    });
                }
                return books;
            }
        }

        /// <summary>
        /// 表:Book 查询(倒序 BSaleCount 前 5)
        /// </summary>
        /// <returns>查询结果</returns>
        public static List<Book> DOrderBy_BSaleCount()
        {
            List<Book> books = new List<Book>();
            using (SqlDataReader dataReader = DBHelp.ExecuteSqlDataReader("select top 5 * from book order by BSaleCount desc", null))
            {
                while (dataReader.Read())
                {
                    books.Add(new Book()
                    {
                        BID = Convert.ToInt32(dataReader["BID"]),
                        BPic = Convert.ToString(dataReader["BPic"]),
                        BPrice = Convert.ToDecimal(dataReader["BPrice"]),
                        BName = Convert.ToString(dataReader["BName"]),
                    });
                }
                return books;
            }
        }

        /// <summary>
        /// 表:Book 根据BLID子查询所有信息
        /// </summary>
        /// <param name="BLID">BLID</param>
        /// <returns>查询结果</returns>
        public static List<Book> Select_BLID(int BLID)
        {
            List<Book> books = new List<Book>();
            using (SqlDataReader dataReader = DBHelp.ExecuteSqlDataReader(
                "select * from Book where BSID in (select BSID from BSCategory where BLID=@BLID)",
                new SqlParameter[] {
                    new SqlParameter("@BLID",BLID)
                }))
            {
                while (dataReader.Read())
                {
                    books.Add(new Book()
                    {
                        BName = Convert.ToString(dataReader["BName"]),
                        BID = Convert.ToInt32(dataReader["BID"]),
                        BPic = Convert.ToString(dataReader["BPic"]),
                        BPrice = Convert.ToDecimal(dataReader["BPrice"]),
                        BAuthor = Convert.ToString(dataReader["BAuthor"]),
                        BComment = Convert.ToString(dataReader["BComment"])
                    });
                }
                return books;
            }
        }

        /// <summary>
        /// 表:Book 根据BLID分页
        /// </summary>
        /// <param name="PageSize">页大小</param>
        /// <param name="PageIndex">当前页</param>
        /// <param name="BLID">子查询所需BLID</param>
        /// <returns>分页结果</returns>
        public static List<Book> TopPaging_BLID(int PageSize, int PageIndex, int BLID)
        {
            List<Book> books = new List<Book>();
            using (SqlDataReader dataReader = DBHelp.ExecuteSqlDataReader(
                "select top (@PageSize) * from Book where BSID in (select BSID from BSCategory where BLID=@BLID) and bid not in(select top (@Notin) BID from Book where BSID in (select BSID from BSCategory where BLID=@BLID))",
                new SqlParameter[] {
                    new SqlParameter("@PageSize",PageSize),
                    new SqlParameter("@BLID",BLID),
                    new SqlParameter("@Notin",(PageIndex-1)*PageSize),
                }))
            {
                while (dataReader.Read())
                {
                    books.Add(new Book()
                    {
                        BID = Convert.ToInt32(dataReader["BID"]),
                        BName = Convert.ToString(dataReader["BName"]),
                        BPrice = Convert.ToDecimal(dataReader["BPrice"]),
                        BPic = Convert.ToString(dataReader["BPic"]),
                        BAuthor = Convert.ToString(dataReader["BAuthor"]),
                        BComment = Convert.ToString(dataReader["BComment"]),
                    });
                }
                return books;
            }
        }

        /// <summary>
        /// 表:Book 根据BSID子查询所有信息
        /// </summary>
        /// <param name="BSID">BSID</param>
        /// <returns>查询结果</returns>
        public static List<Book> Select_BSID(int BSID)
        {
            List<Book> books = new List<Book>();
            using (SqlDataReader dataReader = DBHelp.ExecuteSqlDataReader(
                "select  * from Book where BSID=@BSID",
                new SqlParameter[] {
                    new SqlParameter("@BSID",BSID)
                }))
            {
                while (dataReader.Read())
                {
                    books.Add(new Book()
                    {
                        BName = Convert.ToString(dataReader["BName"]),
                        BID = Convert.ToInt32(dataReader["BID"]),
                        BPic = Convert.ToString(dataReader["BPic"]),
                        BPrice = Convert.ToDecimal(dataReader["BPrice"]),
                        BAuthor = Convert.ToString(dataReader["BAuthor"]),
                        BComment = Convert.ToString(dataReader["BComment"])
                    });
                }
                return books;
            }
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
            List<Book> books = new List<Book>();
            using (SqlDataReader dataReader = DBHelp.ExecuteSqlDataReader(
                "select top(@PageSize) * from Book where BSID = @BSID and BID not in (select top(@Notin) BID from Book where BSID = @BSID)",
                new SqlParameter[] {
                    new SqlParameter("@PageSize",PageSize),
                    new SqlParameter("@BSID",BSID),
                    new SqlParameter("@Notin",(PageIndex-1)*PageSize),
                }))
            {
                while (dataReader.Read())
                {
                    books.Add(new Book()
                    {
                        BID = Convert.ToInt32(dataReader["BID"]),
                        BName = Convert.ToString(dataReader["BName"]),
                        BPrice = Convert.ToDecimal(dataReader["BPrice"]),
                        BPic = Convert.ToString(dataReader["BPic"]),
                        BAuthor = Convert.ToString(dataReader["BAuthor"]),
                        BComment = Convert.ToString(dataReader["BComment"]),
                    });
                }
                return books;
            }
        }

        /// <summary>
        /// 表:Book 根据BID查询
        /// </summary>
        /// <param name="BID">BSID</param>
        /// <returns>查询结果</returns>
        public static Book Select_BID(int BID)
        {
            using (SqlDataReader dataReader = DBHelp.ExecuteSqlDataReader(
                "select  * from Book where BID=@BID",
                new SqlParameter[] {
                    new SqlParameter("@BID",BID)
                }))
            {
                Book book = null;
                while (dataReader.Read())
                {
                    book = new Book()
                    {
                        BSID=Convert.ToInt32(dataReader["BSID"]),
                        BISBN=Convert.ToString(dataReader["BISBN"]),
                        BName = Convert.ToString(dataReader["BName"]),
                        BID = Convert.ToInt32(dataReader["BID"]),
                        BPic = Convert.ToString(dataReader["BPic"]),
                        BPrice = Convert.ToDecimal(dataReader["BPrice"]),
                        BAuthor = Convert.ToString(dataReader["BAuthor"]),
                        BComment = Convert.ToString(dataReader["BComment"]),
                        BCount = Convert.ToInt32(dataReader["BCount"]),
                        BTOC=Convert.ToString(dataReader["BTOC"]),
                        BSaleCount = Convert.ToInt32(dataReader["BSaleCount"]),
                    };
                }
                return book;
            }
        }

        /// <summary>
        /// 表:Book (根据BID修改BCount与BSaleCount
        /// </summary>
        /// <param name="book">修改的数据</param>
        /// <returns>执行成功的行数</returns>
        public static int Update_BCountAndBSaleCount(Book book)
        {
            if (Select_BCount(book.BID) > book.BCount)
            {
                return DBHelp.ExecuteNonQuery(
                        "update Book set BCount=BCount-@BCount,BSaleCount=BSaleCount+@BCount where BID=@BID",
                        new SqlParameter[] {
                    new SqlParameter("@BCount",book.BCount),
                    new SqlParameter("@BID",book.BID)
                        });
            }
            return 0;
        }

        /// <summary>
        /// 表:Book (根据BID查找BCount
        /// </summary>
        /// <param name="BID">参数数据</param>
        /// <returns>查询结果</returns>
        public static int Select_BCount(int BID)
        {
            return Convert.ToInt32(DBHelp.ExecuteScalar(
                "select BCount from Book where BID=@BID",
                new SqlParameter[] {
                    new SqlParameter("@BID",BID)
                }));
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
            List<Book> books = new List<Book>();
            using (SqlDataReader dataReader = DBHelp.ExecuteSqlDataReader(
                "select top (@PageSize) * from Book where BName like '%'+@BName+'%' and BID not in (select top (@Notin) BID from Book where BName like '%'+@BName+'%' ) order by BID",
                new SqlParameter[] {
                    new SqlParameter("@PageSize",PageSize),
                    new SqlParameter("@BName",BName),
                    new SqlParameter("@Notin",PageSize*(PageIndex-1)),
                }))
            {
                while (dataReader.Read())
                {
                    books.Add(new Book()
                    {
                        BID = Convert.ToInt32(dataReader["BID"]),
                        BName = Convert.ToString(dataReader["BName"]),
                        BPrice = Convert.ToDecimal(dataReader["BPrice"]),
                        BPic = Convert.ToString(dataReader["BPic"]),
                        BAuthor = Convert.ToString(dataReader["BAuthor"]),
                        BComment = Convert.ToString(dataReader["BComment"]),
                    });
                }
                return books;
            }
        }

        /// <summary>
        /// 表:Book (根据BName进行模糊查询
        /// </summary>
        /// <param name="BName"></param>
        /// <returns></returns>
        public static List<Book> DimSelect_BName(string BName)
        {
            List<Book> books = new List<Book>();
            using (SqlDataReader dataReader = DBHelp.ExecuteSqlDataReader(
                "select * from Book where BName like '%'+@BName+'%'",
                new SqlParameter[] {
                    new SqlParameter("@BName",BName)
                }))
            {
                while (dataReader.Read())
                {
                    books.Add(new Book()
                    {
                        BName = Convert.ToString(dataReader["BName"]),
                        BID = Convert.ToInt32(dataReader["BID"]),
                        BPic = Convert.ToString(dataReader["BPic"]),
                        BPrice = Convert.ToDecimal(dataReader["BPrice"]),
                        BAuthor = Convert.ToString(dataReader["BAuthor"]),
                        BComment = Convert.ToString(dataReader["BComment"])
                    });
                }
                return books;
            }
        }

        /// <summary>
        /// 表:Book (分页处理
        /// </summary>
        /// <param name="PageSize">页大小</param>
        /// <param name="PageIndex">当前页</param>
        /// <returns>分页结果</returns>
        public static List<Book> TopPaging(int PageSize, int PageIndex)
        {
            List<Book> books = new List<Book>();
            using (SqlDataReader dataReader = DBHelp.ExecuteSqlDataReader(
                "select top (@PageSize) * from Book where BID not in(select top (@Notin) Bid from Book)",
                new SqlParameter[] {
                    new SqlParameter("@PageSize",PageSize),
                    new SqlParameter("@Notin",(PageIndex-1)*PageSize),
                }))
            {
                while (dataReader.Read())
                {
                    books.Add(new Book() {
                        BName = Convert.ToString(dataReader["BName"]),
                        BID = Convert.ToInt32(dataReader["BID"]),
                        BPic = Convert.ToString(dataReader["BPic"]),
                        BPrice = Convert.ToDecimal(dataReader["BPrice"]),
                        BISBN = Convert.ToString(dataReader["BISBN"]),
                    });
                }
                return books;
            }
        }

        /// <summary>
        /// 表:Book (查询总行数
        /// </summary>
        /// <returns>查询结果</returns>
        public static int RowCount()
        {
            return Convert.ToInt32(DBHelp.ExecuteScalar("select count(*) from Book",null));
        }

        /// <summary>
        /// 表:Book (查询总行数
        /// </summary>
        /// <returns>查询结果</returns>
        public static int RowCount_BName(string BName)
        {
            return Convert.ToInt32(DBHelp.ExecuteScalar(
                "select count(*) from Book where BName  like '%'+@BName+'%'",
                new SqlParameter[] {
                    new SqlParameter("@BName",BName)
                }));
        }

        /// <summary>
        /// 表:Book (添加一条数据
        /// </summary>
        /// <param name="book">添加的数据</param>
        /// <returns>执行成功的行数</returns>
        public static int Insert(Book book)
        {
            return DBHelp.ExecuteNonQuery(
                "insert into Book values(@BID,@BSID,@BName,@BAuthor,@BISBN,@BTOC,@BComment,@BPic,@BPrice,@BCount,@BDate,@BSaleCount)",
                new SqlParameter[] {
                    new SqlParameter("@BID",book.BID),
                    new SqlParameter("@BSID",book.BSID),
                    new SqlParameter("@BName",book.BName),
                    new SqlParameter("@BAuthor",book.BAuthor),
                    new SqlParameter("@BISBN",book.BISBN),
                    new SqlParameter("@BTOC",DBNull.Value),
                    new SqlParameter("@BComment",DBNull.Value),
                    new SqlParameter("@BPic",book.BPic),
                    new SqlParameter("@BPrice",book.BPrice),
                    new SqlParameter("@BCount",book.BCount),
                    new SqlParameter("@BDate",book.BDate),
                    new SqlParameter("@BSaleCount",book.BSaleCount),
            });
        }

        /// <summary>
        /// 表:Book (查询最大的BISBN
        /// </summary>
        /// <returns>查询结果</returns>
        public static ulong Select_MaxBISBN()
        {
            return Convert.ToUInt64(DBHelp.ExecuteScalar(
                "select Max(bisbn) from book",
                null).ToString().Trim());
        }

        /// <summary>
        /// 表:Book (查询最大的BID
        /// </summary>
        /// <returns>查询结果</returns>
        public static int Select_MaxBID()
        {
            return Convert.ToInt32(DBHelp.ExecuteScalar(
                "select Max(bid) from book",
                null));
        }

        /// <summary>
        /// 表:Book (根据BID删除
        /// </summary>
        /// <param name="BID">所需BID</param>
        /// <returns>执行成功行数</returns>
        public static int Delete_BID(int BID) {
            return DBHelp.ExecuteNonQuery(
                "delete from Book where BID=@BID",
                new SqlParameter[] {
                    new SqlParameter("@BID",BID)
                });
        }

        /// <summary>
        /// 表:Book (根据BID修改数据
        /// </summary>
        /// <param name="book">修改的数据</param>
        /// <returns>执行成功的行数</returns>
        public static int Update_BID(Book book)
        {
            return DBHelp.ExecuteNonQuery(
                "update Book set BSID=@BSID,BName=@BName,BAuthor=@BAuthor,BISBN=@BISBN,BTOC=@BTOC,BComment=@BComment,BPic=@BPic,BPrice=@BPrice,BCount=@BCount,BSaleCount=@BSaleCount where BID=@BID",
                new SqlParameter[] {
                    new SqlParameter("@BSID",book.BSID),
                    new SqlParameter("@BName",book.BName),
                    new SqlParameter("@BAuthor",book.BAuthor),
                    new SqlParameter("@BISBN",book.BISBN),
                    new SqlParameter("@BTOC",book.BTOC),
                    new SqlParameter("@BComment",book.BComment),
                    new SqlParameter("@BPic",book.BPic),
                    new SqlParameter("@BPrice",book.BPrice),
                    new SqlParameter("@BCount",book.BCount),
                    new SqlParameter("@BSaleCount",book.BSaleCount),
                    new SqlParameter("@BID",book.BID)
                });
        }

        /// <summary>
        /// 表:Book (判断单个BID是否存在
        /// </summary>
        /// <param name="BID">所需BID</param>
        /// <returns>是否存在</returns>
        public static bool Exists_BID(int BID)
        {
            return Convert.ToInt32(DBHelp.ExecuteScalar(
                "select count(*) from book where Bid=@BID",
                new SqlParameter[] {
                    new SqlParameter("@BID",BID)
                }))>0;
        }
    }
}
