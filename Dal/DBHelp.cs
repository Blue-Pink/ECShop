using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace Dal
{
    public class DBHelp
    {
        private static readonly string ObtainConnection = System.Configuration.ConfigurationManager.ConnectionStrings["ObtainConnection"].ConnectionString;

        #region 增删改通用方法
        /// <summary>
        /// 增删改通用方法
        /// </summary>
        /// <param name="sql">增删改 sql执行 语句</param>
        /// <param name="sqlParameters">参数化数组</param>
        /// <returns>返回执行成功的行数</returns>
        public static int ExecuteNonQuery(string sql, SqlParameter[] sqlParameters)
        {
            using (SqlConnection connection = new SqlConnection(ObtainConnection))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sql, connection);

                if (sqlParameters != null)
                {
                    command.Parameters.AddRange(sqlParameters);
                }
                return command.ExecuteNonQuery();
            }
        } 
        #endregion

        #region 查询通用方法(SqlDataReader
        /// <summary>
        /// 查询通用方法
        /// </summary>
        /// <param name="sql">查询 sql执行 语句</param>
        /// <param name="sqlParameters">参数化数组</param>
        /// <returns>返回查询所得的结果集</returns>
        public static SqlDataReader ExecuteSqlDataReader(string sql, SqlParameter[] sqlParameters)
        {
            SqlConnection connection = new SqlConnection(ObtainConnection);
            connection.Open();
            SqlCommand command = new SqlCommand(sql, connection);
            if (sqlParameters != null)
            {
                command.Parameters.AddRange(sqlParameters);
            }
            SqlDataReader dataReader = command.ExecuteReader(CommandBehavior.CloseConnection);
            return dataReader;
        }
        #endregion

        #region 查询通用方法(DataSet
        /// <summary>
        /// 查询通用方法(DataSet
        /// </summary>
        /// <param name="sql">查询 sql执行 语句</param>
        /// <param name="parameters">参数化数组</param>
        /// <returns>查询的结果集</returns>
        public static DataSet ExecuteDataSet(string sql, SqlParameter[] parameters)
        {
            using (SqlConnection connection = new SqlConnection(ObtainConnection))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command);
                if (parameters != null)
                {
                    command.Parameters.AddRange(parameters);
                }
                DataSet dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet);
                return dataSet;
            }
        }
        #endregion

        #region 通用单值查询方法
        /// <summary>
        /// 通用单值查询方法
        /// </summary>
        /// <param name="sql">sql 执行语句</param>
        /// <param name="parameters">参数化数组</param>
        /// <returns></returns>
        public static object ExecuteScalar(string sql, SqlParameter[] parameters)
        {
            object o = null;
            using (SqlConnection connection = new SqlConnection(ObtainConnection))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sql, connection);
                if (parameters != null)
                {
                    command.Parameters.AddRange(parameters);
                }
                o = command.ExecuteScalar();
            }
            return o;
        } 
        #endregion
    }
}
