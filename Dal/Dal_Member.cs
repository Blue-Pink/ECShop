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
    public class Dal_Member
    {
        /// <summary>
        /// 表:Member (已注册判断
        /// </summary>
        /// <param name="MName">新用户</param>
        /// <returns>是否已注册</returns>
        public static bool Registered(string MName)
        {
            return Convert.ToInt32(DBHelp.ExecuteScalar(
                "select count(*) from Member where MName=@MName",
                new SqlParameter[] {
                    new SqlParameter("@MName",MName)
                })) > 0 ? true : false;
        }

        /// <summary>
        /// 表:Member (添加注册用户信息
        /// </summary>
        /// <param name="member">注册用户</param>
        /// <returns>执行成功行数</returns>
        public static int Register(Member member)
        {
            return DBHelp.ExecuteNonQuery(
                "insert into Member values(@MName,@MEmail,@MPassword)",
                new SqlParameter[] {
                    new SqlParameter("@MName",member.MName),
                    new SqlParameter("@Memail",member.MEmail),
                    new SqlParameter("@MPassword",member.MPassword),
                });
        }

        /// <summary>
        /// 表:Member (登录判断账号密码是否正确
        /// </summary>
        /// <param name="member">登录的用户</param>
        /// <returns>核对信息正确行数</returns>
        public static int Login(Member member)
        {
            return Convert.ToInt32(DBHelp.ExecuteScalar(
                "select count(*) from Member where MName=@MName and MPassword=@MPassword",
                new SqlParameter[] {
                    new SqlParameter("@MName", member.MName),
                    new SqlParameter("@MPassword",member.MPassword)
                }));
        }

        /// <summary>
        /// 表:Member (根据MName查找对应MID
        /// </summary>
        /// <param name="MName"></param>
        /// <returns></returns>
        public static int GetMID(string MName) {
            return Convert.ToInt32(DBHelp.ExecuteScalar(
                "select MID from Member where MName=@MName",
                new SqlParameter[] {
                    new SqlParameter("@MName",MName)
            }));
        }
    }
}
