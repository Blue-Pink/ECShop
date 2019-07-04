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
    public class Bll_Member
    {
        /// <summary>
        /// 表:Member (已注册判断
        /// </summary>
        /// <param name="MName">新用户</param>
        /// <returns>是否已注册</returns>
        public static bool Registered(string MName)
        {
            return Dal_Member.Registered(MName);
        }

        /// <summary>
        /// 表:Member (添加注册用户信息
        /// </summary>
        /// <param name="member">注册用户</param>
        /// <returns>执行成功行数</returns>
        public static int Register(Member member)
        {
            return Dal_Member.Register(member);
        }

        /// <summary>
        /// 表:Member (登录判断账号密码是否正确
        /// </summary>
        /// <param name="member">登录的用户</param>
        /// <returns>核对信息正确行数</returns>
        public static int Login(Member member)
        {
            return Dal_Member.Login(member);
        }

        /// <summary>
        /// 表:Member (根据MName查找对应MID
        /// </summary>
        /// <param name="MName"></param>
        /// <returns></returns>
        public static int GetMID(string MName)
        {
            return Dal_Member.GetMID(MName);
        }
    }
}
